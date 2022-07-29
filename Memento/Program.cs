namespace Memento;

public class SalesProspect
{
    string name;
    string phone;
    double budget;
    // Gets or sets name
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
            Console.WriteLine("Name:   " + name);
        }
    }
    // Gets or sets phone
    public string Phone
    {
        get { return phone; }
        set
        {
            phone = value;
            Console.WriteLine("Phone:  " + phone);
        }
    }
    // Gets or sets budget
    public double Budget
    {
        get { return budget; }
        set
        {
            budget = value;
            Console.WriteLine("Budget: " + budget);
        }
    }
    // Stores memento
    public Memento SaveMemento()
    {
        Console.WriteLine("\nSaving state --\n");
        return new Memento(name, phone, budget);
    }
    // Restores memento
    public void RestoreMemento(Memento memento)
    {
        Console.WriteLine("\nRestoring state --\n");
        Name = memento.Name;
        Phone = memento.Phone;
        Budget = memento.Budget;
    }
}

public class Memento
{
    string name;
    string phone;
    double budget;
    // Constructor
    public Memento(string name, string phone, double budget)
    {
        this.name = name;
        this.phone = phone;
        this.budget = budget;
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public double Budget
    {
        get { return budget; }
        set { budget = value; }
    }
}

public class ProspectMemory
{
    Memento memento;
    public Memento Memento
    {
        set { memento = value; }
        get { return memento; }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SalesProspect s = new SalesProspect();
        s.Name = "Noel van Helsing";
        s.Phone = "(099) 256-09-90";
        s.Budget = 25000.0;
        // Store internal state
        ProspectMemory m = new ProspectMemory();
        m.Memento = s.SaveMemento();
        // Continue changing originator
        s.Name = "Zenfira Tagiyeva";
        s.Phone = "(051) 209-71-11";
        s.Budget = 1000000.0;
        // Restore saved state
        s.RestoreMemento(m.Memento);
        // Wait for user
        Console.ReadKey();
    }
}