namespace Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;
    public class Course
    {
        [Key, JsonIgnore]
        public int Id { get; set; }
        [MinLength(1, ErrorMessage = "O campo Nome deve ter no mínimo 1 caractere"), MaxLength(58, ErrorMessage = "O campo Nome deve ter no máximo 58 caracteres")]
        public string Name  { get; set; } = null!;
        [InverseProperty("Course"), JsonIgnore]
        public ICollection<Registration>? Registration  { get; set; } = null!;
    }

    public class CourseDTO : Course
    {
        public int Id  { get; set; }
    }
}