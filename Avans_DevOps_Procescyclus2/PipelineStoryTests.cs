using Avans_DevOps_Domain.Pipelines;
using Avans_DevOps_Domain.Pipelines.PipelineBuilder;
using Avans_DevOps_Domain.Projects;

namespace Avans_DevOps_Procescyclus2;

public class PipelineStoryTests
{
    [Fact]
    public void CanAdd_Pipeline_ToProject()
    {
        // Arrange
        var project = new Project("TestProject");
        var piplineBuilder = new PipelineBuilder();
        var pipelineBuilderDirector = new PipelineBuilderDirector(piplineBuilder);
  
        // Act
        pipelineBuilderDirector.MakePipeline();
        var pipeline = piplineBuilder.GetResult();
        project.Pipeline = pipeline;
  
        // Assert
        Assert.NotNull(project.Pipeline);
        Assert.IsType<Pipeline>(project.Pipeline);
    }
 
    public void CanExecute_Pipeline()
    {
        // Arrange
        var project = new Project("TestProject");
        var piplineBuilder = new PipelineBuilder();
        var pipelineBuilderDirector = new PipelineBuilderDirector(piplineBuilder);
  
        // Act
        pipelineBuilderDirector.MakePipeline();
        var pipeline = piplineBuilder.GetResult();
        project.Pipeline = pipeline;
        var result = project.Pipeline.Execute();
  
        // Assert
        Assert.NotNull(project.Pipeline);
        Assert.IsType<Pipeline>(project.Pipeline);
        Assert.Equal(true, result);
    }

}