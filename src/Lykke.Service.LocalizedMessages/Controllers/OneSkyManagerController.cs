using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace Lykke.Service.LocalizedMessages.Controllers
{
    public class OneSkyManagerController : Controller
    {
        /// <summary>
        /// Get log of export data from OneSky
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("export/{projectName}/log")]
        [SwaggerOperation("GetExportLog")]
        public IActionResult GetExportLog(string projectName, [FromQuery] DateTime? fromDate = null)
        {
            var date = fromDate ?? DateTime.MinValue;
            return Ok($"export project: {projectName} ,date: {date.ToString("yyyy-MM-dd HH:mm:ss")}");
        }

        /// <summary>
        /// Start export date from OneSky by project
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("export/{projectName}/start")]
        [SwaggerOperation("StartExport")]
        public IActionResult StartExport(string projectName)
        {
            return Ok($"export project: {projectName}");
        }

        /// <summary>
        /// Get project name list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("project/list")]
        [SwaggerOperation("GetNameOfProjectsList")]
        public IActionResult GetProjectNameList()
        {
            return Ok($"project list");
        }

        /// <summary>
        /// Get project languages list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("project/{projectName}/languages")]
        [SwaggerOperation("GetProjectLanguagesList")]
        public IActionResult GetProjectLanguagesList(string projectName)
        {
            return Ok($"locals list from project: {projectName}");
        }
    }
}
