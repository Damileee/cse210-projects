// EXTRA FEATURE: Added mood tracking to each journal entry
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n1. Write\n2. Display\n3. Save\n4. Load\n5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Console.Write("How are you feeling today (Mood): ");
                string mood = Console.ReadLine();

                journal.AddEntry(new Entry(DateTime.Now.ToShortDateString(), prompt, response, mood));
                break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case "5":
                    running = false;
                    break;
            }
        }
    }
}