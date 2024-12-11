// Class Diagram Description:
//
// 1. Class: Video
//    - Attributes: Title (string), Author (string), LengthInSeconds (int), Comments (List<Comment>)
//    - Methods: GetNumberOfComments() (int), AddComment(Comment), DisplayVideoInfo()
//
// 2. Class: Comment
//    - Attributes: CommenterName (string), Text (string)
//    - Methods: None

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

    // Video class
    public class Video
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public int LengthInSeconds { get; private set; }
        private List<Comment> Comments;

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
            Comments = new List<Comment>();
        }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        public int GetNumberOfComments()
        {
            return Comments.Count;
        }

        public void DisplayVideoInfo()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Length: {LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (var comment in Comments)
            {
                Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
            }
        }
    }

    // Comment class
    public class Comment
    {
        public string CommenterName { get; private set; }
        public string Text { get; private set; }

        public Comment(string commenterName, string text)
        {
            CommenterName = commenterName;
            Text = text;
        }
    }
}
