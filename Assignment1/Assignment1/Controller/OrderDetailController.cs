using Assignment1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    var data = context.OrderDetails.ToList();
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
                    var data = context.OrderDetails.ToList().FirstOrDefault(s => s.OrderId == id);
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
        public IActionResult Put(OrderDetail cate)
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {
                    OrderDetail cate1 = context.OrderDetails.ToList().FirstOrDefault(s => s.OrderId == cate.OrderId);
                    if (cate1 == null)
                    {
                        return NotFound();
                    }
                    cate1.ProductId = cate.ProductId;
                    cate1.UnitPrice = cate.UnitPrice;
                    cate1.Quantity = cate.Quantity;
                    context.OrderDetails.Update(cate1);
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
        public IActionResult Post(OrderDetail orderDetail)
        {
            try
            {
                try
                {
                    using (Assg1Prn231Context context = new Assg1Prn231Context())
                    {
                        context.OrderDetails.Add(new OrderDetail
                        {
                            UnitPrice = orderDetail.UnitPrice,
                            Quantity = orderDetail.Quantity,
                            Discount = orderDetail.Discount,
                            OrderId = orderDetail.OrderId,
                            ProductId = orderDetail.ProductId
                        });
                        context.SaveChanges();
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("id")]
        public IActionResult Delete(int id,int productid)
        {
            try
            {
                using (Assg1Prn231Context context = new Assg1Prn231Context())
                {

               OrderDetail ORDER1 = context.OrderDetails.ToList().FirstOrDefault(s => s.OrderId == id&&s.ProductId==productid);
                    if(ORDER1 == null)
                    {
                        return NotFound();
                    }
                   
                        context.Remove(ORDER1);
                    
                  
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
