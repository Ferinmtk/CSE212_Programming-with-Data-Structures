using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Finds all symmetric 2-letter word pairs using a set in O(n) time.
    /// Example: ["am","at","ma","if","fi"] → ["am & ma","if & fi"]
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        // HashSet for fast O(1) lookup
        HashSet<string> seen = new HashSet<string>();

        // List to store results
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            // Fast O(1) reverse for 2-character words
            string reversed = $"{word[1]}{word[0]}";

            // Skip cases like "aa"
            if (word == reversed)
                continue;

            if (seen.Contains(reversed))
                result.Add($"{reversed} & {word}");
            else
                seen.Add(word);
        }

        return result.ToArray();
    }

    /// <summary>
    /// Reads a census file and summarizes the degrees earned.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            // Degree is in the 4th column (index 3)
            string degree = fields[3];

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determines if two words are anagrams using a dictionary.
    /// Ignores spaces and letter case.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Normalize words
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
            return false;

        Dictionary<char, int> counts = new Dictionary<char, int>();

        foreach (char c in word1)
        {
            if (counts.ContainsKey(c))
                counts[c]++;
            else
                counts[c] = 1;
        }

        foreach (char c in word2)
        {
            if (!counts.ContainsKey(c))
                return false;

            counts[c]--;

            if (counts[c] < 0)
                return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        // Not required for full credit
        return [];
    }
}
