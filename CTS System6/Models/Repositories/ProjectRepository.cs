using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTS_System6.Models.Repositories
{
    public class ProjectRepository : ITranslatorRepository<Projects>
    {
        List<Projects> projects;
        public ProjectRepository()
        {
            projects = new List<Projects>();
        }

        public void Add(Projects entity)
        {
            projects.Add(entity);
        }

        public void Delete(string id)
        {
            var project = Find(id);
            projects.Remove(project);
        }

        public Projects Find(string id)
        {
            var project = projects.SingleOrDefault(b => b.Id.ToString() == id);
            return project;
        }

        public IList<Projects> List()
        {
            return projects;
        }

        public void Update(string id, Projects newProject)
        {
            var project = Find(id);
            project.FromLanguage = newProject.FromLanguage;
            project.ToLanguage = newProject.ToLanguage;
            project.Body = newProject.Body;
            project.Currency = newProject.Currency;
            project.DeliveryDate = newProject.DeliveryDate;
            project.Offer = newProject.Offer;
            project.Status = newProject.Status;
            project.Subject = newProject.Subject;
           
        }
    }
}
