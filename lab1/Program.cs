using System;
using System.Collections.Generic;
using System.Linq;

namespace lab1
{
  class Program
    {
        public static void Main(string[] args)
        {
            var user1 = new GameAccount("Denys");
            var user2 = new GameAccount("David");
            var gameOne = new Game(user1, user2, 10, 12, 14);
            gameOne.Play();
            var gameTwo = new Game(user1, user2, 20, 14, 12);
            gameTwo.Play();
            var gameThree = new Game(user1, user2, 10, 14, 12);
            gameThree.Play();
            Console.WriteLine(user1.UserName + "\n" + user1.GetStats());
            Console.WriteLine(user2.UserName + "\n" + user2.GetStats());
        }

        public class GameAccount
        {
            public string UserName { get; }
            public int GamesCount { get; }
            public int CurrentRating
            {
                get
                {
                    return 100 + allCalculations.Sum(item => item.GameRating);
                }
            }
            public int GameIndex
            {
                get
                {
                    int Index = 0;
                    int index = 0;
                    for (; index < allCalculations.Count; index++)
                    {
                        var item = allCalculations[index];
                        Index += item.GameIndex;
                    }
                    return Index;
                }
            }
            
            public void GameStart(int gameRating, string status)
            {
                var startGame = new Calculation(gameRating, status, "None", 0);
                allCalculations.Add(startGame);
            }

            public void WinGame(string opponentName, int gameRating)
            {
                var winGame = new Calculation(gameRating, "Win", opponentName, 1);
                allCalculations.Add(winGame);
            }

            public void LoseGame(string opponentName, int gameRating)
            {
                if (CurrentRating - gameRating < 1)
                {
                    throw new InvalidOperationException("Rating <= 1");
                }
                var loseGame = new Calculation(-gameRating, "Lose", opponentName, 1);
                allCalculations.Add(loseGame);
            }

            public void DrawGame(string opponentName)
            {
                var drawGame = new Calculation(0, "Draw", opponentName, 1);
                allCalculations.Add(drawGame);
            }
            
            public string GetStats()
            {
                var report = new System.Text.StringBuilder();
                int currentRating = 100;
                int gameIndex = 0;
                report.AppendLine("OpponentName\tStatus\tGameRating\tIndexGame");
                foreach (var item in allCalculations)
                {
                    currentRating += item.GameRating;
                    gameIndex += item.GameIndex;
                    report.AppendLine($"{item.OpponentName}\t\t{item.Status}\t\t{item.GameRating}\t\t{gameIndex}");
                }
                return report.ToString();
            }

            public GameAccount(string userName)
            {
                UserName = userName;
                GamesCount = 0;
                GameStart(0, "Start");
            }

            private List<Calculation> allCalculations = new List<Calculation>();

        }

        public class Calculation
        {
            public int GameRating { get; }
            public string Status { get; }
            public string OpponentName { get; }
            public int GameIndex { get; }

        public Calculation(int rating, string status, string opponentName, int gameIndex)
            {
                GameRating = rating;
                Status = status;
                OpponentName = opponentName;
                GameIndex = gameIndex;
            }
        }

        public class Game
        {
            public readonly GameAccount UserOne;
            public readonly GameAccount UserTwo;
            public int Rating { get; }
            public int ChoiceUser1 { get; }
            public int ChoiceUser2 { get; }
            
            public Game(GameAccount userOne, GameAccount userTwo, int rating, int choiceUser1, int choiceUser2)
            {
                if (rating <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(rating), "Rating !<= 0");
                }
                UserOne = userOne;
                UserTwo = userTwo;
                Rating = rating;
                ChoiceUser1 = choiceUser1;
                ChoiceUser2 = choiceUser2;
            }

            public void Play()
            {
                if (ChoiceUser1 > ChoiceUser2)
                {
                    UserOne.WinGame(UserTwo.UserName, Rating);
                    UserTwo.LoseGame(UserOne.UserName, Rating);
                }
                else if (ChoiceUser1 == ChoiceUser2)
                {
                    UserOne.DrawGame(UserTwo.UserName);
                    UserTwo.DrawGame(UserOne.UserName);
                }
                else
                {
                    UserTwo.WinGame(UserOne.UserName, Rating);
                    UserOne.LoseGame(UserTwo.UserName, Rating);
                }
            }
        }
    }
}

