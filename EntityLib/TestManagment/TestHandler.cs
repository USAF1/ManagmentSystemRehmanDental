using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.TestManagment
{
    public class TestHandler
    {
        public static List<Test> GetTests()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Tests.ToList();
            }
        }

    }
}
