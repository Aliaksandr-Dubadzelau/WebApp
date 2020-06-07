using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class Point
    {

        [Key]
        public int PointId { set; get; }
        public int? ChartId { set; get; }
        public float PointX { set; get; }
        public float PointY { set; get; }

        public Point(int ChartId, float PointX, float PointY)
        {

            this.ChartId = ChartId;
            this.PointX = PointX;
            this.PointY = PointY;

        }
    }
}