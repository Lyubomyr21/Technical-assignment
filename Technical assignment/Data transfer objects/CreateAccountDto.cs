namespace Technical_assignment.Data_transfer_objects
{
    public class CreateAccountDto
    {
        public string AccountName { get; set; } = "Account_def_ac";
        public int IncidentId { get; set; } = 1;

        public CreateContactDto Contact { get; set; }
    }
}
