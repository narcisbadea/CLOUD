using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using CLOUD.UserService;
using CLOUD.DataBase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CLOUD.Auth
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly AppDbContext _dbContext;

        public AuthController(IConfiguration configuration, IUserService userService,AppDbContext dbContext)
        {
            _configuration = configuration;
            _userService = userService;
            _dbContext = dbContext;
        }

        [HttpGet, Authorize]
        public IActionResult GetMe()
        {
           var userName = _userService.GetMyName();
           return Ok(new
           {
               userName
           });

            //var userName = User?.Identity?.Name;
            //var userName2 = User.FindFirstValue(ClaimTypes.Name);
            //var role = User.FindFirstValue(ClaimTypes.Role);
            //return Ok(new { userName, userName2, role });
        }
        
        [HttpGet("Date")]
        [Authorize]
        public async Task<List<User>> GetByDate()
        {
            var li = await _dbContext.Users.Where(u => u.Created.Hour == 15) .ToListAsync();
            return li;
        }

        [HttpPost("register/medic/{username}")]
        public async Task<ActionResult<Medic>> RegisterMedic(string username,MedicRequest medicRequest)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            var medic = new Medic
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                TipMedic = medicRequest.TipMedic,
                Updated = DateTime.UtcNow,
                User = user
            };
            var result = await _dbContext.Medici.AddAsync(medic);
            await _dbContext.SaveChangesAsync();
            return Ok(result.Entity);
        }

        [Authorize]
        [HttpPost("register/pacient")]
        public async Task<ActionResult<Pacient>> RegisterPacient(PacientRequest pacientRequest)
        {
            CreatePasswordHash(pacientRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            var user = new User
            {
                Username = pacientRequest.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            
            var pacient = new Pacient
            {
                User = user,
                Id = Guid.NewGuid(),
                CNP = pacientRequest.CNP,
                Created = DateTime.UtcNow,
                Email = pacientRequest.Email,
                Judet = await _dbContext.Judete.FirstOrDefaultAsync(j => j.Jud == pacientRequest.Judet),
                Localitate = pacientRequest.Localitate,
                LocDeMunca = pacientRequest.LocDeMunca,
                Numar = pacientRequest.Numar,
                Strada = pacientRequest.Strada,
                Nume = pacientRequest.Nume,
                Prenume = pacientRequest.Prenume,
                Updated = DateTime.UtcNow,
                Profesie = pacientRequest.Profesie,
                Telefon = pacientRequest.Telefon,
                Varsta = pacientRequest.Varsta
            };
            var result = await _dbContext.Pacienti.AddAsync(pacient);
            await _dbContext.SaveChangesAsync();

            var med = await _dbContext.Medici.FirstOrDefaultAsync(m => m.User != null && _userService.GetMyName() == m.User.Username); 
            var medicPacient = new MedicPacienti
            {
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow,
                Medic = med,
                Pacient = pacient
            };

            await _dbContext.MedicPacienti.AddAsync(medicPacient);
            await _dbContext.SaveChangesAsync();
            return Ok(result.Entity);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRequest request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            
            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Id = Guid.NewGuid(),
                Created = DateTime.UtcNow,
                Updated = DateTime.UtcNow
            };
            var result = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return Ok(result.Entity);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserRequest request)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Username == request.Username);
            if (user?.Username != request.Username)
            {
                return BadRequest("User not found.");
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Wrong password.");
            }

            var role = "medic";
            var isMedic = await _dbContext.Medici.FirstOrDefaultAsync(m => m.User != null && m.User.Id == user.Id);
            if (isMedic == null)
            {
                role = "pacient";
            }
            string token = CreateToken(user);
            return Ok(new
            {
                token,
                role
            });
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
        
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
