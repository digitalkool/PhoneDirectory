using System.ComponentModel.DataAnnotations;

namespace PhoneDirectory.Models
{
    public class Title
    {
        public int TitleID { get; set; }
        
        [Display(Name ="Title")]
        public string TitleName { get; set; }
    }
}