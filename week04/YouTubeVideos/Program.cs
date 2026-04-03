using System;



class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("10 Coding Tips Every Developer Should Know", "CodeWithMengi", 742);
        video1.AddComment(new Comment("Mutesi Sophie", "This saved me so much debugging time!"));
        video1.AddComment(new Comment("Sooma Rufi", "Tip #6 completely changed how I write loops."));
        video1.AddComment(new Comment("Ethan Fourie", "Clear and concise, love your content."));
        video1.AddComment(new Comment("Ukasha Noe", "Would love a follow-up on async programming."));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("How Black Holes Are Formed", "SpaceExplained", 1255);
        video2.AddComment(new Comment("Aksham Sseemu", "Mind blown. The universe is incredible."));
        video2.AddComment(new Comment("Matovu Imran", "Finally an explanation I actually understood."));
        video2.AddComment(new Comment("Kirabo Vivian", "Damn!! The animation at 8 minutes was fantastic."));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("5-Minute Sourdough Starter Guide", "BakingWithBen", 318);
        video3.AddComment(new Comment("Hannah Mariah", "I followed this and mine turned out perfect!"));
        video3.AddComment(new Comment("Ivan Mukisa", "Can you do a video on whole wheat sourdough?"));
        video3.AddComment(new Comment("Juliet Mutesi", "Best beginner guide I've found. Subscribed!"));
        video3.AddComment(new Comment("Kevin Waswa", "My starter died but this made me try again."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Beginner Guitar Lesson: Your First Chords", "GuitarFoundation", 956);
        video4.AddComment(new Comment("Laura Nagawa", "My fingers hurt but I played C major today!"));
        video4.AddComment(new Comment("Marcus Marcus", "Great pacing, not too fast at all."));
        video4.AddComment(new Comment("Ritah Okonkwo", "Been playing for a week and already feel progress."));
        videos.Add(video4);

       
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title:    {video.GetTitle()}");
            Console.WriteLine($"Author:   {video.GetAuthor()}");
            Console.WriteLine($"Length:   {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("--- Comments ---");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetName()}: {comment.GetText()}");
            }
            Console.WriteLine();
        }
    }
}