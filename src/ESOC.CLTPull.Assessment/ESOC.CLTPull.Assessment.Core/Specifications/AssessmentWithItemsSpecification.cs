using Ardalis.Specification;
using ESOC.CLTPull.Assessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Specifications
{
    public sealed class AssessmentRequestSpecification : Specification<Request>
    {
       

        public AssessmentRequestSpecification(int requestid)
        {
            Query
                .Where(b => b.RequestId == requestid)
                .Include(b => b.RequestInteraction);
        }
        public AssessmentRequestSpecification(bool isActive)
        {
            Query
                .Where(b => b.IsActive == isActive);
        }

    }
}
