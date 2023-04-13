using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Final.Models
{
    public class Experience
    {
        public int Id { get; set; }
        [DisplayName("Company Name")]
        public string? CompanyName { get; set; }
        [DisplayName("Job Title")]
        public string? JobTitle { get; set;}
        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime StartDate { get; set;}
        [DataType(DataType.Date)]
        [DisplayName("End Date")]
        public DateTime EndDate { get; set;}
        public string? Details  { get; set;}
        public bool isDeleted { get; set; }
    }
}
