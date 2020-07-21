using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restraunts
{
    public class EditModel : PageModel
    {
        private readonly IRestrauntData restrauntData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public Restraunt restraunt{ get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestrauntData restrauntData,IHtmlHelper htmlHelper)
        {
            this.restrauntData = restrauntData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? id)
        {

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (id.HasValue)
            {
                restraunt = restrauntData.GetRestrauntById(id.Value);

            }
            else
            {
                restraunt = new Restraunt();
            }
            if (restraunt == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (!ModelState.IsValid)
            {

                return Page();

                
            }
            if (restraunt.Id > 0)
            {
                this.restraunt = restrauntData.Update(restraunt);
                
            }
            else
            {
                this.restrauntData.Create(restraunt);
            }
            restrauntData.Commit();
            TempData["Message"] = "Successful operation";
            return RedirectToPage("./Detail", new { id = restraunt.Id });
        }
    }
}