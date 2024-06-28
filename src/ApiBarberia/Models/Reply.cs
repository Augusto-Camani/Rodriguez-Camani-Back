using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBarberia;

public class Reply
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ReplyId { get; set; }
    [ForeignKey("ReviewId")]
    public Review Review { get; set; }
    public int ReviewId { get; set; }
    [Required]
    public string Response { get; set; }
}
