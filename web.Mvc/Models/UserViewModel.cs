using System.ComponentModel.DataAnnotations;

namespace web.Mvc.Models
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Department { get; set; }
    }
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
    }

}