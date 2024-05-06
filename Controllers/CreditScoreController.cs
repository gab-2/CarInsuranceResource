using CarInsuranceApi.Models;
using CarInsuranceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarInsuranceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditScoreController : ControllerBase
    {
        private readonly CreditScoreService _creditScoreService;

        public CreditScoreController(CreditScoreService creditScoreService)
        {
            _creditScoreService = creditScoreService;
        }

        [HttpPost]
        public IActionResult GetCreditScore([FromBody] CreditScoreRequest request)
        {
            var score = _creditScoreService.GetCreditScore(request);
            if (score == null)
                return NotFound("Credit score data not found for the given criteria.");

            return Ok(new { CreditScore = score.Value.ToString("0.################") });
        }
    }
}
