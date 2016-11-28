using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Runtime.Remoting;
using Moq;
using Ninject;
using AdalReleasePublisher.dll.Abstract;
using AdalReleasePublisher.dll.Entities;

namespace AdalReleasePublisher.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IRequestRepository> mock = new Mock<IRequestRepository>();
            mock.Setup(m => m.Requests).Returns(new List<Request>
            {
                new Request {ProductTitle = "Adal v3", VersionNumber = "v1.11.111", ReleaseNotes = "A bunch of text goes here", DateTime = DateTime.Now},
                new Request {ProductTitle = "Build Android Master", VersionNumber = "v0.00.000", ReleaseNotes = "A bunch of text goes here for Android", DateTime = DateTime.Now}
            });

            kernel.Bind<IRequestRepository>().ToConstant(mock.Object);
        }
    }
}