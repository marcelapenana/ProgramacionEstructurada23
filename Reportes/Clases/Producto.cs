using System;
using System.Collections.Generic;

namespace Reportes.Clases;

public partial class Producto
{
    public int IdProd { get; set; }

    public string? NombreProd { get; set; }

    public double? CostoProd { get; set; }

    public int? IdProveedor { get; set; }

    public int? Cantidad { get; set; }
}
