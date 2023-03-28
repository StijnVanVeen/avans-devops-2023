using Avans_DevOps_Domain.Team;
using Avans_DevOps_Domain.Team.Members;
using Avans_DevOps_Domain.Team.TeamMemberFactories;
using Moq;

namespace Avans_DevOps_UnitTest;

public class TeamMemberFactoryDirectorTests
{
    private readonly Mock<TeamMemberFactoryDirector> _director;
    private readonly string _name = "John Doe";
    private readonly string _email = "j.doe@avans.nl";

    public TeamMemberFactoryDirectorTests()
    {
        _director = new Mock<TeamMemberFactoryDirector>();
    }

    [Fact]
    public void CreateDeveloper_CreatesNewDeveloper()
    {
        // Act
        var result = _director.Object.CreateDeveloper(_name, _email);
        
        // Assert
        Assert.Equal(result.GetType(), typeof(Developer));
    }
    
    [Fact]
    public void CreateScrumMaster_CreatesNewScrumMaster()
    {
        // Act
        var result = _director.Object.CreateScrumMaster(_name, _email);
        
        // Assert
        Assert.Equal(result.GetType(), typeof(ScrumMaster));
    }
    
    [Fact]
    public void CreateProductOwner_CreatesNewProductOwner()
    {
        // Act
        var result = _director.Object.CreateProductOwner(_name, _email);
        
        // Assert
        Assert.Equal(result.GetType(), typeof(ProductOwner));
    }
    
    [Fact]
    public void CreateTester_CreatesNewTester()
    {
        // Act
        var result = _director.Object.CreateTester(_name, _email);
        
        // Assert
        Assert.Equal(result.GetType(), typeof(Tester));
    }
}