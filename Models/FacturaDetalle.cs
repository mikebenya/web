using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TaskSharpHTTP.Models
{
    [Table("FACTURADETALLE")]
    public class FacturaDetalle
    {
        [Key] [JsonProperty("detalle_id")][DatabaseGenerated(DatabaseGeneratedOption.None)] public string DETALLE_ID { get; set; }

        [JsonProperty("detalle_cantidad")] public int DETALLE_CANTIDAD { get; set; }

        [JsonProperty("detalle_precio_ven")] public double DETALLE_PRECIO { get{return Producto.PRODUCTO_PRECIO;} set{} }

        [JsonProperty("detalle_fecha_det")] public DateTime DETALLE_FECHA { get; set; }

        [JsonProperty("detalle_subtotal")] public double DETALLE_SUBTOTAL { get{return DETALLE_CANTIDAD*DETALLE_PRECIO; } set{} }

        [ForeignKey("FK_PRODUCTO")] [JsonProperty("producto_id")] public string PRODUCTO_ID { get; set; }
        [JsonProperty("producto")]  public virtual Producto Producto { get; set; }

        [ForeignKey("FK_MFACTURA")] [JsonProperty("maestro_id")] public string MAESTRO_ID { get; set; }
        [JsonProperty("facturaMaestro")] public virtual FacturaMaestro facturaMaestro { get; set; }

    }
}