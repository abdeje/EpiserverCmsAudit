﻿using EPiServer.Scheduler;
using EPiServer.Web;
using N1990.Episerver.Cms.Audit.Models;
using System;
using System.Collections.Generic;

namespace N1990.Episerver.Cms.Audit.Business
{
    public interface ICmsAuditor
    {
        List<ContentTypeAudit> GetContentTypesOfType<T>();

        List<VGAudit> GetVisitorGroups();
        DateTime JobLastRunTime<T>() where T : ScheduledJobBase;
        void JobStartManually<T>() where T : ScheduledJobBase;

        ContentTypeAudit GenerateContentTypeAudit(int contentTypeId,
                    bool includeReferences, bool includeParentDetail);

        ContentTypeAudit GetBlockTypeAudit(int contentTypeId);
        ContentTypeAudit GetPageTypeAudit(int contentTypeId);

        SiteAudit GetSiteAudit(Guid siteGuid);

        List<SiteDefinition> GetSiteDefinitions();
    }
}