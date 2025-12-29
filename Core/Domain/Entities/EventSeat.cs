namespace ConferenceMaster.Domain.Entities;

public class EventSeat
{
    public  Guid Id { get; set; }
    public Guid EventId { get; set; }
    public Guid PhysicalSeatId { get; set; }
    
    //Bu etkinlikte bu koltuktan kim sorumlu
    public Guid ResponsibleUserId { get; set; }

    //Satış durumu
    public bool IsSold { get; set; }
    public decimal Price { get; set; }

    //Transfer talep durumu
    public Guid? TransferRequestedToUserId { get; set; }
}