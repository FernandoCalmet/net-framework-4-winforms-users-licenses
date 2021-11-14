namespace LicenseActivationApp.DataAccess
{
    public interface IUserRepository
    {
        bool Login(string username, string password);
    }
}
