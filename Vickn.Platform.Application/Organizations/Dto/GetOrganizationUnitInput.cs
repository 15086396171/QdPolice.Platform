using Abp.Runtime.Validation;
using Vickn.Platform.Dtos;

namespace Vickn.Platform.Organizations.Dto
{
    public class GetOrganizationUnitInput:PagedAndSortedInputDto,IShouldNormalize
    {
        public long? ParentId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }
    }
}