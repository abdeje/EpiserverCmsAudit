using EPiServer.DataAbstraction;
using N1990.Episerver.Cms.Audit.Business;
using N1990.Episerver.Cms.Audit.Models;
using System.Web.Mvc;

namespace N1990.Episerver.Cms.Audit.Controllers
{
    [Authorize(Roles = "CmsEditors,CmsAdmins,Administrators")]
    public class PageTypesController : Controller
    {
        private readonly ICmsAuditor _cmsAuditor;

        public PageTypesController(ICmsAuditor cmsAuditor)
        {
            _cmsAuditor = cmsAuditor;
        }

        public ActionResult Index()
        {
            var model = new CmsAuditPage();
            model.ContentTypes = _cmsAuditor.GetContentTypesOfType<PageType>();
            model.JobLastRunTime = _cmsAuditor.JobLastRunTime<PageTypeAuditScheduledJob>();

            return View(model);
        }

        public ActionResult RunJob()
        {
            _cmsAuditor.JobStartManually<PageTypeAuditScheduledJob>();
            return RedirectToAction("Index");
        }

        public ActionResult PageTypeAudit(int contentTypeId)
        {
            var model = _cmsAuditor.GetPageTypeAudit(contentTypeId);
            return View(model);
        }
    }
}