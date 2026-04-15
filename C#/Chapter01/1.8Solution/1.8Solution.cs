/*
zero Matrix: Write an algorithm such that if an element in an MxN matrix is 0, its entire row and 
column are set to 0. 

[x,x,0,x]
[0,x,0,x]
[x,0,x,x]
[x,x,x,x]

[0,0,0,0]
[0,0,0,0]
[0,0,0,0]
[0,0,0,x]


*/

int[,] ZeroMatrix(int[,] matrix)
{
	HashSet<int> rows = new HashSet<int>(); 
	HashSet<int> columns = new HashSet<int>(); 
	int M = matrix.GetLength(0);
	int N = matrix.GetLength(1);  
	for(int i=0; i<M; i++)
	{
		for(int j=0; j<N; j++)
		{
			if(matrix[i,j] == 0)
			{
				rows.Add(i); 
				columns.Add(j); 
			}
		}
	}

	foreach(int row in rows)
	{
        for(int j= 0; j<N; j++)
        {
            matrix[row, j] = 0; 
        }
	}

    foreach(int column in columns)
    {
        for(int i = 0; i<M; i++)
        {
            matrix[i, column] = 0; 
        }
    }
	return matrix; 

}

/*------------------TEST--------------------*/

bool CompareMatrices(int[,] m1, int[,] m2)
{
    if (m1.GetLength(0) != m2.GetLength(0) ||
        m1.GetLength(1) != m2.GetLength(1))
        return false;

    for (int i = 0; i < m1.GetLength(0); i++)
    {
        for (int j = 0; j < m1.GetLength(1); j++)
        {
            if (m1[i, j] != m2[i, j])
                return false;
        }
    }

    return true;
}

void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.Write(" | ");
    }
}

void Test(int[,] input, int[,] expected)
{
    ZeroMatrix(input); // in-place

    bool result = CompareMatrices(input, expected);

    Console.Write("Result: ");
    PrintMatrix(input);

    Console.Write(" Expected: ");
    PrintMatrix(expected);

    Console.WriteLine(result ? " ✅" : " ❌");
}

void RunTests()
{
    Console.WriteLine("=== ZERO MATRIX TESTS ===");

    // 1x1 sin cero
    Test(
        new int[,] { { 1 } },
        new int[,] { { 1 } }
    );

    // 1x1 con cero
    Test(
        new int[,] { { 0 } },
        new int[,] { { 0 } }
    );

    // 2x2 sin ceros
    Test(
        new int[,]
        {
            { 1, 2 },
            { 3, 4 }
        },
        new int[,]
        {
            { 1, 2 },
            { 3, 4 }
        }
    );

    // 2x2 con un cero
    Test(
        new int[,]
        {
            { 1, 0 },
            { 3, 4 }
        },
        new int[,]
        {
            { 0, 0 },
            { 3, 0 }
        }
    );

    // 3x3 con cero en medio
    Test(
        new int[,]
        {
            { 1, 2, 3 },
            { 4, 0, 6 },
            { 7, 8, 9 }
        },
        new int[,]
        {
            { 1, 0, 3 },
            { 0, 0, 0 },
            { 7, 0, 9 }
        }
    );

    // múltiples ceros
    Test(
        new int[,]
        {
            { 1, 2, 0 },
            { 4, 5, 6 },
            { 0, 8, 9 }
        },
        new int[,]
        {
            { 0, 0, 0 },
            { 0, 5, 0 },
            { 0, 0, 0 }
        }
    );

    // fila completa en cero
    Test(
        new int[,]
        {
            { 0, 0, 0 },
            { 1, 2, 3 },
            { 4, 5, 6 }
        },
        new int[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        }
    );

    // columna completa en cero
    Test(
        new int[,]
        {
            { 1, 0, 3 },
            { 4, 0, 6 },
            { 7, 0, 9 }
        },
        new int[,]
        {
            { 0, 0, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        }
    );

    // sin cambios (ya procesada)
    Test(
        new int[,]
        {
            { 0, 0 },
            { 0, 0 }
        },
        new int[,]
        {
            { 0, 0 },
            { 0, 0 }
        }
    );

    // rectangular (no cuadrada)
    Test(
        new int[,]
        {
            { 1, 2, 3, 4 },
            { 5, 0, 7, 8 }
        },
        new int[,]
        {
            { 1, 0, 3, 4 },
            { 0, 0, 0, 0 }
        }
    );

    // cero en esquina
    Test(
        new int[,]
        {
            { 0, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        },
        new int[,]
        {
            { 0, 0, 0 },
            { 0, 5, 6 },
            { 0, 8, 9 }
        }
    );

    // tricky: muchos ceros dispersos
    Test(
        new int[,]
        {
            { 1, 2, 3 },
            { 0, 5, 6 },
            { 7, 8, 0 }
        },
        new int[,]
        {
            { 0, 2, 0 },
            { 0, 0, 0 },
            { 0, 0, 0 }
        }
    );
}

RunTests();