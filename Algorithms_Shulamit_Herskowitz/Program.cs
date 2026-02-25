using Algorithms_Shulamit_Herskowitz;

#region Question 1

#region logical explanation
/*
 * I used Dinamic plan, Every step the code checks if it's better to add the current number
 * to the sum of the previous numbers or to start a new sum with the current number. and besides
 * I kept the max sum of subarray untill this step. It also keeps the indexes for returning the subarray 
 * with maximum sumat the end.
 * (I built the code based on the fact that the input includes positive values)
 */
#endregion

#region implemention

static int[] Ex1(int[] arr)
{
    int maxWithout, withCurrent;
    int start = 0, end = arr.Length - 1, maxS = 0, maxE = arr.Length - 1;
    withCurrent = Math.Max(0, arr[0]);
    maxWithout = withCurrent;
    for (int i = 1; i < arr.Length; i++)
    {
        withCurrent = Math.Max(withCurrent + arr[i], arr[i]);
        if (withCurrent == arr[i])
        {
            start = i;
            end = i;
        }
        else
            end = i;
        if (withCurrent > maxWithout)
        {
            maxWithout = withCurrent;
            maxS = start;
            maxE = end;
        }
    }
    int[] res = new int[maxE - maxS + 1];
    for (int i = maxS; i <= maxE; i++)
        res[i - maxS] = arr[i];
    return res;
}
#endregion

#region complexity analysis
/*
 * Time complexity:
 * going through the array once O(n) 
 * 
 * Space complexity:
 * - local variables: o(1)
 * - subarray for returning: o(k) ( k is the size of the subarray that we return.
 * altogether: o(k) 
 */

#endregion

#endregion

#region Question 2

#region logical description
/*
 * The data structure will be made of an hashTable (dictionary) that will include objects who are made of:
 * 1. PublicVal - private "global" variable for changing the value in o(1).
 * 2. UpdatesPVal - private "global" variable for counting the number of changes in PublicValue.
 * 3. LocalVal - local variable for updating changing a specific key.
 * 4. ChangesUpdate - local variable for knowing the value of ChangesPVal when updating the local variable
 *    (for knowing which value was updated the last in Get operation
 * 
 * Explanation:
 * (Each operation in the data structure must run in o(1) time. for implementing Get and Get it's 
 * enough to use a hashTable and then the runtime is o(1) in average. The challenge was with SetAll
 * that we have to implement in o(1) runtime that in one hand you can do it only with global variable
 * and in the other hand I need an option to ovveride it for each without changing everything. and to 
 * know what was changed the last, the local or the global for each. 
 * The way that I thought about, for coping with is to use:
 * 1. a global variable who will count how many changes were in the global variable.
 * 2. a local variable for each that will save how many changes were in the global variable before 
 *    setting the local variable. 
 *    int Get operation we will check if the global variable for counting is same as the local variable
 *    that saved how much it was before:
 *    - if it's the same: means that the last change was in the local value.
 *    - else (the global counter is greater) means that the last change was in the global value.)
 */


#endregion

#region implemention

// implemented seperately in GlobalDictionary class.

#endregion

#region complexity analysis

/*
 * time complexity:
 * Set(key, value) direct access to the hashTable o(1) in average.
 *                 update the value and the counter for this key o(1).
 *                 altogether o(1) in average.
 *                 
 * Get(key) direct access to the hashTable and return the key of the last who was updated o(1) in average.
 * 
 * SetAll(value) : update PublicVal (the "global" variable) and UpdatesPVal (the counter for it) o(1).
 *
 * space complexity:
 * the data structure o(n):
 * constant amount of variables o(1) 
 * hashTable that for each value in the hashtable-dictionary, we keep permanent amount of variables o(1) * n
 * the data structure itself is o(n) because we have to keep all the keys and values in the hashTable.
 */

#endregion

#endregion

#region Question 3

#region logical description

/*
 * This algorithm is based on scanning last routes for getting the
 * longest route who is non decreasing. (remind a little the algorithms 
 * of bfs in graphs..),
 * every node (value) is initialized in the beginning as a route of one
 * node, then we use nested loops for checking if we can add the
 * current node to the route of the previous nodes (only when they are not bigger)
 * if it's possible we check if it's better than the current route and update
 * it if needed.
 * afterwards, we scan the array for counting to find the longest route and
 * return the difference between the real size and the longest route.
 */

#endregion

#region implemention
static int Ex3(Node<int> head)
{
    int count = 0;
    Node<int> temp = head;
    while (temp != null)
    {
        count++;
        temp = temp.Next;
    }
    int[] arr = new int[count];
    int[] res = new int[count];
    temp = head;
    for (int i = 0; i < count; i++)
    {
        arr[i] = temp.Value;
        temp = temp.Next;
    }
    int max = 0, indMax = 0;
    for (int i = 0; i < res.Length; i++)
    {
        res[i] = 1;
        for (int j = 0; j < i; j++)
        {
            if (arr[j] <= arr[i])
            {
                res[i] = Math.Max(res[i], res[j] + 1);
            }
        }
        if (res[i] > max)
        {
            max = res[i];
            indMax = i;
        }
    }
    return arr.Length - max;
}

#endregion

#region complexity analysis
/*
 * time complexity:
 * going through the linked list for finding the length. o(n)
 * going through the linked list for saving the values in a temporary array O(n)
 * 2 nested loops for finding the longest nondecreasing subsequence o(n^2)
 * altogether: O(n^2) (the main)
 * 
 * space complexity:
 * local variables: o(1)
 * temporary array for the values: o(n) ( n num of nodes in the linked list).
 * altogether: o(n)
 */

#endregion

#endregion

#region Question 4

#region implemention

// This solution based on assumption that the array contains only positive numbers 
static int Ex4(int[] arr, int x)
{
    int start = 0, sum = 0, count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        sum += arr[i];
        if (sum > x)
        {
            sum -= arr[start];
            start++;
        }
        if (sum == x)
            count++;
    }
    return count;
}

#endregion

#region complexity analysis
/*
 * Time complexity:
 * going through the array once O(n)
 * 
 * The space complexity is O(1) because we use only a constant amount of variables.
 */
#endregion

#endregion

#region Question 5

static int MinEggs(Egg[] eggs)
{
    int countToys = 0, countStickers = 0;
    for (int i = 0; i < eggs.Length; i++)
    {
        if (eggs[i].EggContent.HasFlag(Egg.Content.Both))
        {
            countToys++;
            countStickers++;
        }
        else if (eggs[i].EggContent.HasFlag(Egg.Content.Toy))
            countToys++;
        else if (eggs[i].EggContent.HasFlag(Egg.Content.Sticker))
            countStickers++;
    }
    return Math.Max(countToys, countStickers) + 1;
}

#endregion





