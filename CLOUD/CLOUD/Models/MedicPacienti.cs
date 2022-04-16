using System.Text.Json.Serialization;

namespace CLOUD;

public class MedicPacienti:Entity
{
    public Pacient Pacient { get; set; }
    [JsonIgnore] public Medic Medic { get; set; }
}