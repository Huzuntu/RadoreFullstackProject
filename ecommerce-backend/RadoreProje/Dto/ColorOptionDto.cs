

namespace RadoreProje.Dto
{
    public class ColorOptionDto
    {
        public int Id { get; set; }
        public string Color { get; set; } = string.Empty; 
        public string? Img { get; set; } 
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
