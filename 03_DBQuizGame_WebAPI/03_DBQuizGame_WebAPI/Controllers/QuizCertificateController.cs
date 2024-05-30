using Microsoft.AspNetCore.Mvc;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.DTO;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuizCertificateController : ControllerBase
    {
        private readonly ILogger<QuizCertificateController> _logger;
        private readonly IQuizCertificateService _service;

        public QuizCertificateController(ILogger<QuizCertificateController> logger, IQuizCertificateService QuizCertificateService)
        {
            _logger = logger;
            _service = QuizCertificateService;
        }

        #region Generic Functions

        [HttpGet]
        public IEnumerable<QuizCertificate> GetAll()
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
        public IEnumerable<QuizCertificate> GetActive()
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
        public IEnumerable<QuizCertificate> GetTerminated()
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
        public QuizCertificate GetById(Guid id)
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
        public void Post(QuizCertificate entity)
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
        public void Put(QuizCertificate entity)
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
