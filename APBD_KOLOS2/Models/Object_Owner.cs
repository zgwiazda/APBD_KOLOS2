using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOLOS2.Models;
[Table("Object_Owner")]
public class Object_Owner
{
    [Key, Column(Order = 0)]
    [ForeignKey("Object")]
    public int Object_ID { get; set; }

    [Key, Column(Order = 1)]
    [ForeignKey("Owner")]
    public int Owner_ID { get; set; }

   
    public Object Object { get; set; }
    public Owner Owner { get; set; }
}