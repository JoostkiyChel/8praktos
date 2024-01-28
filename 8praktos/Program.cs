using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using _8praktos;
using Newtonsoft.Json;
public class Program
{
    public static void Main()
    {
        while (true)
        {
            int choice = ArrowMenu.ShowMenu(
                new List<MenuItem>
                {
                    new MenuItem("Start Typing Test"),
                    new MenuItem("View Leaderboard"),
                    new MenuItem("Exit")
                },
                "Main Menu"
            );

            switch (choice)
            {
                case 0:
                    Console.Write("Enter your name: ");
                    string name = Console.ReadLine();
                    User currentUser = new User { Name = name };
                    TypingTest.StartTest(currentUser);
                    break;

                case 1:
                    Leaderboard.DisplayLeaderboard();
                    break;

                case 2:
                    Leaderboard.SaveLeaderboard();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}