using System;
using lab1.Games;
using lab1.Others;

namespace lab1.Accounts
{
    public class PremiumGameAccount: StandartGameAccount
    {
        public PremiumGameAccount(string userName) : base(userName)
        {
        }

        public override void WinGame(string opponentName, BaseGame baseGame)
        {
            var winGame = new Calculation(2*baseGame.Rating, "Win", opponentName, 1);
            allCalculations.Add(winGame);
        }
        
        public override void LoseGame(string opponentName, BaseGame baseGame)
        {
            if (CurrentRating - baseGame.Rating < 1)
            {
                throw new InvalidOperationException("Rating <= 1");
            }
            var loseGame = new Calculation(-baseGame.Rating/2, "Lose", opponentName, 1);
            allCalculations.Add(loseGame);
        }
    }
}