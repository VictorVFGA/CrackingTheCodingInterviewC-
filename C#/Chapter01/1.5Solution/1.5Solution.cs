/*
One Away: There are three types of edits that can be performed on strings: insert a character, 
remove a character, or replace a character. Given two strings, write a function to check if they are 
one edit (or zero edits) away. 
EXAMPLE 
pale, ple -> true 
pales, pale -> true 
pale, bale -> true 
pale, bake -> false

There are two scenarios, the same Length or length +/- 1
If its same Length its just a replace.... For loop and check that there is just a different char or zero. 

if its +/-1 in Length, We are going to check the longest word... if we find a dif char, turn on a flag 
With the case that the different is in the last element of the longest string, we return true without checking the short string
pales, pale -> true 

*/


bool OneAway(string txt1, string txt2)
{
	if(txt1.Length == txt2.Length)
	{
		//First scenario
		bool hasChanged = false; 
		for(int i = 0; i < txt1.Length; i++)
		{
			if(txt1[i] != txt2[i])
			{
				if(hasChanged)
				{
					return false; 
				}
				else
				{
					hasChanged = true; 
				}
			}
		}
		return true; 

	}else if(txt1.Length - txt2.Length == -1 || txt1.Length - txt2.Length == 1)
	{
		//second
 
		string longest; 
		string shortest; 
		if (txt1.Length - txt2.Length == -1)
		{
			longest = txt2;
			shortest = txt1;  
		}
		else
		{
			longest = txt1; 
			shortest = txt2; 
		}

		bool detection = false;
		int gap = 0; 
		for(int i = 0; i < longest.Length; i++){
			if(shortest.Length == i && !detection)
			{
				return true; 
			}
			if(longest[i] != shortest[i-gap])
			{
				if(detection)
				{
					return false; 
				}
				else
				{
					detection = true; 
					gap = 1; 
				}
			}
		}
		return true; 
	}
	else
	{
		return false; 
	}

}


/*------------------TEST--------------------*/

void Test(string s1, string s2, bool expected)
{
    bool result = OneAway(s1, s2);

    Console.WriteLine(
        $"Input: (\"{s1}\", \"{s2}\") | Result: {result} | Expected: {expected} " +
        (result == expected ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== ONE AWAY TESTS ===");

    // ejemplos del problema
    Test("pale", "ple", true);     // remove
    Test("pales", "pale", true);   // insert
    Test("pale", "bale", true);    // replace
    Test("pale", "bake", false);   // 2 edits

    // iguales (0 edits)
    Test("test", "test", true);
    Test("", "", true);

    // un solo carácter
    Test("a", "", true);
    Test("", "a", true);
    Test("a", "b", true);

    // longitud diferente > 1
    Test("abc", "a", false);
    Test("a", "abc", false);

    // inserciones
    Test("abc", "abxc", true);
    Test("abc", "xabc", true);
    Test("abc", "abcx", true);

    // removals
    Test("abxc", "abc", true);
    Test("xabc", "abc", true);
    Test("abcx", "abc", true);

    // reemplazos
    Test("abc", "axc", true);
    Test("abc", "xbc", true);
    Test("abc", "abx", true);

    // más de un cambio
    Test("abc", "axy", false);
    Test("abcdef", "abqdefg", false);

    // caracteres repetidos
    Test("aab", "ab", true);
    Test("aab", "abb", true);
    Test("aaa", "aa", true);
    Test("aaa", "a", false);

    // espacios
    Test("a c", "ac", true);
    Test("abc", "a c", true);
    Test("a c", "a d", true);
    Test("a c", "b d", false);

    // case sensitive
    Test("abc", "Abc", true);
    Test("abc", "ABC", false);

    // tricky (puntero se desincroniza)
    Test("pale", "paale", true);
    Test("pale", "paless", false);
    Test("pale", "plae", false); // swap NO es 1 edit

    // números y símbolos
    Test("123", "12", true);
    Test("123", "1a3", true);
    Test("123", "1a4", false);

    // casos edge raros
    Test(" ", "", true);
    Test(" ", "  ", true);
    Test("  ", "    ", false);
}

RunTests();