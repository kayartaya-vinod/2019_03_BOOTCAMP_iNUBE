using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcAppWithDbData.Models;

namespace MvcAppWithDbData.Models
{
    public class ShipperRepo
    {
        private NorthwindDataContext ctx = new NorthwindDataContext();
        public List<Shipper> GetAllShippers()
        {
            return ctx.Shippers.ToList();
        }

        public Shipper AddNew(Shipper shipper)
        {
            ctx.Shippers.InsertOnSubmit(shipper);
            ctx.SubmitChanges();
            return shipper;
        }


        public void Update(Shipper shipper)
        {
            Shipper searchedShipper = ctx.Shippers.First(sh => sh.ShipperID == shipper.ShipperID);
            searchedShipper.CompanyName = shipper.CompanyName;
            searchedShipper.Phone = shipper.Phone;

            ctx.SubmitChanges();
        }

        public void DeleteShipper(int shipperID)
        {
            Shipper searchedShipper = ctx.Shippers.First(sh => sh.ShipperID == shipperID);
            ctx.Shippers.DeleteOnSubmit(searchedShipper);
            ctx.SubmitChanges();
        }


    }
}