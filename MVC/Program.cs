using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns
{
    class Employee
    {
        private int Id { get; set; }
        private string Name { get; set; }

        public int getEmployeeId()
        {
            return Id;
        }

        public void setEmployeeId(int id)
        {
            this.Id = id;
        }

        public string getEmployeeName()
        {
            return Name;
        }

        public void setEmployeeName(string name)
        {
            this.Name = name;
        }

    }

    class EmployeeView
    {
        public void ShowEmployeeInfo(int id, string name)
        {
            Console.WriteLine("Employee: " + id + ", " + name);
        }
    }

    class EmployeeController
    {
        private Employee model;
        private EmployeeView view;

        public EmployeeController(Employee model, EmployeeView view)
        {
            this.model = model;
            this.view = view;
        }

        public void setEmployeeId(int id)
        {
            model.setEmployeeId(id);
        }

        public int getEmployeeId()
        {
            return model.getEmployeeId();
        }

        public void setEmployeeName(string name)
        {
            model.setEmployeeName(name);
        }

        public string getEmployeeName()
        {
            return model.getEmployeeName();
        }

        public void ViewUpdate()
        {
            view.ShowEmployeeInfo(model.getEmployeeId(), model.getEmployeeName());
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            Employee model = Database();
            EmployeeView view = new EmployeeView();
            EmployeeController controller = new EmployeeController(model, view);

            controller.ViewUpdate();
            controller.setEmployeeName("Klein");
            controller.ViewUpdate();

        }

        private static Employee Database()
        {
            Employee employee = new Employee();
            employee.setEmployeeId(1234);
            employee.setEmployeeName("Müller");
            return employee;
        }
    }
}
