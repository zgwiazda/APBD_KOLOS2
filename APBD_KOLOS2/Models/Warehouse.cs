using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOLOS2.Models;
[Table ("Warehouse")]
public class Warehouse
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; }
    
    public ICollection<Object> Objects { get; set; }
}
