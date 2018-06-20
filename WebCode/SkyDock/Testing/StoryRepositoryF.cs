using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkyDock.Models;
using SkyDock.Repositories;

namespace SkyDock.Tests
{
    public class StoryRepositoryF : IStoryRepository
    {
        static List<Stories> bigStoryList = new List<Stories>();

        public StoryRepositoryF() //Construct on creation the following list
        {
            Charter thisFan = new Charter();
            thisFan.Name = "Paul";
            thisFan.Location = "Space";

            Stories story = new Stories
            {
                Headline = "I jumped over a snake!",
                Story = "I was cruising on Day-Dor-Fi" +
                        "and I totally jumped over this snake!",
                TheFanName = thisFan.Name,
                TheFanLocation = thisFan.Location
            };
            bigStoryList.Add(story);

            thisFan = new Charter();
            thisFan.Name = "Joe";
            thisFan.Location = "Mesa";

            story = new Stories
            {
                Headline = "I saw a convoy of 20 Delicas!",
                Story = "I was just sitting there and then" +
                        "20 Delicas drove by all together!",
                TheFanName = thisFan.Name,
                TheFanLocation = thisFan.Location
            };
            bigStoryList.Add(story);

            thisFan = new Charter();
            thisFan.Name = "Bing";
            thisFan.Location = "Ban";

            story = new Stories
            {
                Headline = "Delicas in the jungle!",
                Story = "Days of wheeling into nowhere lead us to a mountaintop" +
                "where we found some old guy camping in a Delica!",
                TheFanName = thisFan.Name,
                TheFanLocation = thisFan.Location
            };
            bigStoryList.Add(story);

            //add another
            thisFan = new Charter();
            thisFan.Name = "Toooood";
            thisFan.Location = "Fooon";

            story = new Stories
            {
                Headline = "Awadasfoneob oadghokneoakdjlaksmd ;alm;s",
                Story = "adg;;;;;;;;;eeeeeeeekjsdfkjsdnksdjnksdjgn" +
                "sdgasdfhsdfhdf ef sdg ea sdfg sg sg sdf sdf wg gg!",
                TheFanName = thisFan.Name,
                TheFanLocation = thisFan.Location
            };
            bigStoryList.Add(story);
        }

        public List<Stories> GetAllStories()
        {
            return bigStoryList;
        }

        public void AddStory(Stories aStory)
        {
            bigStoryList.Add(aStory);
        }

    }
}