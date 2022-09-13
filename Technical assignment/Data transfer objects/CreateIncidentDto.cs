namespace Technical_assignment.Data_transfer_objects
{
    public class CreateIncidentDto
    {      
        public string IncidentName { get; set; }
        public AccountDto Account { get; set; }
        public CreateContactDto Contact { get; set; }

    }
}
