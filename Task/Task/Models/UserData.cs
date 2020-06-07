using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task.Models
{
    public class UserData
    {

        [Key]
        public int UserDataId { get; set; }
        public float RangeFrom { get; set; }
        public float RangeTo { get; set; }
        public float Step { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public UserData()
        {

        }

        public UserData(float RangeFrom, float RangeTo, float Step, int a, int b, int c)
        {
            
            this.RangeFrom = RangeFrom;
            this.RangeTo = RangeTo;
            this.Step = Step;
            this.a = a;
            this.b = b;
            this.c = c;

        }

    }
}