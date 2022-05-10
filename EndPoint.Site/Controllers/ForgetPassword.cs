using Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class ForgetPassword : Controller
    {
        private readonly IPersonRepository _personRepository;
        public ForgetPassword(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public string forgetpass(string Email)
        {

            var chars = "QWE56RTY78UIO9PASDF45G78HJKL235ZXCV7568B4N56Mqw234ea57sdz&xcrfvtgbyhnujmikolp012349";
            var stringChars = new char[10];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            
            var finalString = new String(stringChars);
            var person = (_personRepository.GetidByMail(Email));
            if (person > 0)
            {

               // var password = _personRepository.GetPersontById(person).Password;

                try
                {
                    //MailMessage mail = new MailMessage();
                    //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                    ////نام فرستنده
                    //mail.From = new MailAddress("programer.cshap@gmail.com");
                    ////آدرس گیرنده یا گیرندگان
                    //mail.To.Add(Email);
                    ////عنوان ایمیل
                    //mail.Subject = "Forget Password";
                    ////بدنه ایمیل
                    //mail.Body = finalString;
                    ////مشخص کرن پورت 
                    //SmtpServer.Port = 587;
                    ////username : به جای این کلمه نام کاربری ایمیل خود را قرار دهید
                    ////password : به جای این کلمه رمز عبور ایمیل خود را قرار دهید
                    //SmtpServer.UseDefaultCredentials = true;
                    //SmtpServer.Credentials = new System.Net.NetworkCredential("programer.cshap@gmail.com", "Amiros1999");
                    //SmtpServer.EnableSsl = true;

                    //SmtpServer.Send(mail);

                    return ("code=") + finalString ;

                }
                catch (Exception)
                {
                    throw;
                }

            }
            else
            {
                return ("Not Found Email");
            }
        }
        public string UpdatePass(string email, string password)
        {
            if (_personRepository.GetidByMail(email) > 0)
            {
                var person = _personRepository.GetPersontById(_personRepository.GetidByMail(email));
                person.Password = password;
                _personRepository.UpdatePerson(person);
                _personRepository.Save();
                return "true";
            }
            else
            {
                return "false";
            }
        }
       
    }

}
