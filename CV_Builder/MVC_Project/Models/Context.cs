using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final.Models
{
    public class Context : IdentityDbContext<ApplicationUser>
    {

        public Context() { }

        //inJection

        public Context(DbContextOptions option) : base(option)
        {

        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CvTemplate> CvTemplates { get; set; }
        public DbSet<UserData> UserData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-07S7M2O;Initial Catalog=CvBuilder;Integrated Security=True; trust server certificate = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CvTemplate>().HasData(new[]
            {
                 new CvTemplate
                     {
                        Id=1,
                        Likes = 20,
                        Img= "CV1.jpeg",
                       comments=null,
isDeleted=false,

                     },
                new CvTemplate
                     {
                        Id=2,
                        Likes = 12,
                        Img= "CV2.jpeg",
                           comments=null,
                           isDeleted=false,


                     },
                new CvTemplate
                     {
                        Id=3,
                        Likes = 46,
                        Img= "CV3.jpeg",
                           comments=null,
                           isDeleted=false,

                     },
                new CvTemplate
                     {
                        Id=4,
                        Likes = 76,
                        Img= "CV4.jpeg",
                           comments=null,
                           isDeleted=false,

                     },
                new CvTemplate
                     {
                        Id=7,
                        Likes = 74,
                        Img= "CV5.jpeg",
                           comments=null,
                           isDeleted=false,

                     },
                new CvTemplate
                     {
                        Id=8,
                        Likes = 35,
                        Img= "CV6.jpeg",
                           comments=null,
                           isDeleted=false,

                     },

            });
            base.OnModelCreating(modelBuilder);





        }
    }
}
