using FindMyReport.Models;

namespace FindMyReport.Repositories
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByFirebaseUserId(string firebaseUserId);
    }
}