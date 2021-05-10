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
        public static IRestResponse SendSimpleMessage(string message)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri("https://api.mailgun.net/v3/sandbox74ab02a1ad214821aa276b43a7215e47.mailgun.org/messages");

            client.Authenticator =

                new HttpBasicAuthenticator("api",
                    "e136b2cb19344d1572bcdd17ad887671-2a9a428a-dbb8b81b");
            RestRequest request = new RestRequest();
            request.AddParameter("domain", "sandbox74ab02a1ad214821aa276b43a7215e47.mailgun.org", ParameterType.UrlSegment);
            request.AddParameter("from", "<mailgun@sandbox74ab02a1ad214821aa276b43a7215e47.mailgun.org>");
            request.AddParameter("to", "andre.roygaard@gmail.com");
            request.AddParameter("to", "andre.roygaard@gmail.com");
            request.AddParameter("subject", "Hello");
            request.AddParameter("text", message);
            request.Method = Method.POST;
            var abc = client.Execute(request);
            return abc;
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
                string[] lines = new string[2];
                for (int i = 0; i <= lines.Length; i++)
                {
                    if(await reader.ReadLineAsync() != null)
                    {
                        lines[i] = await reader.ReadLineAsync();
                    }
                    if(lines.Length == 2)
                    {
                        break;
                    }
                    
                }
                
                while(reader.Peek() >= 0) {
                    List<Part> PartsList = new List<Part>();
                    string date = "";
                    bool test = true;
                string CurrentOrder = "";
                string check = "";
                string OwnerList = "";
                string VesselList = "";
                string ShipyardList = "";
                string HullList = "";
                string BuyerList = "";
                while (reader.Peek() >= 0)
                {

                    string read = await reader.ReadLineAsync();
                    string[] data = read.Split(";");
                    CurrentOrder = data[0];
                    if (test && (CurrentOrder != "" || CurrentOrder != "."))
                    {
                        check = "temp";
                        test = false;
                    }
                    else if((CurrentOrder == "" || CurrentOrder == ".") && test==false)
                    {
                        check = "temp2";
                    }else if(CurrentOrder != "" || CurrentOrder != ".")
                    {
                        break;
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
                        Part TempPart = new Part
                        {
                            Name = data[9],
                            Spec = data[10],
                        };
                        PartsList.Add(TempPart);
                        if (data[11] != "" && data[11] != ".")
                        {
                            date = data[11];
                        }
                        else
                        {
                            date = "";
                        }
                        

                }
                test = true;
                    Order temp = new Order();
                    if (date == "" || date == "CANCELLED" || date == "NO RECORD" || date == ".")
                    {
                       temp = new Order
                        {
                            //  OrderId = int.Parse(data[0]),
                            Vessel_name = VesselList,
                            Shipyard = ShipyardList,
                            Owner = OwnerList,
                            HullNr = HullList,
                            // SalesId = int.Parse(data[5]),
                            Buyer = BuyerList,
                            DeliveryDate = DateTime.MinValue,
                            PartsOrdered = PartsList


                        };
                    }
                    else
                    {
                         temp = new Order
                        {
                            //  OrderId = int.Parse(data[0]),
                            Vessel_name = VesselList,
                            Shipyard = ShipyardList,
                            Owner = OwnerList,
                            HullNr = HullList,
                            // SalesId = int.Parse(data[5]),
                            Buyer = BuyerList,
                            DeliveryDate = DateTime.Parse(date),
                            PartsOrdered = PartsList


                        };
                    }

              
               
                orders.Add(temp);

                }
            }
            foreach(Order o in orders)
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
                double NrOfDays = (o.DeliveryDate - DateTime.Now).TotalDays;

                if (NrOfDays <= 30)
                {
                    o.DeliveryIsClose = "DeliverySoon";
                    mailmessage += "The order with order id: " + o.OrderId + "needs to get refreshed" + "\n";
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
