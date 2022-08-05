using AutoMapper;
using MB.MCPP.HappyBusinessLam.Dtos.Buyers;
using MB.MCPP.HappyBusinessLam.Entities;
using MB.MCPP.HappyBusinessLam.EntityframeworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MB.MCPP.HappyBusinessLam.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BuyersController : ControllerBase
    {

        #region Data and Constructors

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BuyersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #endregion

        #region Services
        [HttpGet]
        public  async Task<List<BuyerListDto>> GetBuyersList()
        {
            var buyers = await _context
                             .Buyers
                             .ToListAsync();

            var buyerDtos = _mapper.Map<List<BuyerListDto>>(buyers);

            return buyerDtos;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyerDetailsDto>> GetBuyerDetailsById(int id)
        {
            var buyer = await _context
                           .Buyers
                           .FindAsync(id);

            if(buyer == null)
            {
                return NotFound();
            }

            var buyerDto = _mapper.Map<BuyerDetailsDto>(buyer);

            return buyerDto;
        }

        
        [HttpPost]
        public async Task CreateBuyer([FromBody] BuyerDto buyerDto)
        {
            var buyer = _mapper.Map<Buyer>(buyerDto);

            await _context.AddAsync(buyer);
            await _context.SaveChangesAsync();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> EditBuyer(int id, [FromBody] BuyerDto buyerDto)
        {
            if(id != buyerDto.Id)
            {
                return BadRequest();
            }

            var buyer = _mapper.Map<Buyer>(buyerDto);

            try
            {
                _context.Update(buyer);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new DbUpdateException($"Couldn't Update Buyer ID=[{id}]", ex);
            }

            

            return Ok();
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var buyer = await _context.Buyers.FindAsync(id);

            if(buyer == null)
            {
                return NotFound();
            }

            _context.Remove(buyer);
            await _context.SaveChangesAsync();

            return Ok();
        }
        #endregion
    }
}
