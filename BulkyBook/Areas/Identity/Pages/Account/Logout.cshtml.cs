﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyBook.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BulkyBook.Areas.Identity.Pages.Account
{
   [AllowAnonymous]
   public class LogoutModel : PageModel
   {
      private readonly SignInManager<IdentityUser> _signInManager;
      private readonly ILogger<LogoutModel> _logger;

      public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger)
      {
         _signInManager = signInManager;
         _logger = logger;
      }

      public void OnGet()
      {
      }

      public async Task<IActionResult> OnPost(string returnUrl = null)
      {
         await _signInManager.SignOutAsync();
         _logger.LogInformation("User logged out.");
         HttpContext.Session.SetObj(SD.Shopping_Cart,-1);

         if (returnUrl != null)
         {
            return LocalRedirect(returnUrl);
         }
         else
         {
            return RedirectToPage();
         }
      }
   }
}
