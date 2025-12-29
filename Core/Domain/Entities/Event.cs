namespace ConferenceMaster.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public bool IsPaid { get; set; }
    public Guid HallId { get; set; }
}