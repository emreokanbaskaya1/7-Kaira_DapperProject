namespace KairaWebUI.DTOs.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId {  get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
