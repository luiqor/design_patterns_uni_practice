using System;
using System.Collections.Generic;
using System.Text;

namespace Composite_webapp.Controllers
{
    abstract class OrganizationComponent
    {
        public OrganizationComponent() { }
        public abstract List<string> OperationInfo(int depth, bool isDepartment, bool isEmployee, bool applyCss);
        public virtual void Add(OrganizationComponent component)
        {
            throw new NotSupportedException();
        }

        public virtual void Remove(OrganizationComponent component)
        {
            throw new NotSupportedException();
        }


        public virtual void MoveEmployeeToDepartment(string employeeName, string employeePosition, string oldDepartmentName, string newDepartmentName)
        {
            throw new NotSupportedException();
        }
        public virtual Employee GetEmployeeByNameAndPosition(string employeeName, string employeePosition)
        {
            throw new NotSupportedException();
        }
        public virtual Department FindDepartment(string departmentName)
        {
            throw new NotSupportedException();
        }
    }

    // Class representing a department in the organization
    class Department : OrganizationComponent
    {
        private List<OrganizationComponent> children = new List<OrganizationComponent>();

        public string name;
        public Department(string name)
        {
            this.name = name;
        }
        public void SortChildren()
        {
            children.Sort(new OrganizationComponentComparator());
        }
        public override List<string> OperationInfo(int depth, bool isDepartment, bool isEmployee, bool applyCss)
        {
            SortChildren();
            List<string> info = new List<string>();
            string cssClass = applyCss ? $"organization-string-{depth + 1}" : "";

            info.Add($"{new string(' ', depth)}<div class='{cssClass}'>Відділ: {name}</div>");
            foreach (var component in children)
            {
                if (component is Employee)
                    info.AddRange(component.OperationInfo(depth + 2, isDepartment, isEmployee, applyCss));
                if (component is Department && isDepartment == true)
                    info.AddRange(component.OperationInfo(depth + 2, isDepartment, isEmployee, applyCss));
            }
            return info;
        }

        public override void Add(OrganizationComponent component)
        {
            children.Add(component);
            SortChildren();
        }

        public override void Remove(OrganizationComponent component)
        {
            children.Remove(component);
        }

        public override void MoveEmployeeToDepartment(string employeeName, string employeePosition, string oldDepartmentName, string newDepartmentName)
        {
            Department newDepartment = FindDepartment(newDepartmentName);
            Department oldDepartment = FindDepartment(oldDepartmentName);

            Employee employeeToMove = oldDepartment.GetEmployeeByNameAndPosition(employeeName, employeePosition);
            oldDepartment.Remove(employeeToMove);
            newDepartment.Add(employeeToMove);
            SortChildren();
        }

        public Department FindDepartment(string departmentName)
        {
            if (this.name == departmentName)
            {
                return this;
            }

            foreach (var subComponent in children)
            {
                if (subComponent is Department department)
                {
                    var foundDepartment = department.FindDepartment(departmentName);
                    if (foundDepartment != null)
                    {
                        return foundDepartment;
                    }
                }
            }

            return null;
        }

        public override Employee GetEmployeeByNameAndPosition(string employeeName, string employeePosition)
        {
            foreach (var subComponent in children)
            {

                if (subComponent is Employee employee && employee.name == employeeName && employee.position == employeePosition)
                {
                    return employee;
                }
                else if (subComponent is Department department)
                {
                    var employeeInSubDepartment = department.GetEmployeeByNameAndPosition(employeeName, employeePosition);
                    if (employeeInSubDepartment != null)
                    {
                        return employeeInSubDepartment;
                    }
                }
            }

            return null;
        }
    }

    // Class representing an employee in the organization
    class Employee : OrganizationComponent
    {
        public string name;
        public string position;

        public Employee(string name, string position)
        {
            this.name = name;
            this.position = position;
        }

        public override List<string> OperationInfo(int depth, bool isDepartment, bool isEmployee, bool applyCss)
        {
            List<string> info = new List<string>();
            string cssClass = applyCss ? $"organization-string-{depth + 1}" : "";

            if (!isEmployee)
                return info;

            info.Add($"{new string(' ', depth)}<div class='{cssClass}'>{position}: {name}</div>");

            return info;
        }

        public void ChangePosition(string newPosition)
        {
            this.position = newPosition;

        }
    }

