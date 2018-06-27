using SoftwareAGTask.DTOs;
using System.Collections.Generic;

namespace SoftwareAGTask.Data
{
    public interface IResumeRepository
    {
        /// <summary>
        /// Find all resumes and return info for them.
        /// </summary>
        IEnumerable<ResumeInfo> AllResumesInfo();

        /// <summary>
        /// Find resume by id and returns it.
        /// </summary>
        /// <param name="resumeId"></param>
        Resume ReadResume(string resumeId);

        /// <summary>
        /// Update given resume data.
        /// </summary>
        /// <param name="resume">Edit resume model.</param>
        void UpdateResume(Resume resume);
    }
}
