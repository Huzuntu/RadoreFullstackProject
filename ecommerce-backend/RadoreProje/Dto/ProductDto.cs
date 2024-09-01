
namespace RadoreProje.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Labels { get; set; }
        public string Category { get; set; }
        public string Img { get; set; }
        public string HoverImg { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public RatingDto Rating { get; set; }
        public ICollection<ColorOptionDto> ColorOptions { get; set; }
    }
}
