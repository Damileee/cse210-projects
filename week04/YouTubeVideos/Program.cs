using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("The Art of Pizza Making", "Chef Tony", 420);
        video1.AddComment(new Comment("Alice", "So helpful!"));
        video1.AddComment(new Comment("Ben", "Delicious and simple."));
        video1.AddComment(new Comment("Claire", "I tried this and loved it."));
        videos.Add(video1);

        Video video2 = new Video("Intro to C# Programming", "CodeMaster", 540);
        video2.AddComment(new Comment("Daniel", "Very well explained."));
        video2.AddComment(new Comment("Eva", "I finally understand loops!"));
        video2.AddComment(new Comment("Frank", "This was awesome."));
        videos.Add(video2);

        Video video3 = new Video("Daily Yoga Routine", "Wellness World", 300);
        video3.AddComment(new Comment("Grace", "Great morning session."));
        video3.AddComment(new Comment("Henry", "Just what I needed."));
        video3.AddComment(new Comment("Ivy", "Feeling refreshed."));
        videos.Add(video3);

        // Display details
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}