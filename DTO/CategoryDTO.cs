namespace webAPI.DTO
{
    public class CategoryDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
