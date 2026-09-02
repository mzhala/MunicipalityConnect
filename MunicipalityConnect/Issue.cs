using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace MunicipalityConnect
{
    public class Issue
    {
        public string QueryCode { get; set; }
        public string RequestType { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public DateTime IncidentDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public List<Attachment> Attachments { get; set; }

        public Issue()
        {
            Attachments = new List<Attachment>();
        }
    }
}