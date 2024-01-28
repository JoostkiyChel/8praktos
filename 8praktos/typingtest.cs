using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8praktos
{
    public class TypingTest
    {
        private static string testText = "This is a sample text for typing test. You can modify it as needed.";
        private static bool isTestActive = true;

        public static void StartTest(User user)
        {
            Console.Clear();
            Console.WriteLine($"Welcome, {user.Name}! Get ready for the typing test.\n");

            Console.WriteLine("\n\n");
            Console.WriteLine("Press Enter to start typing...");

            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Type the following text:\n");

            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(testText);

            Console.SetCursorPosition(0, Console.CursorTop + 2);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Red;

            int charactersTyped = 0;
            int errors = 0;
            int i = 0;

            Thread timerThread = new Thread(() =>
            {
                Thread.Sleep(60000);
                isTestActive = false;
            });
            timerThread.Start();

            while (isTestActive && i < testText.Length)
            {
                char letter = testText[i];
                char userKey = Console.ReadKey().KeyChar;

                if (userKey == letter)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(letter);
                    Console.ResetColor();
                    charactersTyped++;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write(letter);
                    Console.ResetColor();
                    errors++;
                }
                i++;
            }

            timerThread.Join();
            Console.Clear();
            Console.WriteLine($"Test completed! Your result: {charactersTyped} characters, {errors} errors");
            Leaderboard.AddUserToLeaderboard(user);
            Leaderboard.DisplayLeaderboard();
        }
    }
}
