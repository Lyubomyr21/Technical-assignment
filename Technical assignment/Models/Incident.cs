using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_assignment.Models
{
    [Index(nameof(Id), IsUnique = true)]
    public class Incident
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key]
        public string IncidentName { get; set; }
    }
}
