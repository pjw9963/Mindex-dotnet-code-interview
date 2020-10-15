using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/reportingStructure")]
    public class ReportingStructure : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingService;

        public ReportingStructure(ILogger<ReportingStructure> logger, IReportingStructureService reportingService)
        {
            _logger = logger;
            _reportingService = reportingService;
        }


        [HttpGet("{id}", Name = "GetReportStructureById")]
        public IActionResult GetReportStructureById(String id)
        {
            _logger.LogDebug($"Received Reporting Structure get request for '{id}'");
            var reportStructure = _reportingService.GetById(id);

            if (reportStructure == null)
                return NotFound();

            return Ok(reportStructure);
        }

    }
}