namespace WebAppMVC.Controllers
{
    public class UserController : Controller
    {
        private UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        //User page (/User)
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        //Create page (User/Create)
        public IActionResult Create()
        {
            return View();
        }

        //User with {id} details page (User/Details/{id})
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            return View(user);
        }

        //User with {id} delete page (User/Delete/{id})
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            return View(user);
        }

        //User with {id} edit page (User/Edit/{id})
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            return View(user);
        }

        //User create (User/Create)
        [HttpPost]
        public async Task<IActionResult> Create([Bind("UserId,FirstName,LastName,Email")] UserModel user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //User delete with {id} (User/Delete/{id})
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            if (userToDelete == null)
            {
                return NotFound();
            }

            _context.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //User delete with {id} (User/Delete/{id})
        [HttpPost]
        [ActionName("Edit")]
        public async Task<IActionResult> Update(int id, [Bind("UserId,FirstName,LastName,Email")] UserModel user)
        {
            var userToUpdate = await _context.Users.FindAsync(id);
            if (userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}