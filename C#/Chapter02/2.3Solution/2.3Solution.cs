/*
Delete Middle Node: Implement an algorithm to delete a node in the middle (i.e., any node but 
the first and last node, not necessarily the exact middle) of a singly linked list, given only access to 
that node. 
EXAMPLE 
lnput:the node c from the linked lista->b->c->d->e->f 
Result: nothing is returned, but the new linked list looks like a->b->d->e->f 


We can not use Previous. 
*/

void DeleteNode(LinkedListNode<char> node)
{
	if(node.Next != null && node != null)
	{
		node.Value = node.Next.Value; 
		node.Next = node.Next.Next;   
	}
}
/*This is the solution, but it doesn't work in C#, because the nodes are protected and they are read only*/

/*------------------TEST--------------------*/

LinkedList<char> BuildList(string s)
{
    return new LinkedList<char>(s.ToCharArray());
}

LinkedListNode<char> GetNode(LinkedList<char> list, char value)
{
    return list.Find(value);
}

string ToStringList(LinkedList<char> list)
{
    return string.Join("", list);
}

void Test(string input, char nodeToDelete, string expected)
{
    var list = BuildList(input);
    var node = GetNode(list, nodeToDelete);

    try
    {
        DeleteNode(node);
        var result = ToStringList(list);

        Console.WriteLine(
            $"Input: {input}, delete '{nodeToDelete}' | Result: {result} | Expected: {expected} " +
            (result == expected ? "✅" : "❌")
        );
    }
    catch
    {
        Console.WriteLine(
            $"Input: {input}, delete '{nodeToDelete}' | Exception ❌"
        );
    }
}

void RunTests()
{
    Console.WriteLine("=== DELETE MIDDLE NODE TESTS ===");

    // ejemplo clásico
    Test("abcdef", 'c', "abdef");

    // borrar en medio
    Test("abcdef", 'd', "abcef");

    // lista pequeña
    Test("abc", 'b', "ac");

    // duplicados (solo elimina ese nodo)
    Test("aabbcc", 'b', "aabcc"); // elimina solo uno

    // números
    Test("12345", '3', "1245");

    // edge: borrar nodo cercano al final
    Test("abcd", 'c', "abd");

    // edge: lista mínima válida
    Test("ab", 'a', "ab"); // inválido, no debe cambiar
    Test("ab", 'b', "ab"); // inválido

    // edge: nodo null
    Test("abc", 'x', "abc");

    // edge: último nodo (no permitido)
    Test("abcde", 'e', "abcde");

    // edge: primer nodo (no permitido)
    Test("abcde", 'a', "abcde");
}

RunTests();