using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSharpHTTP.Models
{
    [Table("VENDEDOR")]
public class Vendedor
{
[Key][JsonProperty("vendedor_id")] public string VENDEDOR_ID { get; set; }
[JsonProperty("vendedor_nombre1_ven")] public string VENDEDOR_NOMBRE1_VEN { get; set; }
[JsonProperty("vendedor_nombre2_ven")] public string VENDEDOR_NOMBRE2_VEN { get; set; }
[JsonProperty("vendedor_apellido1_ven")] public string VENDEDOR_APELLIDO1_VEN { get; set; }
[JsonProperty("vendedor_apellido2_ven")] public string VENDEDOR_APELLIDO2_VEN { get; set; }
[JsonProperty("vendedor_calle_ven")] public string VENDEDOR_CALLE_VEN { get; set; }
[JsonProperty("vendedor_casa_ven")] public string VENDEDOR_CASA_VEN { get; set; }
[JsonProperty("vendedor_barrio_ven")] public string VENDEDOR_BARRIO_VEN { get; set; }
[JsonProperty("vendedor_Telefono_ven")] public string VENDEDOR_TELEFONO_VEN { get; set; }
[JsonProperty("vendedor_usuario")] public string VENDEDOR_USUARIO { get; set; }
[JsonProperty("vendedor_contrasena")] public string VENDEDOR_CONTRASENA { get; set; }
public virtual List<Maestrafactura> Maestrafactura { get; set; }

}
}