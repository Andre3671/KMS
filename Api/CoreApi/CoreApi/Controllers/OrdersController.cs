using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreApi.Data;
using CoreApi.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net.Mail;
using System.Net;
using RestSharp.Authenticators;
using RestSharp;
using System.Text;
using System.Globalization;

namespace CoreApi.Controllers
{
    public class OrdersController : Controller
    {
        private readonly CoreApiContext _context;

        public OrdersController(CoreApiContext context)
        {
            _context = context;
        }
        [Route("api/sendmail/")]
        [HttpGet]
        public static bool SendSimpleMessage(string message)
        {
           

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient();

                mail.From = new MailAddress("pmi@kockumationconnect.com");
                mail.To.Add("andre.roygaard@gmail.com");
                mail.Subject = "Order update";
                mail.Body = message;
                SmtpServer.Host = "smtp.zoho.com";
                SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("pmi@kockumationconnect.com", "7Yr%sSq)");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                Console.WriteLine("Mail was sent");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            return true;
        }

        [Route("api/Orders/file/")]
        [HttpPost]
        public async Task<string> UploadFile(IFormFile file)
        {
            // if (file.FileName.EndsWith(".xlsx"))
            //    {
            long size = file.Length;

            var result = new StringBuilder();
            List<Order> orders = new List<Order>();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                //change depending on header row in file.
                string[] lines = new string[2];
                for (int x = 0; x <= lines.Length; x++)
                {
                    if (await reader.ReadLineAsync() != null)
                    {
                        lines[x] = await reader.ReadLineAsync();
                    }
                    if (lines.Length == 2)
                    {
                        break;
                    }

                }
                string read = "";
                string CurrentOrder = "";
                string[] data = { };
                int i = 0;
                while (reader.Peek() >= 0)
                {
                    List<Part> PartsList = new List<Part>();
                    string date = "";
                    bool test = true;

                    string previousOrder = "";
                    string previousPart = "";
                    string CurrentPart = "";
                    string check = "";
                    string OrderNumberList = "";
                    string OwnerList = "";
                    string VesselList = "";
                    string ShipyardList = "";
                    string HullList = "";
                    string BuyerList = "";
                    string SpecList = "";
                    Part TempPart = new Part();
                    while (reader.Peek() >= 0)
                    {
                        read = await reader.ReadLineAsync();

                        data = read.Split(";");
                        CurrentOrder = data[0];

                        if ((CurrentOrder != "" && CurrentOrder != ".") && test)
                        {
                            previousOrder = CurrentOrder;
                            test = false;
                        }
                        else if ((CurrentOrder != "" && CurrentOrder != ".") && CurrentOrder != previousOrder)
                        {
                            break;
                        }


                        if (data[0] != "" && data[0] != ".")
                        {
                            OrderNumberList += data[0] + "|";
                        }

                        if (data[2] != "" && data[2] != ".")
                        {
                            VesselList += data[2] + "|";
                        }
                        if (data[3] != "" && data[3] != ".")
                        {
                            ShipyardList += data[3] + "|";
                        }
                        if (data[4] != "" && data[4] != ".")
                        {
                            OwnerList += data[4] + "|";
                        }
                        if (data[1] != "" && data[1] != ".")
                        {
                            HullList += data[1] + "|";
                        }
                        if (data[8] != "" && data[8] != ".")
                        {
                            BuyerList += data[8] + "|";
                        }



                        string name = "";
                        string spec = "";
                        if (data[9] != "" && data[9] != ".")
                        {
                            name = data[9];
                            if (CurrentPart != data[9])
                            {
                                CurrentPart = data[9];
                            }

                        }

                        if (data[10] != "" && data[10] != ".")
                        {
                            SpecList += data[10] + " ";
                        }

                        if (SpecList != "")
                        {
                            TempPart.Spec = SpecList;
                        }

                        if (CurrentPart != previousPart)
                        {
                            TempPart.Name = name;
                            PartsList.Add(TempPart);
                            TempPart = new Part();
                            previousPart = CurrentPart;
                            SpecList = "";
                        }

                        if (data[11] != "" && data[11] != ".")
                        {
                            date = data[11];
                        }
                        else
                        {

                        }

                    }
                    test = true;
                    Order temp = new Order();
                    if (date == "" || date == "CANCELLED" || date == "NO RECORD" || date == ".")
                    {
                        temp = new Order
                        {
                            OrderNumber = OrderNumberList,
                            Vessel_name = VesselList,
                            Shipyard = ShipyardList,
                            Owner = OwnerList,
                            HullNr = HullList,
                            // SalesId = int.Parse(data[5]),
                            Buyer = BuyerList,
                            DeliveryDate = null,
                            PartsOrdered = PartsList


                        };
                    }
                    else
                    {
                        DateTime? dt1 = new DateTime();
                        try
                        {
                            dt1 = DateTime.ParseExact(date, "yy-MM-dd",
                                          CultureInfo.InvariantCulture);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            dt1 = null;
                            ;
                        }


                        temp = new Order
                        {
                            OrderNumber = OrderNumberList,
                            Vessel_name = VesselList,
                            Shipyard = ShipyardList,
                            Owner = OwnerList,
                            HullNr = HullList,
                            // SalesId = int.Parse(data[5]),
                            Buyer = BuyerList,
                            DeliveryDate = dt1,
                            PartsOrdered = PartsList


                        };

                    }



                    orders.Add(temp);
                    CurrentOrder = "";
                }
            }
            foreach (Order o in orders)
            {
                await _context.AddAsync(o);
                await _context.SaveChangesAsync();
            }

            return result.ToString();
            // }
            // else
            //  {
            //    return "Wrong file type";
            // }
        }
        [Route("Orders/")]
        // GET: Orders
        public async Task<List<Order>> Index()
        {
            string mailmessage = "";
            List<Order> Orders = await _context.Order.ToListAsync();
            foreach (Order o in Orders)
            {
                double NrOfDays = (o.Delivery.GetValueOrDefault() - DateTime.Now).TotalDays;

                if (NrOfDays <= 30 )
                {
                    if(DateTime.Now - o.Delivery < TimeSpan.FromHours(2))
                    {
                        o.DeliveryIsClose = "DeliverySoon";
                        mailmessage += "The order with order number: " + o.OrderNumber + " needs to get refreshed" + "\n";
                    }
                    else
                    {
                        o.DeliveryIsClose = "";
                    }
                 
                    
                }
                else
                {
                    o.DeliveryIsClose = "";
                }
                o.PartsOrdered = await _context.Part.Where(p => p.OrderId == o.OrderId).ToListAsync();
            }
            SendSimpleMessage(mailmessage);
            return Orders;
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Orders/")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order order)
        {
            //Order NyOrder = JsonConvert.DeserializeObject<Order>(orderjson);
            _context.Add(order);
            await _context.SaveChangesAsync();
            return Ok();

        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Vessel_name,Shipyard,Owner,HullNr,SalesId,Buyer,DeliveryDate")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
