/*
Dominik Michalak
1. Initialize the board
2. Set the starting player to X or O
3. Start the game and continue it untill the board is full or there is a winner
4. Update the board
5. Switch player
6. Display illegal moves
7. Display final board
8. Check for a winner and print the result
 
 */
class Program
{
    static void Main()
    {
        char[,] board = { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        char currentPlayer = (new Random().Next(2) == 0) ? 'X' : 'O';
        Console.WriteLine("Welcome to tic-tac-toe game!");

        while (!FullBoard(board) && !Winner(board))
        {
            PrintBoard(board);
            Console.Write($"{currentPlayer}'s move > ");
            int move;

            if (int.TryParse(Console.ReadLine(), out move) && ValidMove(move, board))
            {
                MakeMove(currentPlayer, move, board);
                currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
            }
            else
            {
                Console.WriteLine("Illegal move! Try again.");
            }
        }
        PrintBoard(board);
        if (Winner(board))
        {
            Console.WriteLine($"{(currentPlayer == 'X' ? 'O' : 'X')} wins! Game over.");
        }
        else
        {
            Console.WriteLine("It's a draw! Game over.");
        }
    }
    static void PrintBoard(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write($" {board[i, j]} ");
                if (j < 2)
                    Console.Write("|");
            }
            Console.WriteLine();
            if (i < 2)
                Console.WriteLine("-----------");
        }
        Console.WriteLine();
    }
    static bool ValidMove(int move, char[,] board)
    {
        int row = (move - 1) / 3;
        int coll = (move - 1) % 3;
        return 1 <= move && move <= 9 && board[row, coll] == ' ';
    }
    static void MakeMove(char player, int move, char[,] board)
    {
        int row = (move - 1) / 3;
        int coll = (move - 1) % 3;
        board[row, coll] = player;
    }
    static bool FullBoard(char[,] board)
    {
        foreach (var cell in board)
        {
            if (cell == ' ')
                return false;
        }
        return true;
    }
    static bool Winner(char[,] board)
    {
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] != ' ' && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                return true;
        }
        for (int j = 0; j < 3; j++)
        {
            if (board[0, j] != ' ' && board[0, j] == board[1, j] && board[1, j] == board[2, j])
                return true;
        }
        if (board[0, 0] != ' ' && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            return true;
        if (board[0, 2] != ' ' && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            return true;

        return false;
    }
}