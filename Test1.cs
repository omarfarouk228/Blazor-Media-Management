using BlazorSuperApp.Dtos;
using BlazorSuperApp.Services;
using Bunit;
using Moq;
using Xunit;

namespace BlazorSuperApp
{

    public class Test1 : TestContext
    {
        [Fact]
        public void ShouldDisplayGroupNames()
        {
            // Arrange
            var mockService = new Mock<GroupService>();
            mockService.Setup(s => s.GetAll()).ReturnsAsync(new List<GroupDto>
        {
            new() { Name = "Group A" },
            new() { Name = "Group B" }
        });

            Services.AddSingleton(mockService.Object);

            // Act
            var cut = RenderComponent<Components.Pages.Group.Index>();

            // Assert
            cut.Markup.Contains("Group A");
            cut.Markup.Contains("Group B");
        }
    }
}