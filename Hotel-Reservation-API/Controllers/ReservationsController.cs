using Hotel_Reservation_API.Data;
using Hotel_Reservation_API.Dtos;
using Hotel_Reservation_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Reservation_API.Controllers;

[Route("[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReservationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetReservations()
    {
        return Ok(await _context.Reservations.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservation(string id)
    {
        var reservation = await _context.Reservations.FindAsync(id);

        if (reservation == null)
            return NotFound();

        return Ok(reservation);
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservation(ReservationDto reservation)
    {
        var newReservation = new Reservation
        {
            Id = Guid.NewGuid().ToString(),
            CheckInDate = reservation.CheckInDate,
            CheckOutDate = reservation.CheckOutDate,
            GuestName = reservation.GuestName,
            GuestEmail = reservation.GuestEmail,
            RoomNumber = reservation.RoomNumber
        };

        _context.Reservations.Add(newReservation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetReservation), new { id = newReservation.Id }, newReservation);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateReservation(string id, ReservationDto reservation)
    {
        var existingReservation = await _context.Reservations.FindAsync(id);
        if (existingReservation == null)
            return NotFound();

        existingReservation.CheckInDate = reservation.CheckInDate;
        existingReservation.CheckOutDate = reservation.CheckOutDate;
        existingReservation.GuestName = reservation.GuestName;
        existingReservation.GuestEmail = reservation.GuestEmail;
        existingReservation.RoomNumber = reservation.RoomNumber;


        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReservation(string id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
            return NotFound();

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
