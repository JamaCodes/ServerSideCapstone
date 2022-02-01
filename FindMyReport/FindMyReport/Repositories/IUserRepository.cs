using FindMyReport.Models;

namespace FindMyReport.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile user);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
    }
}