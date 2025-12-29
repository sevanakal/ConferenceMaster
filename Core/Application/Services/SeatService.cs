using ConferenceMaster.Application.Interfaces;
using ConferenceMaster.Domain.Entities;
using ConfereneceMaster.Application.Interfaces;

namespace ConferenceMaster.Application.Services
{
    public class SeatService : ISeatService
    {
        private readonly ISentinelService _sentinel;
        private readonly IGenericRepository<EventSeat> _repository;
        private readonly IUnitOfWork _unitOfWork;

        // Constructor (Yapıcı Metot): Servis çalıştığında bu araçları yanına alacak
        public SeatService(ISentinelService sentinel, IGenericRepository<EventSeat> repository, IUnitOfWork unitOfWork)
        {
            _sentinel = sentinel;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        
        public async Task<bool> ConfirmTransferAsync(Guid eventSeatId, Guid approvedByUserId)
        {
            _sentinel.ValidateSystemLoad();

            var eventSeat = await _repository.GetByIdAsync(eventSeatId);
            // 1. Güvenlik: Koltuk var mı?
            if (eventSeat == null) return false;
            if (eventSeat.TransferRequestedToUserId.HasValue)
            {
                eventSeat.ResponsibleUserId = eventSeat.TransferRequestedToUserId.Value;
                eventSeat.TransferRequestedToUserId = null;

                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public Task AssignRowsToUserAsync(Guid userId, string rowName, Guid hallId)
        => throw new NotImplementedException();

        public Task<bool> ApproveTransferAsync(Guid requestId)
            => throw new NotImplementedException();

        public Task DistributeSeatsByEventAsync(Guid eventId, Dictionary<string, Guid> rowAssignments)
            => throw new NotImplementedException();

        public Task<bool> RequestSeatTransferAsync(Guid fromUserId, Guid toUserId, Guid seatId)
            => throw new NotImplementedException();

        public Task<object> GetSystemLoadAsync()
            => throw new NotImplementedException();
        /*
        // --- HATALARI GİDERMEK İÇİN EKLENEN BOŞ METODLAR ---

        public Task DistributeSeatsByEventAsync(Guid eventId, Dictionary<string, Guid> rowAssignments)
        {
            throw new NotImplementedException(); // "Henüz yazılmadı" hatası fırlatır ama derleme hatasını çözer
        }

        public Task<bool> CreateTransferRequestAsync(Guid eventSeatId, Guid fromUserId, Guid toUserId)
        {
            throw new NotImplementedException();
        }

        public Task<object> GetSystemLoadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RequestSeatTransferAsync(Guid fromUserId, Guid toUserId, Guid seatId)
        {
            throw new NotImplementedException();
        }

        public Task AssignRowsToUserAsync(Guid userId, string rowName, Guid hallId)
        {
            throw new NotImplementedException();
        }

        // Hata mesajında 'ApproveTransferAsync' mi yoksa 'ConfirmTransferAsync' mi 
        // yazdığına dikkat et. Arayüzde (Interface) ismi neyse aynısı olmalı.
        public Task<bool> ApproveTransferAsync(Guid requestId)
        {
            throw new NotImplementedException();
        }*/
    }
        
}