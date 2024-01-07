using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.API.Entidades;

public class Cliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public double CapacidadeComprar { get; set; }
}
