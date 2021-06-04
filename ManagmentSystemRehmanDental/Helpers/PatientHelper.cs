using System;
using System.Collections.Generic;
using System.Text;
using EntityLibrary.PatientManagment;
using ManagmentSystemRehmanDental.Models;

namespace ManagmentSystemRehmanDental.Helpers
{
    public static class PatientHelper
    {
        public static PatientModel ToModel(this Patient entity)
        {
            PatientModel model = new PatientModel();

            if (entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Age = entity.Age;
                model.Gender = entity.Gender;
                if (entity.Contact != null)
                {
                    model.Contact = Convert.ToInt64(entity.Contact);

                }
            }
            else
            {
                model = null;
            }
            
            return model;
        }

        public static Patient ToEntity(PatientModel model)
        {
            Patient entity = new Patient();

            entity.Name = model.Name;
            entity.Age = model.Age;
            entity.Gender = model.Gender;
            entity.Contact = model.Contact;

            if(model.Tests != null)
            {
                foreach ( var test in model.Tests)
                {
                    entity.Tests.Add(TestHelper.ToEntity(test));
                }
            }

            return entity;
        }
    }
}
