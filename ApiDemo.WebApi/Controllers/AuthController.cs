using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.Extensions.Configuration;
using System.Text;
using ApiDemo.Domain.Common;
using GlobalErrorHandling.Extensions;
using ApiDemo.WebApi.Contracts.v1;
using ApiDemo.Domain.Model.UsuarioAggregate;
using Microsoft.AspNetCore.Authorization;

namespace ApiDemo.WebApi.Controllers
{
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IConfiguration _configuration;
        private IUsuarioService usuarioService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clienteService">Inyectamos la dependencia pasada por el starup.</param>
        /// <param name="logger">Inyectamos el logger.</param>
        public AuthController(IConfiguration configuration, ILogger<AuthController> logger, IUsuarioService usuarioService)
        {
            this._configuration = configuration;
            this._logger = logger;
            this.usuarioService = usuarioService;
        }

        [HttpPost]
        [Route(ApiRoutes.Usuario.Login)]
        [AllowAnonymous]
        public ObjectResult Login(Usuario usuario)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("AuthController", "Login")
            };

            _logger.LogInformation("AuthController", "Login");

            try
            {
                // Leemos el secret_key desde nuestro appseting
                var secretKey = _configuration.GetValue<string>("SecretKey");
                
                objResultado.Resultado = this.usuarioService.LoginToken(usuario, secretKey);
            }
            catch (Exception ex)
            {
                objResultado.Success = "NOK";
                _codeStatus = 500;
                _logger.LogCritical(ex, "Error de procesamiento Trace { trace}", objResultado.Trace);
                Error objerr = new Error
                {
                    Codigo = "500",
                    Descripcion = "Error de procesamiento."
                };
                objResultado.Errores.Add(objerr);
            }

            return StatusCode(_codeStatus, objResultado);
        }
    }
}
