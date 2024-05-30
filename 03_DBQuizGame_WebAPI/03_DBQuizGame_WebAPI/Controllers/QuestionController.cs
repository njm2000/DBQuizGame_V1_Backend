using Microsoft.AspNetCore.Mvc;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.DTO;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly ILogger<QuestionController> _logger;
        private readonly IQuestionService _service;

        public QuestionController(ILogger<QuestionController> logger, IQuestionService questionService)
        {
            _logger = logger;
            _service = questionService;
        }

        #region Generic Functions

        [HttpGet]
        public IEnumerable<Question> GetAll()
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
        public IEnumerable<Question> GetActive()
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
        public IEnumerable<Question> GetTerminated()
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
        public Question GetById(Guid id)
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

        [HttpGet("GetByName/{name}")]
        public Question GetByName(string name)
        {
            try
            {
                var result = _service.GetByName(name);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("ContainsName/{keyword}")]
        public IEnumerable<Question> ContainsName(string keyword)
        {
            try
            {
                var result = _service.ContainsName(keyword);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpGet("ContainsDescription/{keyword}")]
        public IEnumerable<Question> ContainsDescription(string keyword)
        {
            try
            {
                var result = _service.ContainsDescription(keyword);

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.ToString());
                throw;
            }
        }

        [HttpPost]
        public void Post(Question entity)
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
        public void Put(Question entity)
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
        #endregion
    }
}
