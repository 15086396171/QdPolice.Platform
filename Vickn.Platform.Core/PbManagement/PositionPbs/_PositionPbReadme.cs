/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbs
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PositionPbReadme.cs
* 描      述 :     单个岗位下排班时间Readme文件
* 创建时间 :     2018/5/7 13:34:37
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PositionPbs
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var positionPb=new MenuItemDefinition(
                PositionPbAppPermissions.PositionPb,
                L("PositionPb"),
				url:"positionPbInfo",
				icon:"icon-grid",
				 requiredPermissionName: PositionPbAppPermissions.PositionPb
				);

*/
				//有下级菜单
            /*

			   var positionPb=new MenuItemDefinition(
                PositionPbAppPermissions.PositionPb,
                L("PositionPb"),			
				icon:"icon-grid"				
				);

				positionPb.AddItem(
			new MenuItemDefinition(
			PositionPbAppPermissions.PositionPb,
			L("PositionPb"),
			"icon-star",
			"positionPb",
			requiredPermissionName: PositionPbAppPermissions.PositionPb));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<PositionPbAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 单个岗位下排班时间管理 -->


	    <text name="	PositionPbHeaderInfo" value="单个岗位下排班时间信息列表" />
		    <text name="PositionPbDeleteWarningMessage" value="单个岗位下排班时间名称: {0} 将被删除,是否确定删除它。" />

			    <text name="PositionPbName" value="单个岗位下排班时间" />

<!--//用于表格展示的数据信息的标题-->
					<text name="PositionPb.PbPositionId" value="单个岗位排班标题Id" />
				 	<text name="PositionPb.DutyDate" value="值班日期" />
				 	<text name="PositionPb.PositionPbTimes" value="PositionPbTimes" />
				 

    <text name="PositionPb" value="单个岗位下排班时间管理" />
    <text name="CreatePositionPb" value="添加单个岗位下排班时间" />
    <text name="EditPositionPb" value="编辑单个岗位下排班时间" />
    <text name="DeletePositionPb" value="删除单个岗位下排班时间" />
*/

/*
    <!-- 单个岗位下排班时间english管理 -->
		    <text name="	PositionPbHeaderInfo" value="单个岗位下排班时间List" />


    <text name="PositionPb" value="ManagementPositionPb" />
    <text name="CreatePositionPb" value="CreatePositionPb" />
    <text name="EditPositionPb" value="EditPositionPb" />
    <text name="DeletePositionPb" value="DeletePositionPb" />
*/
}