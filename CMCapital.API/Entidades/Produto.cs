using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.API.Entidades;

public class Produto
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public double ValorUnitario { get; set; }

}
