using Microsoft.AspNetCore.Mvc;
using Onatrix.Models;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;

namespace Onatrix.Controllers
{
    public class HomeSurfaceController : SurfaceController
    {
        public HomeSurfaceController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider) 
            : base(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
        {
        }

        public IActionResult HandleSubmit(HomePageFormModel form)
        {
            if (!ModelState.IsValid)
            {
                ViewData["name"] = form.Name;
                ViewData["email"] =form.Email;
                ViewData["phone"] =form.Phone;
                
                ViewData["error-name"] = string.IsNullOrEmpty(form.Name);
                ViewData["error-email"] = string.IsNullOrEmpty(form.Email);
                ViewData["error-phone"] = string.IsNullOrEmpty(form.Phone);
                return CurrentUmbracoPage();
            }

            TempData["submitted"] = "We have succesfully recived your info";
            return  RedirectToCurrentUmbracoPage();
        }
    }
}
