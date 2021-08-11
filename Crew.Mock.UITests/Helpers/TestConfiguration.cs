using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crew.Mock.UITests.Helpers
{
    public class TestConfiguration
    {
        public string AppCode { get; }
        public string Server { get; }
        public string Login { get; }
        public string Password { get; }
        public string Project { get; }
        public string WorkGroupID { get; }

        public TestConfiguration(string appCode)
        {
            AppCode = appCode;
        }

        public TestConfiguration(string appCode, string server)
        {
            AppCode = appCode;
            Server = server;
        }

        public TestConfiguration(string appCode, string server, string login, string password)
        {
            AppCode = appCode;
            Server = server;
            Login = login;
            Password = password;
        }

        public TestConfiguration(string appCode, string server, string login, string password, string project)
        {
            AppCode = appCode;
            Server = server;
            Login = login;
            Password = password;
            Project = project;
        }

        public TestConfiguration(string appCode, string server, string login, string password, string project, string workGroupID)
        {
            AppCode = appCode;
            Server = server;
            Login = login;
            Password = password;
            Project = project;
            WorkGroupID = workGroupID;
        }
    }
}
