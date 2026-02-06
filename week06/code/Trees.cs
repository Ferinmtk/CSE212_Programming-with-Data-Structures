public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Insert the middle value of the current range first, then recurse on left and right
    /// halves to keep the tree balanced. Avoids creating sublists by using indices.
    /// </summary>
    /// <param name="sortedNumbers">Input numbers that are already sorted</param>
    /// <param name="first">The first index in the sortedNumbers to consider</param>
    /// <param name="last">The last index in the sortedNumbers to consider</param>
    /// <param name="bst">The BinarySearchTree to insert values into</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: no numbers left in this range
        if (first > last)
            return;

        // Middle index of current range
        int mid = (first + last) / 2;

        // Insert the middle value first so the tree stays balanced
        bst.Insert(sortedNumbers[mid]);

        // Recurse on left half
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recurse on right half
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
