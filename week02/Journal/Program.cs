// Extra feature: Added mood for each journal entry.


using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {   
            Console.WriteLine();
            Console.WriteLine("------ JOURNAL MENU ----- ");
            Console.WriteLine();
           
            Console.WriteLine("1. Write new entry");
           
            Console.WriteLine("2. Display journal");
         
            Console.WriteLine("3. Save journal");
            
            Console.WriteLine("4. Load journal");
            
            Console.WriteLine("5. Quit");
            
            Console.Write("Choose an option: ");
            
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);

                    Console.Write("Your answer: ");
                    string answer = Console.ReadLine();
                    
                    
                    // Extra feature: mood
                    Console.Write("How do you feel today? ");
                    string mood = Console.ReadLine();
                    
                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToString("MM/dd/yyyy");
                    entry._prompt = prompt;
                    entry._answer = answer;
                     entry._mood = mood; 

                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.Display();
                    break;

                case "3":
                    journal.SaveToFile();
                    break;

                case "4":
                    journal.LoadFromFile();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
            
        }
    }
}
