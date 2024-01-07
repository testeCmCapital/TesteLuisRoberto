using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CMCapital.API.Entidades;

public class CompraCliente
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Codigo { get; set; }
    public int CodigoCliente { get; set; }
    public int CodigoProduto { get; set; }
    public int Quantidade { get; set; }
    public double ValorTotalCompra { get; set; }

}
