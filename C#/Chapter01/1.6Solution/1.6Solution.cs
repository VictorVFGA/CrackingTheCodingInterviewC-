
/*
String Compression: Implement a method to perform basic string compression using the counts 
of repeated characters. For example, the string aabcccccaaa would become a2blc5a3. If the 
"compressed" string would not become smaller than the original string, your method should return 
the original string. You can assume the string has only uppercase and lowercase letters (a - z). 
*/

/*	
	Case Sensitive? 
	AAAaaa -> A3a3 or a6 ? 
	I will do the first scenario. 

	Decalre String Builder
	Declare lastLetter; 
	declare repetitions; 
	for loop in the string 
		check if the letter is the same
			repetitions ++ 
		else 
			append lastLetter + number
			ll = c 
			num  1 
			Check if the sb is longer than the original leng 
*/


string Compress(string text)
{
	StringBuilder sb = new StringBuilder(); 
	char lastLetter = '.'; 
	int repetitions = 0; 

	for(int i = 0; i < text.Length; i++)
	{
        char c = text[i]; 
        if(i == 0)
        {
            lastLetter = c; 
            repetitions = 1;
        }
        else
        {
            if(c != lastLetter)
            {
                sb.Append(lastLetter.ToString() + repetitions.ToString()); 
                if(sb.Length >= text.Length)
                {
                    return text; 
                }
                lastLetter = c; 
                repetitions = 1; 
            }
            else
            {
                repetitions ++; 
            }
        }

	}

    sb.Append(lastLetter.ToString() + repetitions.ToString()); 
    if(sb.Length >= text.Length)
    {
        return text; 
    }

	return sb.ToString(); 
}




/*------------------TEST--------------------*/

void Test(string input, string expected)
{
    string result = Compress(input);

    Console.WriteLine(
        $"Input: \"{input}\" | Result: \"{result}\" | Expected: \"{expected}\" " +
        (result == expected ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== STRING COMPRESSION TESTS ===");

    // ejemplo del problema
    Test("aabcccccaaa", "a2b1c5a3");

    // no comprime (más largo o igual)
    Test("abc", "abc");
    Test("aabb", "aabb"); // a2b2 = mismo tamaño → regresa original

    // un solo carácter
    Test("a", "a");

    // todos iguales
    Test("aaaaa", "a5");

    // mezcla simple
    Test("aab", "aab"); // a2b1 = mismo tamaño → original
    Test("aaab", "aaab");

    // case sensitive
    Test("AAAaaa", "A3a3");
    Test("AaAa", "AaAa"); // no comprime

    // caracteres alternados
    Test("abababab", "abababab"); // no comprime

    // grupos largos
    Test("aaaaaaaaaa", "a10");

    // combinación compleja
    Test("aabbbccccddddd", "a2b3c4d5");

    // edge cases
    Test("", "");
    Test("aaAAaa", "aaAAaa"); // a2A2a2 = mismo tamaño → original

    // tricky
    Test("aabccccaaa", "a2b1c4a3");
    Test("abcddddd", "abcddddd");

    // final corto vs largo
    Test("zzzzzy", "z5y1");
    Test("zzzzz", "z5");

    // otro tricky (crece en vez de reducir)
    Test("abcd", "abcd");
}

RunTests();