using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it. If n <= 0, return 0. No loops.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case: non positive n contributes nothing
        if (n <= 0)
            return 0;

        // Recursive case: n^2 plus the sum up to n-1
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length 'size' from 'letters'
    /// into the results list. Letters are unique and size is valid.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: built a permutation of the required length
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each remaining character once
        for (int i = 0; i < letters.Length; i++)
        {
            char chosen = letters[i];

            // Remove chosen character so it cannot be reused in this word
            string remaining = letters.Remove(i, 1);

            // Continue building the permutation
            PermutationsChoose(results, remaining, size, word + chosen);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb s stairs using 1 2 or 3 steps with memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memo storage on first call
        remember ??= new Dictionary<int, decimal>();

        // Memo hit: return cached value
        if (remember.TryGetValue(s, out var cached))
            return cached;

        // Base cases for this recurrence
        if (s < 0) return 0;   // overshot
        if (s == 0) return 1;  // one valid way: no more steps needed

        // Recursive sum of the three possible last moves
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store result before returning
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Using recursion, expand a binary pattern containing '*' wildcards
    /// into all possible binary strings, inserting them into results.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // Find first wildcard
        int starIndex = pattern.IndexOf('*');

        // Base case: no wildcard left, pattern is a concrete binary string
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Split around the wildcard and branch with 0 and 1
        string left = pattern[..starIndex];
        string right = pattern[(starIndex + 1)..];

        WildcardBinary(left + "0" + right, results);
        WildcardBinary(left + "1" + right, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize current path list on first call
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // Add current position so IsValidMove can detect revisits
        currPath.Add((x, y));

        // If at the end, record the full path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Backtrack: remove current square before returning
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Try Right
        if (maze.IsValidMove(currPath, x + 1, y))
            SolveMaze(results, maze, x + 1, y, currPath);

        // Try Left
        if (maze.IsValidMove(currPath, x - 1, y))
            SolveMaze(results, maze, x - 1, y, currPath);

        // Try Down
        if (maze.IsValidMove(currPath, x, y + 1))
            SolveMaze(results, maze, x, y + 1, currPath);

        // Try Up
        if (maze.IsValidMove(currPath, x, y - 1))
            SolveMaze(results, maze, x, y - 1, currPath);

        // Backtrack: remove current position before returning to caller
        currPath.RemoveAt(currPath.Count - 1);
    }
}
