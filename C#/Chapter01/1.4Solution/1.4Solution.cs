/*

Palindrome Permutation: Given a string, write a function to check if it is a permutation of a palin
drome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation 
is a rearrangement of letters. The palindrome does not need to be limited to just dictionary words. 
EXAMPLE 
Input: 
Output: 
Tact Coa 
True (permutations: "taco cat", "atco eta", etc.) 
*/

/*
	Spaces are not important 
	Palindrome characteristics
	Every letter must be in 2x
	Possible letter with 1 appearence 
	Examples
	barrab  
	barab
	bebtatbeb
*/



bool IsPalindrome(string txt)
{
	Dictionary<char, int> dict = new Dictionary<char,int>(); 

	foreach(char ch in txt)
	{
       char c = Char.ToUpper(ch); 
		if(c != ' ')
		{
			if(dict.ContainsKey(c))
			{
				dict[c] ++; 
			}else
			{
				dict[c] = 1; 
			}
		}
	}
	bool hasImpair = false; 
	foreach(var kvp in dict)
	{
		if(kvp.Value % 2 == 1)
		{
			if(hasImpair)
			{
				return false; 
			}else
			{
				hasImpair = true; 
			}
		}
	}
	return true; 
}





/*------------------TEST--------------------*/

void Test(string input, bool expected)
{
    bool result = IsPalindrome(input);

    Console.WriteLine(
        $"Input: \"{input}\" | Result: {result} | Expected: {expected} " +
        (result == expected ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== PALINDROME PERMUTATION TESTS ===");

    // básico del problema
    Test("Tact Coa", true); // taco cat

    // palíndromos directos
    Test("racecar", true);
    Test("abba", true);
    Test("a", true);

    // no palíndromo
    Test("hello", false);
    Test("abc", false);

    // con espacios
    Test("taco cat", true);
    Test("a man a plan a canal panama", true);
    Test("random words", false);

    // mayúsculas / minúsculas
    Test("TactCoa", true);
    Test("Aa", true); // depende si ignoras case

    // caracteres repetidos
    Test("aabbcc", true);
    Test("aabbc", true);
    Test("aabbcd", false);

    // edge cases
    Test("", true);
    Test(" ", true);
    Test("  ", true);

    // con símbolos
    Test("a!a", true);
    Test("a!b", false);

    // números
    Test("1221", true);
    Test("1231", false);

    // casos tricky
    Test("aaabbbb", true);   // solo uno impar permitido
    Test("aaabbb", false);   // más de uno impar
    Test("abcabcad", false);
    Test("abcabca", true);
}

RunTests();