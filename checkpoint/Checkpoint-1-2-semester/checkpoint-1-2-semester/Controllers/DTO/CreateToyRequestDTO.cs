namespace checkpoint_1_2_semester.Controllers.DTO
{
    public class CreateToyRequestDTO
    {

        public int ToyId { get; set; }

        public string ToyName { get; set; }

        public string ToyType { get; set; }

        public string Classification { get; set; }

        public string Size { get; set; }

        public decimal Price { get; set; }


        public CreateToyRequestDTO(int toyId, string toyName, string toyType, string classification, string size, decimal price)
        {
            ToyId = toyId;
            ToyName = toyName;
            ToyType = toyType;
            Classification = classification;
            Size = size;
            Price = price;
        }

        public CreateToyRequestDTO()
        {
        }
    }
}
