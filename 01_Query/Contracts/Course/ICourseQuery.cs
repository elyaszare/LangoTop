﻿using System.Collections.Generic;

namespace _01_Query.Contracts.Course
{
    public interface ICourseQuery
    {
        List<CourseQueryModel> LatestCourses(int counts);
        List<CourseQueryModel> GetCourses();
        PagingCourseQueryModel GetCourses(int pageId = 1);
        PagingCourseQueryModel GetCoursesBy(string categorySlug, int pageId = 1);
        PagingCourseQueryModel Search(string searchModel, int pageId);
        CourseQueryModel GetDetails(string slug);
        CourseQueryModel GetDetails(long id);
        List<CourseQueryModel> GetCoursesBy(long teacherId);
        List<CourseQueryModel> GetCoursesBy(string username);
    }
}
