/*
FOLLOW UP 
Suppose the digits are stored in forward order. Repeat the above problem. 
EXAMPLE 
lnput:(6 -> 1 -> 7) + (2 -> 9 -> 5).Thatis,617 + 295. 
Output: 9 -> 1 -> 2. That is, 912. 
*/



LinkedList<int> SumListsFw(LinkedList<int> list1, LinkedList<int> list2)
{
	LinkedList<int> result = new LinkedList<int>(); 

	int n = 0;
	var c1 = list1.Last; 
	var c2 = list2.Last;  
	
	while(c1 != null  || c2 != null || n == 1)
	{

        int sum = n; 
        if(c1 != null)
        {
            sum += c1.Value; 
            c1 = c1.Previous; 
        } 
        if(c2!= null)
        {
            sum += c2.Value;
            c2 = c2.Previous; 
        }
		if(sum >= 10)
		{
            int asig = sum -10;
			result.AddFirst(asig); 
			n = 1; 
		}else
		{
			result.AddFirst(sum); 
			n = 0; 
		}
	}
	return result; 
}

/*------------------TEST FORWARD--------------------*/

void TestForward(int[] a, int[] b, int[] expected)
{
    var l1 = Build(a);
    var l2 = Build(b);

    var result = SumListsFw(l1, l2);

    bool isEqual = result.SequenceEqual(expected);

    Console.WriteLine(
        $"Input: [{string.Join(",", a)}] + [{string.Join(",", b)}] | " +
        $"Result: {ToStr(result)} | Expected: {string.Join("->", expected)} " +
        (isEqual ? "✅" : "❌")
    );
}

void RunForwardTests()
{
    Console.WriteLine("=== SUM LISTS FORWARD TESTS ===");

    // ejemplo del problema
    TestForward(new[]{6,1,7}, new[]{2,9,5}, new[]{9,1,2});

    // diferentes tamaños
    TestForward(new[]{9,9}, new[]{1}, new[]{1,0,0});
    TestForward(new[]{1}, new[]{9,9}, new[]{1,0,0});

    // carry múltiple
    TestForward(new[]{9,9,9}, new[]{9,9,9}, new[]{1,9,9,8});

    // sin carry
    TestForward(new[]{1,2,3}, new[]{4,5,6}, new[]{5,7,9});

    // uno vacío
    TestForward(new int[]{}, new[]{1,2,3}, new[]{1,2,3});
    TestForward(new[]{1,2,3}, new int[]{}, new[]{1,2,3});

    // ceros
    TestForward(new[]{0}, new[]{0}, new[]{0});

    // diferente longitud
    TestForward(new[]{1,0,0}, new[]{9}, new[]{1,0,9});

    // carry al frente
    TestForward(new[]{9,9,9,9}, new[]{1}, new[]{1,0,0,0,0});
}
LinkedList<int> Build(int[] values)
{
    return new LinkedList<int>(values);
}

string ToStr(LinkedList<int> list)
{
    return string.Join("->", list);
}

RunForwardTests();