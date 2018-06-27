using SoftwareAGTask.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SoftwareAGTask.Data
{
    public class XmlResumeRepository : IResumeRepository
    {
        private readonly string resumeDirectory;
        private readonly string resumeNamePattern;

        public XmlResumeRepository(string resumeDirectory, string resumeNamePattern)
        {
            this.resumeDirectory = resumeDirectory;
            this.resumeNamePattern = resumeNamePattern;
        }

        /// <summary>
        /// Search all xml files in directory and returns info for them.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ResumeInfo> AllResumesInfo()
        {
            var directory = new DirectoryInfo(this.resumeDirectory);
            var files = directory.GetFiles(this.resumeNamePattern, SearchOption.AllDirectories);

            var result = new List<ResumeInfo>();

            foreach (var file in files)
            {
                var resumeInfo = new ResumeInfo()
                {
                    Name = file.Name.Replace(".xml", ""),
                    ResumeId = file.Name.Replace(".xml", "")
                };

                result.Add(resumeInfo);
            }

            return result;
        }

        /// <summary>
        /// Find XML file in directory by name and return deserialized Resume object.
        /// </summary>
        /// <param name="resumeId"></param>
        /// <returns></returns>
        public Resume ReadResume(string resumeId)
        {
            if (string.IsNullOrWhiteSpace(resumeId))
            {
                throw new ArgumentException("Resume id should not be null or whitespace.");
            }

            var xmlSerializer = new XmlSerializer(typeof(Resume));

            using (var streanReader = new StreamReader($"Resumes\\{resumeId}.xml"))
            {
                var resume = (Resume)xmlSerializer.Deserialize(streanReader);

                resume.ResumeId = resumeId;

                return resume;
            }
        }

        /// <summary>
        /// Update or create XML file with given resume info.
        /// </summary>
        /// <param name="resume"></param>
        public void UpdateResume(Resume resume)
        {
            if (resume == null)
            {
                throw new ArgumentException("Resume should not be null or whitespace.");
            }

            var xmlSerializer = new XmlSerializer(typeof(Resume));

            using (var streamWriter = new StreamWriter($"Resumes\\{resume.ResumeId}.xml"))
            {
                xmlSerializer.Serialize(streamWriter, resume);
            }
        }
    }
}
