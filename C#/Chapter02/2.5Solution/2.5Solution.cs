/*
Sum Lists: You have two numbers represented by a linked list, where each node contains a single 
digit. The digits are stored in reverse order, such that the 1 's digit is at the head of the list. Write a 
function that adds the two numbers and returns the sum as a linked list. 
EXAMPLE 
Input: (7-> 1 -> 6) + (5 -> 9 -> 2).Thatis,617 + 295. 
Output: 2 -> 1 -> 9. That is, 912. 
FOLLOW UP 
Suppose the digits are stored in forward order. Repeat the above problem. 
EXAMPLE 
lnput:(6 -> 1 -> 7) + (2 -> 9 -> 5).Thatis,617 + 295. 
Output: 9 -> 1 -> 2. That is, 912. 

*/

LinkedList<int> SumLists(LinkedList<int> list1, LinkedList<int> list2)
{
	LinkedList<int> result = new LinkedList<int>(); 

	int n = 0;
	var c1 = list1.First; 
	var c2 = list2.First;  
	
	while(c1 != null  || c2 != null || n == 1)
	{

        int sum = n; 
        if(c1 != null)
        {
            sum += c1.Value; 
            c1 = c1.Next; 
        } 
        if(c2!= null)
        {
            sum += c2.Value;
            c2 = c2.Next; 
        }
		if(sum >= 10)
		{
            int asig = sum -10;
			result.AddLast(asig); 
			n = 1; 
		}else
		{
			result.AddLast(sum); 
			n = 0; 
		}
	}
	return result; 
}

/*------------------TEST REVERSE--------------------*/


LinkedList<int> Build(int[] values)
{
    return new LinkedList<int>(values);
}

string ToStr(LinkedList<int> list)
{
    return string.Join("->", list);
}

void TestReverse(int[] a, int[] b, int[] expected)
{
    var l1 = Build(a);
    var l2 = Build(b);

    var result = SumLists(l1, l2);

    bool isEqual = result.SequenceEqual(expected);

    Console.WriteLine(
        $"Input: [{string.Join(",", a)}] + [{string.Join(",", b)}] | " +
        $"Result: {ToStr(result)} | Expected: {string.Join("->", expected)} " +
        (isEqual ? "✅" : "❌")
    );
}

void RunReverseTests()
{
    Console.WriteLine("=== SUM LISTS REVERSE TESTS ===");

    // ejemplo del problema
    TestReverse(new[]{7,1,6}, new[]{5,9,2}, new[]{2,1,9});

    // diferentes tamaños
    TestReverse(new[]{9,9}, new[]{1}, new[]{0,0,1});
    TestReverse(new[]{1}, new[]{9,9}, new[]{0,0,1});

    // carry múltiple
    TestReverse(new[]{9,9,9}, new[]{9,9,9}, new[]{8,9,9,1});

    // sin carry
    TestReverse(new[]{1,2,3}, new[]{4,5,6}, new[]{5,7,9});

    // uno vacío
    TestReverse(new int[]{}, new[]{1,2,3}, new[]{1,2,3});
    TestReverse(new[]{1,2,3}, new int[]{}, new[]{1,2,3});

    // ceros
    TestReverse(new[]{0}, new[]{0}, new[]{0});

    // diferente longitud
    TestReverse(new[]{2,4}, new[]{5}, new[]{7,4});

    // muchos ceros con carry final
    TestReverse(new[]{0,0,1}, new[]{0,0,9}, new[]{0,0,0,1});
}

RunReverseTests();