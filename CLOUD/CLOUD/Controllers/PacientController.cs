using AutoMapper;
using CLOUD.Auth;
using CLOUD.DataBase;
using CLOUD.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CLOUD.Controllers;


[Route("[controller]")]
[ApiController]
public class PacientController:ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;
    
    public PacientController (IConfiguration configuration, IUserService userService,AppDbContext dbContext, IMapper mapper)
    {
        _mapper = mapper;
        _userService = userService;
        _dbContext = dbContext;
    }

    [Authorize]
    [HttpPost("/puls")]
    public async Task<ActionResult<PulsResult>> postPuls(PulsRequest pulsRequest)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == _userService.GetMyName());
        var pacient = await _dbContext.Pacienti.FirstOrDefaultAsync(u => u.User.Id == user.Id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }

        var addPuls = await _dbContext.Puls.AddAsync(new Puls
        {
            Created = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Pacient = pacient,
            Valoare = pulsRequest.Valoare
        });
        return Ok(addPuls);
    }
    
    [Authorize]
    [HttpPost("/temp")]
    public async Task<ActionResult<PulsResult>> postTemp(TempRequest tempRequest)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == _userService.GetMyName());
        var pacient = await _dbContext.Pacienti.FirstOrDefaultAsync(u => u.User.Id == user.Id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }

        var addTemperatura = await _dbContext.Temperatura.AddAsync(new Temperatura
        {
            Created = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Pacient = pacient,
            Valoare = tempRequest.Valoare
        });
        return Ok(addTemperatura);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Pacient>> UpdatePacient(PacientRequestUpdate pacientRequestUpdate, string id)
    {
        var pacient = await _dbContext.Pacienti
            .Include(J => J.Judet)
            .Include(u => u.User)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
        if (pacient != null)
        {
            pacient.User.Username = pacientRequestUpdate.Username;
            pacient.Nume = pacientRequestUpdate.Nume;
            pacient.Prenume = pacientRequestUpdate.Prenume;
            pacient.Varsta = pacientRequestUpdate.Varsta;
            pacient.CNP = pacientRequestUpdate.CNP;
            pacient.Judet = await _dbContext.Judete.FirstOrDefaultAsync(j => j.Jud == pacientRequestUpdate.Judet);
            pacient.Localitate = pacientRequestUpdate.Localitate;
            pacient.Strada = pacientRequestUpdate.Strada;
            pacient.Numar = pacientRequestUpdate.Numar;
            pacient.Telefon = pacientRequestUpdate.Telefon;
            pacient.Email = pacientRequestUpdate.Email;
            pacient.Profesie = pacientRequestUpdate.Profesie;
            pacient.LocDeMunca = pacientRequestUpdate.LocDeMunca;
            await _dbContext.SaveChangesAsync();
            return Ok(pacient);
        }

        return Ok();
    }

    [Authorize]
    [HttpPost("/umiditate")]
    public async Task<ActionResult<PulsResult>> postUmiditate(UmiditateRequest umiditateRequest)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == _userService.GetMyName());
        var pacient = await _dbContext.Pacienti.FirstOrDefaultAsync(u => u.User.Id == user.Id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }
        

        var addUmiditate = await _dbContext.Umiditate.AddAsync(new Umiditate
        {
            Created = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Pacient = pacient,
            Valoare = umiditateRequest.Valoare
        });
        return Ok(addUmiditate);
    }
    
    [Authorize]
    [HttpGet("/umiditate")]
    public async Task<ActionResult<ActionResult<UmiditateBase>>> getUmiditate()
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == _userService.GetMyName());
        var pacient = await _dbContext.Pacienti.FirstOrDefaultAsync(u => u.User.Id == user.Id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }
        var um = await _dbContext.Umiditate.Where(u => u.Pacient.Id == pacient.Id).OrderBy(u => u.Created).ToListAsync();
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
    [HttpGet("/temperatura")]
    public async Task<ActionResult<ActionResult<TempBase>>> getTemp()
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == _userService.GetMyName());
        var pacient = await _dbContext.Pacienti.FirstOrDefaultAsync(u => u.User.Id == user.Id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }
        var temps = await _dbContext.Temperatura.Where(t => t.Pacient.Id == pacient.Id).OrderBy(t => t.Created).ToListAsync();
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
    [HttpGet("/puls")]
    public async Task<ActionResult<PulsBase>> getPuls()
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == _userService.GetMyName());
        var pacient = await _dbContext.Pacienti.FirstOrDefaultAsync(u => u.User.Id == user.Id);
        if (pacient == null)
        {
            throw new ArgumentException("Pacient not found!");
        }
        
        var pulsuri = await _dbContext.Puls.Where(p => p.Pacient.Id == pacient.Id).OrderBy(p => p.Created).ToListAsync();
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
    
  

}