    // Class demonstrating the Composite pattern
    class CompositeDemo
    {
        public static OrganizationComponent organization = new Department("Організація");
        public static void BuildStartOrganization()
        {
            OrganizationComponent hrDepartment = new Department("Відділ кадрів");
            OrganizationComponent salesDepartment = new Department("Відділ продажів");
            OrganizationComponent techDepartment = new Department("Технічний відділ");

            organization.Add(hrDepartment);
            organization.Add(salesDepartment);
            organization.Add(techDepartment);

            organization.Add(new Employee("Директор", "Директор"));
            organization.Add(new Employee("Заступник директора", "Заступник директора"));

            hrDepartment.Add(new Employee("Губка Боб", "Керівник"));
            hrDepartment.Add(new Employee("Спайдер Мен", "Заступник"));
            hrDepartment.Add(new Employee("Доріан Ґрей", "Спеціаліст"));
            hrDepartment.Add(new Employee("Елізабет Галфорд", "Спеціаліст"));
            hrDepartment.Add(new Employee("Блискавка Маквін", "Службовець"));
            hrDepartment.Add(new Employee("Копіка Ганна", "Робітник"));
            hrDepartment.Add(new Employee("Безлад Андрій", "Робітник"));

            salesDepartment.Add(new Employee("Харлі Квін", "Керівник"));
            salesDepartment.Add(new Employee("Джокер", "Заступник"));
            salesDepartment.Add(new Employee("Тоні Старк", "Спеціаліст"));
            salesDepartment.Add(new Employee("Фрозен Ельза", "Спеціаліст"));
            salesDepartment.Add(new Employee("Пітер Паркер", "Робітник"));
            salesDepartment.Add(new Employee("Піг Пеппа", "Робітник"));

            techDepartment.Add(new Employee("Тоні Старк", "Керівник"));
            techDepartment.Add(new Employee("Брюс Вейн", "Заступник"));
            techDepartment.Add(new Employee("Їжак Сонік", "Спеціаліст"));
            techDepartment.Add(new Employee("Хеллоу Кітті", "Робітник"));

            OrganizationComponent developDepartment = new Department("Відділ розробки ПЗ");
            techDepartment.Add(developDepartment);
            developDepartment.Add(new Employee("Крофт Лара", "Керівник"));
            developDepartment.Add(new Employee("Мікі Маус", "Заступник"));
            developDepartment.Add(new Employee("Пітер Паркер", "Спеціаліст"));
            developDepartment.Add(new Employee("Скайуокер Люк", "Службовець"));
            developDepartment.Add(new Employee("Кларк Кент", "Службовець"));
            developDepartment.Add(new Employee("Вейд Уілсон", "Робітник"));
            developDepartment.Add(new Employee("Дональд Дак", "Робітник"));

            OrganizationComponent qaDepartment = new Department("Відділ тестування");
            techDepartment.Add(qaDepartment);
            qaDepartment.Add(new Employee("Джейн Сміт", "Керівник"));
            qaDepartment.Add(new Employee("Адам Джонсон", "Заступник"));
            qaDepartment.Add(new Employee("Емма Девіс", "Спеціаліст"));
            qaDepartment.Add(new Employee("Джеймс Браун", "Службовець"));
            qaDepartment.Add(new Employee("Олівія Уайт", "Службовець"));
            qaDepartment.Add(new Employee("Девід Міллер", "Робітник"));
            qaDepartment.Add(new Employee("Софія Лі", "Робітник"));

            OrganizationComponent seoDepartment = new Department("Відділ SEO");
            techDepartment.Add(seoDepartment);
            seoDepartment.Add(new Employee("Джеймс Бонд", "Керівник"));
            seoDepartment.Add(new Employee("Емма Ватсон", "Заступник"));
            seoDepartment.Add(new Employee("Том Харді", "Спеціаліст"));
            seoDepartment.Add(new Employee("Мері Джейн", "Службовець"));
            seoDepartment.Add(new Employee("Джек Доу", "Службовець"));
            seoDepartment.Add(new Employee("Аліса Купер", "Робітник"));
            seoDepartment.Add(new Employee("Боб Мартін", "Робітник"));

            //organization.OperationInfo(0, isDepartment: false, isEmployee: true);
        }
    }

    class OrganizationComponentComparator : IComparer<OrganizationComponent>
    {
        public int Compare(OrganizationComponent x, OrganizationComponent y)
        {
            if (x is Department && y is Department)
            {
                return ((Department)x).name.CompareTo(((Department)y).name);
            }
            else if (x is Department)
            {
                return 1;
            }
            else if (y is Department)
            {
                return -1;
            }
            else if (x is Employee && y is Employee)
            {
                var positionOrder = new Dictionary<string, int>
            {
                { "Директор", 1 },
                { "Заступник директора", 2 },
                { "Керівник", 3 },
                { "Заступник", 4 },
                { "Спеціаліст", 5 },
                { "Службовець", 6 },
                { "Робітник", 7 }
            };

                var positionComparison = positionOrder[((Employee)x).position].CompareTo(positionOrder[((Employee)y).position]);
                if (positionComparison != 0)
                {
                    return positionComparison;
                }
                else
                {
                    return ((Employee)x).name.CompareTo(((Employee)y).name);
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
