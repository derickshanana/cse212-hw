public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // STEP-BY-STEP PLAN:
        // 1. Create a new array of doubles with the given length.
        // 2. Use a loop that runs from i = 0 to i < length.
        // 3. In each iteration, multiply the base number by (i + 1).
        // 4. Store the result in the array at index i.
        // 5. After the loop, return the array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3, 
    /// the list after the function runs should be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.
    /// This modifies the original list directly.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // STEP-BY-STEP PLAN:
        // 1. The rotation "right by n" means we want to move the last 'amount' elements to the front.
        // 2. Get the last 'amount' elements using GetRange.
        // 3. Get the remaining elements (from index 0 to Count - amount).
        // 4. Clear the original list.
        // 5. Add the last 'amount' elements first.
        // 6. Then add the remaining elements.

        int count = data.Count;
        List<int> tail = data.GetRange(count - amount, amount);
        List<int> head = data.GetRange(0, count - amount);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
