using MyVitarak.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;
using System.Data.SqlClient;
namespace MyVitarak.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AddMaterialGrade()
        {
            MaterialGradeMaster data = new MaterialGradeMaster();

            return View("AddMaterialGrade",data);
        }
        [HttpPost]
        public ActionResult AddMaterialGrade(MaterialGradeMaster db)
        {
           
            JobDbContext dbc = new JobDbContext();
            var res = dbc.Database.ExecuteSqlCommand(@"exec [USP_MaterialGradeMaster]@Material_Grade_Id,@Material_Grade_name,@Material_Grade_Rate",
                new SqlParameter("@Material_Grade_Id", db.Material_Grade_Id),
                new SqlParameter("@Material_Grade_name", db.Material_Grade_name),
                    new SqlParameter("@Material_Grade_Rate", db.Material_Grade_Rate));

            return Json("data inserted");

        }

        //    public ActionResult Login()
        //    {
        //        return View();
        //    }
        //    [HttpGet]
        //    public JsonResult CheckLogin(String UserID, String Password, String DeviceID)
        //    {
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        var LoginInfo = objPayRef.AuthenticateUser(UserID, Password, "0"); 
        //        return Json(LoginInfo, JsonRequestBehavior.AllowGet); 
        //    }
        //    [HttpGet]
        //    public JsonResult MakeSession(String FullName, String UserID, int UserTypeID)
        //    {
        //        Session["FullName"] = FullName;
        //        Session["UserID"] = UserID;
        //        Session["UserTypeID"] = UserTypeID.ToString();
        //        return Json(true,JsonRequestBehavior.AllowGet);
        //    }

        //    public ActionResult List()
        //    {

        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("List")
        //               : View("List"); 
        //    }
        //    public ActionResult DeliveryList(int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        { Day1 = Day.ToString(); }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        else
        //        { Month1 = Month.ToString(); }
        //        DateTime date1 = DateTime.Now.Date;
        //        CultureInfo ci = CultureInfo.InvariantCulture;
        //       // string date1 = Month1 + "/" + Day1 + "/" + Year;
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        var DeliveryList1 = objPayRef.GetDeliveryList(date1, Convert.ToInt32(Session["UserID"]));
        //        if(DeliveryList1== "No Delivery Orders Found")
        //        {
        //            IEnumerable<DeliveryList> result1 = null;
        //            return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("DeliveryList", result1)
        //               : View("DeliveryList", result1);
        //        }
        //        List<DeliveryList> details = new List<DeliveryList>();
        //        IEnumerable<DeliveryList> result = JsonConvert.DeserializeObject<List<DeliveryList>>(DeliveryList1);
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("DeliveryList", result)
        //               : View("DeliveryList", result);
        //    }


        //    public ActionResult OrderList(int CustomerID=0 ,string CustomerName ="")
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }

        //        ViewBag.CustomerID = CustomerID;
        //        ViewBag.CustomerName = CustomerName;

        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("OrderList")
        //               : View("OrderList"); 
        //    }
        //    [HttpPost]
        //    public ActionResult OrderDetails(int CustomerID = 0,int Day=0 , int Month=0 ,int Year=0)
        //    {
        //        ViewBag.CustomerID = CustomerID;
        //        string Day1 = "",Month1="";
        //        if(Day<10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        { Day1 = Day.ToString(); }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        else
        //        { Month1 = Month.ToString(); }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);  
        //        }
        //        catch(Exception e)
        //        {

        //        }
        //        var CustomerList1 = objPayRef.getCustomerOrderDetails(CustomerID, startdate, 1);
        //        List<OrderDetails> details = new List<OrderDetails>();
        //        try
        //        {
        //            IEnumerable<OrderDetails> result = JsonConvert.DeserializeObject<List<OrderDetails>>(CustomerList1);
        //            if (result.Count() > 0)
        //            {
        //                return Request.IsAjaxRequest()
        //                 ? (ActionResult)PartialView("OrderDetails", result)
        //                 : View("OrderDetails", result);
        //            }

        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        OrderDetails result1 = new OrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("OrderDetails", result1)
        //               : View("OrderDetails", result1);
        //    }
        //    [HttpPost]
        //    public ActionResult CreateCustomerOrder(int CustomerID = 0, int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        ViewBag.CustomerID = CustomerID;
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate  = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        var CustomerList1 = objPayRef.CreateCustomerOrder( startdate, CustomerID, Convert.ToInt32(Session["UserID"]));
        //        List<OrderDetails> details = new List<OrderDetails>();
        //        try
        //        {
        //            IEnumerable<OrderDetails> result = JsonConvert.DeserializeObject<List<OrderDetails>>(CustomerList1);
        //            return Request.IsAjaxRequest()
        //             ? (ActionResult)PartialView("OrderDetails", result)
        //             : View("OrderDetails", result);
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        OrderDetails result1 = new OrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("OrderDetails", result1)
        //               : View("OrderDetails", result1);
        //    }

        //    public ActionResult RepeatCustomerOrder(int CustomerID = 0, int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        ViewBag.CustomerID = CustomerID;
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        var CustomerList1 = objPayRef.RepeatCustomerOrder(startdate, CustomerID, Convert.ToInt32(Session["UserID"]));
        //        List<OrderDetails> details = new List<OrderDetails>();
        //        try
        //        {
        //            IEnumerable<OrderDetails> result = JsonConvert.DeserializeObject<List<OrderDetails>>(CustomerList1);
        //            return Request.IsAjaxRequest()
        //             ? (ActionResult)PartialView("OrderDetails", result)
        //             : View("OrderDetails", result);
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        OrderDetails result1 = new OrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("OrderDetails", result1)
        //               : View("OrderDetails", result1);
        //    }
        //    [HttpPost]
        //    public ActionResult UpdateQuantity( int CustomerID = 0, int BillId = 0, int productid = 0, decimal quantity = 0)
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //        ViewBag.CustomerID = CustomerID;
        //        ViewBag.quantity = quantity;
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        objPayRef.UpdateCustomerOrder(BillId, CustomerID, productid, quantity, 1, 0, Convert.ToInt32(Session["UserID"]));
        //        ViewBag.productid = productid;
        //        return Request.IsAjaxRequest()
        //            ? (ActionResult)PartialView("UpdateQuantity")
        //            : View("UpdateQuantity");

        //    }

        //    [HttpPost]
        //    public ActionResult SavePayment(int CustomerID = 0, int BillId = 0, decimal CashAmount = 0, decimal ChequeAmount = 0, String ChequeNo = "")
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //        ViewBag.CustomerID = CustomerID;

        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        objPayRef.UpdatePaymentData(BillId, CustomerID, CashAmount, ChequeAmount, ChequeNo, Convert.ToInt32(Session["UserID"]));

        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }

        //    public ActionResult DeliveryOrderDetails(int CustomerID = 0)
        //    {
        //        ViewBag.CustomerID = CustomerID;

        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate = DateTime.Now;
        //        string Day1 = "", Month1 = "";
        //        int Day = DateTime.Now.Day;
        //        int Month = DateTime.Now.Month;
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        {
        //            Day1=Day.ToString();
        //        }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        else
        //        {
        //            Month1 = Month.ToString();
        //        }
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + DateTime.Now.Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        var CustomerList1 = objPayRef.GetDeliveryDetails( startdate,CustomerID, Convert.ToInt32(Session["UserID"]));
        //        List<DeliveryOrderDetails> details = new List<DeliveryOrderDetails>();
        //        try
        //        {
        //            IEnumerable<DeliveryOrderDetails> result = JsonConvert.DeserializeObject<List<DeliveryOrderDetails>>(CustomerList1);
        //            if (result.Count() > 0)
        //            {
        //                return Request.IsAjaxRequest()
        //                 ? (ActionResult)PartialView("DeliveryOrderDetails", result)
        //                 : View("DeliveryOrderDetails", result);
        //            }

        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        DeliveryOrderDetails result1 = new DeliveryOrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("DeliveryOrderDetails", result1)
        //               : View("DeliveryOrderDetails", result1);
        //    }

        //         [HttpPost]
        //    public ActionResult SaveCrates(  int Day = 0, int Month = 0, int Year = 0, int CustomerID = 0, int CratesIn = 0, int CratesOut = 0)
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //        ViewBag.CustomerID = CustomerID;
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }

        //        DateTime startdate = DateTime.Now;
        //        CultureInfo ci = CultureInfo.InvariantCulture;
        //        string date1 = Month1 + "/" + Day1 + "/" + Year;
        //        try
        //        { 
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        objPayRef.UpdateCrates(startdate, CratesIn , CratesOut, CustomerID, Convert.ToInt32(Session["UserID"]));

        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //    public ActionResult VendorList(int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        } 

        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        var DeliveryList1 = objPayRef.getVendorList(Convert.ToInt32(Session["UserID"]));
        //        List<VendorList> details = new List<VendorList>();
        //        IEnumerable<VendorList> result = JsonConvert.DeserializeObject<List<VendorList>>(DeliveryList1);
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("VendorList", result)
        //               : View("VendorList", result);
        //    }
        //    public ActionResult PurchaseOrderList(int VendorID = 0, string VendorName = "")
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }

        //        ViewBag.VendorID = VendorID;
        //        ViewBag.VendorName = VendorName;

        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("PurchaseOrderList")
        //               : View("PurchaseOrderList");
        //    }
        //    [HttpPost]
        //    public ActionResult PurchaseOrderDetails(int VendorID = 0, int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        ViewBag.VendorID = VendorID;

        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        { Day1 = Day.ToString(); }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        else
        //        { Month1 = Month.ToString(); }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        var VendorList1 = objPayRef.GetSupplierPurchaseOrder(VendorID, startdate, 1);
        //        List<PurchaseOrderDetails> details = new List<PurchaseOrderDetails>();
        //        try
        //        {
        //            IEnumerable<PurchaseOrderDetails> result = JsonConvert.DeserializeObject<List<PurchaseOrderDetails>>(VendorList1);
        //            if (result.Count() > 0)
        //            {
        //                return Request.IsAjaxRequest()
        //                 ? (ActionResult)PartialView("PurchaseOrderDetails", result)
        //                 : View("PurchaseOrderDetails", result);
        //            }

        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        PurchaseOrderDetails result1 = new PurchaseOrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("PurchaseOrderDetails", result1)
        //               : View("PurchaseOrderDetails", result1);
        //    }

        //    [HttpPost]
        //    public ActionResult CreatePurchaseOrder(int VendorID = 0, int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        ViewBag.VendorID = VendorID;
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        {
        //            Day1 = Day.ToString();
        //        }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        else
        //        { Month1 = Month.ToString(); }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        var CustomerList1 = objPayRef.CreatePurchaseOrder(startdate, VendorID, Convert.ToInt32(Session["UserID"]));
        //        List<PurchaseOrderDetails> details = new List<PurchaseOrderDetails>();
        //        try
        //        {
        //            IEnumerable<PurchaseOrderDetails> result = JsonConvert.DeserializeObject<List<PurchaseOrderDetails>>(CustomerList1);
        //            return Request.IsAjaxRequest()
        //             ? (ActionResult)PartialView("PurchaseOrderDetails", result)
        //             : View("PurchaseOrderDetails", result);
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        PurchaseOrderDetails result1 = new PurchaseOrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("PurchaseOrderDetails", result1)
        //               : View("PurchaseOrderDetails", result1);
        //    }

        //    public ActionResult RepeatPurchaseOrder(int VendorID = 0, int Day = 0, int Month = 0, int Year = 0)
        //    {
        //        ViewBag.VendorID = VendorID;
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        { Day1 = Day.ToString(); }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        DateTime startdate = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception e)
        //        {

        //        }
        //        var CustomerList1 = objPayRef.RepeatPurchaseOrder(startdate, VendorID, Convert.ToInt32(Session["UserID"]));
        //        List<PurchaseOrderDetails> details = new List<PurchaseOrderDetails>();
        //        try
        //        {
        //            IEnumerable<PurchaseOrderDetails> result = JsonConvert.DeserializeObject<List<PurchaseOrderDetails>>(CustomerList1);
        //            return Request.IsAjaxRequest()
        //             ? (ActionResult)PartialView("PurchaseOrderDetails", result)
        //             : View("PurchaseOrderDetails", result);
        //        }
        //        catch (Exception e)
        //        {

        //        }

        //        OrderDetails result1 = new OrderDetails();
        //        return Request.IsAjaxRequest()
        //               ? (ActionResult)PartialView("PurchaseOrderDetails", result1)
        //               : View("PurchaseOrderDetails", result1);
        //    }
        //    [HttpPost]
        //    public ActionResult UpdatePurchaseQuantity(int VendorID = 0, int BillId = 0, int productid = 0, int quantity = 0,decimal likageQty=0)
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //        ViewBag.VendorID = VendorID;
        //        ViewBag.quantity = quantity;
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        objPayRef.PurchaseData(BillId, VendorID, productid, quantity, likageQty, Convert.ToInt32(Session["UserID"]));
        //        ViewBag.productid = productid;
        //        return Json(true, JsonRequestBehavior.AllowGet); 
        //    }
        //    [HttpPost]
        //    public ActionResult ConfirmPurchaseOrder(int VendorID = 0, int Day = 0, int Month = 0, int Year = 0 )
        //    {
        //        if (Session["UserID"] == null)
        //        {
        //            return RedirectToAction("Login", "Home");
        //        }
        //        ViewBag.VendorID = VendorID;
        //        string Day1 = "", Month1 = "";
        //        if (Day < 10)
        //        {
        //            Day1 = "0" + Day.ToString();
        //        }
        //        else
        //        { Day1 =  Day.ToString(); }
        //        if (Month < 10)
        //        {
        //            Month1 = "0" + Month.ToString();
        //        }
        //        DateTime startdate = DateTime.Now;
        //        try
        //        {

        //            CultureInfo ci = CultureInfo.InvariantCulture;
        //            string date1 = Month1 + "/" + Day1 + "/" + Year;
        //            startdate = DateTime.ParseExact(date1, "MM/dd/yyyy", ci);
        //        }
        //        catch (Exception )
        //        {

        //        }
        //        VItarakService.MasterDataSoapClient objPayRef = new VItarakService.MasterDataSoapClient();
        //        objPayRef.ConfirmPurchaseOrder(startdate, VendorID, Convert.ToInt32(Session["UserID"]));

        //        return Json(true, JsonRequestBehavior.AllowGet);

        //    }


        //}
    }
}