using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
               "This activity will help you relax by walking you through breathing in and out. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            elapsed += 4;

            if (elapsed >= Duration) break;

            Console.Write("\nBreathe out... ");
            ShowCountDown(6);
            elapsed += 6;
        }

        DisplayEndingMessage();
    }
}