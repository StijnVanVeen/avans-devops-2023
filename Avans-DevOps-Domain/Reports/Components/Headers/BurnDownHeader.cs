namespace Avans_DevOps_Domain.Reports.Components;

public class BurnDownHeader : IHeader
{
    public string Text { get; set; }
    
    public BurnDownHeader()
    {
        Text = "Burn Down Report - " + DateTime.Now.ToString("dd-MM-yyyy");
    }
}