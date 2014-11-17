namespace ForumSystem.Web.ViewModels.PageableFeedbackList
{    
    using System;
    using System.ComponentModel.DataAnnotations;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class PageableViewModel : IMapFrom<Feedback>
    {
        public ApplicationUser Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
    }
}