using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using AdalReleasePublisher.dll.Abstract;
using AdalReleasePublisher.dll.Entities;

namespace AdalReleasePublisher.WebUI.Controllers
{
    public class SubmitProductController : Controller
    {
        [HttpPost]
        public ActionResult CreateRequest(Request request)
        {
            if (string.IsNullOrEmpty(request.ProductTitle))
            {
                ModelState.AddModelError("ProductTitle", "Please select a product from the drop down menu");
            }

            if (string.IsNullOrEmpty(request.VersionNumber) || !Regex.IsMatch(request.VersionNumber, @"^v[1-9]{1,2}\.([0-9]{1,2}\.)([0-9]{1,3})$"))
            {
                ModelState.AddModelError("ReleaseVersion", "The Version number needs to be in semantic versioning (vx.xx.xxx)");
            }

            if (string.IsNullOrEmpty(request.ReleaseNotes))
            {
                ModelState.AddModelError("ReleaseNotes", "Please include the Release Notes for the product");
            }

            if (ModelState.IsValid)
            {
                return View("DisplayRequest", request);
            }
            else
            {
                return View();
            }

        }
    }
}