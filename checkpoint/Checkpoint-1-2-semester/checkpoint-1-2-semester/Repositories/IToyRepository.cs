using checkpoint_1_2_semester.Models;

namespace checkpoint_1_2_semester.Repositories
{
    public interface IToyRepository
    {
        Task<IEnumerable<Toy>> GetAllToysAsync();
        Task<Toy> GetToyByIdAsync(int toyId);
        Task<Toy> AddToyAsync(Toy toy);
        Task<Toy> UpdateToyAsync(Toy toy);
        Task DeleteToyAsync(int toyId);
    }
}
