using Final.Models;

namespace Final.Repository
{
    public interface ITemplatesRepository
    {
        List<CvTemplate> GetAll();
        CvTemplate GetById(int id);
        void Insert(CvTemplate Temp);
        void Update(int id, CvTemplate Temp);
        void Delete(int id);
    }
}
