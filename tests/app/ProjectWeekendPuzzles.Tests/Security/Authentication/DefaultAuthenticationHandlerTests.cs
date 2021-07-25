using System;
using FluentAssertions;
using Moq;
using ProjectWeekendPuzzles.Security.Authentication;
using System.Threading.Tasks;
using Xunit;

namespace ProjectWeekendPuzzles.Tests.Security.Authentication
{
    public class DefaultAuthenticationHandlerTests
    {
        [Fact]
        public async Task AuthenticateAsync_ForRolelessUser_GivesNoRoles()
        {
            var sut = new DefaultAuthenticationHandler();
            var userCredentialsStub = new UserCredentials("UserName", String.Empty);

            var result = await sut.AuthenticateAsync(userCredentialsStub);

            result
                .User.Roles
                .Should().BeNullOrEmpty("becasue corresponding user has no roles included in its name");
        }

        [Fact]
        public async Task AuthenticateAsync_ForTwoRoleUser_GivesTheseTwoRoles()
        {
            var sut = new DefaultAuthenticationHandler();
            var userCredentialsStub = new UserCredentials("UserName-developer-user", String.Empty);

            var result = await sut.AuthenticateAsync(userCredentialsStub);

            result
                .User.Roles
                .Should()
                .HaveCount(2, "becasue corresponding user has two roles included in its name")
                .And
                .Contain(new[] { "user", "developer" }, "because these roles are contained in the user's name");
        }
    }
}
