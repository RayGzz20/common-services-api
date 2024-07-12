using AppCommonServices.Application.Common.Interfaces;
using AppCommonServices.Domain.Common;
using AppCommonServices.Domain.Common.ValueObjects;
using AppCommonServices.Domain.Faq.ValueObjects;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppCommonServices.Infrastructure.Common.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
    {
        private readonly IPublisher _publisher;
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public DbSet<Domain.Faq.Entities.Faq> Faqs { get; set; }
        public DbSet<Domain.Feedback.Entities.Feedback> Feedbacks { get; set; }

        public ApplicationDbContext(
            DbContextOptions options, 
            IPublisher publisher,
            IDateTimeService dateTime,
            IAuthenticatedUserService authenticatedUser
            ) : base(options)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }
                
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var domainEvents = ChangeTracker.Entries<AggregateRoot>()
                .Select(e => e.Entity)
                .Where(e => e.GetDomainEvents().Any())
                .SelectMany(e => e.GetDomainEvents());

            foreach (EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Audit.CreatedOn = _dateTime.NowUtc;
                        entry.Entity.Audit.CreatedBy = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.Audit.UpdatedOn = _dateTime.NowUtc;
                        entry.Entity.Audit.UpdatedBy = _authenticatedUser.UserId;
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);

            foreach (var domainEvent in domainEvents)
            {
                await _publisher.Publish(domainEvent, cancellationToken);
            }

            return result;
        }
    }
}
