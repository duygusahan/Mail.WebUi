using Microsoft.AspNetCore.Mvc;

namespace Mail.WebUi.ViewComponents
{
    public class _SidebarComopnentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
