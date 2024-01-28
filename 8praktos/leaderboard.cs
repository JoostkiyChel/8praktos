using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _8praktos
{
    public static class Leaderboard
    {
        private static List<User> users;
        private static string leaderboardFilePath = "leaderboard.json";

        static Leaderboard()
        {
            LoadLeaderboard();
        }

        public static void LoadLeaderboard()
        {
            if (File.Exists(leaderboardFilePath))
            {
                string json = File.ReadAllText(leaderboardFilePath);
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            else
            {
                users = new List<User>();
            }
        }

        public static void SaveLeaderboard()
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(leaderboardFilePath, json);
        }

        public static void DisplayLeaderboard()
        {
            Console.WriteLine("Leaderboard:\n");

            foreach (var user in users.OrderByDescending(u => u.CharactersPerMinute))
            {
                Console.WriteLine($"{user.Name}: {user.CharactersPerMinute} CPM, {user.CharactersPerSecond} CPS");
            }
        }

        public static void AddUserToLeaderboard(User user)
        {
            users.Add(user);
            SaveLeaderboard();
        }
    }
}
