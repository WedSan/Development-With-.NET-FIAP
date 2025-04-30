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
            try
            {
                return await _toyRepository.GetToyByIdAsync(toyId);
            }
            catch(KeyNotFoundException ex)
            {
                return null;
            }
        }

        public async Task<Toy> AddToyAsync(Toy toy)
        {
            return await _toyRepository.AddToyAsync(toy);
        }

        public async Task<Toy> UpdateToyAsync(Toy toy)
        {
            return await _toyRepository.UpdateToyAsync(toy);
        }
        public async Task<Toy> EditToyAsync(int toyId, Toy toyUpdated)
        {
            Toy toyToUpdate;
            try
            {
                toyToUpdate = await this.GetToyByIdAsync(toyId);
            }
            catch (KeyNotFoundException ex)
            {
                return null;
            }
            
            if(!string.IsNullOrEmpty(toyToUpdate.ToyType))
            {
                toyToUpdate.ToyType = toyUpdated.ToyType;
            }
            if(!string.IsNullOrEmpty(toyToUpdate.ToyName))
            {
                toyToUpdate.ToyName = toyUpdated.ToyName;
            }
            if (!string.IsNullOrEmpty(toyToUpdate.Classification))
            {
                toyToUpdate.Classification = toyUpdated.Classification;
            }
            if (!string.IsNullOrEmpty(toyToUpdate.Size))
            {
                toyToUpdate.Size = toyUpdated.Size;
            }
            if(toyToUpdate.Price > 0)
            {
                toyToUpdate.Price = toyUpdated.Price;
            }
            return await this.UpdateToyAsync(toyToUpdate);
        }

        public async Task DeleteToyAsync(int toyId)
        {
            await _toyRepository.DeleteToyAsync(toyId);
        }

    }
}
