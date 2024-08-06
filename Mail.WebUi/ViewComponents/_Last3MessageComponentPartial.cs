using Mail.BusinessLayer.Abstract;
using Mail.DataAccessLayer.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail.WebUi.ViewComponents
{
    public class _Last3MessageComponentPartial:ViewComponent
    {
        private readonly IMessageService _messageService;

        public _Last3MessageComponentPartial(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string  m)
        {
            var usermail = User.Identity.Name;
            var valuue = _messageService.TGetLast3MessagesByAppUser(m);
            return View(valuue);


        }
    }
}
