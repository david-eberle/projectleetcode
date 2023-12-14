using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public partial class Program
{
	public static void Exercise2481()
	{
	}

    #region 2482
    public static int[][] OnesMinusZeros(int[][] grid)
    {
		int width = grid.Length;
		int height = grid[0].Length;
        int[] colSum = new int[height];
        int[] rowSum = new int[width];
		int value;
		for(int row = 0; row < width; row++) { 
			for(int col = 0; col < height; col++)
			{
				value = (grid[row][col] == 0?-1:1);
                colSum[col] += value;
                rowSum[row] += value;
            }
        }
		//int[][] result = new int[width][];
		//for(int row = 0;row < width; row++)
		//{
		//	result[row] = new int[height];
		//}
        for (int row = 0; row < width; row++)
        {
			for (int col = 0; col < height; col++)
			{
				grid[row][col] = colSum[col] + rowSum[row];
			}
        }
		return grid;
    }
    public static void Exercise2482()
	{
		int[][] grid = new int[][]
		{
			new int[] {0, 1, 1},
            new int[] {1, 0, 1}
		};
		int[][] result = OnesMinusZeros(grid);
        printGrid(result);
    }

    #endregion

    public static void Exercise2483()
	{
	}

	public static void Exercise2484()
	{
		
	}

	public static void Exercise2485()
	{	
		
	}

	public static void Exercise2486()
	{
		
	}

	public static void Exercise2487()
	{
		
	}
	public static void Exercise2488()
	{
		
	}

	public static void Exercise2489()
	{
	}

	public static void Exercise2490()
	{
	}
}