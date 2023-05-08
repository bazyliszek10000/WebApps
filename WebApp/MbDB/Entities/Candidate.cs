namespace MbDB.Entities;

public class Candidate
{
    public Candidate()
    {
        Voters = new List<Voter>();
    }
    
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public List<Voter>? Voters { get; set; }
}