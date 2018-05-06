/*
* 命名空间 :     Vickn.Platform.PbManagement.Positions
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PositionReadme.cs
* 描      述 :     岗位Readme文件
* 创建时间 :     2018/5/6 14:16:40
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.Positions
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var position=new MenuItemDefinition(
                PositionAppPermissions.Position,
                L("Position"),
				url:"positionInfo",
				icon:"icon-grid",
				 requiredPermissionName: PositionAppPermissions.Position
				);

*/
				//有下级菜单
            /*

			   var position=new MenuItemDefinition(
                PositionAppPermissions.Position,
                L("Position"),			
				icon:"icon-grid"				
				);

				position.AddItem(
			new MenuItemDefinition(
			PositionAppPermissions.Position,
			L("Position"),
			"icon-star",
			"position",
			requiredPermissionName: PositionAppPermissions.Position));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<PositionAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 岗位管理 -->


	    <text name="	PositionHeaderInfo" value="岗位信息列表" />
		    <text name="PositionDeleteWarningMessage" value="岗位名称: {0} 将被删除,是否确定删除它。" />

			    <text name="PositionName" value="岗位" />

<!--//用于表格展示的数据信息的标题-->
					<text name="Position.Name" value="岗位名称" />
				 	<text name="Position.LastModificationTime" value="最后编辑时间" />
				 	<text name="Position.CreationTime" value="创建时间" />
				 

    <text name="Position" value="岗位管理" />
    <text name="CreatePosition" value="添加岗位" />
    <text name="EditPosition" value="编辑岗位" />
    <text name="DeletePosition" value="删除岗位" />
*/

/*
    <!-- 岗位english管理 -->
		    <text name="	PositionHeaderInfo" value="岗位List" />


    <text name="Position" value="ManagementPosition" />
    <text name="CreatePosition" value="CreatePosition" />
    <text name="EditPosition" value="EditPosition" />
    <text name="DeletePosition" value="DeletePosition" />
*/
}