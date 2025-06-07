using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();
        int duration = GetDuration();
        int cycleTime = 6; // 3s in, 3s out
        int cycles = duration / cycleTime;

        for (int i = 0; i < cycles; i++)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(3);
            Console.Write("\nNow breathe out... ");
            ShowCountdown(3);
        }

        End();
    }
}