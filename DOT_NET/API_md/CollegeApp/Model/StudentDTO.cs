using Collage_App.Model.Validators;
using CollegeApp.Model.Validators;
using System.ComponentModel.DataAnnotations;

namespace College_App.Model
{
    public class StudentDTO
    {
        [Required]
        public int studentID { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }




        //public int studentId { get; set; }
        //[Required(ErrorMessage = "please enter the name ")]
        //[StringLength(50)]

        //[NameCapitalCheck]
        //public string name { get; set; }

        //[Range(10,20)]
        //public int age { get; set; }




        //[EmailAddress(ErrorMessage = "abe accha se likh")]
        //public string email { get; set; }

        //[SpaceCheck]
        //public string password { get; set; }


        //[Compare(nameof(password))]
        //public string passwordHash { get; set; }











    }

}
 