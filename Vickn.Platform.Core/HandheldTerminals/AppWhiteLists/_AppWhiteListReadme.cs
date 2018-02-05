/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.AppWhiteLists
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _AppWhiteListReadme.cs
* 描      述 :     应用白名单Readme文件
* 创建时间 :     2018/2/5 15:11:35
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.HandheldTerminals.AppWhiteLists
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var appWhiteList=new MenuItemDefinition(
                AppWhiteListAppPermissions.AppWhiteList,
                L("AppWhiteList"),
				url:"appWhiteListInfo",
				icon:"icon-grid",
				 requiredPermissionName: AppWhiteListAppPermissions.AppWhiteList
				);

*/
				//有下级菜单
            /*

			   var appWhiteList=new MenuItemDefinition(
                AppWhiteListAppPermissions.AppWhiteList,
                L("AppWhiteList"),			
				icon:"icon-grid"				
				);

				appWhiteList.AddItem(
			new MenuItemDefinition(
			AppWhiteListAppPermissions.AppWhiteList,
			L("AppWhiteList"),
			"icon-star",
			"appWhiteList",
			requiredPermissionName: AppWhiteListAppPermissions.AppWhiteList));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<AppWhiteListAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 应用白名单管理 -->


	    <text name="	AppWhiteListHeaderInfo" value="应用白名单信息列表" />
		    <text name="AppWhiteListDeleteWarningMessage" value="应用白名单名称: {0} 将被删除,是否确定删除它。" />

			    <text name="AppWhiteListName" value="应用白名单" />

<!--//用于表格展示的数据信息的标题-->
					<text name="AppWhiteList.Name" value="应用名称" />
				 	<text name="AppWhiteList.PackageName" value="包名" />
				 	<text name="AppWhiteList.Src" value="文件" />
				 	<text name="AppWhiteList.CreationTime" value="创建时间" />
				 

    <text name="AppWhiteList" value="应用白名单管理" />
    <text name="CreateAppWhiteList" value="添加应用白名单" />
    <text name="EditAppWhiteList" value="编辑应用白名单" />
    <text name="DeleteAppWhiteList" value="删除应用白名单" />
*/

/*
    <!-- 应用白名单english管理 -->
		    <text name="	AppWhiteListHeaderInfo" value="应用白名单List" />


    <text name="AppWhiteList" value="ManagementAppWhiteList" />
    <text name="CreateAppWhiteList" value="CreateAppWhiteList" />
    <text name="EditAppWhiteList" value="EditAppWhiteList" />
    <text name="DeleteAppWhiteList" value="DeleteAppWhiteList" />
*/
}