using Final.Models;
using Final.Repository;
using NUnit.Framework;
using Final;
namespace Test
{
    [TestFixture]

    public class CommentTest
    {

        Context context = new Context();
        CommentRepository comment;
      
     
        [Test]
        public void CheckGetAll()
        {
            comment = new CommentRepository(context);
            var result = comment.GetAll();
            Assert.That(result.Count == GetCommentL());
        }
        [Test]
        public void CheckGetCommentById()
        {

            comment = new CommentRepository(context);
            var result = comment.GetById(1);
            Assert.That(result.Id, Is.EqualTo(context.Comments.First().Id));
        }

        [Test]
        public void ChcekCommentAdd()
        {
            comment = new CommentRepository(context);
            var lastLength = context.Comments.ToList().Count;
            comment.create();
            Console.WriteLine(lastLength + GetCommentL());
            Assert.That(lastLength, Is.LessThan(GetCommentL()));
        }
        [Test]
        public void CommentIsDelete()
        {

            comment = new CommentRepository(context);
            var lastLength = GetCommentL();
            comment.Delete(6);
            Assert.That(lastLength, Is.GreaterThan(GetCommentL()));

        }
        [Test]
        public void CheckUpdate()
        {
            comment = new CommentRepository(context);
            Comment NewComment = new Comment
            {
                Text = "nono bad",
                isDeleted = false,
                username = "Nada",
                Date = new DateTime(),
                TemplateId = 1,
                image = "client-1.png",

            };
            comment.Update(1,NewComment );
            Assert.That(comment.GetById(1).Text, Is.EqualTo("nono bad"));
      
        }


        public int GetCommentL()
        {
            return context.Comments.Count();
        }

    }
}


