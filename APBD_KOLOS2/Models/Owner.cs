using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOLOS2.Models;

[Table("Owner")]
public class Owner
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required]
    [StringLength(9)]
    public string PhoneNumber { get; set; }

   
    public ICollection<Object_Owner> ObjectOwners { get; set; }
}