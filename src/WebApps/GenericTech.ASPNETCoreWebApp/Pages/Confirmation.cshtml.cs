﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GenericTech.ASPNETCoreWebApp.Pages
{
    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; }

        public void OnGetContact()
        {
            Message = "Your email was sent.";
        }

        public void OnGetOrderSubmitted()
        {
            Message = "Your order submitted successfully.";
        }
    }
}