using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Pharmacists;
using MB.MCPP.HappyBusinessLam.Entities;
using MB.MCPP.HappyBusinessLam.EntityframeworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MB.MCPP.HappyBusinessLam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PharmacistsController : ControllerBase
    {
        #region Data and Constructor
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public PharmacistsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services
        [HttpGet]
        public async Task<List<PharmacistListDto>> GetPharmacistsList()
        {
            var pharmacists = await _context
                                         .Pharmacists
                                         .ToListAsync();

            var pharmacistDtos = _mapper.Map<List<PharmacistListDto>>(pharmacists);

            return pharmacistDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PharmacistDetailsDto>> GetPharmacistById(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);

            if(pharmacist == null)
            {
                return NotFound();
            }

            var pharmacistDto = _mapper.Map<PharmacistDetailsDto>(pharmacist);

            return pharmacistDto;
        }

        [HttpPost]
        public async Task<int> CreatePharmacist([FromBody] PharmacistDto pharmacistDto)
        {
            var pharmacist = _mapper.Map<Pharmacist>(pharmacistDto);

            await _context.AddAsync(pharmacist);
            await _context.SaveChangesAsync();

            return pharmacist.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditPharmacist(int id, [FromBody] PharmacistDto pharmacistDto)
        {
            if(id != pharmacistDto.Id)
            {
                return BadRequest();
            }

            var pharmacist = _mapper.Map<Pharmacist>(pharmacistDto);

            try
            {
                _context.Update(pharmacist);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new DbUpdateException($"Couldn't Udate Pharmacist by ID=[{id}]", ex);
            }
            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePharmacist(int id)
        {
            var pharmacist = await _context.Pharmacists.FindAsync(id);

            if(pharmacist == null)
            {
                return NotFound();
            }

            _context.Remove(pharmacist);
            await _context.SaveChangesAsync();

            return Ok();

        } 
        #endregion
    }
}
