using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApp.Domain.Response;
using TestWebApp.Domain.ViewModels.Review;


namespace TestWebApp.Service.Interfaces
{
    public interface IReviewService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Review>>> GetReviews();

        Task<IBaseResponse<ReviewViewModel>> GetReview(int id);

        Task<IBaseResponse<ReviewViewModel>> CreateReview(ReviewViewModel ReviewViewModel);

        Task<IBaseResponse<bool>> DeleteReview(int id);

        Task<IBaseResponse<Domain.Entity.Review>> GetReviewByName(string name);

        Task<IBaseResponse<Domain.Entity.Review>> Edit(int id, ReviewViewModel model);
    }
}
