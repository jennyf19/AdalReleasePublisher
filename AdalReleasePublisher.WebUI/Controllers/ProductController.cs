using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdalReleasePublisher.dll.Abstract;
using AdalReleasePublisher.dll.Entities;

namespace AdalReleasePublisher.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //Add a constructor that declares a dependency on the IRequestRepository interface
        private IRequestRepository repository;

        public ProductController(IRequestRepository productRepository)
        {
            this.repository = productRepository;
        }
        
        //Action method List will render a view showing the complete list of requests
        public ViewResult _List()
        {
            return View(repository.Requests);
        }
    }
}