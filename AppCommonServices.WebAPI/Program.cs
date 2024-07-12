using AppCommonServices.Application;
using AppCommonServices.Infrastructure;
using AppCommonServices.WebAPI;
using AppCommonServices.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication()
                .AddAndConfigServicesPresentation(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Build a swagger endpoint for each discovered API version
        foreach (var description in app.DescribeApiVersions())
        {
            var url = $"/swagger/{description.GroupName}/swagger.json";
            var name = description.GroupName.ToUpperInvariant();
            options.SwaggerEndpoint(url, name);
        }
    });

    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

// Add middlewares for this api
app.UseApiMiddleware();

app.MapControllers();

app.Run();
