using System;
using lab1.Accounts;

namespace lab1.Games
{
    public class StandartGame: BaseGame
        {
            public int ChoiceUser1 { get; }
            public int ChoiceUser2 { get; }
            
            public StandartGame(StandartGameAccount userOne, StandartGameAccount userTwo, int rating, int choiceUser1, int choiceUser2) : base(userOne, userTwo, rating)
            {
                if (rating <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(rating), "Rating !<= 0");
                }
                Rating = rating;
                ChoiceUser1 = choiceUser1;
                ChoiceUser2 = choiceUser2;
            }

            public override void Play()
            {
                if (ChoiceUser1 > ChoiceUser2)
                {
                    UserOne.WinGame(UserTwo.UserName, this);
                    UserTwo.LoseGame(UserOne.UserName, this);
                }
                else if (ChoiceUser1 == ChoiceUser2)
                {
                    UserOne.DrawGame(UserTwo.UserName);
                    UserTwo.DrawGame(UserOne.UserName);
                }
                else
                {
                    UserTwo.WinGame(UserOne.UserName, this);
                    UserOne.LoseGame(UserTwo.UserName, this);
                }
            }

        }
}