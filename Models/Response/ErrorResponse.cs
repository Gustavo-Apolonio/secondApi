namespace secondApi.Models.Response
{
    public class ErrorResponse
    {
        public ErrorResponse(int code, string error)
        {
            this.Code = code;
            this.Error = error;
        }

        public int Code;
        public string Error;
    }
}