using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Client.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteNotes.Service.Client.UAT.Helper
{
    class FrontClientCreator
    {
        public static IServiceClient Create()
        {
            return new ServiceClient();
        }
    }
}
