using AutoMapper;
using CourseApiData.DTOs.Group;
using CourseApiData.Entities;
using CourseApiService.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupsController(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository; 
            _mapper = mapper;
        }

        // GET: api/<GroupsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Group> groups = _groupRepository.GetAll();
            List<GroupGetDto> data = _mapper.Map<List<GroupGetDto>>(groups);
            return Ok(data);
        }

        // GET api/<GroupsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Group group = _groupRepository.GetById(id);
            if (group is null) return NotFound();
            GroupGetDto data = _mapper.Map<GroupGetDto>(group);
            return Ok(data);
        }

        // POST api/<GroupsController>
        [HttpPost]
        public IActionResult Post([FromForm] GroupPostDto entity)
        {
            try
            {
                Group group = _mapper.Map<Group>(entity); 
                _groupRepository.Add(group); 
                return CreatedAtAction(nameof(Get), new
                {
                    Status = "Success",
                    Message = "Successfully created",
                });
            }
            catch (Exception ex )
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                    Status = "Error"
                });
            }
        }

        // PUT api/<GroupsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] GroupPostDto entity)
        {
            try
            {
                Group group = _mapper.Map<Group>(entity);
                _groupRepository.Update(id, group);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = "Error",
                    Message = ex.Message,
                });
            }
        }

        // DELETE api/<GroupsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Group group = _groupRepository.GetById(id);
                if(group is null) return NotFound();
                _groupRepository.Delete((group));
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = "Error",
                    Message = ex.Message,
                });
            }
        }
    }
}
