using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.DAL.Context;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using(var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using(var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using(var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if(values == null)
                {
                    return NotFound();
                }
                return Ok(values);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null) return NotFound();
                context.Remove(values); context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult VisitorUpdate(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorId);  
                if(values == null) return NotFound();
                values.Name = visitor.Name;
                values.Surname = visitor.Surname;
                values.City = visitor.City;
                values.Mail = visitor.Mail;
                values.Country = visitor.Country;
                context.Update(values);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
