using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Domain.Request.SendEmailRequest
{
    public class SendEmailRequest
    {
        public string subject { get; set; }
        public string body { get; set; }
        public string ToEmail { get; set; }
        public string template { get; set; }
    }
}
