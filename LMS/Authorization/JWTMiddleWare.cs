
using LMS.Helpers;
using Microsoft.Extensions.Options;

namespace LMS.Authorization
{
    public class JWTMiddleWare
    {
        private readonly RequestDelegate _next;
        public JWTMiddleWare(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            string token = context.Request?.Cookies["token"];
            string sessionType = context.Request?.Cookies["sessionType"];
            Console.WriteLine(token + sessionType);
            try
            {
                if (token != null && sessionType != null)
                {
                    Console.WriteLine("debg-2");
                    if (await functionalUtils.AuthenticateActor(token, sessionType) == true)
                    {



                        //authenticate token

                        Console.WriteLine("debg-3");
                        context.Items["resultAuth"] = "success";
                        Console.WriteLine("Authorized");
                    }
                }

            }
            catch (Exception e) { 
            }
            await _next(context);

        }
    }
}
