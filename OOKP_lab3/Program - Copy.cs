using System;
using System.Collections.Generic;

// Абстрактний клас, який представляє компонент організації
abstract class OrganizationComponent
{
    public OrganizationComponent() { }
    public abstract void OperationInfo(int depth);
    public virtual void MoveEmployeeToDepartment(string employeeName, string employeePosition, string oldDepartmentName, string newDepartmentName)
    {
        throw new NotSupportedException();
    }
    public virtual Employee GetEmployeeByNameAndPosition(string employeeName, string employeePosition)
    {
        throw new NotSupportedException();
    }

    public virtual void Add(OrganizationComponent component)
    {
        throw new NotSupportedException();
    }

    public virtual void Remove(OrganizationComponent component)
    {
        throw new NotSupportedException();
    }
}

// Клас, який представляє відділ організації
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
    public override void OperationInfo(int depth)
    {
        Console.WriteLine(new string(' ', depth) + " Відділ: " + name);

        foreach (var component in children)
        {
            component.OperationInfo(depth + 2);
        }
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

        return null; //якщо такого немає - то щось потрібно зробити
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
                // Recursively search for the employee in the sub-department
                var employeeInSubDepartment = department.GetEmployeeByNameAndPosition(employeeName, employeePosition);
                if (employeeInSubDepartment != null)
                {
                    return employeeInSubDepartment;
                }
            }
        }

        return null; // If the employee is not found in this department and its sub-departments
    }
}

// Клас, який представляє працівника організації
class Employee : OrganizationComponent
{
    public string name;
    public string position;

    public Employee(string name, string position)
    {
        this.name = name;
        this.position = position;
    }

    // Перевизначений метод для отримання інформації про працівника
    public override void OperationInfo(int depth)
    {
        Console.WriteLine($"{new string(' ', depth)} {position}: {name}");
    }

    public void changePosition(string newPosition)
    {
        this.position = newPosition;
    }

}                   

    // Клас, який демонструє роботу патерну Композиція
    class CompositeDemo
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Створюємо організацію як кореневий компонент
            OrganizationComponent organization = new Department("Організація");

            // Створюємо відділи та додаємо їх до організації
            OrganizationComponent hrDepartment = new Department("Відділ кадрів");
            OrganizationComponent salesDepartment = new Department("Відділ продажів");
            OrganizationComponent techDepartment = new Department("Технічний відділ");

            organization.Add(hrDepartment);
            organization.Add(salesDepartment);
            organization.Add(techDepartment);

            // Додаємо працівників до відділів
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

        // Отримуємо інформацію про організацію
        organization.OperationInfo(0);

        //organization.MoveEmployeeToDepartment("Джек Доу", "Службовець", "Відділ SEO", "Відділ тестування");

        //organization.OperationInfo(0);

        ////змінити професію
        //Employee dzhekDoy = qaDepartment.GetEmployeeByNameAndPosition("Джек Доу", "Службовець");
        //dzhekDoy.changePosition("ЧАКЛУН");
        //organization.OperationInfo(0);

        //знищення компонента
        //organization.Remove(techDepartment);
        //Employee dzhekDoy = seoDepartment.GetEmployeeByNameAndPosition("Джек Доу", "Службовець");
        //seoDepartment.Remove(dzhekDoy);

        organization.OperationInfo(0);
    }
    }

class OrganizationComponentComparator : IComparer<OrganizationComponent>
{
    public int Compare(OrganizationComponent x, OrganizationComponent y)
    {
        // Якщо обидва об'єкти є відділами, порівнюємо їх за іменем
        if (x is Department && y is Department)
        {
            return ((Department)x).name.CompareTo(((Department)y).name);
        }
        // Якщо об'єкти різних типів, то Department має бути в кінці
        else if (x is Department)
        {
            return 1;
        }
        else if (y is Department)
        {
            return -1;
        }
        // Якщо обидва об'єкти є Employee
        else if (x is Employee && y is Employee)
        {
            // Отримуємо порядок посад за пріоритетом
            var positionOrder = new Dictionary<string, int>
            {  { "Директор", 1 },
                { "Заступник директора", 2 },
                { "Керівник", 3 },
                { "Заступник", 4 },
                { "Спеціаліст", 5 },
                { "Службовець", 6 },
                { "Робітник", 7 }
            };

            // Порівнюємо за пріоритетом посад
            var positionComparison = positionOrder[((Employee)x).position].CompareTo(positionOrder[((Employee)y).position]);
            if (positionComparison != 0)
            {
                return positionComparison;
            }
            // Якщо посади однакові, порівнюємо за іменем
            else
            {
                return ((Employee)x).name.CompareTo(((Employee)y).name);
            }
        }
        // Якщо обидва об'єкти різних типів, але не Employee та Department
        else
        {
            return 0; // ви можете задати свою власну логіку порівняння
        }
    }
}
