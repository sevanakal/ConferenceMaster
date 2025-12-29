namespace ConferenceMaster.Domain.Entities;

public class Hall {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public  int Capacity { get; set; }
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
