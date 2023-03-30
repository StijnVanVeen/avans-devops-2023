using Avans_DevOps_Domain.Pipelines.PipelineBuilder;

namespace Avans_DevOps_UnitTest.Pipeline;

public class PipelineBuilderDirectorTests
{
    [Fact]
    public void SetBuilder_Should_Set_Builder_Property()
    {
        // Arrange
        var oldBuilder = new PipelineBuilder();
        var director = new PipelineBuilderDirector(oldBuilder);


        // Act
        var builder = new PipelineBuilder();
        director.SetBuilder(builder);

        // Assert
        Assert.Equal(builder, director.Builder);
    }

    [Fact]
    public void MakePipeline_Should_Construct_Pipeline()
    {
        // Arrange
        var builder = new PipelineBuilder();
        var director = new PipelineBuilderDirector(builder);

        // Act
        director.MakePipeline();
        var pipeline = builder.GetResult();

        // Assert
        Assert.NotNull(pipeline);
        Assert.NotEmpty(pipeline.Actions);
        Assert.Equal(7, pipeline.Actions.Count);
    }
}