namespace ForumSystem.Web.Controllers
{    
    using System;
    using System.Web.Mvc;
    using ForumSystem.Data.Common.Repository;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure;
    using ForumSystem.Web.InputModels.Feedback;

    public class FeedbackController : Controller
    {
        private readonly IDeletableEntityRepository<Feedback> feedbacks;

        private readonly ISanitizer sanitizer;

        public FeedbackController(IDeletableEntityRepository<Feedback> feedbacks, ISanitizer sanitizer)
        {
            this.feedbacks = feedbacks;
            this.sanitizer = sanitizer;
        }

        public ActionResult Index()
        {           
            return this.View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new FeedbackInputModel();
            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackInputModel inputData)
        {
            if (ModelState.IsValid)
            {
                // var userId = this.User.Identity.GetUserId();
                var feedback = new Feedback
                {
                    Title = inputData.Title,
                    Content = this.sanitizer.Sanitize(inputData.Content),

                    // Author = new ApplicationUser(),
                    IsDeleted = false,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    DeletedOn = DateTime.Now.AddYears(2)
                };
                this.feedbacks.Add(feedback);
                this.feedbacks.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View(inputData);
        }
    }
}