using ConferenceMaster.Domain.Entities;

namespace ConferenceMaster.Application.Interfaces;

public interface ISeatService
{
    // Hata almamak için isimlerin sınıftakilerle tam uyuştuğundan emin olalım
    Task AssignRowsToUserAsync(Guid userId, string rowName, Guid hallId);
    Task<bool> ApproveTransferAsync(Guid requestId); // "Sync" değil "Async"
    Task DistributeSeatsByEventAsync(Guid eventId, Dictionary<string, Guid> rowAssignments);

    // Diğerleri
    Task<bool> RequestSeatTransferAsync(Guid fromUserId, Guid toUserId, Guid seatId);
    Task<bool> ConfirmTransferAsync(Guid eventSeatId, Guid approvedByUserId);
    Task<object> GetSystemLoadAsync();

}