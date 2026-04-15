/*
Rotate Matrix: Given an image represented by an NxN matrix, where each pixel in the image is 4 
bytes, write a method to rotate the image by 90 degrees. Can you do this in place? 
 ROW 
[1,2,3        
 4,5,6
 7,8,9]

[7,4,1
 8,5,2
 9,6,3]

M = N-1

  i,j
 [0,0]  <- [M,0]      =  1 <- 7 
 [0,1]  <- [M-1, 0]   =  2 <- 4
 [0,2] <- [M-2,0]     =  3 <- 1

 [1,0] <- [M , 1]  = 4 <- 8
 [1,1] <- [M-1, 1] = 

 [M-j, i]

*/

int[,] RotateMatrix(int[,] matrix)
{
	int[,] result = new int[matrix.GetLength(0),matrix.GetLength(1)]; 
	for(int i = 0; i < matrix.GetLength(0); i++)
	{
		for(int j = 0; j < matrix.GetLength(1); j++)
		{
			result[i,j] = matrix[matrix.GetLength(0)-1 -j , i]; 
		}
	}
	return result; 
}


/*To make it in place
 
{  1,  2,  3,  4 },
{  5,  6,  7,  8 },
{  9, 10, 11, 12 },
{ 13, 14, 15, 16 }

Guardo el 1, 
Busco 13 -> 1 
{  13,  2,  3,  4 },
{  5,  6,  7,  8 },
{  9, 10, 11, 12 },
{ 13, 14, 15, 16 }
Busco 16 -> 13
{  13,  2,  3,  4 },
{  5,  6,  7,  8 },
{  9, 10, 11, 12 },
{ 16, 14, 15, 16 }
Busco 4 -> 16
{  13,  2,  3,  4 },
{  5,  6,  7,  8 },
{  9, 10, 11, 12 },
{ 16, 14, 15, 4 }
Pongo 1 -> 4 porque j = N-1  
{  13,  2,  3,  1 },
{  5,  6,  7,  8 },
{  9, 10, 11, 12 },
{ 16, 14, 15, 4 }
Guardo 2 
Busco 9 -> 2
{  13,  9,  3,  1 },
{  5,  6,  7,  8 },
{  9, 10, 11, 12 },
{ 16, 14, 15, 4 }
Busco 14 -> 9
{  13,  9,  3,  1 },
{  5,  6,  7,  8 },
{  14, 10, 11, 12 },
{ 16, 14, 15, 4 }
Busco 12 -> 14
{  13,  9,  3,  1 },
{  5,  6,  7,  8 },
{  14, 10, 11, 12 },
{ 16, 12, 15, 4 }
Pongo 2 -> 12 porque j = n-1 
{  13,  9,  3,  1 },
{  5,  6,  7,  8 },
{  14, 10, 11, 2 },
{ 16, 12, 15, 4 }
Guardo 3 
Busco 5 -> 3
{  13,  9,  5,  1 },
{  5,  6,  7,  8 },
{  14, 10, 11, 2 },
{ 16, 12, 15, 4 }
Busco 
*/

// [M-j, i]

int[,] RotateMatrixInPlace(int[,] matrix)
{
    int n = matrix.GetLength(0); 

    for(int layer = 0; layer<n/2; layer++)
    {
        int first = layer; 
        int last = n -1 -layer; 
        for(int i = first; i < last; i++)
        {
            int offset = i-first; 

            int temp = matrix[first,i]; 

            matrix[first,i] = matrix[last-offset , first];
            matrix[last-offset, first] = matrix[last, last-offset]; 
            matrix[last, last-offset] = matrix[i, last];
            matrix[i,last] = temp; 
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
    int[,] resultMatrix = RotateMatrixInPlace(input); 

    bool result = CompareMatrices(resultMatrix, expected);

    Console.Write("Input: ");
    PrintMatrix(input);

    Console.Write(" Rotated: ");
    PrintMatrix(resultMatrix);

    Console.Write(" Expected: ");
    PrintMatrix(expected);

    Console.WriteLine(result ? " ✅" : " ❌");
}

void RunTests()
{
    Console.WriteLine("=== ROTATE MATRIX TESTS ===");

    // 1x1
    Test(
        new int[,] { { 1 } },
        new int[,] { { 1 } }
    );

    // 2x2
    Test(
        new int[,]
        {
            { 1, 2 },
            { 3, 4 }
        },
        new int[,]
        {
            { 3, 1 },
            { 4, 2 }
        }
    );

    // 3x3
    Test(
        new int[,]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        },
        new int[,]
        {
            { 7, 4, 1 },
            { 8, 5, 2 },
            { 9, 6, 3 }
        }
    );

    // 4x4
    Test(
        new int[,]
        {
            {  1,  2,  3,  4 },
            {  5,  6,  7,  8 },
            {  9, 10, 11, 12 },
            { 13, 14, 15, 16 }
        },
        new int[,]
        {
            { 13,  9, 5, 1 },
            { 14, 10, 6, 2 },
            { 15, 11, 7, 3 },
            { 16, 12, 8, 4 }
        }
    );

    // valores repetidos
    Test(
        new int[,]
        {
            { 1, 1 },
            { 1, 1 }
        },
        new int[,]
        {
            { 1, 1 },
            { 1, 1 }
        }
    );

    // números negativos
    Test(
        new int[,]
        {
            { -1, -2 },
            { -3, -4 }
        },
        new int[,]
        {
            { -3, -1 },
            { -4, -2 }
        }
    );

    // caso tricky
    Test(
        new int[,]
        {
            { 5, 1, 9 },
            { 2, 4, 8 },
            { 3, 6, 7 }
        },
        new int[,]
        {
            { 3, 2, 5 },
            { 6, 4, 1 },
            { 7, 8, 9 }
        }
    );
}

RunTests();