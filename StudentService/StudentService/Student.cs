namespace StudentService;

public class Student
{
    public int StudentId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? ContactNumber { get; set; }
    public string? Department { get; set; }
}