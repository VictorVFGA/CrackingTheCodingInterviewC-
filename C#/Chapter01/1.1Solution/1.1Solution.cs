//Is Unique : implement an algorithm to determine if a string has all unique characters 

bool isUnique(string text){
    HashSet<char> chars = new HashSet<char>();
    
    foreach(char c in text)
    {
        if (!chars.Add(c))
        {
            return false; 
        }
    }
    return true; 
} 

/*-------------------TEST-------------------------*/

void RunTests()
{
    Console.WriteLine("=== IS UNIQUE TESTS ===");

    Test("asdfgh", true);      // todos únicos
    Test("hello", false);      // repetidos (l)
    Test("abcABC", true);      // case-sensitive
    Test("aabbcc", false);     // todos repetidos
    Test("", true);            // vacío
    Test("a", true);           // un solo char
    Test("Aa", true);          // distingue mayúsculas
    Test("112233", false);     // números repetidos
    Test("123456", true);      // números únicos
    Test("!@#$%", true);       // símbolos únicos
    Test("!@#@!", false);      // símbolos repetidos
    Test("a b c", false);       // incluye espacios
    Test("a b c a", false);    // espacio + repetido
}

void Test(string input, bool expected)
{
    bool result = isUnique(input);

    Console.WriteLine(
        $"Input: \"{input}\" | Result: {result} | Expected: {expected} " +
        (result == expected ? "✅" : "❌")
    );
}


RunTests();
