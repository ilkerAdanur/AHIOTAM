using AHIOTAM_Api.Repositories.StatisticsRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AHIOTAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsRepository _statisticsRepository;
        public StatisticsController(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var values = _statisticsRepository.ActiveCategoryCount();
            return Ok(values);
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var values = _statisticsRepository.PassiveCategoryCount();
            return Ok(values);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            var values = _statisticsRepository.CategoryCount();
            return Ok(values);
        }
        [HttpGet("ActiveMenuCount")]
        public IActionResult ActiveMenuCount()
        {
            var values = _statisticsRepository.ActiveMenuCount();
            return Ok(values);
        }
        [HttpGet("PassiveMenuCount")]
        public IActionResult PassiveMenuCount()
        {
            var values = _statisticsRepository.PassiveMenuCount();
            return Ok(values);
        }
        [HttpGet("MenuCount")]
        public IActionResult MenuCount()
        {
            var values = _statisticsRepository.MenuCount();
            return Ok(values);
        }
        [HttpGet("CategoryNameByMaxMenuCount")]
        public IActionResult CategoryNameByMaxMenuCount()
        {
            var values = _statisticsRepository.CategoryNameByMaxMenuCount();
            return Ok(values);
        }
    }
}
