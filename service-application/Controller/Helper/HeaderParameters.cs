namespace service_application.Controller.Helper
{
    public class HeaderParameters
    {
        int startByte = 0;
        int endByte = 9;

        public void GetResponseWithHeaders(HttpResponse response, int result)
        {
            response.Headers.Add("Access-Control-Expose-Headers", "Content-Range");
            response.Headers.Add("Content-Range", $"User {startByte}-{endByte}/{result}");
        }
    }


}
