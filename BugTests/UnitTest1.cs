namespace BugTests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void CloseAssignTesting()
    {
        var bug = new Bug(Bug.State.Closed);
        bug.Assign();
        Assert.AreEqual(bug.getState(), Bug.State.Assigned);
    }

    [TestMethod]
    public void DeferAssignTesting()
    {
        var bug = new Bug(Bug.State.Defered);
        bug.Assign();
        Assert.AreEqual(bug.getState(), Bug.State.Assigned);
    }

    [TestMethod]
    public void OpenAssignTesting()
    {
        var bug = new Bug(Bug.State.Open);
        bug.Assign();
        Assert.AreEqual(bug.getState(), Bug.State.Assigned);
    }

    [TestMethod]
    public void CreateFixAcceptFixTesting()
    {
        var bug = new Bug(Bug.State.CreatedFixes);
        bug.AcceptFix();
        Assert.AreEqual(bug.getState(), Bug.State.AcceptedFixes);
    }

    [TestMethod]
    public void CreateFixDeclineFixTesting()
    {
        var bug = new Bug(Bug.State.CreatedFixes);
        bug.DeclineFix();
        Assert.AreEqual(bug.getState(), Bug.State.DeclinedFixes);
    }

    [TestMethod]
    public void AssignCloseTesting()
    {
        var bug = new Bug(Bug.State.Assigned);
        bug.Close();
        Assert.AreEqual(bug.getState(), Bug.State.Closed);
    }

    [TestMethod]
    public void AssignDeferTesting()
    {
        var bug = new Bug(Bug.State.Assigned);
        bug.Defer();
        Assert.AreEqual(bug.getState(), Bug.State.Defered);
    }

    [TestMethod]
    public void AcceptFixCloseTesting()
    {
        var bug = new Bug(Bug.State.AcceptedFixes);
        bug.Close();
        Assert.AreEqual(bug.getState(), Bug.State.Closed);
    }

    [TestMethod]
    public void DeclineFixCreateFixTesting()
    {
        var bug = new Bug(Bug.State.DeclinedFixes);
        bug.CreateFix();
        Assert.AreEqual(bug.getState(), Bug.State.CreatedFixes);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void AcceptFixFromClosedTesting()
    {
        var bug = new Bug(Bug.State.Closed);
        bug.AcceptFix();
    }
}