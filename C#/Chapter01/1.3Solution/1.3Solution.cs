/*URLify Write a method to replace all spaces in a string with '%20'. You may assume that the string 
has sufficient space at the end to hold the additional characters, and that you are given the "true" 
length of the string.  (Note: If implementing in Java, please use a character array so that you can 
perform this operation in place.)  */

//Vamos a usar un list de char 

//for len until 0

//"12 4 6789    "  9
// 9 -> string.length
// 8 -> string.length -1
// .
// .
// " ", "%20" -> (string.length - 4 , -5 , -6)   
//Dice "Suficiente espacio" pero no que debe ser exacto.... entonces contamos espacios 


List<char> URLify(List<char> list, int len)
{
    int spaces = 0;
    for(int a = 0; a < len; a++)
    {
        char ch = list[a]; 
        if(ch == ' ')
        {
            spaces++; 
        }
    }

	int modif = len - 1  + (2 * spaces); 
	for(int i = len - 1; i >= 0; i--)
	{
		char c = list[i]; 
		if(c == ' ')
		{
			list[modif] = '0'; 
			modif--; 

			list[modif] = '2'; 
			modif--; 

			list[modif] = '%'; 
			modif--; 
		}else
		{
			list[modif] = c; 
			modif--; 
		}
	}
	return list; 
}



/*------------------TEST--------------------*/

void Test(string inputString, int trueLength, string expected)
{
    var input = inputString.ToList();

    var nuevo = URLify(input, trueLength);

    var result = new string(nuevo.Take(expected.Length).ToArray());

    Console.WriteLine(
        $"Input: (\"{inputString}\", {trueLength}) | Result: \"{result}\" | Expected: \"{expected}\" " +
        (result == expected ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== URLIFY TESTS ===");

    // básico
    Test("Mr John Smith    ", 13, "Mr%20John%20Smith");

    // sin espacios
    Test("Hola", 4, "Hola");

    // espacios al inicio
    Test(" Hola   ", 5, "%20Hola");

    // espacio al final dentro del true length
    Test("Hola    ", 5, "Hola%20");

    // múltiples espacios
    Test("Ho  la mundo      ", 12, "Ho%20%20la%20mundo");

    // solo espacios
    Test("         ", 3, "%20%20%20");

    // string vacío
    Test("", 0, "");

    // un solo carácter
    Test("a", 1, "a");

    // un solo espacio
    Test("   ", 1, "%20");

    // espacios intermedios
    Test("a b c      ", 5, "a%20b%20c");

    // espacios consecutivos en medio
    Test("a  b      ", 4, "a%20%20b");

    // caso tricky: trueLength corta el string
    Test("abc def ghi      ", 7, "abc%20def");

    // números y símbolos
    Test("1 2 3      ", 5, "1%202%203");
    Test("a! b@ c#      ", 8, "a!%20b@%20c#");
}

RunTests();