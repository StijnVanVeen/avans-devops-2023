using Avans_DevOps_Domain.Team;
using Avans_DevOps_Domain.Team.Members;

namespace Avans_DevOps_UnitTest;

public class UnitTest_Teams
{
    // Team class tests
    [Fact]
    public void AddDeveloper_AddsNewDeveloperToMembersList()
    {
        // Arrange
        var testTeam = new Team("TestTeam");
        var name = "John Doe";
        var email = "j.doe@avans.nl";
        // Act
        testTeam.AddDeveloper(name, email);
        // Assert
        var member = testTeam.GetMember(name);
        Assert.NotNull(member);
        Assert.IsType<Developer>(member);
        Assert.Equal(email, member.Email);
    }
}