namespace Hotel_Reservation_API.Models;

public class Reservation
{
    public string Id { get; set; }
    public DateOnly CheckInDate { get; set; }
    public DateOnly CheckOutDate { get; set; }
    public string GuestName { get; set; }
    public string GuestEmail { get; set; }
    public int RoomNumber { get; set; }
}



