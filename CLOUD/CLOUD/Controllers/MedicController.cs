using AutoMapper;
using CLOUD.DataBase;
using CLOUD.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLOUD.Controllers;

[Route("[controller]")]
[ApiController]
public class MedicController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;

    public MedicController(IConfiguration configuration, IUserService userService,AppDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _configuration = configuration;
        _userService = userService;
        _dbContext = dbContext;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Pacient>> getPacientiMedic()
    {
        var medic = await _dbContext.Medici.FirstOrDefaultAsync(u => u.User.Username == _userService.GetMyName());
        var pacienti = await _dbContext.MedicPacienti
            .Where(mp => mp.Medic == medic)
            .Include(p => p.Pacient)
            .Include(j => j.Pacient.Judet)
            .ToListAsync();
       
        return Ok(pacienti);
    }
}