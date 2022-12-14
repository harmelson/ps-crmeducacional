namespace Api.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text.Json.Serialization;
    public class Lead
    {
        [Key, JsonIgnore]
        public int Id { get; set; }
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O campo CPF deve estar no formato 123.456.789-10")]
        public string CPF { get; set; } = null!;
        [MinLength(1, ErrorMessage = "O campo Nome deve ter no mínimo 1 caractere"), MaxLength(58, ErrorMessage = "O campo Nome deve ter no máximo 58 caracteres")]
        public string Name  { get; set; } = null!;
        [InverseProperty("Lead"), JsonIgnore]
        public ICollection<Registration>? Registration  { get; set; } = null!;
  }

  public class LeadDTO: Lead 
  {
    public new int Id { get; set; }
  }
}