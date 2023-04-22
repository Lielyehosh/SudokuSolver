namespace sudoku;

public class SudokuGrid
{
    public int[,] Data { get; set; }
    
    private int _currentCol = 0;
    private int _currentRow = 0;
    public int Assigns { get; private set; } = 0;

    public SudokuGrid(int[,] data)
    {
        Data = data;
    }
 
    public void Print()
    {
        for (var i = 0; i < 9; i++)
        {
            for (var j = 0; j < 9; j++)
            {
                Console.Write($"{Data[i, j]} ");
                if (j is 2 or 5)
                    Console.Write("  ");
            }

            if (i == 2 || i == 5)
                Console.Write(Environment.NewLine);
            
            Console.Write(Environment.NewLine);
        }
    }

    public Cell? FindNextEmptyCell()
    {
        var cell = new Cell();
        while (Data[_currentRow, _currentCol] != 0)
        {
            _currentCol++;

            if (_currentCol == 9)
            {
                _currentRow++;
                _currentCol = 0;
            }

            if (_currentRow == 9)
            {
                cell.Row = -1;
                cell.Col = -1;
                return null;
            }
        }

        cell.Row = _currentRow;
        cell.Col = _currentCol;

        return cell;
    }

    public bool VerifyNoConflicts(Cell cell, int value)
    {
        return ValidateRow(cell, value) && ValidateCol(cell, value) && ValidateSquare(cell, value);
    }

    private bool ValidateSquare(Cell cell, int value)
    {
        var fromColumn = 3 * (cell.Col/3);
        var fromRow = 3 * (cell.Row / 3);

        for (var colIdx = fromColumn; colIdx < fromColumn + 3; colIdx++)
        {
            for (var rowIdx = fromRow; rowIdx < fromRow + 3; rowIdx++)
            {
                if (Data[rowIdx, colIdx] == value)
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool ValidateCol(Cell cell, int value)
    {
        for (var colIdx = 0; colIdx < 9; colIdx++)
        {
            if (Data[cell.Row, colIdx] == value)
            {
                return false;
            }
        }

        return true;
    }

    private bool ValidateRow(Cell cell, int value)
    {
        for (var rowIdx = 0; rowIdx < 9; ++rowIdx)
        {
            if (Data[rowIdx, cell.Col] == value)
            {
                return false;
            }
        }

        return true;
    }

    public void Assign(Cell cell, int value)
    {
        Assigns++;
        Data[cell.Row, cell.Col] = value;
    }

    public void UnAssign(Cell cell)
    {
        Data[cell.Row, cell.Col] = 0;
        _currentCol = cell.Col;
        _currentRow = cell.Row;
    }


    public void Validate()
    {
        if (Data.Length != 81)
            throw new Exception("Invalid Dimensions");
        

        if (!IsLegal())
            throw new Exception("Illegal numbers populated!");
        
    }

    private bool IsLegal()
    {
        var container = new HashSet<int>();
        
        // vertical check
        for (var c = 0; c < 9; ++c)
        {
            container.Clear();
            for (var r = 0; r < 9; ++r)
            {
                if (Data[r, c] != 0)  
                {
                    if (container.Contains(Data[r, c]))
                    {
                        return false;
                    }
                    container.Add(Data[r, c]);
                }
            }
        }
        // horizontal check
        for (int r = 0; r < 9; ++r)
        {
            container.Clear();
            for (int c = 0; c < 9; ++c)
            {
                if (Data[r, c] != 0)
                {
                    if (container.Contains(Data[r, c]))
                    {
                        return false;
                    }
                    container.Add(Data[r, c]);
                }
            }
        }

        // square check
        var topLeftCorners = new List<Tuple<int, int>>
        {
            new(0,0),
            new(0,3),
            new(0,6),
            new(3,0),
            new(3,3),
            new(3,6),
            new(6,0),
            new(6,3),
            new(6,6)
        };

        foreach (var topLeftCorner in topLeftCorners)
        {
            var fromCol = topLeftCorner.Item2;
            var fromRow = topLeftCorner.Item1;

            container.Clear();

            for (int c = fromCol; c < fromCol + 3; c++)
            {
                for (int r = fromRow; r < fromRow + 3; r++)
                {
                    if (Data[r, c] != 0)
                    {
                        if (container.Contains(Data[r, c]))
                        {
                            return false;
                        }
                        container.Add(Data[r, c]);
                    }
                }
            }
        }

        return true;
    }
}