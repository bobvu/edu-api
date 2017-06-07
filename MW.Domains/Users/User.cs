using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MW.Domains.Users
{
    public class User: IdentityUser<long>
    {
        private DateTime? createdDate;
        //[DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        //[DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public int TenantId { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsEmailVerificationSent { get; set; }

        public bool IsEmailVerified { get; set; }

        public bool IsTermsConditionAccepted { get; set; }

        public bool IsWelcomeEmailSent { get; set; }

        public bool ForcePasswordReset { get; set; }

        public bool ForceProfileReview { get; set; }

        public bool ForceToReviewTermsCondition { get; set; }

        //[InverseProperty("ApplicationUser")]
        //public ApplicationUserProfile ApplicationUserProfile { get; set; }
    }
}
