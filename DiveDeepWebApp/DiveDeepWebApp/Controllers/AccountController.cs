using DiveDeepWebApp.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeepWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");
            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync("login?useCookies=true", new
                {
                    email = model.Email,
                    password = model.Password
                });

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Forkort email eller adgangskode.");
                    return View(model);
                }

                if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string>? cookies))
                {
                    foreach (string cookie in cookies)
                    {
                        Response.Headers.Append("Set-Cookie", cookie);
                    }
                }

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Der opstod en fejl. Prøv igen senere.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using HttpClient client = httpClientFactory.CreateClient("DiveDeepApi");
            try
            {
                using HttpResponseMessage response = await client.PostAsJsonAsync("register", new
                {
                    email = model.Email,
                    password = model.Password
                });

                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError(string.Empty, "Kunne ikke oprette kontoen.");
                    return View(model);
                }

                if (response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string>? cookies))
                {
                    foreach (string cookie in cookies)
                    {
                        Response.Headers.Append("Set-Cookie", cookie);
                    }
                }

                return RedirectToAction(nameof(Login));
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Der opstod en fejl. Prøv igen senere.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}