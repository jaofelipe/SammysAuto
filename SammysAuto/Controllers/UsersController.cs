using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
namespace SammysAuto.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(string option=null, string search=null)
        {
            var users = _db.Users.ToList();

            if (search != null)
            {
                switch (option)
                {
                    case "email": users = _db.Users.Where(m => m.Email.ToLower().Contains(search.ToLower())).ToList(); break;
                    case "name": users = _db.Users.Where(m => m.FirstName.ToLower().Contains(search.ToLower())
                            || m.LastName.ToLower().Contains(search.ToLower())).ToList(); break;
                    case "phone": users = _db.Users.Where(m => m.PhoneNumber.ToLower().Contains(search.ToLower())).ToList(); break;
                    default:
                        break;
                }
            }
            
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();

        }
    }
}