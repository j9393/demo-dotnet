using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult webpageload()
        {

            string constr = ConfigurationManager.ConnectionStrings["DBDetails"].ToString();


            Class1 model = new Class1();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from TestTable", con))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        model.Name = ds.Tables[0].Rows[i][1].ToString();
                        model.Address = ds.Tables[0].Rows[i][2].ToString();
                    }
                };
            };

            return View(model);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}