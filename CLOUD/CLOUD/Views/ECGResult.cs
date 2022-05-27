namespace CLOUD;

public class ECGResult
{
    public List<float> Valori { get; set; }
    public Pacient Pacient { get; set; }
    public DateTime Created { get; set; }
}