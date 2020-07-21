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
    public class DeleteModel : PageModel
    {
        private readonly IRestrauntData restrauntData;
       public Restraunt Restraunt { get; set; }
        public DeleteModel(IRestrauntData  restrauntData)
        {
            this.restrauntData = restrauntData;
        }
        public IActionResult OnGet(int id)
        {
            Restraunt = restrauntData.GetRestrauntById(id);
            if (Restraunt == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost(int id)
        {
          var result =  restrauntData.Delete(id);
            restrauntData.Commit();
            if(result==null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{result.Name} with Id {result.Id} deleted !";
            return RedirectToPage("./List");
        }
    }
}