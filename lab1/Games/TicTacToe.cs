using System;
using lab1.Accounts;

namespace lab1.Games
{
    public class TicTacToe: BaseGame
    {
        public string MoveUserOne { get; set; }
        public string MoveUserTwo { get; set; }
        public string[] UseMove = { "-", "-", "-", "-", "-", "-", "-", "-", "-" };
        public TicTacToe(BaseGameAccount userOne, BaseGameAccount userTwo, int rating) : base(userOne, userTwo, rating)
        {
        }
        public override void Play()
        {
            string[,] TicTacToe = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } }; 
            GetTicTacToe(TicTacToe);
            for (int i = 0; i < TicTacToe.Length; i++)
            {
                if (i % 2 == 0)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write("{0}, select a number: ", UserOne.UserName);
                            MoveUserOne = Console.ReadLine();
                                    if (CheckValideValue(UseMove,MoveUserOne))
                                    {
                                        for (int r = 0; r < 3; r++)
                                        {
                                            for (int y = 0; y < 3; y++)
                                            {
                                                if (TicTacToe[r, y] == MoveUserOne)
                                                {
                                                    TicTacToe[r, y] = "X";
                                                    UseMove[Int32.Parse(MoveUserOne) - 1] = MoveUserOne;
                                                    if (CheckTicTacToe(TicTacToe))
                                                    {
                                                        GetTicTacToe(TicTacToe);
                                                        UserOne.WinGame(UserTwo.UserName, this);
                                                        UserTwo.LoseGame(UserOne.UserName, this);
                                                        Console.WriteLine("Winner - {0}", UserOne.UserName);
                                                        Console.WriteLine("Loser - {0}\n", UserTwo.UserName);
                                                        return;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Try again");
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write("{0}, select a number: ", UserTwo.UserName);
                            MoveUserTwo = Console.ReadLine();
                            if (CheckValideValue(UseMove,MoveUserTwo))
                            {
                                for (int r = 0; r < 3; r++)
                                {
                                    for (int y = 0; y < 3; y++)
                                    {
                                        if (TicTacToe[r, y] == MoveUserTwo)
                                        {
                                            TicTacToe[r, y] = "O";
                                            UseMove[Int32.Parse(MoveUserTwo) - 1] = MoveUserTwo;
                                            if (CheckTicTacToe(TicTacToe))
                                            {
                                                GetTicTacToe(TicTacToe);
                                                UserTwo.WinGame(UserOne.UserName, this);
                                                UserOne.LoseGame(UserTwo.UserName, this);
                                                Console.WriteLine("Winner - {0}\n", UserTwo.UserName);
                                                Console.WriteLine("Loser - {0}\n", UserOne.UserName);
                                                return;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception();
                            }
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Try again");
                        }
                    }
                }
                GetTicTacToe(TicTacToe);
            }
            UserOne.DrawGame(UserTwo.UserName);
            UserTwo.DrawGame(UserOne.UserName);
            Console.WriteLine("Draw Game!");
        }

        public static void GetTicTacToe(string[,] TicTacToe)
        { 
           for (int i = 0; i < TicTacToe.GetLength(0); i++)
           {
                for (int j = 0; j < TicTacToe.GetLength(1); j++)
                {
                    Console.Write(TicTacToe[i, j]+" ");
                }
                Console.WriteLine();
           } 
        }
        public static bool CheckValideValue(string [] UseMove, string MoveUser)
        {
            string[] AllNumber = { "1", "2", "3", "4", "5", "6" , "7", "8", "9"};
            for (int i = 0; i <AllNumber.Length; i++)
            {
                if (MoveUser == AllNumber[i])
                {
                    for (int j = 0; j < UseMove.Length; j++)
                    {
                        if (MoveUser == UseMove[j])
                        {
                            return false;
                        }
                        if (j == 8)
                        {
                            if (MoveUser != UseMove[j])
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public static bool CheckTicTacToe(string[,] TicTacToe)
        {
            if (TicTacToe[0, 0] == TicTacToe[0, 1] && TicTacToe[0, 1] == TicTacToe[0, 2])
            {
                if (TicTacToe[0, 0] == "X" || TicTacToe[0, 0] == "O") return true;
            }
            if (TicTacToe[1, 0] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[1, 2])
            {
                if (TicTacToe[1, 0] == "X" || TicTacToe[1, 0] == "O") return true;
            }
            if (TicTacToe[2, 0] == TicTacToe[2, 1] && TicTacToe[2, 1] == TicTacToe[2, 2])
            {
                if (TicTacToe[2, 0] == "X" || TicTacToe[2, 0] == "O") return true;
            }
            if (TicTacToe[0, 0] == TicTacToe[1, 0] && TicTacToe[1, 0] == TicTacToe[2, 0])
            {
                if (TicTacToe[0, 0] == "X" || TicTacToe[0, 0] == "O") return true;
            }
            if (TicTacToe[0, 1] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[2, 1])
            {
                if (TicTacToe[0, 1] == "X" || TicTacToe[0, 1] == "O") return true;
            }
            if (TicTacToe[0, 2] == TicTacToe[1, 2] && TicTacToe[1, 2] == TicTacToe[2, 2])
            {
                if (TicTacToe[0, 2] == "X" || TicTacToe[0, 2] == "O") return true;
            }
            if (TicTacToe[0, 0] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[2, 2])
            {
                if (TicTacToe[0, 0] == "X" || TicTacToe[0, 0] == "O") return true;
            }
            if (TicTacToe[0, 2] == TicTacToe[1, 1] && TicTacToe[1, 1] == TicTacToe[2, 0])
            {
                if (TicTacToe[0, 2] == "X" || TicTacToe[0, 2] == "O") return true;
            }
            return false;
        }
    }
}