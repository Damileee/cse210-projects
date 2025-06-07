using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            Activity activity = null;

            switch (input)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Press Enter to try again.");
                    Console.ReadLine();
                    continue;
            }

            activity.Run();
        }

        // EXCEEDS CORE REQUIREMENTS   //
        // =========================== //
        // 1. The program features a main menu that loops, allowing the user to 
        //    perform multiple mindfulness activities without restarting the app.
        // 2. It uses a base class (Activity) with shared methods and properties,
        //    showcasing abstraction and inheritance.
        // 3. The UI includes countdowns and animated spinners for a better user experience.
        // 4. Each class is placed in its own file, following good coding style and organization.
        // 5. Prompts and questions are randomized, making each session feel unique.
        // 6. The program is written with clean naming conventions and comments
        //    to make the code maintainable and readable.
    }
}