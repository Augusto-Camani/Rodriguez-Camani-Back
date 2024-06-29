using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiBarberia;

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("barber-appointments")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetAppointmentsByBarberId([FromQuery] int barberId)
        {
            try
            {
                var appointments = _appointmentService.GetAppointmentsByBarberId(barberId);
                if (appointments == null || !appointments.Any())
                {
                    return NotFound("No se encontraron turnos del barbero.");
                }
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("available-slots")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetAvailableSlotsForBarberAndDate([FromQuery] int barberId, [FromQuery] DateTime date)
        {
            try
            {
                var slots = _appointmentService.GetAvailableBarberAppointmentsByDate(barberId, date);
                if (slots == null || !slots.Any())
                {
                    return NotFound("No se encontraron slots disponibles para el barbero en la fecha especificada.");
                }
                return Ok(slots);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("appointment/{appointmentId}")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult GetAppointmentById([FromRoute] int appointmentId)
        {
            try
            {
                var appointment = _appointmentService.GetAppointmentById(appointmentId);
                if (appointment == null)
                {
                    return NotFound("No se encontró el turno especificado.");
                }
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpPost("create-appointment")]
        [Authorize(Policy = "ClientPolicy")]
        public IActionResult CreateAppointment([FromBody] AppointmentDTO appointmentDTO)
        {
            try
            {
                _appointmentService.CreateAppointment(appointmentDTO);
                return Created("api/appointment/create-appointment", appointmentDTO); // Puedes ajustar la URL de retorno si es necesario
            }
            catch (ArgumentException ex)
            {
                return BadRequest($"Error al crear el turno: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpDelete("delete-appointment/{appointmentId}")]
        [Authorize(Policy = "BothPolicy")]
        public IActionResult DeleteAppointment([FromRoute] int appointmentId)
        {
            try
            {
                var existingAppointment = _appointmentService.GetAppointmentById(appointmentId);
                if (existingAppointment == null)
                {
                    return NotFound("No se encontró el turno especificado.");
                }

                _appointmentService.DeleteAppointment(appointmentId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }