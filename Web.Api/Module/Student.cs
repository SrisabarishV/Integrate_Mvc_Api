using System.ComponentModel.DataAnnotations;

namespace Web.Api.Module
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Department { get; set; }
      
    }
}
