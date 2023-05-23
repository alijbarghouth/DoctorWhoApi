using DoctorWho.Web.DTOs.DoctorsDTOs;
using DoctorWho.Web.Filter;
using DoctorWho.Web.Services.DoctorService;
using Microsoft.AspNetCore.Mvc;

namespace DoctorWho.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DoctorWhoExceptionHandlerFilter]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("doctors/all")]
        public async Task<ActionResult> GetAllDoctors()
        {
            return Ok(await _doctorService.GetAllDoctors());
        }

        [HttpPut("updateDoctor/{doctorId:int}")]
        public async Task<IActionResult> UpdateDoctorAsync(Doctor doctor, int doctorId)
        {
            return Ok(await _doctorService.UpdateDoctor(doctor, doctorId));
        }

        [HttpPost("addDoctor")]
        public async Task<IActionResult> AddDoctorAsync(Doctor doctorDtOs)
        {
            return Ok(await _doctorService.AddDoctor(doctorDtOs));
        }
    }
}