namespace BugTests;

[TestClass]
public class UnitTest1
{
    [TestClass]
    public class BugTests
    {
        [TestMethod]
        public void TestInitialState()
        {
            var bug = new Bug(Bug.State.Open);
            Assert.AreEqual(Bug.State.Open, bug.getState());
        }

        [TestMethod]
        public void TestAssignFromOpen()
        {
            var bug = new Bug(Bug.State.Open);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void TestCloseFromAssigned()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Close();
            Assert.AreEqual(Bug.State.Closed, bug.getState());
        }

        [TestMethod]
        public void TestDeferFromAssigned()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Defer();
            Assert.AreEqual(Bug.State.Deferred, bug.getState());
        }

        [TestMethod]
        public void TestReopenFromClosed()
        {
            var bug = new Bug(Bug.State.Closed);
            bug.Reopen();
            Assert.AreEqual(Bug.State.Reopened, bug.getState());
        }

        [TestMethod]
        public void TestAssignFromDeferred()
        {
            var bug = new Bug(Bug.State.Deferred);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void TestAssignFromReopened()
        {
            var bug = new Bug(Bug.State.Reopened);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void TestVerifyFromReopened()
        {
            var bug = new Bug(Bug.State.Reopened);
            bug.Verify();
            Assert.AreEqual(Bug.State.Verified, bug.getState());
        }

        [TestMethod]
        public void TestReopenFromVerified()
        {
            var bug = new Bug(Bug.State.Verified);
            bug.Reopen();
            Assert.AreEqual(Bug.State.Reopened, bug.getState());
        }

        [TestMethod]
        public void TestAssignIgnoreWhenAlreadyAssigned()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Assign();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }

        [TestMethod]
        public void TestVerifyFromAssignedShouldFail()
        {
            var bug = new Bug(Bug.State.Assigned);
            bug.Verify();
            Assert.AreEqual(Bug.State.Assigned, bug.getState());
        }
    }
}