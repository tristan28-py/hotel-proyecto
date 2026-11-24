namespace Hotel.Utilitario
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string Error { get; set; } = string.Empty;
        public int StatusCode { get; set; } = 200;

        public Result()
        {
            Success = true;
            Error = string.Empty;
            StatusCode = 200;
        }

        protected Result(bool success, T? data, string error, int statusCode)
        {
            Success = success;
            Data = data;
            Error = error;
            StatusCode = statusCode;
        }

        public static Result<T> Ok(T data, int statusCode = 200) =>
            new(true, data, string.Empty, statusCode);

        public static Result<T> Fail(string error, int statusCode = 400) =>
            new(false, default, error, statusCode);
    }
}
