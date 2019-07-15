using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSharpHTTP.Models
{
    [Table("PRODUCTO")]
    public class Producto
    {
        [Key] [JsonProperty("producto_id")] public string PRODUCTO_ID { get; set; }
        [JsonProperty("producto_nombre")] public string PRODUCTO_NOMBRE { get; set; }
        [JsonProperty("producto_costo")] public double PRODUCTO_COSTO { get; set; }
        [JsonProperty("producto_precio")] public double PRODUCTO_PRECIO { get { return (PRODUCTO_COSTO + (PRODUCTO_COSTO * 0.2)); } set { } }
        [JsonProperty("producto_descripcion")] public string PRODUCTO_DESCRIPCION { get; set; }
        [JsonProperty("producto_imagen")] public string PRODUCTO_IMAGEN { get; set; }
        [JsonProperty("producto_iva")] public double PRODUCTO_IVA { get; set; }
        [JsonProperty("producto_estado")] public bool PRODUCTO_ESTADO { get; set; }
        public virtual List<Detallefactura> Detallefactura { get; set; }
    }
}