using _02_DBQuizGame_Service.DTO;
using Microsoft.AspNetCore.Mvc;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;

        public DefaultController(ILogger<DefaultController> logger)
        {
            _logger = logger;
        }

        //Test API Connection
        [HttpGet]
        public Default Get()
        {
            try
            {
                Default connection = new Default();

                connection.IsConnected = true;
                connection.Message = "DBQuizGame WebAPI: Connection Established!";

                return connection;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
