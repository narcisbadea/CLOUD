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
        var pulsuri = await _dbContext.Puls.Where(p => p.Pacient.Id.ToString() == id).ToListAsync();
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

    /*[Authorize]
    [HttpGet("/puls")]
    public async Task<ActionResult<ActionResult<PulsResult>>> getPuls()
    {
        var medic = await _dbContext.Medici.FirstOrDefaultAsync(u => u.User.Username == _userService.GetMyName());
        var pacienti = await _dbContext.MedicPacienti
            .Where(mp => mp.Medic == medic)
            .Include(p => p.Pacient)
            .Include(j => j.Pacient.Judet)
            .Include(u => u.Pacient.User)
            .ToListAsync();
        List<PulsResult> PR = new List<PulsResult>();
        foreach (var pacient in pacienti)
        {
            var forAdd = new PulsResult();
            forAdd.ID_Pacient = pacient.Pacient.Id;
            var puls = await _dbContext.Puls.Where(p => p.Pacient.Id.ToString() == pacient.Pacient.Id.ToString()).ToListAsync();
            List<PulsBase> Pulsuri = new List<PulsBase>();
            foreach (var p in puls)
            {
                PulsBase pb = new PulsBase
                {
                    Created = p.Created.Day.ToString()+"."+p.Created.Month.ToString()+"."+p.Created.Year.ToString()+" "+p.Created.Hour.ToString()+":"+p.Created.Minute.ToString(),
                    Valoare = p.Valoare
                };
                forAdd.Pulsuri.Add(pb);
            }
            PR.Add(forAdd);
        }

        return Ok(PR);

    }*/

    /*[HttpGet("/puls/{id}")]
    public async Task<ActionResult<PulsResult>> getPuls(string id)
    {
        var puls = await _dbContext.Puls.Where(p => p.Pacient.Id.ToString() == id).ToListAsync();
        var pulsResult = new List<PulsResult>();
        foreach (var p in puls)
        {
            pulsResult.Add(new PulsResult
            {
                Created = p.Created,
                Valoare = p.Valoare
            });
        }
        return Ok(pulsResult);
    }*/
    [HttpGet("/temperatura/{id}")]
    public async Task<ActionResult<PulsResult>> getTemperatura(string id)
    {
        var temperatura = await _dbContext.Temperatura.Where(p => p.Pacient.Id.ToString() == id).ToListAsync();
        var temperaturaResult = new List<TemperaturaResult>();
        foreach (var p in temperatura)
        {
            temperaturaResult.Add(new TemperaturaResult
            {
                Created = p.Created,
                Valoare = p.Valoare
            });
        }
        return Ok(temperaturaResult);
    }
    
    [HttpGet("/umiditate/{id}")]
    public async Task<ActionResult<UmiditateResult>> getUmiditate(string id)
    {
        var umiditate = await _dbContext.Umiditate.Where(p => p.Pacient.Id.ToString() == id).ToListAsync();
        var umiditateResult = new List<UmiditateResult>();
        foreach (var p in umiditate)
        {
            umiditateResult.Add(new UmiditateResult
            {
                Created = p.Created,
                Valoare = p.Valoare
            });
        }
        return Ok(umiditateResult);
    }
}