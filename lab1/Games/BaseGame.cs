using lab1.Accounts;

namespace lab1.Games
{
    public abstract class BaseGame
    {
        public int Rating { get; set; }
        protected readonly BaseGameAccount UserOne;
        protected readonly BaseGameAccount UserTwo;
        protected BaseGame(BaseGameAccount userOne, BaseGameAccount userTwo, int rating)
        {
            UserOne = userOne;
            UserTwo = userTwo;
            Rating = rating;
        }
        protected BaseGame(BaseGameAccount userOne, BaseGameAccount userTwo)
        {
            UserOne = userOne;
            UserTwo = userTwo;
            Rating = 0;
        }
        public abstract void Play();
    }
}