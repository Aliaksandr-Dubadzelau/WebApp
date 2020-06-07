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
        public JsonResult Index(float RangeFrom, float RangeTo, float Step, int a, int b, int c)
        {


            UserData Data = new UserData(RangeFrom, RangeTo, Step, a, b, c);

            AddUserDataSQL(Data);
            SaveBD();

            List<Point> Points = FindPoints(Data);

            SaveBD();

            return Json(Points);

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
