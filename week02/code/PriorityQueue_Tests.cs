using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Add multiple items with different priorities to the queue.
    // Expected Result:
    // The item with the highest priority value is removed first.
    // Defect(s) Found:
    // Initial implementation did not always select the highest priority
    // item correctly and did not remove the item from the queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("medium", 3);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario:
    // Add multiple items with the same highest priority.
    // Expected Result:
    // The item that was enqueued first should be dequeued first (FIFO).
    // Defect(s) Found:
    // Initial implementation violated FIFO behavior when priorities
    // were equal by removing the most recently added item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("first", 4);
        priorityQueue.Enqueue("second", 4);
        priorityQueue.Enqueue("third", 2);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("first", result);
    }

    // Add more test cases as needed below.
}
