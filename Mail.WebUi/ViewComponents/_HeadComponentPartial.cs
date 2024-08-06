using Microsoft.AspNetCore.Mvc;

namespace Mail.WebUi.ViewComponents
{
    public class _HeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
