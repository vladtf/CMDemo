namespace CMDemo.Models
{
    public interface IPersonModel
    {
        string FirstName { get; set; }
        string FullName { get; }
        string LastName { get; set; }
    }
}