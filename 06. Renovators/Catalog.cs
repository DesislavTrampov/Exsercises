using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;
        public Catalog(string name,int neededRenovaters,string project)
        {


            Name = name;    
            NeededRenovators = neededRenovaters;
            Project = project;
            renovators = new List<Renovator>();
        }

        private string  name;

        public string  Name
        {
            get { return name; }
            set { name = value; }
        }
        private int neededRenovators;

        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }
        private string project;

        public string Project
        {
            get { return project; }
            set { project = value; }
        }
        public int Count => renovators.Count;


        public string AddRenovator(Renovator renovator)
        {
            if (renovator.Type == null || string.IsNullOrEmpty(renovator.Name))
            {
                return "Invalid renovator's information.";
            }

            if(NeededRenovators< renovators.Count)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";

        }
        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(renovators => renovators.Name == name);

            return renovators.Remove(renovator);
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            List<Renovator> leftrenovators = renovators.Where(r=> r.Type!=type).ToList();
            int removeCount = Count - leftrenovators.Count;
            renovators = leftrenovators;
            return removeCount;
        }
        public Renovator HireRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(renovators=>renovators.Name==name);
            if (renovator != null)
            {
                renovator.Hired = true;
            }
            return renovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return renovators.Where(r => r.Days>=days).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {project}:");

           var unrenovator = renovators.Where(x => x.Hired == false).ToList();



            foreach(var renovator in unrenovator)
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().Trim();
        }




    }
}
