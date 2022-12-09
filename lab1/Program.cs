using System;
using lab1.Accounts;
using lab1.Others;

namespace lab1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var user1 = new StandartGameAccount("Denys");
            var user2 = new PremiumGameAccount("David");
            var gameOne = ReturnGames.GetStandartGame(user1, user2, 10, 12, 14);
            gameOne.Play();
            var gameTwo = ReturnGames.GetStandartGame(user1, user2, 20, 10, 12);
            gameTwo.Play();
            var gameThree = ReturnGames.GetTraineGame(user1, user2,  14, 12);
            gameThree.Play();
            var gameFour = ReturnGames.GetTicTacToe(user1, user2, 50); 
            gameFour.Play();
            Console.WriteLine(user1.UserName + "\n" + user1.GetStats());
            Console.WriteLine(user2.UserName + "\n" + user2.GetStats());
        }
    }
}