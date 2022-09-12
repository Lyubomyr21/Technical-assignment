

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Technical_assignment.Models
{
    [Index(nameof(AccountName), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public Incident Incident { get; set; }
        public int IncidentId { get; set; }

    }
}
