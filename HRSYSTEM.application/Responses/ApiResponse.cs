using HRSYSTEM.domain;

namespace HRSYSTEM.application
{
    /// <summary>
    /// Standarized the API responses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        public ApiResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public Metadata Metadata { get; set; }

    }
}
