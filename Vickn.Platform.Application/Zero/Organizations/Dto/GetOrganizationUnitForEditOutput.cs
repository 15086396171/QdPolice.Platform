using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;
using Abp.Organizations;

namespace Vickn.Platform.Organizations.Dto
{
    [AutoMap(typeof(OrganizationUnit))]
    public class GetOrganizationUnitForEditOutput
    {
        public long? Id { get; set; }
        public long? ParentId { get; set; }

        [Required]
        [StringLength(OrganizationUnit.MaxDisplayNameLength)]
        [DisplayName("组织名称")]
        public string DisplayName { get; set; }

    }
}