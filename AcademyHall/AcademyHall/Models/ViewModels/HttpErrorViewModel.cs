using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace AcademyHall.Models.ViewModels
{
    public class HttpErrorViewModel
    {

        public HttpErrorViewModel() { }

        public HttpErrorViewModel(int statusCode, string errMessge)
        {
            StatusCode = statusCode;
            ErrorMessage = errMessge;
        }

        public HttpErrorViewModel(string errorController, string errorMethod, string errorMessage, string errorStackTrace)
        {
            StringBuilder sb_builder = new StringBuilder();
            string dateStamp = DateTime.Now.ToString();
            sb_builder.Append(dateStamp);
            sb_builder.AppendLine("\n");
            sb_builder.Append(errorController);
            sb_builder.AppendLine("\n");
            sb_builder.Append(errorMethod);
            sb_builder.AppendLine("\n");
            sb_builder.Append(errorMessage);
            sb_builder.AppendLine("\n");
            sb_builder.Append(errorStackTrace);
           ErrorLineMessage = sb_builder.ToString();
        }

        [Display(Name="Status Code:")]
        public int StatusCode { get; set; }
        [Display(Name="Error Code: ")]
        public string ErrorMessage { get; set; }
        public string ErrorController { get; set; }
        public string ErrorMethod { get; set; }
        public string ErrorStackTrace { get; set; }
        public string ErrorLineMessage { get; set; }
    }
}