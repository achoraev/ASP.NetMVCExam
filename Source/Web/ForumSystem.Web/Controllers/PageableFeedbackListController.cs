namespace ForumSystem.Web.Controllers
{    
    using System.Web.Mvc;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure;
    using ForumSystem.Web.ViewModels.PageableFeedbackList;

    public class PageableFeedbackListController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        private readonly ISanitizer sanitizer;

        public PageableFeedbackListController(IDeletableEntityRepository<Feedback> feedbacks, ISanitizer sanitizer)
        {
            this.feedbacks = feedbacks;
            this.sanitizer = sanitizer;
        }

        [Authorize]
        public ActionResult Index(int? page = 1)
        {
            // int feedForPage = 4;
            // int pageNumber = (page ?? 1);
            // for (int i = pageNumber; i < (feedForPage + pageNumber); i++)
            // {
            //    feedbacks.Add(feedbacks[i]);
            // }
            var feedbacks = this.feedbacks.All();

            return this.View(feedbacks);
        }
    }
}