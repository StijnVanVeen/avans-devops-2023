using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Teams.Members;

namespace Avans_DevOps_UnitTest;

public class TeamTests
{
    private readonly Team TestTeam = new Team("TestTeam");
    private readonly string Name = "John Doe";
    private readonly string Email = "j.doe@avans.nl";
    
    [Fact]
    public void AddDeveloper_AddsNewDeveloperToMembersList()
    {
        // Arrange
        TestTeam.Members.Clear();
        
        // Act
        TestTeam.AddDeveloper(Name, Email);
        
        // Assert
        var member = TestTeam.GetMember(Name);
        Assert.NotNull(member);
        Assert.IsType<Developer>(member);
        Assert.Equal(Name, member.Name);
        Assert.Equal(Email, member.Email);
    }

    /*[Fact]
    public void AddScrumMaster_AddsNewScrumMasterToMembersList()
    {
        // Arrange
        TestTeam.Members.Clear();
        
        // Act
        TestTeam.AddScrumMaster(Name, Email);

        // Assert
        var member = TestTeam.GetMember(Name);
        Assert.NotNull(member);
        Assert.IsType<ScrumMaster>(member);
        Assert.Equal(Name, member.Name);
        Assert.Equal(Email, member.Email);
    }*/

    /*[Fact]
    public void AddProductOwner_AddsNewProductOwnerToMembersList()
    {
        // Arrange
        TestTeam.Members.Clear();

        // Act
        TestTeam.AddProductOwner(Name, Email);

        // Assert
        var member = TestTeam.GetMember(Name);
        Assert.NotNull(member);
        Assert.IsType<ProductOwner>(member);
        Assert.Equal(Name, member.Name);
        Assert.Equal(Email, member.Email);
    }

    [Fact]
    public void AddTester_AddsNewTesterToMembersList()
    {
        // Arrange
        TestTeam.Members.Clear();

        // Act
        TestTeam.AddTester(Name, Email);

        // Assert
        TeamMember member = TestTeam.GetMember(Name);
        Assert.NotNull(member);
        Assert.IsType<Tester>(member);
        Assert.Equal(Name, member.Name);
        Assert.Equal(Email, member.Email);
    }*/

    [Fact]
    public void DeleteMember_DeletesMemberFromMembersList()
    {
        // Arrange
        TestTeam.Members.Clear();
        TeamMember member = new Developer(Name, Email);

        // Act
        TestTeam.AddDeveloper(Name, Email);
        TestTeam.DeleteMember(member);

        // Assert
        Assert.DoesNotContain(member, TestTeam.Members);
    }

    [Fact]
    public void GetMember_ReturnsNullWhenMemberNotFound()
    {
        // Arrange
        TestTeam.Members.Clear();

        // Act
        var member = TestTeam.GetMember("Jane Doe");
        
        // Assert
        Assert.Null(member);
    }
}