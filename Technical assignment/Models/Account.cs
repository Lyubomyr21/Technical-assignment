namespace Technical_assignment.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; } = string.Empty;

        public Incident Incident { get; set; }
        public int IncidentId { get; set; }
    }
}
