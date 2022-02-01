using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMyReport.Repositories;
using FindMyReport.Models;

namespace FindMyReport.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestRepository _testRepository;
        public TestController(ITestRepository testRepository)
        {
            _testRepository = testRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tests = _testRepository.GetAll();
            return Ok(tests);
        }
        [HttpPost]
        public IActionResult Add(Test test)
        {
            _testRepository.Add(test);
            return Ok(test);
        }
    }
}

