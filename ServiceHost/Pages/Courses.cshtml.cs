using _01_Query.Contracts.Course;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class CoursesModel : PageModel
    {
        private readonly ICourseQuery _courseQuery;

        public CoursesModel(ICourseQuery courseQuery)
        {
            _courseQuery = courseQuery;
        }

        public PagingCourseQueryModel Courses { get; set; }
        [TempData] public string PageId { get; set; }

        public void OnGet(int id = 1)
        {
            PageId = id.ToString();
            Courses = _courseQuery.GetCourses(id);
        }
    }
}
