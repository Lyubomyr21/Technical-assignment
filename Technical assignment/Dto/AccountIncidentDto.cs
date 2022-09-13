namespace Technical_assignment.Data_transfer_objects
{
    public class AccountIncidentDto
    {
        public string AccountName { get; set; } = "Account_def_ac";
        public int IncidentId { get; set; } = 1;
        public ContactDto Contact { get; set; }
    }
}
