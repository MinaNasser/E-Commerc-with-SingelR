namespace EShop.API
{
    public class APIResault<T>
    {
        public int Status { get; set; }//200, 201,400, 500
        public bool Success { get; set; }
        public string Massage { get; set; }
        public T Data { get; set; }
    }
}
