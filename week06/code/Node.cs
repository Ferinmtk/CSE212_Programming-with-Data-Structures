public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Only allow unique values
        // If value already exists, do nothing
        if (value == Data)
            return;

        if (value < Data)
        {
            // Insert into left subtree
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert into right subtree
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Recursively search the tree

        // Found value
        if (value == Data)
            return true;

        // Search left subtree
        if (value < Data)
        {
            return Left is not null && Left.Contains(value);
        }

        // Search right subtree
        return Right is not null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // Problem 4: Height = 1 + max(left height, right height)

        int leftHeight = Left is null ? 0 : Left.GetHeight();
        int rightHeight = Right is null ? 0 : Right.GetHeight();

        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
