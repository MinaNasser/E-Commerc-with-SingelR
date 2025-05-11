using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Text;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API
{
    public class GenaralExceptionFilter : ExceptionFilterAttribute
    {
        private string path =
            Directory.GetCurrentDirectory() + "/Logging/" + DateTime.Today.ToString("dd-MM-yyyy");
        public override void OnException(ExceptionContext context)
        {

            #region Logging 
            string User = context.HttpContext.User.Claims.Any() ?
                    context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value
                    : "Guest";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"On {DateTime.Now}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($"User {User}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($"Error {context.Exception.Message}");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($"Details {context.Exception.StackTrace}");

            File.AppendAllText(path, stringBuilder.ToString());
            #endregion


            #region Send Mail 
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("6ecff26c8406b7", "83304a61e8f702"),
                EnableSsl = true
            };
            client.Send("from@example.com", "to@example.com", "Genaral Exception Filter", stringBuilder.ToString());

            #endregion

            context.ExceptionHandled = true;
            context.Result = new JsonResult(new APIResault<string>
            {
                Massage = "Sorry Someting wrong happand!!!",
                Success = false,
                Status = 500,
                Data = ""
            });
        }
    }
}
