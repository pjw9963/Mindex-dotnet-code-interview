using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportingStructureService> _logger;

        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        public ReportingStructure GetById(string id)
        {
            if(!String.IsNullOrEmpty(id))
            {
                var reportEmployee = _employeeRepository.GetById(id);
                int reportCount = getReportingCount(reportEmployee);;                

                var result = new ReportingStructure();
                result.employee = reportEmployee;
                result.numberOfReports = reportCount;

                return result;
            }

            return null;
        }

        private int getReportingCount(Employee emp)
        {
            if (emp.DirectReports != null && emp.DirectReports.Any()) 
            {
                int reportCount = emp.DirectReports.Count;
                foreach (Employee dr in emp.DirectReports)
                {
                    reportCount += getReportingCount(dr);
                }
                return reportCount;
            }
            else 
            {
                return 0;
            }
        }

    }
}