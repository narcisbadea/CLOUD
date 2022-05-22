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

    [HttpGet("/pacienti")]
    [Authorize]
    public async Task<ActionResult<Pacient>> getPacientiMedic()
    {
        var medic = await _dbContext.Medici.FirstOrDefaultAsync(u => u.User.Username == _userService.GetMyName());
        var pacienti = await _dbContext.MedicPacienti
            .Where(mp => mp.Medic == medic)
            .Include(p => p.Pacient)
            .Include(j => j.Pacient.Judet)
            .Include(u => u.Pacient.User)
            .ToListAsync();
       
        return Ok(pacienti);
    }


    [Authorize]
    [HttpGet("/puls/{id}")]
    public async Task<ActionResult<PulsBase>> getPuls(string id)
    {
        var pulsuri = await _dbContext.Puls.Where(p => p.Pacient.Id.ToString() == id).OrderBy(p => p.Created).ToListAsync();
        List<PulsBase> pb = new List<PulsBase>();
        foreach (var puls in pulsuri)
        {
            pb.Add(new PulsBase
            {
                Created = puls.Created.Hour.ToString()+":"+puls.Created.Minute.ToString(),
                Valoare = puls.Valoare
            });
        }

        return Ok(pb);
    }

    [Authorize]
    [HttpGet("/temperatura/{id}")]
    public async Task<ActionResult<ActionResult<TempBase>>> getTemp(string id)
    {
        var temps = await _dbContext.Temperatura.Where(t => t.Pacient.Id.ToString() == id).OrderBy(t => t.Created).ToListAsync();
        List<TempBase> tb = new List<TempBase>();
        foreach (var temp in temps)
        {
            tb.Add(new TempBase
                {
                    Created = temp.Created.Hour.ToString()+":"+temp.Created.Minute.ToString(),
                    Valoare = temp.Valoare
                });
        }

        return Ok(tb);
    }

    [Authorize]
    [HttpGet("/umiditate/{id}")]
    public async Task<ActionResult<ActionResult<UmiditateBase>>> getUmiditate(string id)
    {
        var um = await _dbContext.Umiditate.Where(u => u.Pacient.Id.ToString() == id).OrderBy(u => u.Created).ToListAsync();
        List<UmiditateBase> ub = new List<UmiditateBase>();
        foreach (var umiditate in um)
        {
            ub.Add(new UmiditateBase
            {
                Created = umiditate.Created.Hour.ToString()+":"+umiditate.Created.Minute.ToString(),
                Valoare = umiditate.Valoare
            });
        }

        return Ok(ub);
    }

    [Authorize]
    [HttpDelete("/remove-pacient/{id}")]
    public async Task<ActionResult<Pacient>> deletePacient(string id)
    {
        var pacient = await _dbContext.Pacienti.Include(p => p.User).FirstOrDefaultAsync(p => p.Id.ToString() == id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }

        var user = await _dbContext.Users.FirstOrDefaultAsync(u => pacient.User.Id.ToString() == u.Id.ToString());
        if (user == null)
        {
            throw new ArgumentException("User not found!");
        }

       // _dbContext.Pacienti.Remove(pacient);
        _dbContext.Users.Remove(user);
        
        await _dbContext.SaveChangesAsync();
        return Ok(pacient);
    }

    [Authorize]
    [HttpGet("/pacient/{id}")]
    public async Task<ActionResult<Pacient>> getPacient(string id)
    {
        var pacient = await _dbContext.Pacienti
            .Include(u => u.User)
            .Include(j => j.Judet)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }

        return Ok(pacient);
    }
}