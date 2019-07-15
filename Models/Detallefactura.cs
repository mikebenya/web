using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSharpHTTP.Models
{
    [Table("DETALLEFACTURA")]
    public class Detallefactura
    {
        [Key] [JsonProperty("detalle_id")] public string DETALLE_ID { get; set; }

        [JsonProperty("detalle_cantidad")] public int DETALLE_CANTIDAD { get; set; }

        [JsonProperty("detalle_precio_ven")] public double DETALLE_PRECIO_VENTA { get; set; }

        [JsonProperty("detalle_fecha_det")] public string DETALLE_FECHA_DET { get; set; }

        [JsonProperty("detalle_subtotal")] public double DETALLE_SUBTOTAL { get; set; }

        [ForeignKey("FK_PRODUCTO")] [JsonProperty("producto_id")] public string PRODUCTO_ID { get; set; }
        public virtual Producto Producto { get; set; }

        [ForeignKey("FK_MFACTURA")] [JsonProperty("maestro_id")] public string MAESTRO_ID { get; set; }
        public virtual Maestrafactura Maestrafactura { get; set; }

    }
}