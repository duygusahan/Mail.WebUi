using Mail.BusinessLayer.Abstract;
using Mail.BusinessLayer.Concrete;
using Mail.DataAccessLayer.Context;
using Mail.DataAccessLayer.EntityFramework;
using Mail.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mail.WebUi.Controllers
{
    public class MessagesController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public MessagesController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager; 
            _messageService = messageService;
        }

        public async Task<IActionResult> ListMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p=values.Email;
            var messageList = _messageService.TGetListReciverMessage(p);
            return View(messageList);   
        }
        public IActionResult MessageDetails(int id)
        {
            var message = _messageService.TGetById(id);
            return View(message);   
        }

        public async Task<IActionResult> SentMessageList(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _messageService.TGetListSendMessage(p);
            return View(messageList);
        }

        public IActionResult SendMessageDetails(int id)
        {
            var sendMessages= _messageService.TGetById(id);
            return View(sendMessages);
        }

        [HttpGet]
        public IActionResult CreateNewMessage()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> CreateNewMessage(Message message)
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = value.Email;
            string name = value.Name + " " + value.Surname;
            message.Date = DateTime.Now;
            message.SenderMail = mail;
            message.SenderName = name;
            message.Status = true;
            message.IsDraft = false;
            message.IsRead = false;
            MailContext context = new MailContext();    
            var usernamesurname = context.Users.Where(x => x.Email == message.ReceiverMail).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            message.ReceiverName = usernamesurname;
            _messageService.TInsert(message);
            return RedirectToAction("SentMessageList");

        }
        public async Task<IActionResult> TrashBox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var trashMessages = _messageService.TGetTrashBox(user.Email);
            return View(trashMessages);
        }
        public IActionResult DeleteMessage(int id)
        {
            MailContext _context= new MailContext();
            var value=_context.Messages.Where(x=>x.MessageID== id).FirstOrDefault();  
            value.Status=false;
            _context.SaveChanges();
            return RedirectToAction("TrashBox");
        }
    }
}
