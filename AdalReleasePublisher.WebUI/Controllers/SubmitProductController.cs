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

        public ActionResult CreateRequest()
        {
            return View(new Request());
        }

        [HttpPost]
        public ActionResult CreateRequest(Request request)
        {
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
        /*public ActionResult LoadProducts()
        {
            List<SelectListItem> productList = new List<SelectListItem>();
            productList.Add(new SelectListItem { Text = "Select", Value = "0" });
            productList.Add(new SelectListItem { Text = "Adal-v4", Value = "1" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-android-convergence", Value = "2" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-dotnet-v2", Value = "3" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-dotnet-v3", Value = "4" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-java", Value = "5" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-js-dev", Value = "6" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-js-master", Value = "7" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-nodejs-master", Value = "8" });
            productList.Add(new SelectListItem { Text = "Azure-activedirectory-library-for-objc-dev", Value = "9" });
            productList.Add(new SelectListItem { Text = "build-android-master", Value = "10" });
            productList.Add(new SelectListItem { Text = "gradle-build-android-master", Value = "11" });
            productList.Add(new SelectListItem { Text = "msal-dotnet", Value = "12" });
            productList.Add(new SelectListItem { Text = "NativeADAL", Value = "13" });
            productList.Add(new SelectListItem { Text = "WilsonForDotNet45Dev", Value = "14" });
            productList.Add(new SelectListItem { Text = "WilsonForDotNet45Release", Value = "15" });
            productList.Add(new SelectListItem { Text = "WilsonForKDev", Value = "16" });
            productList.Add(new SelectListItem { Text = "WilsonForKMaster", Value = "17" });
            productList.Add(new SelectListItem { Text = "WilsonForKRelease", Value = "18" });
            ViewData["product"] = productList;
            return View();*/
    }
}
