using Avans_DevOps_Domain.Teams;
using Avans_DevOps_Domain.Teams.Members;

using Moq;

namespace Avans_DevOps_UnitTest;

public class TeamMemberFactoryDirectorTests
{
    private readonly Mock<TeamMemberFactoryDirector> _director;
    private const string _name = "John Doe";
    private const string _email = "j.doe@avans.nl";

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
        Assert.NotNull(result);
        Assert.IsType<Developer>(result);
        Assert.Equal(_name, result.Name);
        Assert.Equal(_email, result.Email);
    }
    
    [Fact]
    public void CreateScrumMaster_CreatesNewScrumMaster()
    {
        // Act
        var result = _director.Object.CreateScrumMaster(_name, _email);
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<ScrumMaster>(result);
        Assert.Equal(_name, result.Name);
        Assert.Equal(_email, result.Email);
    }
    
    [Fact]
    public void CreateProductOwner_CreatesNewProductOwner()
    {
        // Act
        var result = _director.Object.CreateProductOwner(_name, _email);
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<ProductOwner>(result);
        Assert.Equal(_name, result.Name);
        Assert.Equal(_email, result.Email);
    }
    
    [Fact]
    public void CreateTester_CreatesNewTester()
    {
        // Act
        var result = _director.Object.CreateTester(_name, _email);
        
        // Assert
        Assert.NotNull(result);
        Assert.IsType<Tester>(result);
        Assert.Equal(_name, result.Name);
        Assert.Equal(_email, result.Email);
    }
}