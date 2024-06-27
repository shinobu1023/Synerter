namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        /// <summary>
        /// 商品名
        /// </summary>
        public string ProductName { get; set; } = null;
        public string SellerName { get; set; }
        public string Price { get; set; }
    }
}