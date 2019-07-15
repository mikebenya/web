using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskSharpHTTP.Models
{

    [Table("CLIENTE")]
public class Cliente
{
[Key][JsonProperty("cliente_id")] public string CLIENTE_ID { get; set; }
[JsonProperty("cliente_nombre1")] public string CLIENTE_NOMBRE1 { get; set; }
[JsonProperty("cliente_nombre2")] public string CLIENTE_NOMBRE2 { get; set; }
[JsonProperty("cliente_apellido1")] public string CLIENTE_APELLIDO1{ get; set; }
[JsonProperty("cliente_apellido2")] public string CLIENTE_APELLIDO2 { get; set; }
[JsonProperty("cliente_calle")] public string CLIENTE_CALLE { get; set; }
[JsonProperty("cliente_casa")] public string CLIENTE_CASA { get; set; }
[JsonProperty("cliente_barrio")] public string CLIENTE_BARRIO { get; set; }
[JsonProperty("cliente_fechaN")] public string CLIENTE_FECHAN { get; set; }
[JsonProperty("cliente_telefono")] public string CLIENTE_TELEFONO { get; set; }
[JsonProperty("cliente_email")] public string CLIENTE_EMAIL { get; set; }
public virtual List<Maestrafactura> Maestrafactura { get; set; }
}

}