using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace Task.Models
{
    public class UserData
    {

        [Key]
        public int UserDataId { get; set; }
        [Required(ErrorMessage = "Field From is required.")]
        public float RangeFrom { get; set; }
        [Required(ErrorMessage = "Field To is required.")]
        public float RangeTo { get; set; }
        [Required(ErrorMessage = "Field Step is required.")]
        [Range(0.01, 3.40282347E+38, ErrorMessage = "Step must be more then 0,01")]
        public float Step { get; set; }
        [Required(ErrorMessage = "Field A is required.")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "A must be INTEGER")]
        public int a { get; set; }
        [Required(ErrorMessage = "Field B is required.")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "B must be INTEGER")]
        public int b { get; set; }
        [Required(ErrorMessage = "Field C is required.")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "C must be INTEGER")]
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