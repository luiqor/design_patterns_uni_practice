using Composite_webapp.Controllers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{

    public IActionResult Index(string componentName, bool isEmployee, bool isDepartment)
    {
        Department organization = (Department)CompositeDemo.organization;
        List<string> organizationInfo = new List<string>();

        if (string.IsNullOrEmpty(componentName))
        {
            organizationInfo = organization.OperationInfo(0, isDepartment: true, isEmployee: true, applyCss: true).ToList();
        }
        else
        {
            Department userwrittenComp = organization.FindDepartment(componentName.Trim());
            if (userwrittenComp != null)
            {
                organizationInfo = userwrittenComp.OperationInfo(0, isDepartment: isDepartment, isEmployee: isEmployee, applyCss: true).ToList();
            }
            else
            {
                organizationInfo.Add("Такого відділу не знайдено");
                return View(organizationInfo);
            }
        }

        return View(organizationInfo);
    }

    public IActionResult EmloyeeAddRemove(string userwrittenName, string userwrittenPosition, string userwrittenDep, bool isAdding)
    {
        //знищення компонента
        //Employee dzhekDoy = seoDepartment.GetEmployeeByNameAndPosition("Джек Доу", "Службовець");
        //seoDepartment.Remove(dzhekDoy);
        Department organization = (Department)CompositeDemo.organization;
        Department emloyeesDep = organization.FindDepartment(userwrittenDep.Trim());
        List<string> organizationInfo = new List<string>();

        if (emloyeesDep == null) 
        {
            organizationInfo.Add("Такого відділу не знайдено");
            return View("Index", organizationInfo);
        }
        if (isAdding)
        {
            //salesDepartment.Add(new Employee("Фрозен Ельза", "Спеціаліст"));
            emloyeesDep.Add(new Employee(userwrittenName, userwrittenPosition));
        }
        else if (!isAdding)
        {
            Employee userwrittenEmpl = emloyeesDep.GetEmployeeByNameAndPosition(userwrittenName, userwrittenPosition);
            if (userwrittenEmpl == null) 
            {
                organizationInfo.Add("Такого співробітника не знайдено");
                return View("Index", organizationInfo);
            }
            emloyeesDep.Remove(userwrittenEmpl);

        }
        organizationInfo.Add("Успіх");
        return View("Index", organizationInfo);
    }

    public IActionResult EmloyeeTransfer(string userwrittenName, string userwrittenPosition, string oldDepartment, string newDepartment)
    {
        //organization.MoveEmployeeToDepartment("Джек Доу", "Службовець", "Відділ SEO", "Відділ тестування");
        List<string> organizationInfo = new List<string>();
        Department organization = (Department)CompositeDemo.organization;
        Department oldDepComp = organization.FindDepartment(oldDepartment.Trim());
        Department newDepComp = organization.FindDepartment(newDepartment.Trim());
        if (oldDepComp == null || newDepComp == null) 
        {
            organizationInfo.Add($"Одного з віддліів не існує");
            return View("Index", organizationInfo);
        }
        Employee userwrittenEmpl = oldDepComp.GetEmployeeByNameAndPosition(userwrittenName, userwrittenPosition);
        if (userwrittenEmpl == null)
        {
            organizationInfo.Add("Такого співробітника не знайдено");
            return View("Index", organizationInfo);
        }


        organization.MoveEmployeeToDepartment(userwrittenName, userwrittenPosition, oldDepartment, newDepartment);
        organizationInfo.Add("Успіх");
        return View("Index", organizationInfo);
    }

    public IActionResult EmloyeePositionChange(string userwrittenName, string userwrittenDep, string oldPosotion, string newPosition)
    {
        ////змінити професію
        //Employee dzhekDoy = qaDepartment.GetEmployeeByNameAndPosition("Джек Доу", "Службовець");
        //dzhekDoy.changePosition("ЧАКЛУН");
        //organization.OperationInfo(0);
        List<string> organizationInfo = new List<string>();
        Department organization = (Department)CompositeDemo.organization;
        Department emloyeesDep = organization.FindDepartment(userwrittenDep.Trim());
        if (emloyeesDep == null)
        {
            organizationInfo.Add("Такого відділу не знайдено");
            return View("Index", organizationInfo);
        }

        Employee userwrittenEmpl = emloyeesDep.GetEmployeeByNameAndPosition(userwrittenName, oldPosotion);
        if (userwrittenEmpl == null)
        {
            organizationInfo.Add("Такого співробітника не знайдено");
            return View("Index", organizationInfo);
        }

        userwrittenEmpl.ChangePosition(newPosition);

        organizationInfo.Add("Успіх");
        return View("Index", organizationInfo);
    }

    public IActionResult DepartmentAddRemove(string departmentName,string ancestorDepName, bool isAdding)
    {
        List<string> organizationInfo = new List<string>();
        Department organization = (Department)CompositeDemo.organization;
        Department ancestorDepComp = organization.FindDepartment(ancestorDepName.Trim());
        if (ancestorDepComp == null)
        {
            organizationInfo.Add($"Відділ {ancestorDepName} не існує");
            return View("Index", organizationInfo);
        }


        if (isAdding)
        {
            ancestorDepComp.Add(new Department(departmentName));
            //organization.Add();
        }
        else if (!isAdding)
        {
            Department departmentComp = organization.FindDepartment(departmentName.Trim());
            if (departmentComp == null) 
            {
                organizationInfo.Add($"Відділ {departmentName} не існує");
                return View("Index", organizationInfo);
            }
            ancestorDepComp.Remove(departmentComp);
            //organization.Remove();
        }
        organizationInfo.Add("Успіх");
        return View("Index", organizationInfo);
    }
}
