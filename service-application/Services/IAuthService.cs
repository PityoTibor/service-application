namespace service_application.Services
{
    public interface IAuthService
    {
        public string CreateToken(string username);
    }
}
