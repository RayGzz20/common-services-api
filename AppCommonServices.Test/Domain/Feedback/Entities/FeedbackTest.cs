using AppCommonServices.Domain.Common.ValueObjects;
using E = AppCommonServices.Domain.Feedback.Entities;
using AppCommonServices.Domain.Feedback.ValueObjects;
using AppCommonServices.Test.Utilities;

namespace AppCommonServices.Test.Domain.Feedback.Entities
{
    [TestClass]
    public class FeedbackTest : UnitTestBase
    {
        [TestMethod]
        public void FeedbackCreateWhenUserAndCommentsAreValidShouldResultOK()
        {
            // Prepare
            UserId? userId = UserId.Create("55");
            Comments? comments = Comments.Create("test");

            // Execute
            E.Feedback? result = E.Feedback.Create(userId!, comments!);

            // Verify
            Assert.IsNotNull(result, "result is null");
            Assert.IsInstanceOfType<E.Feedback>(result, "result is not a Feedback");
            Assert.IsNotNull(result.Id, "result has no Id");
            Assert.IsInstanceOfType<Id>(result.Id, "result.Id is not an Id type");
            Assert.IsTrue(result.Id.Value.ToString().Length > 0, "result has an empty Id");
            Assert.IsInstanceOfType<Guid>(result.Id.Value, "result.Id is not an Guid type");
        }

        [TestMethod]
        public void FeedbackCreateWhenUserAndCommentsAreNotValidShouldResultError()
        {
            // Prepare
            UserId? userId = UserId.Create("");
            Comments? comments = Comments.Create("");

            // Execute
            E.Feedback? result = E.Feedback.Create(userId!, comments!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FeedbackCreateWhenUserIsNotValidShouldResultError()
        {
            // Prepare
            UserId? userId = UserId.Create("");
            Comments? comments = Comments.Create("test");

            // Execute
            E.Feedback? result = E.Feedback.Create(userId!, comments!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }

        [TestMethod]
        public void FeedbackCreateWhenCommentsIsNotValidShouldResultError()
        {
            // Prepare
            UserId? userId = UserId.Create("15");
            Comments? comments = Comments.Create("");

            // Execute
            E.Feedback? result = E.Feedback.Create(userId!, comments!);

            // Verify
            Assert.IsNull(result, "result is not null");
        }
    }
}
