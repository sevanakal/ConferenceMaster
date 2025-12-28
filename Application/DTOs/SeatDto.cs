namespace ConferenceMaster.Application.DTOs;

public record SeatDto(
    Guid Id,
    string RowName,
    int Number,
    string Status,
    string ResponsibleUserName
    );