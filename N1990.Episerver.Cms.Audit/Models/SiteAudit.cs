using EPiServer.Web;
using System.Collections.Generic;

namespace N1990.Episerver.Cms.Audit.Models
{
    public class SiteAudit
    {
        public SiteDefinition SiteDefo { get; set; }
        public List<ContentTypeAudit> ContentTypes { get; set; }

        public SiteAudit()
        {
            ContentTypes = new List<ContentTypeAudit>();
        }
    }
}