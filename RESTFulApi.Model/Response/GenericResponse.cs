namespace RESTFulApi.Model.Response
{
    public class GenericResponse<T> 
    {
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}
