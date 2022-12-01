using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EmployeeApp.CustomModelBinders
{
    public class EmployeeSearchBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var data = bindingContext.HttpContext.Request.Query;

            var salary_result = data.TryGetValue("salary", out var salary);
            var v_result = data.TryGetValue("v", out var v);
            var department_result = data.TryGetValue("department", out var department);
            var page_result = data.TryGetValue("page", out var page);

            var employeeSearchModel = new EmployeeSearchModel();

            if (salary_result)
            {
                var salaryRange = Array.ConvertAll(salary.ToString().Split("-"), n => int.Parse(n));

                employeeSearchModel.SalaryRange = salaryRange;
            }

            if (department_result)
            {
                var departmentList = department.ToString().Split(",");

                employeeSearchModel.DepartmentList = departmentList;
            }

            if (v_result) employeeSearchModel.v = v;

            if (page_result) employeeSearchModel.Page = int.Parse(page);


            bindingContext.Result = ModelBindingResult.Success(employeeSearchModel);

            return Task.CompletedTask;
        }
    }
}
