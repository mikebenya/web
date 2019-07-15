using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSharpHTTP.Models
{
    [Table("MAESTRAFACTURA")]
    public class Maestrafactura
    {
        [Key] [JsonProperty("maestro_id")] public string MAESTRO_ID { get; set; }
        [JsonProperty("maestro_fecha_fac")] public string MAESTRO_FECHA_FAC { get; set; }
        [JsonProperty("maestro_total")] public double MAESTRO_TOTAL { get; set; }
        public virtual List<Detallefactura> Detallefactura { get; set; }
        [ForeignKey("FK_CLIENTE")] [JsonProperty("cliente_id")] public string CLIENTE_ID { get; set; }
        public virtual Cliente Cliente { get; set; }
        [ForeignKey("FK_VENDEDOR")] [JsonProperty("vendedor_id")] public string VENDEDOR_ID { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }

}