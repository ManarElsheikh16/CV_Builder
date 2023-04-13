using Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Final.Repository
{
    public class CommentRepository : ICommentRepository
    {
        Context context;
        public CommentRepository(Context context)
        {
            this.context = context;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment Comment, int Tid)
        {
      
        
          
            CvTemplate cvtemp = context.CvTemplates.Include(c=>c.comments).FirstOrDefault(c => c.Id == Tid);
            Comment.CvTemplate = cvtemp;
            cvtemp.comments.Add(Comment);
         
            context.SaveChanges();

        }

        public void Update(int id, Comment Comment)
        {
            throw new NotImplementedException();
        }
    }
}
