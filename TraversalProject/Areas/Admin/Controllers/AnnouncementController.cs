using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using TraversalProject.Areas.Admin.Models;

namespace TraversalProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index() 
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.GetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto model) 
        {
            if(ModelState.IsValid)
            {
                _announcementService.Add(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return Redirect("/Admin/Announcement/Index");


            }
            return View();
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            {
                var values = _announcementService.GetById(id);
                _announcementService.Delete(values);
                return Redirect("/Admin/Announcement/Index");
            }
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDto>(_announcementService.GetById(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDto model)
        {
            if(ModelState.IsValid)
            {
                _announcementService.Update(new Announcement
                {
                    AnnouncementId = model.AnnouncementId,
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return Redirect("/Admin/Announcement/Index");
            }
            return View(model);
        }
    }
}
