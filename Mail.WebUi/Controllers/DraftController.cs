using Mail.BusinessLayer.Concrete;
using Mail.DataAccessLayer.Context;
using Mail.DataAccessLayer.EntityFramework;
using Mail.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Mail.WebUi.Controllers
{
    public class DraftController : Controller
    {
        private readonly DraftManager _draftManager;
    private readonly UserManager<AppUser> _userManager;

        public DraftController(DraftManager draftManager, UserManager<AppUser> userManager)
        {
            _draftManager = draftManager;
            _userManager = userManager;
        }

        public IActionResult DraftMessageList()
        {
            var values = _draftManager.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult DraftMessageSave()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> DraftMessageSave(Draft p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.SenderMail = mail;
            p.SenderName = name;
            p.Status = true;
            MailContext c = new MailContext();
            var usernamesurname = c.Users.Where(x => x.Email == p.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _draftManager.TInsert(p);
            return RedirectToAction("DraftMessageList");

        }
        public IActionResult DraftOut(int id)
        {
            _draftManager.TDelete(id);
            return RedirectToAction("DraftMessageList");
        }
    }
}
