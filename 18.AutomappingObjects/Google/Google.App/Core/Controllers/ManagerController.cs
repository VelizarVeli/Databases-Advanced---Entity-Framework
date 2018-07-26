using System;
using System.Linq;
using AutoMapper.QueryableExtensions;
using Google.App.Core.Contracts;
using Google.App.Core.Dtos;
using Google.Data;
using Microsoft.EntityFrameworkCore;

namespace Google.App.Core.Controllers
{
    public class ManagerController : IManagerController
    {
        private readonly GoogleContext context;

        public ManagerController(GoogleContext context)
        {
            this.context = context;
        }

        public ManagerDto GetManagerInfo(int employeeId)
        {
            var employee = context.Employees
                .Where(x => x.Id == employeeId)
                .ProjectTo<ManagerDto>()
                .SingleOrDefault();

            if (employee == null)
            {
                throw new ArgumentException("Invalid id");
            }

            return employee;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var manager = this.context.Employees.Find(managerId);

            if (employee == null || manager == null)
            {
                throw new ArgumentException("Invalid id");
            }

            employee.Manager = manager;

            context.SaveChanges();
        }
    }
}
