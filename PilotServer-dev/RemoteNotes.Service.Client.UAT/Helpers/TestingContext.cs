using System;
using System.Collections.Generic;
using System.Text;
using RemoteNotes.Service.Client.Contract;
using RemoteNotes.Service.Client.Service;
namespace RemoteNotes.Service.Client.UAT.Helper
{
    public class TestingContext
    {
        public static Exception LastException { get; set; } = null;

        private static IServiceClient frontServiceClient;

        static TestingContext()
        {
            frontServiceClient = FrontClientCreator.Create();
        }

        public static void Clear()
        {
            LastException = null;
        }

        public static IServiceClient GetFrontServiceClient()
        {
            Clear();
            return frontServiceClient;
        }
    }
}

