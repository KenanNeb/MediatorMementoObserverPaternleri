namespace Mediator;

public abstract class AbstractChatroom
{
    public abstract void Register(Participant participant);
    public abstract void Send(
        string from, string to, string message);
}

public class Chatroom : AbstractChatroom
{
    private Dictionary<string, Participant> participants = new Dictionary<string, Participant>();
    public override void Register(Participant participant)
    {
        if (!participants.ContainsValue(participant))
        {
            participants[participant.Name] = participant;
        }
        participant.Chatroom = this;
    }
    public override void Send(string from, string to, string message)
    {
        Participant participant = participants[to];
        if (participant != null)
        {
            participant.Receive(from, message);
        }
    }
}

public class Participant
{
    Chatroom chatroom;
    string name;
    // Constructor
    public Participant(string name)
    {
        this.name = name;
    }
    // participant name alırıq
    public string Name
    {
        get { return name; }
    }
    // chatroom alırıq
    public Chatroom Chatroom
    {
        set { chatroom = value; }
        get { return chatroom; }
    }
    // verilən participanta mesaj göndərir
    public void Send(string to, string message)
    {
        chatroom.Send(name, to, message);
    }
    // verilən participantdan məsaj qəbul edir
    public virtual void Receive(
        string from, string message)
    {
        Console.WriteLine("{0} to {1}: '{2}'",
            from, Name, message);
    }
}

public class Beatle : Participant
{
    // Constructor
    public Beatle(string name)
        : base(name)
    {
    }
    public override void Receive(string from, string message)
    {
        Console.Write("To a Beatle: ");
        base.Receive(from, message);
    }
}

public class NonBeatle : Participant
{
    // Constructor
    public NonBeatle(string name)
        : base(name)
    {
    }
    public override void Receive(string from, string message)
    {
        Console.Write("To a non-Beatle: ");
        base.Receive(from, message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Chatroom yaradırıq
        Chatroom chatroom = new Chatroom();
        // İştirakçılar yaradın və onları qeydiyyatdan keçirin
        Participant Zehra = new Beatle("Zehra");
        Participant Selim = new Beatle("Selim");
        Participant Rehim = new Beatle("Rehim");
        Participant Hemid = new Beatle("Hemid");
        Participant Seyide = new NonBeatle("Seyide");
        chatroom.Register(Zehra);
        chatroom.Register(Selim);
        chatroom.Register(Rehim);
        chatroom.Register(Hemid);
        chatroom.Register(Seyide);
        // Chatting iştirakşılarını göndəririk
        Seyide.Send("Hemid", "Salam Hemid!");
        Selim.Send("Zehra", "Davadan uzaq gez biraz!");
        Rehim.Send("Selim", "bu gun menim bashim yaman agriyir");
        Selim.Send("Rehim", "Yadimdan chixdi corek almaq sonra gedib alacam!");
        Hemid.Send("Seyide", "Harda qalmisan gozum yollarda qaldi");
       
        Console.ReadKey();
    }
}