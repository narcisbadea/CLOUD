namespace CLOUD.Auth;

public class DateMedicale:Entity
{
    public Pacient Pacient { get; set; }
    public IstoricMedical IstoricMedical { get; set; }
    public List<Alergie> Alergii { get; set; }
    public string ConsulatatiiCardiologice { get; set; }
}