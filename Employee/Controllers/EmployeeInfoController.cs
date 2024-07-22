using AutoMapper;
using EmployeeApiData.DTOs.EmployeeInfo;
using EmployeeApiData.Entities;
using EmployeeApiService.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeInfoController : ControllerBase
    {
        private readonly IFileRepository _fileRepository;
        private readonly IEmployeeInfoRepository _employeeInfoRepository;
        private readonly IMapper _mapper;
        private IWebHostEnvironment _env;
        public EmployeeInfoController(IFileRepository fileRepository, 
            IEmployeeInfoRepository employeeInfoRepository, 
            IMapper mapper,
            IWebHostEnvironment env)
        {
            _env = env;
            _fileRepository = fileRepository;
            _employeeInfoRepository = employeeInfoRepository;
            _mapper = mapper;
        }
        // GET: api/<EmployeeInfoController>
        [HttpGet]
        public IActionResult Get()
        {
            List<EmployeeInfo> employeeInfo = _employeeInfoRepository.GetAll();
            List<EmployeeInfoGetDTO> data = new List<EmployeeInfoGetDTO>();
            return Ok(data);
        }

        // GET api/<EmployeeInfoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            EmployeeInfo employeeInfo = _employeeInfoRepository.GetById(id);
            if (employeeInfo == null) return NotFound(); 
            EmployeeInfoGetDTO data = _mapper.Map<EmployeeInfoGetDTO>(employeeInfo);
            return Ok();
        }

        // POST api/<EmployeeInfoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] EmployeeInfoPostDTO entity)
        {
            try
            {
                EmployeeInfo employeeInfo = _mapper.Map<EmployeeInfo>(entity);
                if(entity.File != null)
                {
                    employeeInfo.Image = await _fileRepository.FileUpload(_env.WebRootPath,"employeeInfo",entity.File);
                }
                _employeeInfoRepository.Add(employeeInfo);
                return CreatedAtAction(nameof(Get), new
                {
                    Status = "Sucess",
                    Message = "Successfully created"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Status = "error",
                    Message = ex.Message
                });
            }
        }

        // PUT api/<EmployeeInfoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] EmployeeInfoPostDTO entity)
        {
            try
            {
                EmployeeInfo employeeInfo = _mapper.Map<EmployeeInfo>(entity);
                if (entity.File != null)
                {
                    _fileRepository.FileDelete(_env.WebRootPath, "eployeeInfo", employeeInfo.Image);
                    employeeInfo.Image = await _fileRepository.FileUpload(_env.WebRootPath, "employeeinfo", entity.File);
                }
                _employeeInfoRepository.Update(id, employeeInfo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                    Status = "error",
                });
            }
        }

        // DELETE api/<EmployeeInfoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                EmployeeInfo employeeInfo = _employeeInfoRepository.GetById(id);
                if (employeeInfo == null) return NotFound();
                _fileRepository.FileDelete(_env.WebRootPath, "employeeInfo", employeeInfo.Image);
                _employeeInfoRepository.Delete(employeeInfo);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Message = ex.Message,
                    Status = "error",
                });
            }
        }
    }
}
