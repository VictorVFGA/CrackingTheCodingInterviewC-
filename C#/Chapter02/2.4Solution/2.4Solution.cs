/*
Partition: Write code to partition a linked list around a value x, such that all nodes less than x come 
before all nodes greater than or equal to x. If xis contained within the list, the values of x only need 
to be after the elements less than x (see below). The partition element x can appear anywhere in the 
"right partition"; it does not need to appear between the left and right partitions. 
EXAMPLE 
Input: 
Output: 
3 -> 5 -> 8 -> 5 -> 10 -> 2 -> 1 [partition= 5] 
3 -> 1 -> 2 -> 10 -> 5 -> 5 -> 8 


Result : 
[1 2 3 5 8 5 10]

*/

LinkedList<int> Partition(LinkedList<int> list, int partition)
{
	LinkedList<int> result = new LinkedList<int>(); 

	foreach(var node in list)
	{
		if(node < partition)
		{
			result.AddFirst(node); 
		}else 
		{
			result.AddLast(node); 
		}
	}
	return result; 
}
/*------------------TEST--------------------*/

void Test(List<int> inputList, int x)
{
    var list = new LinkedList<int>(inputList);

    var resultList = Partition(list, x);
    var result = resultList.ToList();

    bool isValid = ValidatePartition(result, x) &&
                   result.Count == inputList.Count; // no se pierdan elementos

    Console.WriteLine(
        $"Input: [{string.Join(",", inputList)}], x={x} | Result: [{string.Join(",", result)}] " +
        (isValid ? "✅ VALID" : "❌ INVALID")
    );
}

// valida la regla del problema
bool ValidatePartition(List<int> list, int x)
{
    bool seenGreaterOrEqual = false;

    foreach (var val in list)
    {
        if (val >= x)
        {
            seenGreaterOrEqual = true;
        }
        else if (seenGreaterOrEqual)
        {
            return false; // hay un menor después de un mayor
        }
    }

    return true;
}

void RunTests()
{
    Console.WriteLine("=== PARTITION LINKED LIST TESTS ===");

    // ejemplo del problema
    Test(new List<int>{3,5,8,5,10,2,1}, 5);

    // todos menores
    Test(new List<int>{1,2,3}, 5);

    // todos mayores
    Test(new List<int>{6,7,8}, 5);

    // mezcla simple
    Test(new List<int>{1,4,3,2,5,2}, 3);

    // duplicados de x
    Test(new List<int>{5,1,5,2,5,3}, 5);

    // negativos
    Test(new List<int>{-1,5,3,-2,4}, 3);

    // un solo elemento
    Test(new List<int>{5}, 5);

    // lista vacía
    Test(new List<int>{}, 5);

    // x no está en la lista
    Test(new List<int>{1,2,3,6,7}, 5);

    // todos iguales a x
    Test(new List<int>{5,5,5,5}, 5);

    // orden mezclado
    Test(new List<int>{9,1,8,2,7,3}, 5);

    // ya particionado
    Test(new List<int>{1,2,3,5,6,7}, 5);

    // completamente invertido
    Test(new List<int>{7,6,5,4,3,2,1}, 5);

    // muchos duplicados
    Test(new List<int>{2,2,2,3,3,1,1,5,5}, 3);

    // caso tricky
    Test(new List<int>{5,4,3,2,1}, 3);
}

RunTests();