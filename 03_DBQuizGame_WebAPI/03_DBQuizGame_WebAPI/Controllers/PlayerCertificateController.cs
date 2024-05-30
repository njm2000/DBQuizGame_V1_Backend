using Microsoft.AspNetCore.Mvc;
using _02_DBQuizGame_Service.IService;
using _02_DBQuizGame_Service.DTO;
using _02_DBQuizGame_Service.Request;
using _02_DBQuizGame_Service.Response;

namespace _03_DBQuizGame_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerCertificateController : ControllerBase
    {
        private readonly ILogger<PlayerCertificateController> _logger;
        private readonly IPlayerCertificateService _service;

        public PlayerCertificateController(ILogger<PlayerCertificateController> logger, IPlayerCertificateService playerCertificateService)
        {
            _logger = logger;
            _service = playerCertificateService;
        }

        #region Generic Functions

        [HttpGet]
        public IEnumerable<PlayerCertificate> GetAll()
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
        public IEnumerable<PlayerCertificate> GetActive()
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
        public IEnumerable<PlayerCertificate> GetTerminated()
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
        public PlayerCertificate GetById(Guid id)
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

        //[HttpGet("GetByIdPlayer/{id}")]
        //public IEnumerable<PlayerCertificate> GetByIdPlayer(Guid id)
        //{
        //    try
        //    {
        //        var result = _service.GetByIdPlayer(id);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        this._logger.LogError(ex.ToString());
        //        throw;
        //    }
        //}

        //[HttpGet("GetByIdCertificate/{id}")]
        //public PlayerCertificate GetByIdCertificate(Guid id)
        //{
        //    try
        //    {
        //        var result = _service.GetByIdCertificate(id);

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        this._logger.LogError(ex.ToString());
        //        throw;
        //    }
        //}


        [HttpPost]
        public void Post(PlayerCertificate entity)
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
        public void Put(PlayerCertificate entity)
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
        [HttpPost("ViewPlayerCertificate")]
        public ViewPlayerCertificateResponse ViewPlayerCertificate(ViewPlayerCertificateRequest request)
        {
            ViewPlayerCertificateResponse response = new ViewPlayerCertificateResponse();

            try
            {
                response = _service.ViewPlayerCertificate(request);
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

        [HttpPost("SavePlayerCertificate")]
        public SavePlayerCertificateResponse SavePlayerCertificate(SavePlayerCertificateRequest request)
        {
            SavePlayerCertificateResponse response = new SavePlayerCertificateResponse();

            try
            {
                response = _service.SavePlayerCertificate(request);
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
