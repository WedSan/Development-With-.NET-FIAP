using checkpoint_1_2_semester.Models;

namespace checkpoint_1_2_semester.Services
{
    public interface IToyService
    {
        Task<IEnumerable<Toy>> GetAllToysAsync();
        Task<Toy> GetToyByIdAsync(int toyId);
        Task<Toy> AddToyAsync(Toy toy);
        Task<Toy> UpdateToyAsync(Toy toy);
        Task<Toy> EditToyAsync(int toyId, Toy toy);
        Task DeleteToyAsync(int toyId);
    }
}
