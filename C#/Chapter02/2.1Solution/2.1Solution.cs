/* Write code to remove duplicates from an unsorted linked list.*/

/*We could do this with a HashSet */
/*
LinkedList<int> RemoveDuplicates(LinkedList<int> list)
{
	HashSet<int> set = new HashSet<int>(); 

	var current = list.First; 

	while(current != null)
	{
		var next = current.Next; 
		int value = current.Value; 
		if(!set.Add(value))
		{
			list.Remove(current); 
		}
		current = next; 
	}

	return list; 
}*/

/*
FOLLOW UP 
How would you solve this problem if a temporary buffer is not allowed? 
Now, my solution*/

LinkedList<int> RemoveDuplicates(LinkedList<int>list)
{
	var current = list.First; 
	while(current != null)
	{
		int currentValue = current.Value; 
		var tempNext = current.Next; 
		while(tempNext != null)
		{	
			var next = tempNext.Next; 
			if(tempNext.Value == currentValue)
			{
				list.Remove(tempNext); 
			}
			tempNext = next; 
		}
		current = current.Next; 
	}
	return list; 
}

/*------------------TEST--------------------*/

void Test(List<int> inputList, List<int> expectedList)
{
    var list = new LinkedList<int>(inputList);

    RemoveDuplicates(list);

    var result = list.ToList();

    bool isEqual = result.SequenceEqual(expectedList);

    Console.WriteLine(
        $"Input: [{string.Join(",", inputList)}] | Result: [{string.Join(",", result)}] | Expected: [{string.Join(",", expectedList)}] " +
        (isEqual ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== REMOVE DUPLICATES LINKED LIST TESTS ===");

    // básico
    Test(new List<int>{1,2,3,2,1}, new List<int>{1,2,3});

    // sin duplicados
    Test(new List<int>{1,2,3,4}, new List<int>{1,2,3,4});

    // todos duplicados
    Test(new List<int>{1,1,1,1}, new List<int>{1});

    // duplicados consecutivos
    Test(new List<int>{1,1,2,2,3,3}, new List<int>{1,2,3});

    // duplicados no consecutivos
    Test(new List<int>{3,1,2,3,4,2,1}, new List<int>{3,1,2,4});

    // un solo elemento
    Test(new List<int>{5}, new List<int>{5});

    // lista vacía
    Test(new List<int>{}, new List<int>{});

    // mezcla compleja
    Test(new List<int>{1,2,3,4,3,2,1,5,6,5}, new List<int>{1,2,3,4,5,6});

    // números negativos
    Test(new List<int>{-1,-2,-1,-3,-2}, new List<int>{-1,-2,-3});

    // ceros
    Test(new List<int>{0,0,0,1,0}, new List<int>{0,1});

    // duplicados al final
    Test(new List<int>{1,2,3,4,4,4}, new List<int>{1,2,3,4});

    // duplicados al inicio
    Test(new List<int>{2,2,2,3,4}, new List<int>{2,3,4});

    // patrón tricky
    Test(new List<int>{1,2,1,2,1,2}, new List<int>{1,2});
}

RunTests();