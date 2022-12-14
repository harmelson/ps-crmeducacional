namespace Api.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations.Schema;
    [PrimaryKey(nameof(IdLead), nameof(IdCourse))]
    public class Registration
    {
        [ForeignKey("IdLead")]
        public int IdLead { get; set; }
        public Lead Lead { get; set; } = null!;
        [ForeignKey("IdCourse")]
        public int IdCourse { get; set; }
        public Course Course { get; set; } = null!;
    }
}