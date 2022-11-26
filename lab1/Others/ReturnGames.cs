using lab1.Accounts;
using lab1.Games;

namespace lab1.Others
{
    public class ReturnGames
    {
        public static BaseGame GetStandartGame(StandartGameAccount userOne, StandartGameAccount userTwo, int rating, int choiceUser1, int choiceUser2)
        {
            return new StandartGame(userOne, userTwo, rating, choiceUser1, choiceUser2);
        }
        
        public static BaseGame GetTraineGame(StandartGameAccount userOne, StandartGameAccount userTwo, int choiceUser1, int choiceUser2)
        {
            return new TraineGame(userOne, userTwo, choiceUser1, choiceUser2);
        } 
    }
}