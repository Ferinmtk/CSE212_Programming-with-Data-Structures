public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create a new array with a size equal to the given length
        // Step 2: Loop through the array from index 0 to length - 1
        // Step 3: For each position calculate the multiple by multiplying
        //         the number by (index + 1)
        // Step 4: Store the calculated value in the array
        // Step 5: Return the completed array

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Determine the index where the split should happen
        //         This is data.Count minus the amount to rotate
        // Step 2: Use GetRange to copy the last 'amount' elements
        // Step 3: Use GetRange to copy the remaining front elements
        // Step 4: Clear the original list
        // Step 5: Add the last elements first
        // Step 6: Add the front elements after

        int splitIndex = data.Count - amount;

        List<int> endSlice = data.GetRange(splitIndex, amount);
        List<int> frontSlice = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(endSlice);
        data.AddRange(frontSlice);
    }
}
