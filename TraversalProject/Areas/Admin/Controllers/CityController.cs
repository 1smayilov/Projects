using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalProject.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.GetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            try
            {
                destination.Status = true;
                _destinationService.Add(destination);
                var values = JsonConvert.SerializeObject(destination);
                return Json(values);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Xəta: {ex.Message}");
            }
        }

        public IActionResult GetById(int DestinationId)
        {
            var values = _destinationService.GetById(DestinationId);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.GetById(id);
            _destinationService.Delete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.Update(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }


        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityId = 1,
        //        CityName = "Bakı",
        //        CityCountry = "Azərbaycan"
        //    },

        //    new CityClass
        //    {
        //        CityId = 2,
        //        CityName = "Roma",
        //        CityCountry = "Italiya"
        //    },

        //    new CityClass
        //    {
        //        CityId = 3,
        //        CityName = "London",
        //        CityCountry = "Ingiltərə"
        //    }
        //};
    }
}
