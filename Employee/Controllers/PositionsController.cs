using AutoMapper;
using EmployeeApiData.DTOs.Positions;
using EmployeeApiData.Entities;
using EmployeeApiService.Abstract;
using EmployeeApiService.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IPositionsRepository _positionsRepository;
        private readonly IMapper _mapper; 

        public PositionsController(IPositionsRepository positionsRepository, IMapper mapper)
        {
            _positionsRepository = positionsRepository;
            _mapper = mapper;
            
        }

        // GET: api/<PositionsController>
        [HttpGet]
        public IActionResult Get()
        {
            List<Positions> positions = _positionsRepository.GetAll();
            //List<PositionsGetDTO> data = new List<PositionsGetDTO>();
            //foreach(Positions position in positions)
            //{
            //    data.Add(new PositionsGetDTO
            //    {
            //        Id = position.Id,
            //        Name = position.Name,
            //    });
            //}
            List<PositionsGetDTO> data = _mapper.Map<List<PositionsGetDTO>>(positions);

            return Ok(positions);
        }

        // GET api/<PositionsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Positions positions = _positionsRepository.GetById(id);
            if(positions == null) return NotFound();
            //PositionsGetDTO data = new PositionsGetDTO
            //{
            //    Id = positions.Id,
            //    Name = positions.Name
            //};
            PositionsGetDTO data = _mapper.Map<PositionsGetDTO>(positions);
            return Ok(positions);
        }

        // POST api/<PositionsController>
        [HttpPost]
        public IActionResult Post([FromForm] PositionsPostDTO entity)
        {
            try
            {
                //Positions positions = new Positions
                //{
                //    Name = entity.Name
                //};
                Positions positions = _mapper.Map<Positions>(entity);
                _positionsRepository.Add(positions);
                return CreatedAtAction(nameof(Get), new
                {
                    Status = "Success",
                    Message = "Successfully created"
                });
            }
            catch (Exception ex)
            {
               return BadRequest(new
                {
                    Status = "Error",
                    Message = ex.Message,
                });
            }
        }

        // PUT api/<PositionsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] PositionsPostDTO entity)
        {
            try
            {
                //Positions positions = new Positions
                //{
                //    Name = entity.Name
                //};
                Positions positions = _mapper.Map<Positions>(entity);
                _positionsRepository.Update(id, positions);
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

        // DELETE api/<PositionsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Positions positions = _positionsRepository.GetById(id);
                if (positions == null) return NotFound();
                _positionsRepository.Delete(positions);
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
