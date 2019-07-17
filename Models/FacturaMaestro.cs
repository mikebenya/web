using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;

namespace TaskSharpHTTP.Models
{
    [Table("FACTURAMAESTRO")]
    public class FacturaMaestro
    {
        [Key] [JsonProperty("maestro_id")][DatabaseGenerated(DatabaseGeneratedOption.None)] public string MAESTRO_ID { get; set; }
        [JsonProperty("maestro_fecha_fac")] public DateTime MAESTRO_FECHA { get; set; }
        [JsonProperty("maestro_total")] public double MAESTRO_TOTAL { get{return facturaDetalles.Sum(s=>s.DETALLE_SUBTOTAL);} set{} }
        [JsonProperty("maestro_facDetalles")] public virtual List<FacturaDetalle> facturaDetalles { get; set; }
        [ForeignKey("FK_CLIENTE")] [JsonProperty("cliente_id")] public string CLIENTE_ID { get; set; }
        [JsonProperty("cliente")] public virtual Cliente Cliente { get; set; }
        [ForeignKey("FK_VENDEDOR")] [JsonProperty("vendedor_id")] public string VENDEDOR_ID { get; set; }
        [JsonProperty("vendedor")] public virtual Vendedor Vendedor { get; set; }
    }

}