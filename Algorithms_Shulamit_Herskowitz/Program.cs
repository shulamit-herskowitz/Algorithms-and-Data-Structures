using System;

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
 * 3. LocalVal - local variable for updating changing a specific key.
 * 4. ChangesUpdate - local variable for knowing the value of ChangesPVal when updating the local variable
 *    (for knowing which value was updated the last in Get operation
 */
//public class GlobalDictionary<K, V>
//{
//    public  T PublicVal { set; }
//    public int UpdatesPVal { get; set; }
//    private class Element
//    {
//        public V LocalVal { get; set; }
//        public int ChangesUpdate { get; set; }

//        public Element(V localVal, int changesUpdate)
//        {
//            this.LocalVal = localVal;
//            this.ChangesUpdate = UpdatesPVal+1;
//        }
//    }

//    private T LocalValue { get; set;}
//    public T UpdatesPVal { get; set; }
//}


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
 * memory complexity:
 * the data structure o(n):
 * constant amount of variables o(1) 
 * hashTable that for each value in the hashtable-dictionary, we keep permanent amount of variables o(1) * n
 * the data structure itself is o(n) because we have to keep all the keys and values in the hashTable.
 */

#endregion

#endregion

#region Question 3
static int Ex3(int[] arr, int n, int last = int.MaxValue)
{
    if (n == 0)
        return 0;
    int with = arr[n - 1] <= last ? 1 + Ex3(arr, n - 1, arr[n - 1]) : 0;
    int without = Ex3(arr, n - 1, last);
    return Math.Max(with, without);
}

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

public class Egg
{
    [Flags]
    public enum Content { Toy = 1, Sticker = 2, Both = 3 };
    public Content EggContent { get; set; }
}
#endregion
