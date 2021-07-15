using Microsoft.AspNetCore.Mvc;
using ApiDemo.Domain.Model.ClienteAggregate;
using System;
using Microsoft.Extensions.Logging;
using ApiDemo.WebApi.Contracts.v1;
using ApiDemo.Domain.Common;
using GlobalErrorHandling.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace ApiDemo.WebApi.Controllers
{
    /// <summary>
    /// Clase Cliente Controller.
    /// </summary>
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {

        private readonly ILogger<ClienteController> _logger;
        private IClienteService clienteService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="clienteService">Inyectamos la dependencia pasada por el starup.</param>
        /// <param name="logger">Inyectamos el logger.</param>
        public ClienteController(IClienteService clienteService, ILogger<ClienteController> logger)
        {
            this.clienteService = clienteService;
            this._logger = logger;
        }

        /// <summary>
        /// Metodo Get para obtener una lista de Clientes.
        /// </summary>
        /// <returns>Retorna una lista de Clientes.</returns>
        [HttpGet]
        [Route(ApiRoutes.Cliente.RestBase)]
        public ObjectResult get()
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("ClienteController", "get")
            };

            _logger.LogInformation("ClienteController", "get");

            try
            {
                objResultado.Resultado = this.clienteService.GetAll();
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

        /// <summary>
        /// Metodo Get para obtener una entidad cliente por id.
        /// </summary>
        /// <param name="id">Recibe el id.</param>
        /// <returns>Retorna una entidad.</returns>
        [HttpGet]
        [Route(ApiRoutes.Cliente.RestBase + "/{id}")]
        public ObjectResult get(int id)
        {
            int _codeStatus = 200;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("ClienteController", "get")
            };

            _logger.LogInformation("ClienteController", "get");

            try
            {
                var empleado = this.clienteService.GetByID(id);

                if (empleado == null) {
                    objResultado.Success = "NOK";
                    _codeStatus = 400;
                    _logger.LogError(string.Format("El cliente con el id: {id} no fue encontrado.", id), objResultado.Trace);
                    Error objerr = new Error
                    {
                        Codigo = "400",
                        Descripcion = string.Format("El cliente con el id: {id} no fue encontrado.", id)
                    };
                    objResultado.Errores.Add(objerr);
                }

                objResultado.Resultado = empleado;
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

        /// <summary>
        /// Metodo post para agregar un cliente.
        /// </summary>
        /// <param name="cliente">Recibe un cliente.</param>
        /// <returns>Retorna el cliente creado con su id correspondiente.</returns>
        [HttpPost]
        [Route(ApiRoutes.Cliente.RestBase)]
        public ObjectResult post([FromBodyAttribute] Cliente cliente)
        {
            int _codeStatus = 201;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("ClienteController", "post")
            };

            _logger.LogInformation("ClienteController", "post");

            try
            {
                this.clienteService.Add(cliente);

                objResultado.Resultado = cliente;
                //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + cliente.Id, cliente);
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

        /// <summary>
        /// Metodo para eliminar un cliente.
        /// </summary>
        /// <param name="id">Recibe el id de cliente.</param>
        /// <returns></returns>
        [HttpDelete]
        [Route(ApiRoutes.Cliente.RestBase  + "/{id}")]
        public ObjectResult delete(int id)
        {
            int _codeStatus = 201;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("ClienteController", "delete")
            };

            _logger.LogInformation("ClienteController", "delete");

            try
            {
                // buscamos el cliente.
                var cliente = this.clienteService.GetByID(id);

                if (cliente == null)
                {
                    objResultado.Success = "NOK";
                    _codeStatus = 400;
                    _logger.LogError(string.Format("El cliente con el id: {id} no fue encontrado.", id), objResultado.Trace);
                    Error objerr = new Error
                    {
                        Codigo = "400",
                        Descripcion = string.Format("El cliente con el id: {id} no fue encontrado.", id)
                    };
                    objResultado.Errores.Add(objerr);
                }else
                    this.clienteService.Remove(cliente);
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


        /// <summary>
        /// Metodo para actualizar el cliente.
        /// </summary>
        /// <param name="id">Recibe el id de cliente.</param>
        /// <param name="cliente">Recibe la entidad cliente.</param>
        /// <returns>Retorna una lista de clientes.</returns>
        [HttpPut]
        [Route(ApiRoutes.Cliente.RestBase + "/{id}")]
        public ObjectResult put(int id, [FromBodyAttribute] Cliente cliente)
        {
            int _codeStatus = 201;
            Respuesta objResultado = new Respuesta
            {
                Success = "OK",
                Trace = Trace.Instance.generaTrace("ClienteController", "put")
            };

            _logger.LogInformation("ClienteController", "put");

            try
            {
                var clienteExiste = this.clienteService.GetByID(id);

                if (clienteExiste == null)
                {
                    objResultado.Success = "NOK";
                    _codeStatus = 400;
                    _logger.LogError(string.Format("El cliente con el id: {id} no fue encontrado.", id), objResultado.Trace);
                    Error objerr = new Error
                    {
                        Codigo = "400",
                        Descripcion = string.Format("El cliente con el id: {id} no fue encontrado.", id)
                    };
                    objResultado.Errores.Add(objerr);
                }
                else
                    this.clienteService.Update(cliente);
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