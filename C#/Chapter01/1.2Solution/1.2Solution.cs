//Given two strings, write a method to decide if one is a permutation of the other. 

bool isPermutation (string text1, string text2)
{
    if(text1.Length  != text2.Length )
	{
		return false; 
	}
	var dict1 = new Dictionary<char, int>(); 

	foreach(char c in text1)
	{
		if(dict1.ContainsKey(c))
		{
			dict1[c] ++; 
		}else
		{
			dict1[c] = 1; 
		}
	}

	foreach(char c in text2)
	{
		if(dict1.ContainsKey(c))
		{
			dict1[c] --;
            if(dict1[c] < 0)
            {
                return false; 
            } 
		}else
		{
			return false; 
		}
	}
    return true; 
}


/*------------------TEST--------------------*/

void Test(string s, string t, bool expected)
{
    bool result = isPermutation(s, t);

    Console.WriteLine(
        $"Input: (\"{s}\", \"{t}\") | Result: {result} | Expected: {expected} " +
        (result == expected ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== IS PERMUTATION TESTS ===");

    // básicos
    Test("abc", "bca", true);
    Test("abc", "abc", true);
    Test("abc", "abcd", false);
    Test("abc", "abx", false);

    // repetidos (MUY importante)
    Test("aabbcc", "abcabc", true);
    Test("aabbcc", "aabbc", false);
    Test("aabb", "abbb", false);

    // strings vacíos
    Test("", "", true);
    Test("", "a", false);

    // case sensitive
    Test("abc", "ABC", false);
    Test("aBc", "Cba", false);

    // espacios
    Test("a b c", "c b a", true);
    Test("a b", "ab", false);
    Test("a  b", "b a ", true);

    // símbolos
    Test("a!b@c", "c@b!a", true);
    Test("a!b", "a@b", false);

    // números
    Test("123", "321", true);
    Test("112233", "332211", true);
    Test("123", "122", false);

    // palabras reales
    Test("listen", "silent", true);
    Test("triangle", "integral", true);
    Test("apple", "papel", true);
    Test("rat", "car", false);
}

RunTests();