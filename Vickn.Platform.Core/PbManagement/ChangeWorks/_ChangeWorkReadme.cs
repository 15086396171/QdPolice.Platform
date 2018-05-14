/*
* 命名空间 :     Vickn.Platform.PbManagement.ChangWorks
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _ChangeWorkReadme.cs
* 描      述 :     换班Readme文件
* 创建时间 :     2018/5/14 9:16:03
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.ChangeWorks
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var changeWork=new MenuItemDefinition(
                ChangeWorkAppPermissions.ChangeWork,
                L("ChangeWork"),
				url:"changeWorkInfo",
				icon:"icon-grid",
				 requiredPermissionName: ChangeWorkAppPermissions.ChangeWork
				);

*/
				//有下级菜单
            /*

			   var changeWork=new MenuItemDefinition(
                ChangeWorkAppPermissions.ChangeWork,
                L("ChangeWork"),			
				icon:"icon-grid"				
				);

				changeWork.AddItem(
			new MenuItemDefinition(
			ChangeWorkAppPermissions.ChangeWork,
			L("ChangeWork"),
			"icon-star",
			"changeWork",
			requiredPermissionName: ChangeWorkAppPermissions.ChangeWork));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<ChangeWorkAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 换班管理 -->


	    <text name="	ChangeWorkHeaderInfo" value="换班信息列表" />
		    <text name="ChangeWorkDeleteWarningMessage" value="换班名称: {0} 将被删除,是否确定删除它。" />

			    <text name="ChangeWorkName" value="换班" />

<!--//用于表格展示的数据信息的标题-->
					<text name="ChangeWork.PositionPbMapId" value="PositionPbMapId" />
				 	<text name="ChangeWork.BePositionPbMapId" value="BePositionPbMapId" />
				 	<text name="ChangeWork.UserId" value="UserId" />
				 	<text name="ChangeWork.UserName" value="UserName" />
				 	<text name="ChangeWork.BeUserId" value="BeUserId" />
				 	<text name="ChangeWork.BeUserName" value="BeUserName" />
				 	<text name="ChangeWork.Reason" value="Reason" />
				 	<text name="ChangeWork.TimeStr" value="TimeStr" />
				 	<text name="ChangeWork.BeTimeStr" value="BeTimeStr" />
				 	<text name="ChangeWork.PositionName" value="PositionName" />
				 	<text name="ChangeWork.BePositionName" value="BePositionName" />
				 	<text name="ChangeWork.Status" value="Status" />
				 	<text name="ChangeWork.StatusDes" value="StatusDes" />
				 	<text name="ChangeWork.LeaderId" value="LeaderId" />
				 	<text name="ChangeWork.Leader" value="Leader" />
				 	<text name="ChangeWork.IsOnDuty" value="IsOnDuty" />
				 	<text name="ChangeWork.LastModificationTime" value="最后编辑时间" />
				 	<text name="ChangeWork.CreationTime" value="创建时间" />
				 

    <text name="ChangeWork" value="换班管理" />
    <text name="CreateChangeWork" value="添加换班" />
    <text name="EditChangeWork" value="编辑换班" />
    <text name="DeleteChangeWork" value="删除换班" />
*/

/*
    <!-- 换班english管理 -->
		    <text name="	ChangeWorkHeaderInfo" value="换班List" />


    <text name="ChangeWork" value="ManagementChangeWork" />
    <text name="CreateChangeWork" value="CreateChangeWork" />
    <text name="EditChangeWork" value="EditChangeWork" />
    <text name="DeleteChangeWork" value="DeleteChangeWork" />
*/
}