namespace sudoku;

public class SudokuSolver
{
    private readonly SudokuGrid _sudokuGrid;

    public SudokuSolver(SudokuGrid sudokuGrid)
    {
        _sudokuGrid = sudokuGrid;
        _sudokuGrid.Validate();
    }

    public int[,] SolvePuzzle()
    {
        Solve();
        Console.WriteLine(_sudokuGrid.Assigns + " tries total.");
        return _sudokuGrid.Data;
    }

    /// <summary>
    /// RECURSIVE method
    /// </summary>
    private bool Solve()
    {
        var cell = _sudokuGrid.FindNextEmptyCell();
        if (cell == null)
        {
            // no empty cells, sudoku is solved
            return true;
        }

        for (var num = 1; num <= 9; num++)
        {
            if (_sudokuGrid.VerifyNoConflicts(cell, num))
            {
                _sudokuGrid.Assign(cell, num);

                if (Solve())
                    return true;
                
                _sudokuGrid.UnAssign(cell);
            }
        }

        return false;
    }
}