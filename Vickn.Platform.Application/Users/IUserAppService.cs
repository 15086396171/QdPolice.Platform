using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Vickn.Platform.Dtos;
using Vickn.Platform.Users.Dto;
using Vickn.Platform.Users.Dtos;

namespace Vickn.Platform.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        /// <summary>
        /// ��ȡ�û��б�
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<UserListDto>> GetUsers();

        Task CreateUser(CreateUserInput input);

        #region �û��������

        /// <summary>
        /// ���ݲ�ѯ������ȡ�û������ҳ�б�
        /// </summary>
        Task<PagedResultDto<UserListDto>> GetPagedUsersAsync(GetUserInput input);

        /// <summary>
        /// ͨ��Id��ȡ�û�������Ϣ���б༭���޸� 
        /// </summary>
        Task<GetUserForEdit> GetUserForEditAsync(NullableIdDto<long> input);

        /// <summary>
        /// ͨ��ָ��id��ȡ�û�����ListDto��Ϣ
        /// </summary>
        Task<UserListDto> GetUserByIdAsync(EntityDto<long> input);

        /// <summary>
        /// ����������û�����
        /// </summary>
        Task CreateOrUpdateUserAsync(GetUserForEdit input);

        /// <summary>
        /// ����û��������
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<CustomerModelStateValidationDto> CheckErrorAsync(GetUserForEdit input);

            /// <summary>
        /// �����û�����
        /// </summary>
        Task<UserEditDto> CreateUserAsync(GetUserForEdit input);

        /// <summary>
        /// �����û�����
        /// </summary>
        Task UpdateUserAsync(GetUserForEdit input);

        /// <summary>
        /// ɾ���û�����
        /// </summary>
        Task DeleteUserAsync(EntityDto<long> input);

        /// <summary>
        /// ����ɾ���û�����
        /// </summary>
        Task BatchDeleteUserAsync(List<long> input);

        /// <summary>
        /// ͣ�û������û�
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DisableUser(EntityDto<long> input);

        #endregion
    }
}