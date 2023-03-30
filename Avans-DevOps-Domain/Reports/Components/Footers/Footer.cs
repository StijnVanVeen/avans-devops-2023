namespace Avans_DevOps_Domain.Reports.Components;

public class Footer : IFooter
{
    public string Text { get; set; }
    
    public Footer()
    {
        Text = "Footer";
    }
}