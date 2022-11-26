using System;
using System.Collections.Generic;
using System.Linq;
using lab1.Games;
using lab1.Others;

namespace lab1.Accounts
{
    public class StandartGameAccount: BaseGameAccount
        {
            public override int CurrentRating
            {
                get
                {
                    return 100 + allCalculations.Sum(item => item.GameRating);
                }
            }
            public override int GameIndex
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

            public override void GameStart(int gameRating, string status)
            {
                var startGame = new Calculation(gameRating, status, "None", 0);
                allCalculations.Add(startGame);
            }

            public override void WinGame(string opponentName, BaseGame baseGame)
            {
                var winGame = new Calculation(baseGame.Rating, "Win", opponentName, 1);
                allCalculations.Add(winGame);
            }

            public override void LoseGame(string opponentName, BaseGame baseGame)
            {
                if (CurrentRating - baseGame.Rating < 1)
                {
                    throw new InvalidOperationException("Rating <= 1");
                }
                var loseGame = new Calculation(-baseGame.Rating, "Lose", opponentName, 1);
                allCalculations.Add(loseGame);
            }

            public override void DrawGame(string opponentName)
            {
                var drawGame = new Calculation(0, "Draw", opponentName, 1);
                allCalculations.Add(drawGame);
            }
            
            public override string GetStats()
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

            public StandartGameAccount(string userName) : base(userName)
            {
                GameStart(0, "Start");
            }

            protected List<Calculation> allCalculations = new List<Calculation>();
        }
}