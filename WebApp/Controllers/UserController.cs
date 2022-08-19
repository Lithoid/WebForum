using BL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using System.Security.Claims;
using WebApp.Models;



namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;

        public UserController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                UserViewModel user = UserViewModel.GetUserByCred(_userRepository, model.Email, model.Password);
                

                if (user == null)
                {

                    user = new UserViewModel();
                    user.Id = Guid.NewGuid();
                    string userID = user.Id.ToString();
                    var token =  UserViewModel.GenerateEmailConfirmationToken(user);
                    var callbackUrl = Url.Action(
                        "ConfirmEmail",
                        "User",
                        new { userId = userID, token = token },
                        protocol: HttpContext.Request.Scheme);

                    EmailManager emailService = new EmailManager();
                    await emailService.SendEmailAsync(model.Email, "Confirm your account",
                        $"Confirm registration by clicking on link: <a href='{callbackUrl}'>link</a>");

                    
                    var role = RoleViewModel.GetMemberRole(_roleRepository);
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.Name = model.Name;
                    user.RoleId = role.Id;
                    user.RoleName = role.Name;
                    await _userRepository.AddItemAsync(user);
                   

                    return RedirectToAction("Confirm", new { message = "Check your email and confirm email" });
                }
                ModelState.AddModelError("", "User currently exists");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Confirm", new { message = $"User id or token is null" });
            }
            var user = UserViewModel.GetUserById(Guid.Parse(userId),_userRepository);
            if (user == null)
            {
                return RedirectToAction("Confirm", new { message = $"User does not exists" });
            }
            
            if (user.AuthToken == token)
            {
                UserViewModel newUser = user;
                newUser.IsConfirmed = true;
                await _userRepository.DeleteItemAsync(user.Id);
                await _userRepository.AddItemAsync(newUser);
                await Authenticate(user);
                return RedirectToAction("TopicList", "Forum");
            }
            else
                return RedirectToAction("Confirm", new { message = $"Token doesnt match" });
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = UserViewModel.GetUserByCred(_userRepository, model.Email, model.Password);

                if (user != null)
                {
                    if (!user.IsConfirmed)
                    {
                        RedirectToAction("Confirm");
                    }
                     await Authenticate(user);


                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong pass or(and) email");
            }
            return View(model);
        }

        private async Task Authenticate(UserViewModel user)
        {
            
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));

        }
        public async Task<IActionResult> Confirm(string message=" ")
        {


            ViewBag.ErrorMessage = message;
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
