using lab1.Games;

namespace lab1.Accounts
{
    public abstract class BaseGameAccount
    {
        public string UserName { get; set; }
        protected int GamesCount { get; set; }
        public abstract int CurrentRating { get; }
        public abstract int GameIndex { get; }

        public abstract void GameStart(int gameRating, string status);
        public abstract void WinGame(string opponentName, BaseGame baseGame);
        public abstract void LoseGame(string opponentName, BaseGame baseGame);
        public abstract void DrawGame(string opponentName);
        public abstract string GetStats();

        protected BaseGameAccount(string userName)
        {
            UserName = userName;
            GamesCount = 0;
        }
    }
}