﻿using sudoku;

var sudokuData = new int[9, 9]
{
    {5,3,0, 0,7,0, 0,0,0},
    {6,0,0, 1,9,5, 0,0,0},
    {0,9,8, 0,0,0, 0,6,0},
    
    {8,0,0, 0,6,0, 0,0,3},
    {4,0,0, 8,0,3, 0,0,1},
    {7,0,0, 0,2,0, 0,0,6},
    
    {0,6,0, 0,0,0, 2,8,0},
    {0,0,0, 4,1,9, 0,0,5},
    {0,0,0, 0,8,0, 0,7,9},
};

var sudokuData2 = new int[9, 9]
{
    {2,0,0, 5,0,7, 4,0,6},
    {0,0,0, 0,3,1, 0,0,0},
    {0,0,0, 0,0,0, 2,3,0},
    
    {0,0,0, 0,2,0, 0,0,0},
    {8,6,0, 3,1,0, 0,0,0},
    {0,4,5, 0,0,0, 0,0,0},
    
    {0,0,9, 0,0,0, 7,0,0},
    {0,0,6, 9,5,0, 0,0,2},
    {0,0,1, 0,0,6, 0,0,8},
};

var hardsudoku = new int[9, 9]
{
    {0,0,0, 0,0,0, 0,0,0},
    {0,0,0, 0,0,3, 0,8,5},
    {0,0,1, 0,2,0, 0,0,0},
    
    {0,0,0, 5,0,7, 0,0,0},
    {0,0,4, 0,0,0, 1,0,0},
    {0,9,0, 0,0,0, 0,0,0}, 
    
    {5,0,0, 0,0,0, 0,7,3},
    {0,0,2, 0,1,0, 0,0,0},
    {0,0,0, 0,4,0, 0,0,9},
};


var sudokuGrid = new SudokuGrid(hardsudoku);
Console.WriteLine("Before solving:");
sudokuGrid.Print();

var sudokuSolver = new SudokuSolver(sudokuGrid);
sudokuSolver.SolvePuzzle();

Console.WriteLine("After solving:");
sudokuGrid.Print();

