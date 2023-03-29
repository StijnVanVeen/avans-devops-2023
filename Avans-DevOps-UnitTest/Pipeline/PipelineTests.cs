using Avans_DevOps_Domain.Pipelines.Actions;
using Moq;

namespace Avans_DevOps_UnitTest.Pipeline;

public class PipelineTests
{
    [Fact]
    public void Execute_WithNoActions_DoesNothing()
    {
        // Arrange
        var pipeline = new Avans_DevOps_Domain.Pipelines.Pipeline();

        // Act
        var result = pipeline.Execute();

        // Assert
        Assert.Equal(false, result);
        
    }
    
    [Fact]
    public void AddAction_AddsActionToPipeline()
    {
        // Arrange
        var sourceAction = new SourceAction();
        var pipeline = new Avans_DevOps_Domain.Pipelines.Pipeline();

        // Act
        pipeline.AddAction(sourceAction);

        // Assert
        Assert.Contains(sourceAction, pipeline.Actions);
    }

    [Fact]
    public void Execute_WithAllActions_ReturnsTrue()
    {
        // Arrange
        var sourceAction = new SourceAction();
        var packageAction = new PackageAction();
        var buildAction = new BuildAction();
        var testAction = new TestAction();
        var analyseAction = new AnalyseAction();
        var utilityAction = new UtilityAction();
        var deployAction = new DeployAction();
        
        var pipeline = new Avans_DevOps_Domain.Pipelines.Pipeline();
        
        pipeline.AddAction(sourceAction);
        pipeline.AddAction(packageAction);
        pipeline.AddAction(buildAction);
        pipeline.AddAction(testAction);
        pipeline.AddAction(analyseAction);
        pipeline.AddAction(utilityAction);
        pipeline.AddAction(deployAction);

        // Act
        var result = pipeline.Execute();

        // Assert
        Assert.Equal(true, result);
    }
}