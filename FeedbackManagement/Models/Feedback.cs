using System;
using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Name must contain 3 to 50 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a subject")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please select a rating")]
        [Range(1, 5, ErrorMessage = "Select a rating from 1 to 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter your feedback")]
        [StringLength(500, MinimumLength = 10,
            ErrorMessage = "Feedback must contain 10 to 500 characters")]
        public string Comments { get; set; }

        public DateTime SubmittedOn { get; set; }
    }
}