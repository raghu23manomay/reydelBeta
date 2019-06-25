using ReyDel.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReyDel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MaterialGradeList()
        {
            ReydeldbContext _db = new ReydeldbContext();
            IEnumerable<MaterialGradeMaster> result = _db.MaterialGradeMasters.SqlQuery(@"exec USPGetMaterialGrade").ToList<MaterialGradeMaster>();

            //totalCount = 0;
            //if (result.Count() > 0)
            //{
            //    totalCount = Convert.ToInt32(result.FirstOrDefault().TotalRows);
            //}
            ///var itemsAsIPagedList = new StaticPagedList<EmployeeDetails>(result, pageIndex, pageSize, totalCount);
           // return itemsAsIPagedList;
            return View("MaterialGradeList",result);
        }

        
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName, string Password) 
        {
            
            try
            {
               // ReydeldbContext _db = new ReydeldbContext();

                //var result = _db.LoginDetail.SqlQuery(@"exec usp_login 
                //@username,@password",
                //    new SqlParameter("@username", L.UserName),
                //    new SqlParameter("@password", L.password)).ToList<Login>();
                //Login data = new Login();
                //data = result.FirstOrDefault();
                if(UserName == "Test" && Password=="1234")
                {
                    Session["UserName"] = "Test";
                    Session["UserID"] = 1;
                    return Json(true,"Sucess");
                }
              else
                    return Json(false, "failed"); 

            }


            catch (Exception ex)
            {
                return Json(ex.Message);
            }

        }
        public ActionResult AddMaterialGrade()
        {
            MaterialGradeMaster data = new MaterialGradeMaster();

            return View("AddMaterialGrade", data);
        }
        [HttpPost]
        public ActionResult AddMaterialGrade(String GradeName ,String GradeRate)
        {

            ReydeldbContext dbc = new ReydeldbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec USPInsertMaterialGrade @GradeName,@GradeRate", 
                new SqlParameter("@GradeName", GradeName),
                new SqlParameter("@GradeRate", GradeRate)); 
            return Json("data inserted"); 
        }
        public ActionResult Dashboard()
        {  
            return View();
        }
        public List<SelectListItem> binddropdown(string action, int val = 0)
        {
            ReydeldbContext _db = new ReydeldbContext();

            var res = _db.Database.SqlQuery<SelectListItem>("exec USP_BindDropDown @action , @val",
                   new SqlParameter("@action", action),
                    new SqlParameter("@val", val))
                   .ToList()
                   .AsEnumerable()
                   .Select(r => new SelectListItem
                   {
                       Text = r.Text.ToString(),
                       Value = r.Value.ToString(),
                       Selected = r.Value.Equals(Convert.ToString(val))
                   }).ToList();

            return res;
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Home");
        }

    }
}