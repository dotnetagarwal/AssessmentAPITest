using Ardalis.Specification;
using ESOC.CLTPull.Assessment.Core.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Specifications
{
    public sealed class AssessmentRequestInteractionHistorySpecification : Specification<RequestInteractionHistory>
    {
        public AssessmentRequestInteractionHistorySpecification(int requestInteractionId)
        {
            //Take only those records where we will have LastAccessedDate not null
            Query
                .Where(b => b.RequestInteractionId == requestInteractionId && b.LastAccessedDate != null)
                .OrderByDescending(b => b.LastAccessedDate);
        }

    }
}
