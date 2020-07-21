using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restraurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestrauntData restrauntData;
        [BindProperty(SupportsGet =true)]
        public string SearchRes { get; set; }
        public IEnumerable<Restraunt> Restraunts { get; set; }

        public string Message { get; set; }
        public ListModel(IRestrauntData restrauntData,IConfiguration configuration  )
        {
            this.restrauntData = restrauntData;
            this.config = configuration;
        }
       /* public void OnGet()
        {
          Restraunts=  restrauntData.GetAll();
        }*/
        public void OnGet(string searchRes=null)
        {
            Restraunts = restrauntData.GetRestrauntByName(searchRes);
        }
    }
}