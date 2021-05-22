using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sqlapp.Models;
using sqlapp.Services;

namespace sqlapp.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _course_service;

        public CourseController(CourseService _svc) 
        {
            _course_service = _svc;
        }

        public IActionResult Index()
        {
            IEnumerable<Course> _course_list = _course_service.GetCourses();
            return View(_course_list);        
        }

    }
}
