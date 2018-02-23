/*
* 命名空间 :     Vickn.Platform.PrivatePhoneWhites
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PrivatePhoneWhiteReadme.cs
* 描      述 :     个人白名单Readme文件
* 创建时间 :     2018/2/23 14:15:11
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PrivatePhoneWhites
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var privatePhoneWhite=new MenuItemDefinition(
                PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite,
                L("PrivatePhoneWhite"),
				url:"privatePhoneWhiteInfo",
				icon:"icon-grid",
				 requiredPermissionName: PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite
				);

*/
				//有下级菜单
            /*

			   var privatePhoneWhite=new MenuItemDefinition(
                PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite,
                L("PrivatePhoneWhite"),			
				icon:"icon-grid"				
				);

				privatePhoneWhite.AddItem(
			new MenuItemDefinition(
			PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite,
			L("PrivatePhoneWhite"),
			"icon-star",
			"privatePhoneWhite",
			requiredPermissionName: PrivatePhoneWhiteAppPermissions.PrivatePhoneWhite));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //  


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 个人白名单管理 -->


*/

/*
    <!-- 个人白名单english管理 -->
		    <text name="	PrivatePhoneWhiteHeaderInfo" value="个人白名单List" />


    <text name="PrivatePhoneWhite" value="ManagementPrivatePhoneWhite" />
    <text name="CreatePrivatePhoneWhite" value="CreatePrivatePhoneWhite" />
    <text name="EditPrivatePhoneWhite" value="EditPrivatePhoneWhite" />
    <text name="DeletePrivatePhoneWhite" value="DeletePrivatePhoneWhite" />
*/
}