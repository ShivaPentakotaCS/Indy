using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sports_Team01.Pages
{
    public class InitializeModel : PageModel
    {
        public RedirectResult OnGet()
        {
            //Logout the user.
            HttpContext.Session.Clear();

            //Initialize the header data.
            HttpContext.Session.SetString("User", "*");
            HttpContext.Session.SetString("Status", "*");
            HttpContext.Session.SetString("MessageColor", "Green");
            HttpContext.Session.SetString("Message", "Please log in.");


            //Redirect to the login page.
            return Redirect("/Login");
        }
    }
}