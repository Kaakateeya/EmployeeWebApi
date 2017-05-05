using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebapiApplication;
using WebapiApplication.ML;
using WebapiApplication.Interfaces;
using WebapiApplication.DAL;

namespace WebapiApplication.ML
{
    public class ML
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Genre { set; get; }
        public DateTime ReleaseDate { set; get; }
    }


    public class ActivePatientReport
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Genre { set; get; }
        public DateTime ReleaseDate { set; get; }
    }


    public class ActivePatientConditionReport
    {
        public int ID { set; get; }
        public string Title { set; get; }
        public string Genre { set; get; }
        public DateTime ReleaseDate { set; get; }
    }

    public class person
    {
        public string name { get; set; }
        public string surname { get; set; }
    }
}

