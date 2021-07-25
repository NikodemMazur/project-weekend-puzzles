using FluentAssertions;
using Moq;
using ProjectWeekendPuzzles.Security.Authorization;
using ProjectWeekendPuzzles.Security.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjectWeekendPuzzles.Tests.Security.Authorization
{
    public class RoleAuthorizationRequirementTests
    {
        [Fact]
        public void HandleAuthorizationRequest_ForAuthorizedUser_GivesSuccess()
        {
            var allowedRoles = new[] { "Developer" };
            var userStub = new Mock<User>(() => new User(String.Empty, allowedRoles));
            var sut = new RoleAuthorizationRequirement(allowedRoles);

            var result = sut.HandleAuthorizationRequest(userStub.Object);

            result.Success.Should().BeTrue("because the user has required role");
        }

        public static IEnumerable<object[]> TheoryArgumentSet =>
            new[] { new[] { Array.Empty<string>() },
                    new[] { new[] { "developer" } } };

        [Theory]
        [MemberData(nameof(TheoryArgumentSet))]
        public void HandleAuthorizationRequest_WithNoAllowedRolesProvided_GivesSuccess(IEnumerable<string> userRoles)
        {
            var allowedRoles = Enumerable.Empty<string>();
            var sut = new RoleAuthorizationRequirement(allowedRoles);
            var userStub = new Mock<User>(() => new User(String.Empty, userRoles));

            var result = sut.HandleAuthorizationRequest(userStub.Object);

            result.Success.Should().BeTrue("because no allowed roles have been defined");
        }
    }
}
