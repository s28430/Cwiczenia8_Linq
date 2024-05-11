using LinqTasks.Models;

namespace LinqTasks.Extensions;

public static class CustomExtensionMethods
{
    //Put your extension methods here
    public static IEnumerable<Emp> GetEmpsWithSubordinates(this IEnumerable<Emp> emps)
    {
        return emps
            .GroupBy(emp => emp.Mgr)
            .Where(group => group.Key is not null && group.Any())
            .Select(group => group.Key)
            .OrderBy(emp => emp.Ename)
            .ThenByDescending(emp => emp.Salary);
    }
}