using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task.Models;

namespace Task.Controllers
{
    public class HomeController : Controller
    {

        PointContext db = new PointContext();

        [HttpPost]
        public JsonResult Index(UserData Data)
        {

            if (ModelState.IsValid)
            {

                AddUserDataSQL(Data);
                SaveBD();

                List<Point> Points = FindPoints(Data);

                SaveBD();

                return Json(Points);

            }

            string exceptionString = CreateExceprionsString();
            return Json(exceptionString);

        }

        private List<Point> FindPoints(UserData Data)
        {

            List<Point> Points = new List<Point>();
            float currentY;
            int chartId = Data.UserDataId;
            float currentX = Data.RangeFrom;
            float maximumX = Data.RangeTo;
            float step = Data.Step;

            while (currentX <= maximumX)
            {

                currentY = CountY(Data, currentX);
                Point point = new Point(chartId, currentX, currentY);
                Points.Add(point);

                AddPointSQL(point);

                currentX += step;
            }

            return Points;
        }

        private string CreateExceprionsString()
        {
            string defaultExceptionString = "The server rejected your request.";
            string createdExceprionString = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            
            return defaultExceptionString + createdExceprionString;
        }

        private void SaveBD()
        {
            db.SaveChanges();
        }

        private void AddPointSQL(Point Point)
        {
            db.Points.Add(Point);
        }

        private void AddUserDataSQL(UserData Data)
        {
            db.UserData.Add(Data);
        }

        private float CountY(UserData Data, float x)
        {

            int a = Data.a;
            int b = Data.b;
            int c = Data.c;

            float y = x * x * a + x * b + c;

            return y;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
