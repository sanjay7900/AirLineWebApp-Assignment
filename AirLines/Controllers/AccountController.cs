using AirLines.Data;
using AirLines.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;

namespace AirLines.Controllers
{
    public class AccountController : Controller
    {
        private readonly AirLineDbContext _context;
        

        public AccountController(AirLineDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                return RedirectToAction("Index", "Home");
               
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> IsEmailExsist(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                    var finduser = await _context.user!.FirstOrDefaultAsync(x => x.Email == email);
                    if (finduser != null)
                    {
                        return Ok("Exist");
                    }
                
            }
            return Ok("NotExist");

        }
        [HttpPost]
        public IActionResult Create(User user)
        {
            var Isemail= _context.user!.FirstOrDefault(u=>u.Email==user.Email);
            if(Isemail != null)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                _context.user!.Add(user);
                _context.SaveChanges();
                var whatrole = _context.role!.FirstOrDefault(r => r.Id == user.RoleId);
                if (whatrole != null)
                {
                  

                    EmailSend(user.Email!,user.Email!);
                    if (whatrole.Name == "Admin")
                    {
                        return RedirectToAction("Login");
                    }
                    else if (whatrole.Name == "Operator")
                    {
                        return RedirectToAction("Login");

                    }
                }
                return RedirectToAction(nameof(Index));
            }

        }
        [HttpPost]
        public async Task<IActionResult> Login(string Email,string password)
        {
            var Isuser=await _context.user!.FirstOrDefaultAsync(u=>u.Email==Email && u.Password==password);
            if (Isuser != null && Isuser.Status!="Pending" && Isuser.Status!="Reject")
            {
                HttpContext.Session.SetString("Name", Isuser.Email!);
                var rol=_context.role!.FirstAsync(r => r.Id==Isuser.RoleId).Result;
                HttpContext.Session.SetInt32("RoleId", Isuser.RoleId);
                HttpContext.Session.SetString("role", rol.Name!);
                var whatrole =await _context.role!.FirstOrDefaultAsync(r => r.Id == Isuser.RoleId);
                if (whatrole!.Name == "Admin")
                {
                    return RedirectToAction("Index", "Home", new { area = "Home" });
                }
                else if(whatrole!.Name == "Operator")
                {
                    return RedirectToAction("Index", "Home", new { area = "Home" });
                }
            }
            else
            {
                ViewData["loginInvalid"] = "Invalid Credentials";
                return View();

            }
            return View();

        }
        [HttpGet]
        public IActionResult Login()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Name")))
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
        }
        //==========================================
        
        private static void EmailSend(string to, string username)
        {
            string from = "sanjay.singh_bca18@gla.ac.in";
            string password = "7900434644";
            string subject = "Welcome  Dear Customre";
            string body = $"{username}\n<h1>Thanks for the registration. Please login using"+"'<a href=\"https://localhost:7289/Account/\" </h1>\n'";
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(from);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));

        }
        public IActionResult ErrorPage()
        {
            return View();
        }


        //==========================================
    }
}
