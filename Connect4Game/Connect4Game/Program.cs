// Connect Four Game Project

// 4 Core Classes aside from Main Class Program
// controller class
// information about the game (game board)
// 2 classes that extend Player abstract class

// Make the game playable for 2 human players
// optional for AI (computer)





///// ocpided by Matias

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Board
{
    private char[,] grid;
    private const int Rows = 6;
    private const int Columns = 7;
    private const char EmptyCell = '#';

    public Board()
    {
        grid = new char[Rows, Columns];
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                grid[i,j] = EmptyCell;           }
        }
    }

}

public bool InsertDisc(int column, char disc)
{
    if (column < 0 || column >= Columns)
        throw new ArgumentOutOfRangeException(nameof(column));

    for (int row = Rows - 1; row >= 0; row--)
    {
        if (grid[row, column] == EmptyCell)
        {
            grid[row, column] = disc;
            return true;
        }
    }

    return false;



}

public bool CheckWin(char disk)
{
    // Check horizontal, vertical and diagonal wins
    return CheckHorizontalWin(disk) || CheckVerticalWin(disk) ||
        CheckDiagonalWin(Disk);
}

private bool CheckHorizontalWin(char disk)
{
    for (int row = 0; row < Rows;  row++)
    {
        int count = 0;
        for (int col = 0; col < Columns; col++)
        {
            if (grid[row, col] == disc)
            {
                count++;
                if (count == 4) return true;
            }
            else
            {
                count = 0;

            }
        }
    }
    return false;

}






















///// ocpided by Joel























///// ocpided by Ali

public abstract class Player
{
    public string Name { get; private set; }
    public char Disc { get; private set; }

    protected Player(string name, char disc)
    {
        Name = name;
        Disc = disc;
    }

    public abstract int GetMove();
}


public class HumanPlayer : Player
{
    public HumanPlayer(string name, char disc) : base(name, disc) { }

    public override int GetMove()
    {
        Console.Write($"{Name}, enter your move (1-7): ");
        return int.Parse(Console.ReadLine()) - 1;
    }
}

public class Game
{
    private Board board;
    private Player player1;
    private Player player2;
    private Player currentPlayer;

    public Game()
    {
        board = new Board();
        player1 = new HumanPlayer("Player 1", 'X');
        player2 = new HumanPlayer("Player 2", 'O');
        currentPlayer = player1;
    }

    
    public void Play()
    {
        while (true)
        {
            board.Print();
            int column = currentPlayer.GetMove();

            if (!board.InsertDisc(column, currentPlayer.Disc))
            {
                Console.WriteLine("Column full. Try another column.");
                continue;
            }

            if (board.CheckWin(currentPlayer.Disc))
            {
                board.Print();
                Console.WriteLine($"{currentPlayer.Name} wins!");
                break;
            }

            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }
    }
