using System.ComponentModel.DataAnnotations;
using Abp.Organizations;

namespace Vickn.Platform.Organizations.Dto
{
    public class CreateOrganizationUnitInput 
    {
        public long? ParentId { get; set; }

        [Required]
        [StringLength(OrganizationUnit.MaxDisplayNameLength)]
        public string DisplayName { get; set; } 
    }
}