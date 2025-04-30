using checkpoint_1_2_semester.Controllers.DTO;
using checkpoint_1_2_semester.Models;
using Microsoft.AspNetCore.Mvc;

namespace checkpoint_1_2_semester.mapper
{
    public class ToyMapper 
    {
        public static ToyResponseDTO ToDTO(Toy toy)
        {
            return new ToyResponseDTO(
                toyId: toy.ToyId,
                toyName: toy.ToyName,
                toyType: toy.ToyType,
                classification: toy.Classification,
                size: toy.Size,
                price: toy.Price
                );
        }

        public static IEnumerable<ToyResponseDTO> ToDTO(IEnumerable<Toy> toys)
        {
            return toys.Select(toy => ToDTO(toy)).ToList();
        } 

        public static Toy ToDomainObj(CreateToyRequestDTO dto)
        {
            return new Toy(toyId: dto.ToyId,
                toyName: dto.ToyName,
                toyType: dto.ToyType,
                classification: dto.Classification,
                size: dto.Size,
                price: dto.Price);
        }
        public static Toy ToDomainObj(UpdateToyRequestDTO dto)
        {
            var toy = new Toy();
            toy.Size = dto.Size;
            toy.Price = dto.Price ?? 0;
            toy.Classification = dto.Classification;
            toy.ToyName = dto.ToyName;
            toy.ToyType = dto.ToyType;
            return toy;
        }

    }
}
