using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restraunts
{
    public class DetailModel : PageModel
    {
        private readonly IRestrauntData restrauntData;
        [TempData]
        public string Message { get; set; }
        public DetailModel(IRestrauntData restrauntData)
        {
            this.restrauntData = restrauntData;
        }
        public Restraunt restraunt { get; set; }
        public IActionResult OnGet(int id)
        {
            restraunt = restrauntData.GetRestrauntById(id);
            if (restraunt == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}