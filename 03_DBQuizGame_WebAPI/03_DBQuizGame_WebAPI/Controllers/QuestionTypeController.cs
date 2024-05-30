using Microsoft.AspNetCore.Mvc;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.DTO;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionTypeController : ControllerBase
    {
        private readonly ILogger<QuestionTypeController> _logger;
        private readonly IQuestionTypeService _service;

        public QuestionTypeController(ILogger<QuestionTypeController> logger, IQuestionTypeService questionTypeService)
        {
            _logger = logger;
            _service = questionTypeService;
        }

        #region Generic Functions

        [HttpGet]
        public IEnumerable<QuestionType> GetAll()
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
        public IEnumerable<QuestionType> GetActive()
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
        public IEnumerable<QuestionType> GetTerminated()
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
        public QuestionType GetById(int id)
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
        public QuestionType GetByName(string name)
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
        public IEnumerable<QuestionType> ContainsName(string keyword)
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
        public IEnumerable<QuestionType> ContainsDescription(string keyword)
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
        public void Post(QuestionType entity)
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
        public void Put(QuestionType entity)
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
        public void Delete(int id)
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
        public void Terminate(int id)
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
        public void Reactivate(int id)
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
