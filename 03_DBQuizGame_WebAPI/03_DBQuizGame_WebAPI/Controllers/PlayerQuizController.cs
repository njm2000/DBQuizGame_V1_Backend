using Microsoft.AspNetCore.Mvc;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.DTO;
using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerQuizController : ControllerBase
    {
        private readonly ILogger<PlayerQuizController> _logger;
        private readonly IPlayerQuizService _service;

        public PlayerQuizController(ILogger<PlayerQuizController> logger, IPlayerQuizService playerQuizService)
        {
            _logger = logger;
            _service = playerQuizService;
        }

        #region Generic Functions

        [HttpGet]
        public IEnumerable<PlayerQuiz> GetAll()
        {
            try
            {
                var result = _service.GetAll();

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("GetActive")]
        public IEnumerable<PlayerQuiz> GetActive()
        {
            try
            {
                var result = _service.GetActive();

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("GetTerminated")]
        public IEnumerable<PlayerQuiz> GetTerminated()
        {
            try
            {
                var result = _service.GetTerminated();

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("{id}")]
        public PlayerQuiz GetById(Guid id)
        {
            try
            {
                var result = _service.GetById(id);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }
    
        [HttpPost]
        public void Post(PlayerQuiz entity)
        {
            try
            {
                _service.Create(entity);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPut]
        public void Put(PlayerQuiz entity)
        {
            try
            {
                _service.Update(entity);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _service.Delete(id);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPut("Terminate/{id}")]
        public void Terminate(Guid id)
        {
            try
            {
                _service.Terminate(id);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPut("Reactivate/{id}")]
        public void Reactivate(Guid id)
        {
            try
            {
                _service.Reactivate(id);

            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        #endregion

        #region Custom Functions
        [HttpPost("ViewQuiz")]
        public ViewQuizResponse ViewQuiz(ViewQuizRequest request)
        {
            ViewQuizResponse response = new ViewQuizResponse();

            try
            {
                response = _service.ViewQuiz(request);
                response.IsCallSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsCallSuccess = false;
                response.ErrorMessage = ex.Message;
                this._logger.LogError(ex.ToString());
                throw;
            }

            return response;
        }

        [HttpPost("SavePlayerQuiz")]
        public SavePlayerQuizResponse SavePlayerQuiz(SavePlayerQuizRequest request)
        {
            SavePlayerQuizResponse response = new SavePlayerQuizResponse();

            try
            {
                response = _service.SavePlayerQuiz(request);
                response.IsCallSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsCallSuccess = false;
                response.ErrorMessage = ex.Message;
                this._logger.LogError(ex.ToString());
                throw;
            }

            return response;
        }
        #endregion
    }
}
