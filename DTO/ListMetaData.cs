using api_demo_e19.Utils;

namespace api_demo_e19.DTO
{
    public class ListMetaData
    {
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }


        // Computed Properties
        // Calculated property for total pages 
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)GlobalConstants.PageSize);

        // Helper properties for frontend UI 
        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
