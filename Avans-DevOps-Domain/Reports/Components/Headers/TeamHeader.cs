namespace Avans_DevOps_Domain.Reports.Components;

public class TeamHeader : IHeader
{
    public string Text { get; set; }
    
    public TeamHeader(string teamName)
    {
        Text = $"Team Report: {teamName} - {DateTime.Now.ToString("dd-MM-yyyy")}";
    }
}