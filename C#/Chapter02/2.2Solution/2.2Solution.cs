/*
Return Kth to Last: Implement an algorithm to find the kth to last element of a singly linked list. 
*/

/*It is a singly linked list, so we can nos use Previous*/

/*
[ 5 8 9 6 7 4 1 2] , 5 
[ 8 7 6 5 4 3 2 1] KTH to the end 
 => K = 5 
 => Count = 8
*/
/*
int? KthToLast(LinkedList<int> list, int k)
{
	int count = list.Count; 

	if(k > count)
	{
		return null; 
	}
	var current = list.First; 
	while(k != count)
	{
		current = current.Next; 
		count --; 
	}

	return current.Value; 
			
}*/
/*But maybe we need to do it without using Count, so...
[ 5 8 9 6 7 4 1 2] , 5 
[ 5 8 9 6 7 4 1 2] , 5 */
int? KthToLast(LinkedList<int> list, int k)
{
	var nodeLast = list.First; 
    var nodeK = list.First; 

    for(int i = 0; i< k; i++)
    {
        if(nodeLast == null)
        {
            return null; 
        }
        nodeLast = nodeLast.Next; 
        
    }

    while (nodeLast != null)
    {
        nodeLast = nodeLast.Next; 
        nodeK = nodeK.Next; 
    }
    return nodeK.Value; 
			
}

/*------------------TEST--------------------*/

void Test(List<int> inputList, int k, int? expected)
{
    var list = new LinkedList<int>(inputList);

    int? result = null;

    try
    {
        result = KthToLast(list, k);
    }
    catch
    {
        result = null; // para casos inválidos
    }

    bool isEqual = result == expected;

    Console.WriteLine(
        $"Input: [{string.Join(",", inputList)}], k={k} | Result: {result} | Expected: {expected} " +
        (isEqual ? "✅" : "❌")
    );
}

void RunTests()
{
    Console.WriteLine("=== KTH TO LAST TESTS ===");

    // básico
    Test(new List<int>{1,2,3,4,5}, 1, 5);
    Test(new List<int>{1,2,3,4,5}, 2, 4);
    Test(new List<int>{1,2,3,4,5}, 3, 3);
    Test(new List<int>{1,2,3,4,5}, 5, 1);

    // k igual al tamaño
    Test(new List<int>{10,20,30}, 3, 10);

    // k mayor al tamaño (inválido)
    Test(new List<int>{1,2,3}, 4, null);

    // k = 0 (depende de tu definición, aquí lo tratamos inválido)
    Test(new List<int>{1,2,3}, 0, null);

    // un solo elemento
    Test(new List<int>{42}, 1, 42);
    Test(new List<int>{42}, 2, null);

    // lista vacía
    Test(new List<int>{}, 1, null);

    // números negativos
    Test(new List<int>{-1,-2,-3,-4}, 1, -4);
    Test(new List<int>{-1,-2,-3,-4}, 4, -1);

    // duplicados
    Test(new List<int>{1,2,3,2,1}, 1, 1);
    Test(new List<int>{1,2,3,2,1}, 3, 3);

    // casos tricky
    Test(new List<int>{1,2}, 1, 2);
    Test(new List<int>{1,2}, 2, 1);

    // más grande
    Test(new List<int>{1,2,3,4,5,6,7,8,9,10}, 5, 6);
}

RunTests();