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

    [Fact]
    public void AddScrumMaster_AddsNewScrumMasterToMembersList()
    {
        // Arrange
        var testTeam = new Team("TestTeam");
        var name = "John Doe";
        var email = "j.doe@avans.nl";

        // Act
        testTeam.AddScrumMaster(name, email);

        // Assert
        var member = testTeam.GetMember(name);
        Assert.NotNull(member);
        Assert.IsType<ScrumMaster>(member);
        Assert.Equal(email, member.Email);
    }

    [Fact]
    public void AddProductOwner_AddsNewProductOwnerToMembersList()
    {
        // Arrange
        var testTeam = new Team("TestTeam");
        var name = "John Doe";
        var email = "j.doe@company.com";

        // Act
        testTeam.AddProductOwner(name, email);

        // Assert
        var member = testTeam.GetMember(name);
        Assert.NotNull(member);
        Assert.IsType<ProductOwner>(member);
        Assert.Equal(email, member.Email);
    }

    [Fact]
    public void AddTester_AddsNewTesterToMembersList()
    {
        // Arrange
        var testTeam = new Team("TestTeam");
        var name = "John Doe";
        var email = "j.doe@avans.nl";

        // Act
        testTeam.AddTester(name, email);

        // Assert
        var member = testTeam.GetMember(name);
        Assert.NotNull(member);
        Assert.IsType<Tester>(member);
        Assert.Equal(email, member.Email);
    }

    [Fact]
    public void DeleteMember_DeletesMemberFromMembersList()
    {
        // Arrange
        var testTeam = new Team("TestTeam");
        var member = new Developer("John Doe", "j.doe@avans.nl");
        testTeam.Members.Add(member);

        // Act
        testTeam.DeleteMember(member);

        // Assert
        Assert.DoesNotContain(member, testTeam.Members);
    }

    [Fact]
    public void GetMember_ReturnsNullWhenMemberNotFound()
    {
        // Arrange
        var testTeam = new Team("TestTeam");
        
        // Act
        var member = testTeam.GetMember("John Doe");
        
        // Assert
        Assert.Null(member);
    }
}