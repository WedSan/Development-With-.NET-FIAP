using checkpoint_1_2_semester.Models;
using Microsoft.EntityFrameworkCore;

namespace checkpoint_1_2_semester.Repositories
{
    public class ToyRepository : IToyRepository
    {

        private readonly AppDBContext _context;

        public ToyRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Toy>> GetAllToysAsync()
        {
            return await _context.Toys.ToListAsync();
        }

        public async Task<Toy> GetToyByIdAsync(int toyId)
        {
            var toy = await _context.Toys.FindAsync(toyId);
            if (toy == null)
            {
                throw new KeyNotFoundException($"Toy with ID {toyId} was not found.");
            }
            return toy;
        }

        public async Task<Toy> AddToyAsync(Toy toy)
        {
            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();
            return toy;
        }

        public async Task<Toy> UpdateToyAsync(Toy toy)
        {
            _context.Entry(toy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return toy;
        }

        public async Task DeleteToyAsync(int toyId)
        {
            var toy = await _context.Toys.FindAsync(toyId);
            if (toy != null)
            {
                _context.Toys.Remove(toy);
                await _context.SaveChangesAsync();
            }
        }

    }
}
