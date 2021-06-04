using System;
using System.Collections.Generic;
using System.Text;
using EntityLibrary.TestManagment;
using ManagmentSystemRehmanDental.Models;
using ManagmentSystemRehmanDental.Extras;

namespace ManagmentSystemRehmanDental.Helpers
{
    public class TestHelper
    {
        public static TestModel ToModel(Test entity)
        {
            TestModel model = new TestModel();

            if(entity != null)
            {
                model.Id = entity.Id;
                model.Name = entity.Name;
                model.Price = entity.Price;
            }
            return model;
        }

        public static List<Tests> TestItems(List<Tests> entitie)
        {
            List<Tests> items = new List<Tests>();


            foreach (var entity  in entitie)
            {
                items.Add(new Tests() { Name = entity.Name });
            }

            return items;
        }

        public static Test ToEntity(TestModel model)
        {
            Test entity = new Test();

            entity.Id = model.Id;
            entity.Name = model.Name;
            entity.Price = model.Price;

            return entity;
        }
    }
}
