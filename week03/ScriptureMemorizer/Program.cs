

// EXCEEDED REQUIREMENTS 
// 1. Scripture Library: Instead of a single hardcoded scripture, the
//    program randomly selects from a library of 5 scriptures (including
//    multi-verse references), giving users variety each session.
 
// 2. Smart Random Hiding: Only visible words are eligible for hiding,
//    so no turn is ever wasted re-hiding an already-hidden word.

// 3. Configurable Hide Count: Hides 3 words per press for good pacing.


using System;


class Program
{
    static void Main(string[] args)
    {
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life"),
            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding In all thy ways acknowledge him and he shall direct thy paths"),
            new Scripture(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me"),
            new Scripture(new Reference("Joshua", 1, 9),
                "Have not I commanded thee Be strong and of a good courage be not afraid neither be thou dismayed for the Lord thy God is with thee whithersoever thou goest"),
            new Scripture(new Reference("Romans", 8, 28),
                "And we know that all things work together for good to them that love God to them who are the called according to his purpose"),
        };

        Scripture scripture = scriptures[new Random().Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden!! Great memorization practice");
                break;
            }

            Console.Write("Press Enter to hide more words, or type 'quit' to exit:: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}