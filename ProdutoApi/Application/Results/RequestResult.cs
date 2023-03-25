namespace ProdutoApi.Application.Results
{
    public class RequestResult
    {
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }

        public RequestResult Ok(object data)
        {
            StatusCode = 200;
            Message = "Success";
            Data = data;
            return this;
        }

        public RequestResult BadRequest(string details, object data = null)
        {
            StatusCode = 400;
            Message = $"Something went wrong, more details in: {details}";
            Data = data;
            return this;
        }
    }
}
