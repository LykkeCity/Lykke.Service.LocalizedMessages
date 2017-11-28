using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Service.LocalizedMessages.Core.Domain;
using Lykke.Service.LocalizedMessages.Core.Domain.Messages;
using Lykke.Service.LocalizedMessages.Core.Services;
using Lykke.Service.LocalizedMessages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Swashbuckle.SwaggerGen.Annotations;

namespace Lykke.Service.LocalizedMessages.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ILog _log;

        public MessageController(IMessageRepository messageRepository, ILog log)
        {
            _messageRepository = messageRepository;
            _log = log;
        }

        /// <summary>
        /// Get single message from project by code and local
        /// </summary>
        /// <param name="componentName">Component owner of message</param>
        /// <param name="messageCode">Code of message</param>
        /// <param name="localCode">Locale of message</param>
        [HttpGet]
        [Route("{componentName}/{messageCode}/{localCode}")]
        [SwaggerOperation("GetLocalizeByCode")]
        [ProducesResponseType(typeof(MessageResponce), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetLocalizeByCode(string componentName, string messageCode, string localCode)
        {
            if (string.IsNullOrEmpty(localCode))
            {
                await _log.WriteInfoAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}, {localCode}", "Cannot work with empty localCode");

                return NotFound(ErrorResponse.Create("Cannot work with empty component"));
            }

            if (string.IsNullOrEmpty(componentName))
            {
                await _log.WriteInfoAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}, {localCode}", "Cannot work with empty component");

                return NotFound(ErrorResponse.Create("Cannot work with empty component"));
            }

            if (string.IsNullOrEmpty(messageCode))
            {
                await _log.WriteInfoAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}, {localCode}", "Cannot work with empty messageCode");

                return NotFound(ErrorResponse.Create("Cannot work with empty component"));
            }

            var message = await _messageRepository.GetLocalizedByMessageCode(messageCode, componentName, localCode);

            if (message == null)
            {
                await _log.WriteWarningAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}, {localCode}", "Cannot find message code");

                return NotFound(ErrorResponse.Create("Cannot find message code"));
            }

            var responce = Mapper.Map<IMessageLocalized, MessageResponce>(message);

            return Ok(responce);
        }

        /// <summary>
        /// Get all message from project by Code. Return all translate of message in project.
        /// </summary>
        /// <param name="componentName">Component owner of message</param>
        /// <param name="messageCode">Code of message</param>
        [HttpGet]
        [Route("{componentName}/{messageCode}")]
        [SwaggerOperation("GetAllMessagesByCode")]
        [ProducesResponseType(typeof(List<MessageResponce>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllByCode(string componentName, string messageCode)
        {
            var message = await _messageRepository.GetAllTranslationByMessageAsync(messageCode, componentName);

            if (message == null)
            {
                await _log.WriteWarningAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}", "Cannot find message code");

                return NotFound(ErrorResponse.Create("Cannot find message code"));
            }

            if (string.IsNullOrEmpty(componentName))
            {
                await _log.WriteInfoAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}", "Cannot work with empty component");

                return NotFound(ErrorResponse.Create("Cannot work with empty component"));
            }

            if (string.IsNullOrEmpty(messageCode))
            {
                await _log.WriteInfoAsync(nameof(MessageController), nameof(GetLocalizeByCode),
                    $"{componentName}, {messageCode}", "Cannot work with empty messageCode");

                return NotFound(ErrorResponse.Create("Cannot work with empty component"));
            }

            var responce = message.Select(Mapper.Map<IMessageLocalized, MessageResponce>).ToList();

            return Ok(responce);
        }

        /// <summary>
        /// Get all message from project. Return all message with all local in project.
        /// </summary>
        /// <param name="componentName">Component owner of message</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{componentName}")]
        [SwaggerOperation("GetMessageByComponent")]
        [ProducesResponseType(typeof(List<MessageResponce>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetAllByProject(string componentName)
        {
            var message = await _messageRepository.GetAllTranslationByComponentAsync(componentName);
            var responce = message.Select(Mapper.Map<IMessageLocalized, MessageResponce>).ToList();
            return Ok(responce);
        }
    }
}
