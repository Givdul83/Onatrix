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
                
                
                if (string.IsNullOrEmpty(form.Name))
                {
                    ViewData["error-name"] = "You must enter your name";
                }
                else if (ModelState.ContainsKey(nameof(form.Name)) && ModelState[nameof(form.Name)]?.Errors.Count > 0)
                {
                    ViewData["error-name"] = "Your name must contain at least two characters";
                }



                if (string.IsNullOrEmpty(form.Email))
                {
                    ViewData["error-email"] = "You must enter a valid email";
                }
                else if (ModelState.ContainsKey(nameof(form.Email)) && ModelState[nameof(form.Email)]?.Errors.Count > 0)
                {
                    ViewData["error-email"] = "Invalid email address";
                }

                ViewData["error-phone"] = string.IsNullOrEmpty(form.Phone);

                if (string.IsNullOrEmpty(form.Name))
                {
                    ViewData["error-phone"] = "You must enter your phone number";
                }
                else if (ModelState.ContainsKey(nameof(form.Phone)) && ModelState[nameof(form.Phone)]?.Errors.Count > 0)
                {
                    ViewData["error-phone"] = "Your phone number must be a valid phone number";
                }

                return CurrentUmbracoPage();
            }



            TempData["submitted"] = "We have succesfully recived your info";
            return  RedirectToCurrentUmbracoPage();
        }
    }
}
