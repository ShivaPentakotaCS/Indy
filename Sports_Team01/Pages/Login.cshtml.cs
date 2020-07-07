using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Sports_Team01
{
    [BindProperties]
    public class LoginModel : PageModel
    {
        public string SessionStatus_Name { get; set; }
        public string Message { get; set; }
        public string MessageColor { get; set; }

        public string radUser { get; set; }


        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email address is required. Please enter a valid email address.")]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required. Please enter a valid password.")]
        [StringLength(8)]
        public string Password { get; set; }


        public void OnGet()
        {

            //Initialize the header data.
            ViewData["Page"] = "Login";
            ViewData["User"] = HttpContext.Session.GetString("User");
            ViewData["Status"] = HttpContext.Session.GetString("Status");
            ViewData["MessageColor"] = HttpContext.Session.GetString("MessageColor");
            ViewData["Message"] = HttpContext.Session.GetString("Message");

            MessageColor = "White";
            Message = "Please select the appropriate user type to login.";

        }

        public IActionResult OnPostLogin()
        {
            if (radUser == "Employee")
            {
                if(EmailAddress == "austin@indysportsnet.com" && Password == "abc")
                {
                    string strUser = "Austin Holbrook";
                    string strStatus = "Employee";

                    HttpContext.Session.SetString("User", strUser);
                    HttpContext.Session.SetString("Status", strStatus);
                    HttpContext.Session.SetString("MessageColor", "Green");
                    HttpContext.Session.SetString("Message", "Logged In");
                    return Redirect("HomeLoggedIn");
                }
                else if(EmailAddress == "shiva@indysportsnet.com" && Password == "abc")
                {
                    string strUser = "Shiva Pentakota";
                    string strStatus = "Employee";

                    HttpContext.Session.SetString("User", strUser);
                    HttpContext.Session.SetString("Status", strStatus);
                    HttpContext.Session.SetString("MessageColor", "Green");
                    HttpContext.Session.SetString("Message", "Logged In");
                    return Redirect("HomeLoggedIn");
                }
                else if(EmailAddress == "chris@indysportsnet.com" && Password == "abc")
                {
                    string strUser = "Chris Lee";
                    string strStatus = "Employee";

                    HttpContext.Session.SetString("User", strUser);
                    HttpContext.Session.SetString("Status", strStatus);
                    HttpContext.Session.SetString("MessageColor", "Green");
                    HttpContext.Session.SetString("Message", "Logged In");
                    return Redirect("HomeLoggedIn");
                }
                else
                {
                    //initialize the header data.
                    HttpContext.Session.SetString("User", "*");
                    HttpContext.Session.SetString("Messagecolor", "Red");
                    HttpContext.Session.SetString("Message", "Please enter a valid email address and password.");
                    return Redirect("Login");
                }
            }
            else
            {
                if(EmailAddress == "jake@abc.com" && Password == "abc")
                {
                    string strUser = "Jake Smith";
                    string strStatus = "Customer";

                    HttpContext.Session.SetString("User", strUser);
                    HttpContext.Session.SetString("Status", strStatus);
                    HttpContext.Session.SetString("MessageColor", "Green");
                    HttpContext.Session.SetString("Message", "Logged In");
                    return Redirect("HomeLoggedIn");
                }
                else
                {
                    //initialize the header data.
                    HttpContext.Session.SetString("User", "*");
                    HttpContext.Session.SetString("Messagecolor", "Red");
                    HttpContext.Session.SetString("Message", "Please enter a valid email address and password.");
                    return Redirect("Login");
                }
            }
        }
    }
}