namespace Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;
    public class Course
    {
        [Key, JsonIgnore]
        public int Id { get; set; }
        [MinLength(1), MaxLength(58)]
        public string Name  { get; set; } = null!;
        [InverseProperty("Course"), JsonIgnore]
        public Registration Registration  { get; set; } = null!;
  }
}