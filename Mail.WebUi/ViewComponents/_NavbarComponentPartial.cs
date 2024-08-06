using Microsoft.AspNetCore.Mvc;

namespace Mail.WebUi.ViewComponents
{
    public class _NavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
