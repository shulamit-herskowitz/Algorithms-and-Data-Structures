
#region Question 1

#region logical explanation
/*
 * I used Dinamic plan, Every step the code checks if it's better to add the current number
 * to the sum of the previous numbers or to start a new sum with the current number. and besides
 * I kept the max sum of subarray untill this step. It also keeps the indexes for returning the subarray 
 * with maxsimum sumat the end.
 */
#endregion

#region implemention
static int[] Ex1(int[] arr)
{
    int maxWithout = 0, withCurrent;
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
 * The time complexity of the algorithm is O(n) because we go through the array once. 
 * The space complexity is:
 * - local variables: o(1)
 * - subarray for returning: o(k) ( k is the size of the subarray that we return.
 */

#endregion

#endregion

#region Question 2----

#region logical description

/*
 * Each operation in the data structure must run in o(1) time. for implementing Get and Get it's 
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
 *    - else (the global counter is greater) means that the last change was in the global value.
 */


#endregion

#region implemention

/*
 * The data structure will be made of an hashTable (dictionary) that will include objects who are made of:
 * 1. PublicVal - private "global" variable for changing the value in o(1).
 * 2. UpdatesPVal - private "global" variable for counting the number of changes in PublicValue.
 * 3. LocalVal - local variable for changing a specific key.
 * 4. ChangesUpdate - local variable for knowing the value of ChangesPVal when updating the local variable
 *    (for knowing which value was updated the last in Get operation
 */
public class GlobalDictionary<K, V>
{
    private class Element
    {
        public V LocalVal { get; set; }
        public int LastUpdatePVal;
        public static T PublicVal {set; }
    public static int LocalVal { get; set; }
    private T LocalValue { get; set;}
    public T UpdatesPVal { get; set; }
}


#endregion

#endregion

#region Question 3




#endregion

#region Question 4

#endregion

#region Question 5

#endregion