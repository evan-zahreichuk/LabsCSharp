namespace Lab03;

public class Family
{
    private List<Person> FamilyMembers { get; set; }

    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }

    public void AddMember(Person member)
    {
        this.FamilyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        return this.FamilyMembers.MaxBy(fm => fm.Age);
    }
}