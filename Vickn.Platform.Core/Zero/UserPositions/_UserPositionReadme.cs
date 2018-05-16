/*
* 命名空间 :     Vickn.Platform.Zero.UserPositions
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _UserPositionReadme.cs
* 描      述 :     职位信息Readme文件
* 创建时间 :     2018/5/16 9:57:50
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.Zero.UserPositions
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var userPosition=new MenuItemDefinition(
                UserPositionAppPermissions.UserPosition,
                L("UserPosition"),
				url:"userPositionInfo",
				icon:"icon-grid",
				 requiredPermissionName: UserPositionAppPermissions.UserPosition
				);

*/
				//有下级菜单
            /*

			   var userPosition=new MenuItemDefinition(
                UserPositionAppPermissions.UserPosition,
                L("UserPosition"),			
				icon:"icon-grid"				
				);

				userPosition.AddItem(
			new MenuItemDefinition(
			UserPositionAppPermissions.UserPosition,
			L("UserPosition"),
			"icon-star",
			"userPosition",
			requiredPermissionName: UserPositionAppPermissions.UserPosition));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<UserPositionAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 职位信息管理 -->


	    <text name="	UserPositionHeaderInfo" value="职位信息信息列表" />
		    <text name="UserPositionDeleteWarningMessage" value="职位信息名称: {0} 将被删除,是否确定删除它。" />

			    <text name="UserPositionName" value="职位信息" />

<!--//用于表格展示的数据信息的标题-->
					<text name="UserPosition.PositionName" value="职位名称" />
				 	<text name="UserPosition.RankOfPosition" value="职位等级" />
				 	<text name="UserPosition.LastModificationTime" value="最后编辑时间" />
				 	<text name="UserPosition.CreationTime" value="创建时间" />
				 

    <text name="UserPosition" value="职位信息管理" />
    <text name="CreateUserPosition" value="添加职位信息" />
    <text name="EditUserPosition" value="编辑职位信息" />
    <text name="DeleteUserPosition" value="删除职位信息" />
*/

/*
    <!-- 职位信息english管理 -->
		    <text name="	UserPositionHeaderInfo" value="职位信息List" />


    <text name="UserPosition" value="ManagementUserPosition" />
    <text name="CreateUserPosition" value="CreateUserPosition" />
    <text name="EditUserPosition" value="EditUserPosition" />
    <text name="DeleteUserPosition" value="DeleteUserPosition" />
*/
}