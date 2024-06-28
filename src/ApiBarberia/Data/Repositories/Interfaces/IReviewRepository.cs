namespace ApiBarberia;

public interface IReviewRepository
{
    public IEnumerable<Review> GetReviews();
    public Review GetReviewById(int reviewId);
    void CreateReview(Review review);
    void UpdateReview(Review review);
    void DeleteReview(int reviewId);
    public IEnumerable<Review> GetReviewsByUserId(int userId);
}
