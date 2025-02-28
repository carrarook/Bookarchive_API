using System.Net;
using System.Reflection;
using System.Globalization;
using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

using API.Controllers.Contract;

using Application.Dictionary;
using Application.DTOs.Response;
using Application.Configurations;
using Application.Interfaces;


namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : BaseController
    {
        private readonly DateTime _startupTime;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="defaultDictionary">Dicion�rio de respostas padr�o.</param>
        /// <param name="startupTimeService">Servi�o para obter o tempo de inicializa��o da aplica��o.</param>
        /// <param name="configuration">Configura��o da aplica��o.</param>
        public HomeController(
            DefaultDictionary defaultDictionary,
            StartupTimeService startupTimeService,
            IConfiguration configuration
            ) : base(defaultDictionary)
        {
            _startupTime = startupTimeService.StartupTime;
            _configuration = configuration;
        }

        /// <summary>
        /// Verifica se a API est� online e retorna informa��es sobre o ambiente.
        /// </summary>
        /// <remarks>
        /// Esta rota retorna informa��es detalhadas sobre o ambiente em que a aplica��o est� sendo executada, incluindo o nome do projeto, ambiente de execu��o, cultura atual, SO e framework alvo.
        /// </remarks>
        /// <returns>Um objeto com informa��es do ambiente e status de sa�de da aplica��o.</returns>
        /// <response code="200">Sucesso - Retorna as informa��es do ambiente.</response>
        /// <response code="500">Erro Interno - Falha ao processar a solicita��o.</response>
        [HttpGet]
        [Route("status")]
        [SwaggerOperation(Summary = "Verifica o status da API", Description = "Retorna informa��es sobre o ambiente e a sa�de da aplica��o.")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ApiResponseModel<IResponseHome>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponseErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult IsOnline()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var projectName = assembly.GetName().Name;
            var environment = _configuration["ASPNETCORE_ENVIRONMENT"];
            var culture = CultureInfo.CurrentCulture.DisplayName;
            var os = Environment.GetEnvironmentVariable("OS");

            var targetFrameworkAttribute = Assembly
                .GetExecutingAssembly()?
                .GetCustomAttribute<TargetFrameworkAttribute>();

            var targetFramework = targetFrameworkAttribute?.FrameworkName ?? "Unknown";

            IResponseHome responseData = new()
            {
                ProjectName = projectName,
                Machine = os,
                Culture = culture,
                Environment = environment,
                TargetFramework = targetFramework,
                StartupTime = _startupTime,
                Alive = true
            };

            return ApiResponse(
                responseData, 
                _defaultDictionary.Response["Success"], 
                HttpStatusCode.OK
                );
        }
    }
}