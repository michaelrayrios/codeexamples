using SkyDock.Controllers;
using SkyDock.Models;
using System.Collections.Generic;
using Xunit;

namespace SkyDock.Tests
{
    public class StoryTests
    {
        //Setup Test Environment
        StoryRepositoryF repository;
        FlightController controller;
        List<Stories> storiesFromRepo;

        //Finish setup
        public StoryTests()
        {
            repository = new StoryRepositoryF();
            storiesFromRepo = repository.GetAllStories();
            controller = new FlightController(repository);
        }

        //Test GetAllStories()
        [Fact]
        public void GetAllStoriesTest()
        {
            var stories = controller.ListStories().ViewData.Model as List<Stories>;

            for(int i = 0; i < storiesFromRepo.Count; i++)
            {
                Assert.Equal(storiesFromRepo[i].Headline, stories[i].Headline);
                Assert.Equal(storiesFromRepo[i].Story, stories[i].Story);
                Assert.Equal(storiesFromRepo[i].TheFanLocation, stories[i].TheFanLocation);
                Assert.Equal(storiesFromRepo[i].TheFanName, stories[i].TheFanName);
            }
        }

        //Test AddStory()
        [Fact]
        public void AddStoryTest()
        {
            Stories aStory = new Stories();
            aStory.Headline = "This is a test story";
            aStory.Story = "This is a test story body";
            aStory.TheFanLocation = "Test place";
            aStory.TheFanName = "Test Guy";

            repository.AddStory(aStory);

            List<Stories> storyList = repository.GetAllStories();

            Assert.Equal(storyList[storyList.Count - 1].Headline, aStory.Headline);
            Assert.Equal(storyList[storyList.Count - 1].Story, aStory.Story);
            Assert.Equal(storyList[storyList.Count - 1].TheFanLocation, aStory.TheFanLocation);
            Assert.Equal(storyList[storyList.Count - 1].TheFanName, aStory.TheFanName);
        }

        //Test that a fan is auto created and that the field is not "Null" without a fan object with a "stories" object is created
        [Fact]
        public void StoryAutoCreatesFanTest()
        {
            Stories aStory = new Stories();
            Assert.NotNull(aStory.TheFan);
        }

        //Test that the auto created fan's name and location fields are "null" and do not contain anything on creation
        [Fact]
        public void StoryAutoCreateBlankFanTest()
        {
            Stories aStory = new Stories();
            Assert.NotNull(aStory.TheFan);
            Assert.Null(aStory.TheFan.Name);
            Assert.Null(aStory.TheFan.Location);
        }
    }
}
