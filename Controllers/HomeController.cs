using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetEmpChartData()
        {
            List<Employee> empChartList = new List<Employee>();

            string query = "SELECT Id, FirstName, Designation, Email, ReportID";
            query += " FROM tblEmployee";

            //string connetionString = "Data Source=JIYAUL-UNVPNSI1\\SQLEXPRESS;Initial Catalog=CSG;Integrated Security=True;";
            string connetionString = "Server=JIYAUL-UNVPNSI1\\SQLEXPRESS;Database=CSG;User ID= sa; Password=Vtu11786@#;Trusted_Connection=false;";
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            empChartList.Add(new Employee()
                            {
                                Id = dr.GetInt32(0),
                                FirstName = dr.GetString(1),
                                Designation = dr.GetString(2),
                                Email = dr["Email"].ToString(),
                                ReportID = dr["ReportID"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return Json(empChartList, JsonRequestBehavior.AllowGet);
        }
       
    }
}
