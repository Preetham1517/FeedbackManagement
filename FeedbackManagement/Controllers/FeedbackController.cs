using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FeedbackManagement.Models;

namespace FeedbackManagement.Controllers
{
    public class FeedbackController : Controller
    {
        // Temporary storage for feedback
        private static readonly List<Feedback> feedbackList =
            new List<Feedback>();

        // Display all feedback
        public ActionResult Index()
        {
            return View(feedbackList.OrderByDescending(
                f => f.SubmittedOn).ToList());
        }

        // Display feedback form
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Process submitted feedback
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedback.Id = feedbackList.Count == 0
                    ? 1
                    : feedbackList.Max(f => f.Id) + 1;

                feedback.SubmittedOn = DateTime.Now;

                feedbackList.Add(feedback);

                TempData["SuccessMessage"] =
                    "Feedback submitted successfully!";

                return RedirectToAction("Index");
            }

            return View(feedback);
        }
    }
}