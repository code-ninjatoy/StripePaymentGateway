using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Stripe;
using StripePayments.Models;

namespace StripePayments.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Charge()
        {
            ViewBag.Message = "Learn how to process payments with Stripe";
            return View(new StripeChargeModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Charge(StripeChargeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var chargeId = await ProcessPayment(model);
            return View("Index");
        }

        private async Task<string> ProcessPayment(StripeChargeModel model)
        {
           
                //StripeConfiguration.SetApiKey("pk_test_ZwQQ3DpHRcIWDMKgVObfuSYl");
                return await Task.Run(() =>
                {
                    var myCharge = new StripeChargeCreateOptions
                    {
                        Amount = (int)(model.Amount * 1),
                        Currency = "gbp",
                        Description = "Description for test charge",
                        // SourceTokenOrExistingSourceId = model.Token
                    };
                    try
                    {
                        var chargeService = new StripeChargeService("sk_test_sunSx6HuXZrAcIp2W8k7L4zk");
                        var stripeCharge = chargeService.Create(myCharge);
                        return stripeCharge.Id;
                    }
                    catch (Exception e)
                    {
                        Response.Write("<script>alert('Data Saved succesfully in Database but further transaction process  you must provide Cutomer or merchant.')</script>");
                        return e.Message;
                    }     
                });
       
           
        }

        [HttpPost]
        public JsonResult AddUserCardInfo(tblStripe stripe)
        {
            StripeChargeModel sm = new StripeChargeModel();
            int op = sm.AddUserCardInfo(stripe);
            return Json(op,JsonRequestBehavior.AllowGet);
        }
    }
}