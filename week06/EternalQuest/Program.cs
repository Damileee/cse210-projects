using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"You have {score} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Press enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string input = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (input)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("Enter target times: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        goals.Add(newGoal);
    }

    static void ListGoals()
    {
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }

    static void SaveGoals()
    {
        Console.Write("Enter file name to save to: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(score);
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine("Goals saved successfully. Press enter to continue...");
        Console.ReadLine();
    }

    static void LoadGoals()
    {
        Console.Write("Enter file name to load from: ");
        string fileName = Console.ReadLine();

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found. Press enter to continue...");
            Console.ReadLine();
            return;
        }

        goals.Clear();
        string[] lines = File.ReadAllLines(fileName);
        score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];
            switch (type)
            {
                case "SimpleGoal":
                    goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;
                case "EternalGoal":
                    goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;
                case "ChecklistGoal":
                    goals.Add(new ChecklistGoal(
                        parts[1],
                        parts[2],
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])
                    ));
                    break;
            }
        }

        Console.WriteLine("Goals loaded successfully. Press enter to continue...");
        Console.ReadLine();
    }

    static void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.Write("Enter the number of the goal: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 1 && index <= goals.Count)
        {
            int earned = goals[index - 1].RecordEvent();
            score += earned;
            Console.WriteLine($"You earned {earned} points! Press enter to continue...");
        }
        else
        {
            Console.WriteLine("Invalid selection. Press enter to continue...");
        }
        Console.ReadLine();
    }
}