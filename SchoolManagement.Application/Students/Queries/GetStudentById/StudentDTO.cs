namespace SchoolManagement.Application.Students.Queries.GetStudentById;

public record StudentDto(
    int Id, 
    string FirstName, 
    string LastName,
    string Email,
    string PhoneNumber,
    DateTime DateOfBirth,
    bool IsActive);