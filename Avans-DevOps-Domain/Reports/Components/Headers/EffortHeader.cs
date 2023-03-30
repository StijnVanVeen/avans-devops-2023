namespace Avans_DevOps_Domain.Reports.Components;

public class EffortHeader : IHeader
{
    public string Text { get; set; }
    
    public EffortHeader()
    {
        Text = "Effort Rapport - " + DateTime.Now.ToString("dd-MM-yyyy");
    }
}