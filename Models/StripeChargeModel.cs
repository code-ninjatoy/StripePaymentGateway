using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StripePayments.Models;

namespace StripePayments.Models
{
    public class StripeChargeModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public double Amount { get; set; }


        //optional fields
        public string CardHolderName { get; set; }
        public string cardno { get; set; }
        public string expDate { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressPostcode { get; set; }
        public string AddressCountry { get; set; }



        public int AddUserCardInfo(tblStripe model)
        {
            Database1Entities1 db = new Database1Entities1();
            
            try
            {
                db.tblStripes.Add(model);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}