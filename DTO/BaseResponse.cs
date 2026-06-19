namespace api_demo_e19.DTO
{
    public class BaseResponse<T>
    {
        public string? DevErrorMessage { get; }

        public T? Data { get; }

        public bool IsSuccess { get; }
        
        public ListMetaData? MetaData { get; }

        private BaseResponse(bool isSuccess, string? devErrorMessage, T? data, ListMetaData? metaData) {
            this.IsSuccess = isSuccess;
            this.DevErrorMessage = devErrorMessage;
            this.Data = data;
            this.MetaData = metaData;
        }


        // Static Factory Method
        public static BaseResponse<T> Sucess(T data, ListMetaData? metadata = null)
        {
            return new BaseResponse<T>(true, null, data, metadata);
        }

        public static BaseResponse<T> Failure(string errorMessage) => new (false, errorMessage, default, null);
    }
}
