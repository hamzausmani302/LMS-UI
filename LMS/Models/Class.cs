﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
 
    public class Class
    {

        public int Id { get; set; }
        public string? CourseID { get; set; }
        public virtual Course? Course { get; set; }         //Navigation attributes

        public string? ClassCode { get; set; }

        public string? InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }      //Navigation attributes

        public DateTime StartDate { get; set; }

        public string? Section { get; set; }

        //public virtual List<User> Users { get; set; }

        //public virtual List<Announcement> Announcements { get; set; }            //Navigation attributes

    }
}
