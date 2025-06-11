using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository _courtRepository;

        public CourtService(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }

        public async Task<List<CourtFrontDto>> GetAll()
        {
            var court = await _courtRepository.GetAllCourts();
            return court.Select(CourtFrontDto.Create).ToList();
        }

        public async Task<Court> GetById(int id)
        {
            return await _courtRepository.GetById(id);
        }
        public async Task<Court> Create(CourtRequest request)
        {
            Court court = new Court
            {
                Name = request.Name,
                Duration = request.Duration,
                Price = request.Price,
                Description = request.Description,
                Category = request.Category
            };
           return await _courtRepository.Create(court);
        }

        public async Task<Court> Update(CourtUpdateRequest request)
        { 
            var courtFound = await _courtRepository.GetById(request.Id);
            if (courtFound == null) throw new Exception("Cancha no encontrada");


            courtFound.Name = request.Name ?? courtFound.Name;
            courtFound.Duration = request.Duration ?? courtFound.Duration;
            courtFound.Price = request.Price ?? courtFound.Price;
            courtFound.Description = request.Description ?? courtFound.Description;
            courtFound.Category = request.Category ?? courtFound.Category;
           

            return await _courtRepository.Update(courtFound);
        }

        public async Task<Court> Delete(int id)
        {
            var court = await _courtRepository.GetById(id);
            if (court == null) throw new Exception("Cancha no encontrada");
            
            await _courtRepository.Delete(court);

            return court;
        }

    }
}
