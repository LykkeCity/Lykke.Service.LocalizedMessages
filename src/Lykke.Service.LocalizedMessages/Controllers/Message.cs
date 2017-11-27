using System;
using System.Net;
using Lykke.Service.LocalizedMessages.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.SwaggerGen.Annotations;

namespace Lykke.Service.LocalizedMessages.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        /// <summary>
        /// Get single message from project by code and local
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{projectName}/{messageCode}/{local}")]
        [SwaggerOperation("GetMessageByCode")]
        public IActionResult GetLocalizeByCode(string projectName, string messageCode, string local)
        {
            return Ok($"{projectName} {messageCode} {local}");
        }

        /// <summary>
        /// Get all message from project by Code. Return all translate of message in project.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{projectName}/{messageCode}")]
        [SwaggerOperation("GetAllMessagesByCode")]
        public IActionResult GetAllByCode(string projectName, string messageCode)
        {
            return Ok($"{projectName} {messageCode}");
        }

        /// <summary>
        /// Get all message from project. Return all message with all local in project.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{projectName}")]
        [SwaggerOperation("GetMessageByProject")]
        public IActionResult GetAllByProject(string projectName)
        {
            return Ok($"{projectName}");
        }
    }
}
