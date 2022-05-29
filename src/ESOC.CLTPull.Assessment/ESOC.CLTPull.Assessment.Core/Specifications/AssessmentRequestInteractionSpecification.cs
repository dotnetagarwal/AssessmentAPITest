using Ardalis.Specification;
using ESOC.CLTPull.Assessment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace ESOC.CLTPull.Assessment.Core.Specifications
{
    public sealed class AssessmentRequestInteractionSpecification : Specification<RequestInteraction>
    {
       

        public AssessmentRequestInteractionSpecification(string assessmentRequestInteractionKey, string assessmentRequestInteractionValue)
        {
            
            ConstantExpression constantValue = Expression.Constant(assessmentRequestInteractionValue);
            var  param = Expression.Parameter(typeof(RequestInteraction));
            var leftExpression = Expression.Property(param, assessmentRequestInteractionKey);
            var body = Expression.Equal(leftExpression, constantValue);
            var deleg = Expression.Lambda<Func<RequestInteraction, bool>>(body, param);
            Query
                .Where(deleg)
                .OrderByDescending(r => r.RequestInteractionId);
        }

        public AssessmentRequestInteractionSpecification(int requestInteractionId)
        {
            Query
                .Where(b => b.RequestInteractionId == requestInteractionId)
                .OrderByDescending(b => b.LastAccessedDate);
        }
        public AssessmentRequestInteractionSpecification(int? requestId)
        {
            Query
                .Where(b => b.RequestId == (int)requestId)
                .OrderBy(b => b.RequestInteractionId);
        }
    }
}
