using CTS_System6.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class ProjectRepository : ITranslatorRepository<Projects>
    {
        ApplicationDbContext db;
        public ProjectRepository(ApplicationDbContext _db)
        {
            db = _db;
        }

        public void Add(Projects entity)
        {
            db.Projects.Add(entity);
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            var project = Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
        }

        public Projects Find(string id)
        {
            var project = db.Projects.SingleOrDefault(b => b.Id.ToString() == id);
            return project;
        }

        public IList<Projects> List()
        {
            return db.Projects.ToList();
        }

        public IList<Projects> List(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Projects newProject)
        {
            db.Update(newProject);
            db.SaveChanges();
            //var project = Find(id);
            //project.FromLanguage = newProject.FromLanguage;
            //project.ToLanguage = newProject.ToLanguage;
            //project.Body = newProject.Body;
            //project.Currency = newProject.Currency;
            //project.DeliveryDate = newProject.DeliveryDate;
            //project.Offer = newProject.Offer;
            //project.Status = newProject.Status;
            //project.Subject = newProject.Subject;
           
        }


        public void UpdateElement(string elementId, string elementName, string newValue)
        {


            //db.Projects.Where(p => p.Id == Convert.ToInt32(elementId)).
            var project = Find(elementId);
            switch(elementName)
            {
                case "Status":
                    project.Status = newValue;
                    break;
                case "SelectedTranslator":
                    project.SelectedTranslator = newValue;
                    break;
            };

            db.SaveChanges();
          }
    }
}
