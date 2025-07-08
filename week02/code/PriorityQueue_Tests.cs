using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 3 items with different priorities.
    // Expected Result: Dequeue returns item with highest priority.
    // Defect(s) Found: Logic error if priority comparison or loop is incorrect.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 3);
        pq.Enqueue("High", 5);

        var result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Add 2 items with the same highest priority.
    // Expected Result: The one added first should be returned (FIFO).
    // Defect(s) Found: May return the later item incorrectly.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 4);
        pq.Enqueue("Second", 4);

        var result = pq.Dequeue();
        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException with correct message.
    // Defect(s) Found: Wrong message or no exception.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("Queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Add multiple items and dequeue all to ensure order is preserved after multiple operations.
    // Expected Result: Highest priority first, FIFO on tie.
    // Defect(s) Found: Priority logic or order can fail if not implemented correctly.
    public void TestPriorityQueue_MultipleDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 4);
        pq.Enqueue("C", 4); // same priority as B
        pq.Enqueue("D", 1);

        Assert.AreEqual("B", pq.Dequeue()); // First of the two with priority 4
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
    }
}