namespace ApiBarberia;

public class ReviewRepository : Repository, IReviewRepository
{
    public ReviewRepository(DbContextCR context) : base(context)
    {
    }

    public void CreateReview(Review review)
    {
        _context.Add(review);
        _context.SaveChanges();
    }

    public IEnumerable<Review> GetReviews()
    {
        return _context.Reviews;
    }

    public Review GetReviewById(int reviewId)
    {
        return _context.Reviews.FirstOrDefault(r => r.ReviewId == reviewId);
    }

    public void DeleteReview(int reviewId)
    {
        _context.Reviews.Remove(GetReviewById(reviewId));
        _context.SaveChanges();
   
    }

    public void UpdateReview(Review review)
    {
        _context.Update(review);
        _context.SaveChanges();
    }

    public IEnumerable<Review> GetReviewsByUserId(int userId)
    {
        var reviewsDtoList = _context.Reviews
            .Where(x => x.UserId == userId);

        return reviewsDtoList;
    }

}