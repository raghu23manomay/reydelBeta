﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;


namespace MyVitarak.Models
{
    public class MaterialGradeMaster
    {
        [Key]
       public int? Material_Grade_Id { get; set; }
        public string Material_Grade_name { get; set; }
        public float Material_Grade_Rate { get; set; }
    }
    public class AllMaster
    {
    }
  
    public class Route
    {
        public DataTable dtTable;
        [Key]
        public int RouteId { get; set; }
        public int CityId { get; set; }
        [Required]
        public string Area { get; set; }

    }
   
    public class copyrate
    {
        [Key]
        public int? Sr_No { get; set; }
        public string CustomerName { get; set; }
        public string Area { get; set; }
    }
  
    public class ProductDetails
    {

        [Key]
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int? ProductBrandID { get; set; }
        public int CrateSize { get; set; }
        public Decimal? GST { get; set; }
        public int? TotalRows { get; set; }

    }

    public class ProductMaster
    {

        [Key]
        public int ProductID { get; set; }
        public string Product { get; set; }
        public int? ProductBrandID { get; set; }
        public int? StockCount { get; set; }
        public Decimal? SalePrice { get; set; }
        public int CrateSize { get; set; }
        public Decimal GST { get; set; }

    }

    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public int AreaID { get; set; }
        public string Mobile { get; set; }
    }

    public class EmployeeList
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public int AreaID { get; set; }
        public string Mobile { get; set; }
    }

    public class EmployeeDetails
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        IEnumerable<EmployeeDetails> EmployeeDetail { get; set; }
        public string Address { get; set; }
        public int AreaID { get; set; }
        public string Area { get; set; }
        public string Mobile { get; set; }
        public int? TotalRows { get; set; }
    }

    public class Vehical
    {
        [Key]
        public int VechicleID { get; set; }
        public string Transport { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string VechicleNo { get; set; }
        public string Marathi { get; set; }
        public Decimal RatePerTrip { get; set; }
        public int PrintOrder { get; set; }
    }

    public class VehicalDetails
    {
        [Key]
        public int VechicleID { get; set; }
        public string Transport { get; set; }
        public string Owner { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string VechicleNo { get; set; }
        public string Marathi { get; set; }
        public Decimal RatePerTrip { get; set; }
        public int PrintOrder { get; set; }
        public int? TotalRows { get; set; }
    }


    public class SupplierDetails
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string PersonMobileNo { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
        public Boolean IsActive { get; set; }
        public int? TotalRows { get; set; }

    }

    public class SupplierMaster
    {
        [Key]
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string PersonMobileNo { get; set; }
        public string ContactPerson { get; set; }
        public string EmailID { get; set; }
        public Boolean IsActive { get; set; }
        public string OfficeNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Address { get; set; }
        public Int64? TenantID { get; set; }
        public Int64? userid { get; set; }

    }

    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int AreaID { get; set; }
        public string Area { get; set; }
        public int SalesPersonID { get; set; }
        public string EmployeeName { get; set; }
        public int VehicleID { get; set; }
        public string VechicleNo { get; set; }
        public int? CustomerTypeId { get; set; }
        public string CustomerType { get; set; }
        public string CustomerNameEnglish { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public Boolean isBillRequired { get; set; }
        public Boolean isActive { get; set; }
        public Decimal DeliveryCharges { get; set; }
    }



    //public class CustomerList
    //{
    //    [Key]
    //    public int CustomerID { get; set; }
    //    public string CustomerName { get; set; }
    //    public string Address { get; set; }
    //    public string Mobile { get; set; }
    //    public int AreaID { get; set; }
    //    public string Area { get; set; }
    //    public int SalesPersonID { get; set; }
    //    public string EmployeeName { get; set; }
    //    public int VehicleID { get; set; }
    //    public string VechicleNo { get; set; }
    //    public int? CustomerTypeId { get; set; }
    //    public string CustomerType { get; set; }
    //    public Boolean isBillRequired { get; set; }
    //    public Boolean isActive { get; set; }
    //    public Decimal? DeliveryCharges { get; set; }
    //}


    public class CustomerDetails
    {

        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public int AreaID { get; set; }
        public int SalesPersonID { get; set; }
        public string CustomerNameEnglish { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string EmployeeName { get; set; }
        public int? VehicleID { get; set; }
        public Boolean? isBillRequired { get; set; }
        public Boolean? isActive { get; set; }
        public Decimal? DeliveryCharges { get; set; }
        public string Area { get; set; }
        public string VechicleNo { get; set; }
        public int? TotalRows { get; set; }
    }

    public class OpeningBalance
    {
        [Key]
        public int CustomerID { get; set; }
        public Decimal PreviousBalance { get; set; }
    }

    public class RouteDetails
    {

        [Key] public int AreaID { get; set; }
        public string Area { get; set; }
        IEnumerable<RouteDetails> RouteDetail { get; set; }
        public int? TotalRows { get; set; }

    }


    public class EditRoute
    {
        [Key]
        public int AreaID { get; set; }
        public int CityID { get; set; }
        public string Area { get; set; }

    }
    public class OpeningBalanceDeatils
    {
        [Key]
        public int Sr_No { get; set; }
        public string CustomerName { get; set; }
        public string Area { get; set; }
        public int TotalRows { get; set; }
        public Decimal BalanceAmount { get; set; }
    }

    public class CustomerProductDetails
    {

        [Key]
        public int ProductID { get; set; }
        public int CustRateID { get; set; }
        public int Customerid { get; set; }
        public string Product { get; set; }
        public decimal Rate { get; set; }
        public int CrateSize { get; set; }

    }
    public class DashboardCounts
    {

        [Key]
        public Int64 vendorCount { get; set; }
        public Int64 PurchaseAmount { get; set; }
        public Int64 salesAmount { get; set; }
        public Int64 CustomerCount { get; set; }

    }


    public class NotificationDetails
    {

        [Key]
        public Int64 NotificationID { get; set; }
        public Int64 FromTenantID { get; set; }
        public Int64 ToTenantID { get; set; }
        public int? NotType { get; set; }
        public int? IsApprove { get; set; }
        public String Messege { get; set; }
        public int CreatedBy { get; set; }
        public String CreatedDate { get; set; }
        public String MessegeFrom { get; set; }
        public String Mobile { get; set; }
        public String Address { get; set; }
        public int? IsRead { get; set; }

    }
    public class Chart
    {

        [Key]
        public string Label { get; set; }
        public Int32 Value1 { get; set; }
        public Int32 Value2 { get; set; }
        
    }

    public class NotoficationCount
    {

        [Key]
        public int CountAll { get; set; }

    }
}
