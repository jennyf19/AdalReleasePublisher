using System;
using System.Collections.Generic;
using AdalReleasePublisher.dll.Entities;

namespace AdalReleasePublisher.dll.Abstract
{
    public interface IRequestRepository
    {
        //Allow a user to obtain a sequence of Request without knowing
        //where they are coming from or how the implemnetations class will
        //deliver them
        IEnumerable<Request> Requests { get; }
    }
    
}
