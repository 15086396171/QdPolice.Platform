/*
* 命名空间 :     Vickn.Platform.PbManagement.PositionPbTimes
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PositionPbTimeReadme.cs
* 描      述 :     当天上下班时间Readme文件
* 创建时间 :     2018/5/8 14:06:14
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PositionPbTimes
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var positionPbTime=new MenuItemDefinition(
                PositionPbTimeAppPermissions.PositionPbTime,
                L("PositionPbTime"),
				url:"positionPbTimeInfo",
				icon:"icon-grid",
				 requiredPermissionName: PositionPbTimeAppPermissions.PositionPbTime
				);

*/
				//有下级菜单
            /*

			   var positionPbTime=new MenuItemDefinition(
                PositionPbTimeAppPermissions.PositionPbTime,
                L("PositionPbTime"),			
				icon:"icon-grid"				
				);

				positionPbTime.AddItem(
			new MenuItemDefinition(
			PositionPbTimeAppPermissions.PositionPbTime,
			L("PositionPbTime"),
			"icon-star",
			"positionPbTime",
			requiredPermissionName: PositionPbTimeAppPermissions.PositionPbTime));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<PositionPbTimeAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 当天上下班时间管理 -->


	    <text name="	PositionPbTimeHeaderInfo" value="当天上下班时间信息列表" />
		    <text name="PositionPbTimeDeleteWarningMessage" value="当天上下班时间名称: {0} 将被删除,是否确定删除它。" />

			    <text name="PositionPbTimeName" value="当天上下班时间" />

<!--//用于表格展示的数据信息的标题-->
					<text name="PositionPbTime.IsDuty" value="是否已值班" />
				 	<text name="PositionPbTime.PositionPbId" value="PositionPbId" />
				 	<text name="PositionPbTime.StartTime" value="上班时间" />
				 	<text name="PositionPbTime.EndTime" value="下班时间" />
				 	<text name="PositionPbTime.UserId" value="UserId" />
				 	<text name="PositionPbTime.RealName" value="RealName" />
				 	<text name="PositionPbTime.PositionPbMaps" value="人员安排" />
				 

    <text name="PositionPbTime" value="当天上下班时间管理" />
    <text name="CreatePositionPbTime" value="添加当天上下班时间" />
    <text name="EditPositionPbTime" value="编辑当天上下班时间" />
    <text name="DeletePositionPbTime" value="删除当天上下班时间" />
*/

/*
    <!-- 当天上下班时间english管理 -->
		    <text name="	PositionPbTimeHeaderInfo" value="当天上下班时间List" />


    <text name="PositionPbTime" value="ManagementPositionPbTime" />
    <text name="CreatePositionPbTime" value="CreatePositionPbTime" />
    <text name="EditPositionPbTime" value="EditPositionPbTime" />
    <text name="DeletePositionPbTime" value="DeletePositionPbTime" />
*/
}