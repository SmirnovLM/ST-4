using Stateless;

public class Bug
{
    public enum State { Open, Assigned, Defered, Closed, CreatedFixes, DeclinedFixes, AcceptedFixes }
    private enum Trigger { Assign, Defer, Close, CreateFix, DeclineFix, AcceptFix }
    private StateMachine<State, Trigger> sm;

    public Bug(State state)
    {
        sm = new StateMachine<State, Trigger>(state);
        sm.Configure(State.Open)
              .Permit(Trigger.Assign, State.Assigned);
        sm.Configure(State.Assigned)
              .Permit(Trigger.Close, State.Closed)
              .Permit(Trigger.Defer, State.Defered)
              .Ignore(Trigger.Assign);
        sm.Configure(State.Closed)
              .Permit(Trigger.Assign, State.Assigned);
        sm.Configure(State.Defered)
              .Permit(Trigger.Assign, State.Assigned);
        sm.Configure(State.CreatedFixes)
            .Permit(Trigger.AcceptFix, State.AcceptedFixes)
            .Permit(Trigger.DeclineFix, State.DeclinedFixes)
            .Ignore(Trigger.CreateFix);
        sm.Configure(State.DeclinedFixes)
            .Permit(Trigger.CreateFix, State.CreatedFixes);
        sm.Configure(State.AcceptedFixes)
            .Permit(Trigger.Close, State.Closed);
    }
    public void Close()
    {
        sm.Fire(Trigger.Close);
        Console.WriteLine("Close");
    }
    public void Assign()
    {
        sm.Fire(Trigger.Assign);
        Console.WriteLine("Assign");
    }
    public void Defer()
    {
        sm.Fire(Trigger.Defer);
        Console.WriteLine("Defer");
    }
    public void CreateFix()
    {
        sm.Fire(Trigger.CreateFix);
        Console.WriteLine("Create Fix");
    }
    public void DeclineFix()
    {
        sm.Fire(Trigger.DeclineFix);
        Console.WriteLine("Decline Fix");
    }
    public void AcceptFix()
    {
        sm.Fire(Trigger.AcceptFix);
        Console.WriteLine("Accept Fix");
    }
    public State getState()
    {
        return sm.State;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var bug = new Bug(Bug.State.Open);
        bug.Assign();
        bug.Close();
        bug.Assign();
        bug.Defer();
        bug.Assign();
        Console.WriteLine(bug.getState());
    }
}