using System;
using System.Collections.Generic;

namespace YouTubeVideoTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create sample videos
            Video video1 = new Video("C# Abstraction Tutorial", "Tech Guru", 600);
            video1.AddComment(new Comment("Alice", "Great tutorial, very helpful!"));
            video1.AddComment(new Comment("Bob", "Thanks for explaining abstraction."));
            video1.AddComment(new Comment("Charlie", "Can you do a video on inheritance next?"));

            Video video2 = new Video("Top 10 Programming Tips", "Code Master", 720);
            video2.AddComment(new Comment("David", "Tip #3 is a lifesaver!"));
            video2.AddComment(new Comment("Eve", "Loved the concise explanations."));

            Video video3 = new Video("Understanding Design Patterns", "Dev Pro", 900);
            video3.AddComment(new Comment("Frank", "Excellent content, as always."));
            video3.AddComment(new Comment("Grace", "Can you elaborate on the Singleton pattern?"));
            video3.AddComment(new Comment("Hannah", "I learned a lot, thank you!"));

            // Add videos to a list
            List<Video> videos = new List<Video> { video1, video2, video3 };

            // Display video information and comments
            foreach (var video in videos)
            {
                video.DisplayVideoInfo();
                Console.WriteLine();
            }
        }
    }
}