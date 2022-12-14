namespace Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;
    public class Lead
    {
        [Key, JsonIgnore]
        public int Id { get; set; }
        [StringLength(11)]
        public string CPF { get; set; } = null!;
        [MinLength(1), MaxLength(58)]
        public string Name  { get; set; } = null!;
        [InverseProperty("Lead"), JsonIgnore]
        public ICollection<Registration>? Registration  { get; set; } = null!;
  }

  public class LeadDTO: Lead 
  {
    public new int Id { get; set; }
  }
}