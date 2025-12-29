namespace ConferenceMaster.Domain.Entities;

public class Seat
{
    public Guid Id { get; set; }
    public Guid HallId { get; set; }
    public string RowName { get; set; }
    public int Number { get; set; }
    public int CoordX { get; set; }
    public int CoordY { get; set; }
    public Guid? ResponsibleUserId { get; set; }
    public Guid? DelegatedUserId { get; set; }
}
