namespace ApiBarberia;

public class ReviewDTO
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public decimal Rating { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}
