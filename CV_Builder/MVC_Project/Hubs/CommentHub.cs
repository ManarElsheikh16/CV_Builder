using Final.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using Final.Repository;
using Microsoft.EntityFrameworkCore;
using Windows.System;
using System.Text;

namespace Final.Hubs
{
    public class CommentHub : Hub
    {

        ITemplatesRepository templatesRepository;
        ICommentRepository commentRepository;
        Context context = new Context();
        private readonly UserManager<ApplicationUser> _userManager;

        public CommentHub(UserManager<ApplicationUser> userManager, ITemplatesRepository templatesRepository, ICommentRepository commentRepository)
        {
            templatesRepository = templatesRepository;
            this.commentRepository = commentRepository;
            _userManager = userManager;
        }
        public void NewComment(string comment, int Tid, string UserName)
        {
            var currentUser = _userManager.Users.FirstOrDefault(c=> c.UserName == UserName);

            Clients.All.SendAsync("CommentAdded", UserName, comment,Tid);

            var date = DateTime.Now;

            Comment c = new Comment { Text = comment, TemplateId = Tid, username = UserName , Date =date,image= Encoding.Default.GetString(currentUser.image) };

            commentRepository.Insert(c, Tid);
            

        }

        public void Liked(CvTemplate cvTemplate , int id)
        {
            Clients.All.SendAsync("LikeAdded", ++cvTemplate.Likes);

            templatesRepository.Update(id , cvTemplate);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
