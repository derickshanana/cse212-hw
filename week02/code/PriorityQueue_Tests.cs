using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities.
    // Expected Result: Item with highest priority ("High") dequeued first.
    // Defect(s) Found: None.
    public void TestPriorityQueue_1()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 2);
        pq.Enqueue("High", 3);

        string result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: Items dequeued in FIFO order among equals.
    // Defect(s) Found: None.
    public void TestPriorityQueue_2()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 2);
        pq.Enqueue("Second", 2);
        pq.Enqueue("Third", 2);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue mix of priorities and test complex dequeue order.
    // Expected Result: Dequeue order: Max1, Max2, Mid, Low.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Mixed()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Mid", 5);
        pq.Enqueue("Max1", 10);
        pq.Enqueue("Max2", 10);

        Assert.AreEqual("Max1", pq.Dequeue());
        Assert.AreEqual("Max2", pq.Dequeue());
        Assert.AreEqual("Mid", pq.Dequeue());
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to dequeue from empty queue.
    // Expected Result: InvalidOperationException with correct message.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
