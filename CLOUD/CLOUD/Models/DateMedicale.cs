using System.ComponentModel.DataAnnotations.Schema;

namespace CLOUD;

public class DateMedicale:Entity
{
    public Pacient Pacient { get; set; }
    public string IstoricMedical { get; set; }
    
    public List<String> Alergii { get; set; }
    
    public string ConsulatatiiCardiologice { get; set; }
}