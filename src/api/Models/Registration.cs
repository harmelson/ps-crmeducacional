namespace Api.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;
    [PrimaryKey(nameof(IdLead), nameof(IdCourse))]
    public class Registration
    {
        [ForeignKey("IdLead")]
        public int IdLead { get; set; }
        [JsonIgnore]
        public Lead Lead { get; set; } = null!;
        [ForeignKey("IdCourse")]
        public int IdCourse { get; set; }
        [JsonIgnore]
        public Course Course { get; set; } = null!;
    }

    public class RegistrationDTO
    {
        public int IdLead { get; set; }
        public int IdCourse { get; set; }
    }
}