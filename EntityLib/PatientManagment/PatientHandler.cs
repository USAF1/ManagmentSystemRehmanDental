using EntityLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLibrary.PatientManagment
{
    public class PatientHandler
    {
        public static void AddPatient(Patient entity)
        {

            using (ApplicationDb  context = new ApplicationDb())
            {
                context.Add(entity);
                context.SaveChanges();
            }

        }

        public static Patient GetPatient(int id)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return (from Patient in context.Patients.Include(t => t.Tests).Include(z=>z.XRays) where Patient.Id == id select Patient).FirstOrDefault();
            }
        }


        public static Patient GetRecentPatient()
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                return context.Patients.FromSqlRaw("select * from Patients where Id = (select MAX(Id) from Patients)").FirstOrDefault();
            }
        }

        public static void UpdatePatient(Patient pt)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if (pt.Tests !=null)
                {
                    foreach (var Test in pt.Tests)
                    {
                        context.Entry(Test).State = EntityState.Unchanged;
                    }
                }

                if (pt.XRays != null)
                {
                    foreach (var xray in pt.XRays)
                    {
                        context.Entry(xray).State = EntityState.Unchanged;
                    }
                }
                context.Update(pt);
                context.SaveChanges();
            }
        }

        public static void UpdatePatientTest(Patient pt)
        {
            using (ApplicationDb context = new ApplicationDb())
            {
                if (pt.Tests != null)
                {
                    foreach (var Test in pt.Tests)
                    {
                        context.Entry(Test).State = EntityState.Unchanged;
                    }
                }
                pt.XRays.Clear();
                context.Update(pt);
                context.SaveChanges();
            }
        }

        public static void UpdatePatientXRay(Patient pt)
        {
            using (ApplicationDb context = new ApplicationDb())
            {


                if (pt.XRays != null)
                {
                    foreach (var xray in pt.XRays)
                    {
                        context.Entry(xray).State = EntityState.Unchanged;
                        
                    }
                }
                pt.Tests.Clear();
                pt.XRays.Clear();
                context.Update(pt);
                context.SaveChanges();
            }
        }
    }
}
