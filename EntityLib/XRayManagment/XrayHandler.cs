using EntityLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.XRayManagment
{
   public class XrayHandler
    {
        public static List<Xray> GetXRays()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.XRays.ToList();
            }
        }
    }
}
