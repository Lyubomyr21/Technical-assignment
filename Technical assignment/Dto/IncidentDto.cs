namespace Technical_assignment.Data_transfer_objects
{
    public class IncidentDto
    {
        public string IncidentName { get; set; } = "Incident_def_in";
        public AccountDto Account { get; set; }
        public ContactDto Contact { get; set; }

    }
}
