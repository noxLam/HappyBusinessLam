using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Drugs;
using MB.MCPP.HappyBusinessLam.Entities;
using MB.MCPP.HappyBusinessLam.EntityframeworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MB.MCPP.HappyBusinessLam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DrugsController : ControllerBase
    {

        #region Data and Constructor
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DrugsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        #region Services
        [HttpGet]
        public async Task<List<DrugListDto>> GetDrugsList()
        {
            var drugs = await _context
                             .Drugs
                             .ToListAsync();

            var drugDtos = _mapper.Map<List<DrugListDto>>(drugs);

            return drugDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DrugDetailsDto>> GetDrugById(int id)
        {
            var drug = await _context
                                  .Drugs
                                  .Include(d => d.Classification)
                                  .SingleOrDefaultAsync(d => d.Id == id);

            if(drug == null)
            {
                return NotFound();
            }

            var drugDto = _mapper.Map<DrugDetailsDto>(drug);

            return drugDto;
        }

        [HttpPost]
        public async Task<int> CreateDrug([FromBody] DrugDto drugDto)
        {
            var drug = _mapper.Map<Drug>(drugDto);

            await _context.AddAsync(drug);
            await _context.SaveChangesAsync();

            return drug.Id;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditDrug(int id, [FromBody] DrugDto drugDto)
        {
            if(id != drugDto.Id)
            {
                return BadRequest();
            }

            var drug = _mapper.Map<Drug>(drugDto);

            try
            {
                _context.Update(drug);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new DbUpdateException($"Couldn't Update Drug ID=[{id}]", ex);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDrug(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);

            if(drug == null)
            {
                return NotFound();
            }

            _context.Remove(drug);
            await _context.SaveChangesAsync();

            return Ok();
        } 
        #endregion
    }
}
