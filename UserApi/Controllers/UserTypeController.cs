using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserApi.DataModelLayer;
using UserApi.Service;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : Controller
    {
        private readonly UserDbContext dbContext;

        public UserTypeController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //AddUsertype
        [HttpPost]
        public async Task<IActionResult> AddUsertype([FromBody] Usertype usertype)
        {
            if (usertype != null)
            {
                await dbContext.user_type.AddAsync(usertype);
                await dbContext.SaveChangesAsync();
                return Ok("{\"status\":\"success\"}");
            }
            else
            {
                return BadRequest();
            }
        }


        //GetAllUsertype
        [HttpGet]

        public async Task<IActionResult> GetAllUsertype()
        {
            var userTypes = await dbContext.user_type.Include(opt=> opt.Appuser).ToListAsync();
            if (userTypes != null)
            {
                return Ok(userTypes);
            }
            else
            {
                return NotFound("No records found");
            }
        }

        //EditUsertype
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditUsertype([FromRoute] int id, [FromBody] Usertype usertype)
        {
            var appUserType = await dbContext.user_type.SingleOrDefaultAsync(option => option.UserTypeId == id);
            if (appUserType != null)
            {
                appUserType.UserType = usertype.UserType;
                appUserType.Description = usertype.Description;
                appUserType.IsActive = usertype.IsActive;
                await dbContext.SaveChangesAsync();
                return Ok(appUserType);
            }
            else { return NotFound($"User Type with id: {id} is not found"); }
        }
    }
}