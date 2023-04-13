namespace Final.Models
{
    public class CvTemplate
    {
        public int Id { get; set; }
        public virtual List<Comment> comments { get; set; }
        public int Likes { get; set; }
        public  string Img { get; set; }
        public bool isDeleted { get; set; }

    }
}
