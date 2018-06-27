using Microsoft.AspNetCore.Mvc;
using SoftwareAGTask.Data;
using SoftwareAGTask.DTOs;
using SoftwareAGTask.Models;
using System;
using System.Diagnostics;

namespace SoftwareAGTask.Controllers
{
    /// <summary>
    /// View resumes and edit them.
    /// </summary>
    public class ResumeController : Controller
    {
        private readonly IResumeRepository resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            this.resumeRepository = resumeRepository ?? throw new ArgumentNullException(nameof(resumeRepository));
        }

        /// <summary>
        /// Return view with links to all resumes.
        /// </summary>
        public IActionResult Index()
        {
            var resumes = this.resumeRepository.AllResumesInfo();

            return this.View(resumes);
        }

        /// <summary>
        /// Return View of given resume.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when parameter resumeId is null or whitespace.</exception>
        /// <param name="resumeId"></param>
        public IActionResult ViewResume(string resumeId)
        {
            if (string.IsNullOrWhiteSpace(resumeId))
            {
                throw new ArgumentException("Resume id should not be null or whitespace.");
            }

            var resume = this.resumeRepository.ReadResume(resumeId);

            return this.View(resume);
        }

        /// <summary>
        /// Returns View for edit given resume.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when parameter resumeId is null or whitespace.</exception>
        /// <param name="resumeId"></param>
        public IActionResult EditResume(string resumeId)
        {
            if (string.IsNullOrWhiteSpace(resumeId))
            {
                throw new ArgumentException("Resume id should not be null or whitespace.");
            }

            var resume = this.resumeRepository.ReadResume(resumeId);

            return this.View(resume);
        }

        /// <summary>
        /// Post method for edit resume.
        /// </summary>
        /// <param name="resume">Resume edit model</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateResume(Resume resume)
        {
            if (this.ModelState.IsValid)
            {
                // does not have edit for now
                var r = this.resumeRepository.ReadResume(resume.ResumeId);
                resume.PersonInfo.Jobs = r.PersonInfo.Jobs;
                resume.PersonInfo.Educations = r.PersonInfo.Educations;
                resume.PersonInfo.Skills = r.PersonInfo.Skills;
                ////////////////////////////

                this.resumeRepository.UpdateResume(resume);

                return this.RedirectToAction("ViewResume", new { resumeId = resume.ResumeId });
            }

            return this.BadRequest();
        }

        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
