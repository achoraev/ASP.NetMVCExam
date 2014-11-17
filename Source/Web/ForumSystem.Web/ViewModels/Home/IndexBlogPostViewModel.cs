namespace ForumSystem.Web.ViewModels.Home
{    
    using System.Collections;
    using ForumSystem.Data.Models;
    using ForumSystem.Web.Infrastructure.Mapping;

    public class IndexBlogPostViewModel : IMapFrom<Post>
    {
        public string Title { get; set; }

        public int Id { get; set; }

        public IEnumerable Tags { get; set; }
    }
}