using Mail.DtoLayer.LoginDtos;
using Mail.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail.WebUi.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}
		[HttpGet]
		public IActionResult SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
		{
			var result =await _signInManager.PasswordSignInAsync(createLoginDto.Username , createLoginDto.Password , false , false);
			if (result.Succeeded) 
			{
				return RedirectToAction("ListMessage", "Messages");
			}
			return View();
		}
	}
}
