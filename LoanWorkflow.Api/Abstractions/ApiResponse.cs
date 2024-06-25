namespace LoanWorkflow.Api.Abstractions
{
    public class ApiResponse<TData> : ApiResponse
    {
        public static ApiResponse<T> FromValue<T>(T data) => new(data);
        public ApiResponse(TData data) => Data = data;
        public TData Data { get; set; }
    }

    public class ApiResponse
    {
        public Dictionary<string, List<Error>> Errors { get; private set; }

        public ApiResponse AddError(string key, Error error)
        {
            Errors ??= new Dictionary<string, List<Error>>();

            if (!Errors.ContainsKey(key)) Errors[key] = new List<Error>();
            Errors[key].Add(error);
            return this;
        }

        public bool Success => Errors == null;
    }

    public class Error
    {
        public string Key { get; set; }
        public IDictionary<string, string> Params { get; set; } = new Dictionary<string, string>();
        public class Param
        {
            public string Name { get; set; }
            public object Value { get; set; }
        }
    }
}
