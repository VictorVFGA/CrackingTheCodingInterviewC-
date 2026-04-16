/*
String Rotation:Assume you have a method isSubstring which checks if one word is a substring 
of another. Given two strings, sl and s2, write code to check if s2 is a rotation of sl using only one 
call to isSubstring (e.g., "waterbottle" is a rotation of"erbottlewat").
*/

/*La solucion que me imaginé sin usar el subString*/
bool IsRotation(string s1, string s2)
{
	if(s1.Length != s2.Length)
	{
		return false; 
	}
    if (s1.Length == 0)
    {
        return true; 
    }
	List<int> indexes = new List<int>(); 
	for(int i = 0; i<s2.Length; i++)
	{
		char c = s2[i];
		if(c == s1[0])
		{
			indexes.Add(i); 
		}
	}

	foreach(int initial in indexes)
	{
		string word = s2.Substring(initial) + s2.Substring(0, initial); 
		if(word== s1)
		{
			return true; 
		}

	}
	return false; 
}

/*Usando isSubstring*/
bool IsRotationSub(string s1, string s2)
{
    if(s1.Length != s2.Length)
	{
		return false; 
	}
    return IsSubstring(s2+s2, s1); 
}

/* Implementado para hacer tests*/
bool IsSubstring(string text, string pattern)
{
    if (pattern.Length == 0)
        return true;

    if (pattern.Length > text.Length)
        return false;

    for (int i = 0; i <= text.Length - pattern.Length; i++)
    {
        int j = 0;

        while (j < pattern.Length && text[i + j] == pattern[j])
        {
            j++;
        }

        if (j == pattern.Length)
            return true;
    }

    return false;
}

/*------------------TEST--------------------*/

void Test(string s1, string s2, bool expected)
{
    //bool result = IsRotation(s1, s2);
    bool result = IsRotationSub(s1, s2);
    Console.WriteLine(
        $"s1: \"{s1}\" | s2: \"{s2}\" | Result: {result} | Expected: {expected} " +
        (result == expected ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== STRING ROTATION TESTS ===");

    // ejemplo clásico
    Test("waterbottle", "erbottlewat", true);

    // rotaciones válidas
    Test("abcdef", "defabc", true);
    Test("abcdef", "cdefab", true);
    Test("abcdef", "fabcde", true);

    // misma string
    Test("abc", "abc", true);

    // longitud distinta
    Test("abc", "ab", false);
    Test("abc", "abcd", false);

    // no es rotación
    Test("abcdef", "abcfed", false);
    Test("abcdef", "acbdef", false);

    // caracteres repetidos (tricky)
    Test("aaaa", "aaaa", true);
    Test("aaab", "abaa", true);
    Test("aaab", "aaba", true);
    Test("aaab", "baaa", true);
    Test("aaab", "abaa", true);
    Test("aaab", "bbaa", false);

    // edge cases
    Test("", "", true);
    Test("a", "a", true);
    Test("a", "b", false);

    // espacios y símbolos
    Test("a b c", "c a b", false);
    Test("!@#$", "#$!@", true);

    // casi rotación pero no
    Test("waterbottle", "erbottlewta", false);

    // rotación completa
    Test("rotation", "rotation", true);

    // casos tricky
    Test("abab", "baba", true);
    Test("abab", "abba", false);

    // otro tricky
    Test("abcabc", "bcabca", true);
    Test("abcabc", "cababc", false);
}

RunTests();