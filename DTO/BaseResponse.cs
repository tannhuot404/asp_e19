namespace api_demo_e19.DTO
{
    public class BaseResponse<T>
    {
        public int statusCode { get; set; }
        public string devErrorMessage { get; set; } = string.Empty;

        public T? data { get; set; }
        
        public ListMetaData ListMetaData { get; set; }
    }
}
