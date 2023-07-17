using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortsTracker.Domain.Models;

public class Movement
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MovementId { get; set; }
    public string Name { get; set; }
    public string Zone { get; set; }
    public DateTime MovementTime { get; set; }
    public string PhoneNumber { get; set; }
}