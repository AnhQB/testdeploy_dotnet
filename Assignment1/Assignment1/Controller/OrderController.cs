using Assignment1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    var data = context.Orders.ToList();
                    if (data == null)
                    {
                        return NotFound();
                    }
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    var data = context.Orders.ToList().FirstOrDefault(s => s.OrderId == id);
                    if (data == null)
                    {
                        return NotFound();
                    }
                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public IActionResult Put([FromBody]Order cate)
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    Order cate1 = context.Orders.ToList().FirstOrDefault(s => s.OrderId == cate.OrderId);
                   
                    if (cate1 == null)
                    {
                        return NotFound();
                    }
                    cate1.MemberId = cate.MemberId;
                    cate1.UnitPrice = cate.UnitPrice;
                    cate1.Quantity = cate.Quantity;
                    context.Orders.Update(cate1);
                    context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //  Search by name

        [HttpPost]
        public IActionResult Post( Order cate)
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    context.Orders.Add(cate);
                    context.SaveChanges();
                    
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    Order ORDER = context.Orders.ToList().FirstOrDefault(s => s.OrderId == id);
                    List<OrderDetail> ORDER1 = context.OrderDetails.ToList().FindAll(s => s.OrderId == id);
                    foreach (OrderDetail detail in ORDER1)
                    {
                        context.Remove(detail);
                    }
                    context.Orders.Remove(ORDER);
                    
                    context.SaveChanges();
                    //c2
                    //if (Get(id) == NotFound())
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    context.Categories.Remove(cate);
                    //}
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    
        
}
}
