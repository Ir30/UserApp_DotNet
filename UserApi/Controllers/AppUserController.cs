using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using UserApi.DataModelLayer;
using UserApi.Service;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : Controller
    {
        private readonly UserDbContext dbContext;

        public AppUserController(UserDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //AddAppuser
        [HttpPost]
        public async Task<IActionResult> AddAppuser([FromBody] Appuser appuser)
        {
            await dbContext.app_user.AddAsync(appuser);
            await dbContext.SaveChangesAsync();
            return Ok("{\"status\":\"success\"}");
        }

        // GetAllAppuser
        [HttpGet]
        public async Task<IActionResult> GetAllAppuser()
        {
            var users = await dbContext.app_user.ToListAsync();
            if (users != null)
            {
                return Ok(users);
            }
            else
            {
                return NotFound("No records found");
            }
        }




        //GetAllAppuserByUserType
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAllAppuserByUserType([FromRoute] int id)
        {
            var users = await dbContext.app_user.Where(e => e.UserTypeId == id).ToListAsync();
            if (users != null)
            {
                return Ok(users);
            }
            else { return NotFound("Record not found"); }
        }

        //EditAppuser
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> EditAppuser([FromRoute] int id, [FromBody] Appuser appuser)
        {
            var user = await dbContext.app_user.SingleOrDefaultAsync(option => option.AppUserId == id);
            if(user != null)
            {
                user.UserTypeId = appuser.UserTypeId;
                user.UserName = appuser.UserName;
                user.Password = appuser.Password;
                user.IsActive = appuser.IsActive;
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            else { return NotFound($"User with id: {id} is not found"); }
        }

        //DeleteAppuser
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAppuser([FromRoute] int id)
        {
            var user  = await dbContext.app_user.FirstOrDefaultAsync(option => option.AppUserId == id);
            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok(user);
            }
            else
            {
                return NotFound($"User with id: {id} is not found");
            }
        }



    }
}
