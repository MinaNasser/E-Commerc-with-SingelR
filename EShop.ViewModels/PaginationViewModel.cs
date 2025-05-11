namespace EShop.ViewModels
{
    public class PaginationViewModel<T>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 16;
        public int Total { get; set; } = 20;

        public List<T> Data { get; set; }



    }
    //PageCount = Total 
    //canNext = PageNumber * PageSize < Total  
    //canback = PageNumber > 0
}
