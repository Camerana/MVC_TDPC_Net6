using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_TDPC_Net6.DB;
using MVC_TDPC_Net6.DB.Entities;
using MVC_TDPC_Net6.Models;
using System.Diagnostics;

namespace MVC_TDPC_Net6.Controllers
{
    /*
     - creare DB per l'identity AuthDB
     - eseguire script DBscript.txt
     - creare classe User : IdentityUser
     - creare classe Role : IdentityRole
     - creare classe AuthDBContext : IdentityDbContext<User, Role, string>
     - aggiungere la connection string in appsettings.json
     - registrare i servizi in Program:

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthDB")));

        //User Management
        builder.Services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<AuthDBContext>()
            .AddDefaultTokenProviders();
        builder.Services.AddScoped<SignInManager<User>>();
        builder.Services.AddScoped<UserManager<User>>();
        builder.Services.AddScoped<RoleManager<Role>>();

     - aggiungere in Program:
         app.UseAuthentication();
         app.UseAuthorization();
     - creare la classe LoginModel
     - creare la view Login.cshtml
     - copiare i link di navigazione dal Layout.cshtml
     - in HomeController: 
         - fare dependency injection di:
             private SignInManager<User> signInManager;
             private UserManager<User> userManager;
             private UserDBContext dbContext;
             public HomeController(SignInManager<User> signInManager,
                 UserManager<User> userManager,
                 UserDBContext dbContext)
             {
                 this.signInManager = signInManager;
                 this.userManager = userManager;
                 this.dbContext = dbContext;
             }
         - creare l'endpoint public IActionResult Login()
         - creare l'endpoint public async Task<IActionResult> Login(LoginModel loginModel)
         - creare l'endpoint public async Task<IActionResult> Logout()
      */
    public class HomeController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private AuthDBContext dbContext;
        public HomeController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            AuthDBContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ButtonPage()
        {
            return View();
        }

        [Authorize]
        public IActionResult HiddenPage()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AdminPage()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            try
            {
                User user = await userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Redirect("Index");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (signInManager.IsSignedIn(User))
                {
                    await signInManager.SignOutAsync();
                }
            }
            catch (Exception ex)
            {
            }
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}