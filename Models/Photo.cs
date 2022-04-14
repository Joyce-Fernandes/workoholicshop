namespace workoholicshop.Models
{
    public class Photo
    {
      public int Id { get; set; }
      public string Image { get; set; }


      public int ProductId { get; set; }
      public Product Product { get; set; }
    }
}
