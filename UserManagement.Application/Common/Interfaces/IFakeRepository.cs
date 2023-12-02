namespace UserManagement.Application.Common.Interfaces
{
    public interface IFakeRepository
    {
        Task<string> Users();
        Task<string> PostWithComments(int userId);
        Task<string> Todos(int userId);
        Task<string> Album(int userId);

    }
}
