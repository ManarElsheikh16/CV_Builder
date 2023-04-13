using Final.Models;
using Final.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    public class TemplateTest
    {


        Context context = new Context();

        TemplatesRepository template;
        [Test]
        public void CheckGetTempById()
        {
            template = new TemplatesRepository(context);
            var result = template.GetById(1);
            Assert.That(result.Id, Is.EqualTo(context.CvTemplates.First().Id));
        }
        [Test]
        public void CheckGetAll()
        {
            template = new TemplatesRepository(context);
            var result = template.GetAll();
            Assert.That(result.Count == GetTemplateL());
        }
        [Test]
        public void CheckGetCommentById()
        {

            template = new TemplatesRepository(context);
            var result = template.GetById(1);
            Assert.That(result.Id, Is.EqualTo(context.Comments.First().Id));
        }

        [Test]
        public void ChcekCommentAdd()
        {
            template = new TemplatesRepository(context);
            var lastLength = GetTemplateL();
            template.create();
          Assert.That(lastLength, Is.LessThan(GetTemplateL()));
        }
        [Test]
        public void CommentIsDelete()
        {

            template = new TemplatesRepository(context);
            var lastLength = GetTemplateL();
            template.Delete(5);
            Assert.That(lastLength, Is.GreaterThan(GetTemplateL()));

        }
        [Test]
        public void CheckUpdate()
        {
            template = new TemplatesRepository(context);
            CvTemplate NewTemplate = new CvTemplate
            {
                Img = "anthony.jpg",
                comments = null,
                Likes = 24,
                isDeleted = false

            };
            template.Update(1, NewTemplate);
            Assert.That(template.GetById(1).Likes, Is.EqualTo(24));

        }


        public int GetTemplateL()
        {
            return context.CvTemplates.Count();
        }


    }
}
