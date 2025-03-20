using checkpoint_1_2_semester.Models;
using checkpoint_1_2_semester.Repositories;

namespace checkpoint_1_2_semester.Services
{
    public class ToyService : IToyService
    {
        private readonly IToyRepository _toyRepository;

        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public async Task<IEnumerable<Toy>> GetAllToysAsync()
        {
            return await _toyRepository.GetAllToysAsync();
        }

        public async Task<Toy> GetToyByIdAsync(int toyId)
        {
            return await _toyRepository.GetToyByIdAsync(toyId);
        }

        public async Task<Toy> AddToyAsync(Toy toy)
        {
            return await _toyRepository.AddToyAsync(toy);
        }

        public async Task<Toy> UpdateToyAsync(Toy toy)
        {
            return await _toyRepository.UpdateToyAsync(toy);
        }

        public async Task DeleteToyAsync(int toyId)
        {
            await _toyRepository.DeleteToyAsync(toyId);
        }
    }
}
