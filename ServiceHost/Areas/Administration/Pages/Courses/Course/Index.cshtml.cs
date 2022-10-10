
using System.Collections.Generic;
using LangoTop.Application.Contract.Account;
using LangoTop.Application.Contract.Course;
using LangoTop.Application.Contract.CourseCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Courses.Course
{
    public class IndexModel : PageModel
    {
        private readonly ICourseApplication _courseApplication;
        private readonly ICourseCategoryApplication _courseCategoryApplication;
        private readonly IAccountApplication _accountApplication;
        public SelectList CourserCategories;
        public SelectList Teachers;
        public List<CourseViewModel> Courses;
        public CourseSearchModel SearchModel;

        public IndexModel(ICourseApplication courseApplication, ICourseCategoryApplication courseCategoryApplication, IAccountApplication accountApplication)
        {
            _courseApplication = courseApplication;
            _courseCategoryApplication = courseCategoryApplication;
            _accountApplication = accountApplication;
        }

        public string Message { get; set; }

        public void OnGet(CourseSearchModel searchModel)
        {
            CourserCategories = new SelectList(_courseCategoryApplication.GetCourseCategories(), "Id", "Name");
            Teachers = new SelectList(_accountApplication.GetAccounts(), "Id", "Fullname");
            Courses = _courseApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateCourse
            {
                CourseCategories = _courseCategoryApplication.GetCourseCategories(),
                Teachers = _accountApplication.GetAccounts()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateCourse command)
        {
            var result = _courseApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var course = _courseApplication.GetDetails(id);
            course.CourseCategories = _courseCategoryApplication.GetCourseCategories();
            course.Teachers = _accountApplication.GetAccounts();
            return Partial("./Edit", course);
        }

        public JsonResult OnPostEdit(EditCourse command)
        {
            var result = _courseApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _courseApplication.Remove(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _courseApplication.Restore(id);
            if (result.IsSucceeded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}