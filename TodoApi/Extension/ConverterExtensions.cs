namespace WebApi.Extension
{
    public static class ConverterExtensions
    {
        public static PaymentSystem.Models.Student ToDAL(this WebApi.Models.StudentDTO studentDTO)
        {
            return new PaymentSystem.Models.Student
            {
                Firstname = studentDTO.Firstname,
                Lastname = studentDTO.Lastname,
                Username = studentDTO.Username
            };
        }
         
        public static WebApi.Models.StudentDTO ToModel(this PaymentSystem.Models.Student student)
        {
            return new WebApi.Models.StudentDTO
            {
                StudentId = student.StudentId,
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Username = student.Username
            };
        }

    }
}