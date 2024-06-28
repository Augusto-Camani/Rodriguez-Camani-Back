using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBarberia;

public class Appointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AppointmentId { get; set; }
    [Required]
    public DateTime DateTime { get; set; }
    public TimeSpan StartTime { get; set; }
    public string Service { get; set; }

    [ForeignKey("ClientId")]
    public Client Client { get; set; }
    public int ClientId { get; set; }

    [ForeignKey("BarberId")]

    public Barber Barber { get; set; }
    public int BarberId { get; set; }

    [ForeignKey("BarberAvailabilityId")]
    public BarberAvailability BarberAvailability { get; set; }
    public int BarberAvailabilityId { get; set; }
    public Review Review { get; set;}
}
