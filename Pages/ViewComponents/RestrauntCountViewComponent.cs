using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Pages.ViewComponents
{
    public class RestrauntCountViewComponent : ViewComponent
    {
        private readonly IRestrauntData restrauntData;

        public RestrauntCountViewComponent(IRestrauntData restrauntData)
        {
            this.restrauntData = restrauntData;
        }
        public IViewComponentResult Invoke()
        {
            var count = restrauntData.RestrauntsCount();
            return View(count);
        }
    }
}
