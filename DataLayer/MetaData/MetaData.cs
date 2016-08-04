using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class MetaData
    {
        // Departments
        public class tstDepartmentMetaData
        {
            [Required(ErrorMessage = "*Name Is Required.")]
            public string Name { get; set; }

            [UIHint("MultilineText")]
            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Description { get; set; }

            [Display(Name = "Is Active")]
            public bool IsActive { get; set; }
        }
        [MetadataType(typeof(tstDepartmentMetaData))]
        // 2)
        public partial class tstDepartments { }


        //---------------------------------------------------------------------  
        //Employees
        public class tstEmployeeMetaData
        {
            [Required(ErrorMessage = "*First Name is Required.")]
            public string Name { get; set; }

            [Display(Name = "Last Name")]
            [Required(ErrorMessage = "*Last Name Is Required.")]
            public string Lname { get; set; }

            [Required(ErrorMessage = "*Date Of Birth Is Required.")]
            [DisplayFormat(DataFormatString = "{0:d}")]
            [Display(Name = "Date Of Birth")]
            public System.DateTime Hiredate { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string UserID { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public int StatusID { get; set; }

            [Display(Name = "Job title")]
            public string Jobtitle { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Adress { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Adress2 { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string City { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string State { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Zip { get; set; }

            [Required(ErrorMessage = "*Email Is Required.")]
            public string Email { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Phone { get; set; }

            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string ImmageURL { get; set; }

            [UIHint("MultilineText")]
            public string Notes { get; set; }

            [DisplayFormat(DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> Dateofbirth { get; set; }

            [DisplayFormat(DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> separationDate { get; set; }
        }
        [MetadataType(typeof(tstEmployeeMetaData))]
        public partial class tstEmployee { }

        //---------------------------------------------------------------------  

        //Employees stats
        public class tstEmployeeStauMetaData
        {


            [Required(ErrorMessage = "*Name Is Required.")]
            public string Name { get; set; }

            [UIHint("MultilineText")]
            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Description { get; set; }
        }

        [MetadataType(typeof(tstEmployeeStauMetaData))]
        public partial class tstEmployeeStatu { }

        //---------------------------------------------------------------------  



        //Tech notes
        public class tstTechNoteMetaData
        {

            [UIHint("MultilineText")]
            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Notation { get; set; }


            [Display(Name = "Time Created")]
            [DisplayFormat(DataFormatString = "{0:d}")]
            public System.DateTime NotationDate { get; set; }


        }


        [MetadataType(typeof(tstTechNoteMetaData))]
        public partial class tstTechNote { }
        //---------------------------------------------------------------------  

        //Ticket
        public class tstTicketMetaData
        {
            [DisplayFormat(DataFormatString = "{0:d}")]
            public System.DateTime CreatedDate { get; set; }

            [Display(Name = "Resolution Date")]
            [DisplayFormat(NullDisplayText = "[-N/A-]", DataFormatString = "{0:d}")]
            public Nullable<System.DateTime> ResoloutionDate { get; set; }

            public string Subject { get; set; }


        }
        [MetadataType(typeof(tstTechNoteMetaData))]
        public partial class tstTicket { }

        //---------------------------------------------------------------------  


        //Ticket Priorities
        public class tstTicketPriortyMetaData
        {
            [Required(ErrorMessage = "*Name Is Required.")]
            public string Name { get; set; }

            [UIHint("MultilineText")]
            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Description { get; set; }


        }

        [MetadataType(typeof(tstTicketPriortyMetaData))]
        public partial class tstTicketPriorty { }



        //---------------------------------------------------------------------  


        //ticket status
        public class tstTicketStatuMetaData
        {
            [Required(ErrorMessage = "*Name Is Required.")]
            public string Name { get; set; }

            [UIHint("MultilineText")]
            [DisplayFormat(NullDisplayText = "[-N/A-]")]
            public string Description { get; set; }


        }

        [MetadataType(typeof(tstTicketStatuMetaData))]
        public partial class tstTicketStatu { }


        //---------------------------------------------------------------------  






    }
}
