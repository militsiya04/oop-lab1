namespace lab1.Others
{
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
}