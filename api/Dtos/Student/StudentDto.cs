namespace api.Dtos.Student
{
  /// <summary>
  /// Data Transfer Object for sending student data to the client
  /// </summary>
  public class StudentDto
  {
    public int Id { get; set; }        // Unique identifier for the student
    public string Name { get; set; }   // Student's name
    public string Email { get; set; }  // Student's email address
    public string Phone { get; set; }  // Student's phone number
  }
}
