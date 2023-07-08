using Student.API.Models.Domain;

namespace Student.API.Repository
{
    public interface IStudent
    {
        List<Students> GetAllStudent();
    }
}
