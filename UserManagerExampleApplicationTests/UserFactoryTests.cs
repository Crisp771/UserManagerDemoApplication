using System;
using System.Configuration;
using UserManagerDemoApplication.Factories;
using UserManagerDemoApplication.PropertyBags;
using NUnit.Framework;

namespace UserManagerExampleApplicationTests
{
    [TestFixture]
    public class UserFactoryTests
    {
        [SetUp]
        public void SetUp()
        {
            
        }

        [Test]
        public void WhenICreateAUserItIsCreatedCorrectly()
        {
            var target = new UserFactory();

            var expectedUserId = new Random().Next(100);
            var expectedName = Guid.NewGuid().ToString();
            var expectedRoleDisplay = Guid.NewGuid().ToString();
            var expectedRoleId = new Random().Next(100);
            var expectedStatusDisplay = Guid.NewGuid().ToString();
            var expectedstatusId = new Random().Next(100);
            var expectedUpdatedAt = DateTime.Now;

            var expectedResult = new User()
            {
                UserId = expectedUserId,
                Name= expectedName,
                RoleDisplay = expectedRoleDisplay,
                RoleId = expectedRoleId,
                StatusDisplay = expectedStatusDisplay,
                StatusId = expectedstatusId,
                UpdatedAt = expectedUpdatedAt
            };

            var actualResult = target.Create(expectedUserId, expectedName, expectedRoleId, expectedRoleDisplay,
                expectedstatusId, expectedStatusDisplay, expectedUpdatedAt);

            Assert.AreEqual(expectedUserId, actualResult.UserId);
            Assert.AreEqual(expectedName, actualResult.Name);
            Assert.AreEqual(expectedRoleId, actualResult.RoleId);
            Assert.AreEqual(expectedRoleDisplay, actualResult.RoleDisplay);
            Assert.AreEqual(expectedstatusId, actualResult.StatusId);
            Assert.AreEqual(expectedStatusDisplay, actualResult.StatusDisplay);
            Assert.AreEqual(expectedUpdatedAt, actualResult.UpdatedAt);
        }

    }
}
