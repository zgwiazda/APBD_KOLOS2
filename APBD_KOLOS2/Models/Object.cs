using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_KOLOS2.Models;
[Table ("Object")]
public class Object
{
    [Key]
    public int ID { get; set; }

    [ForeignKey("Warehouse")]
    public int Warehouse_ID { get; set; }

    [ForeignKey("ObjectType")]
    public int Object_Type_ID { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal Width { get; set; }

    [Column(TypeName = "decimal(4, 2)")]
    public decimal Height { get; set; }
    
    public Warehouse Warehouse { get; set; }
    public Object_Type ObjectType { get; set; }
    public ICollection<Object_Owner> ObjectOwners { get; set; }
}