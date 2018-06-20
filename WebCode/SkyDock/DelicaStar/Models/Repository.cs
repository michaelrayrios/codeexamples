using System.Collections.Generic;

namespace DelicaStar.Models
{
    public static class Repository
    {
        private static List<Stories> stories = new List<Stories>();
        public static IEnumerable<Stories> TheStories
        {
            get
            {
                return stories;
            }
        }
        public static void AddStory(Stories story)
        {
            stories.Add(story);
        }
    }
}