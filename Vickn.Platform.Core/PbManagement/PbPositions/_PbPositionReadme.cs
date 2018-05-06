/*
* 命名空间 :     Vickn.Platform.PbManagement.PbPositions
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PbPositionReadme.cs
* 描      述 :     排班岗位Readme文件
* 创建时间 :     2018/5/6 15:05:48
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PbPositions
{
    // 1.Core层权限配置
    // 2.Core层本地化
    // 3.EntityFrame层数据映射配置
    // 4.Application层注入权限
    // 5.Web层菜单配置
    //TODO:admin后端的导航栏目设计

    /*
	//无次级导航属性
	   var pbPosition=new MenuItemDefinition(
                PbPositionAppPermissions.PbPosition,
                L("PbPosition"),
				url:"pbPositionInfo",
				icon:"icon-grid",
				 requiredPermissionName: PbPositionAppPermissions.PbPosition
				);

*/
    //有下级菜单
    /*

       var pbPosition=new MenuItemDefinition(
        PbPositionAppPermissions.PbPosition,
        L("PbPosition"),			
        icon:"icon-grid"				
        );

        pbPosition.AddItem(
    new MenuItemDefinition(
    PbPositionAppPermissions.PbPosition,
    L("PbPosition"),
    "icon-star",
    "pbPosition",
    requiredPermissionName: PbPositionAppPermissions.PbPosition));



    */




    //配置权限模块初始化

    //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
    //   Configuration.Authorization.Providers.Add<PbPositionAppAuthorizationProvider>();




    //TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
    /*
        <!-- 排班岗位管理 -->


            <text name="	PbPositionHeaderInfo" value="排班岗位信息列表" />
                <text name="PbPositionDeleteWarningMessage" value="排班岗位名称: {0} 将被删除,是否确定删除它。" />

                    <text name="PbPositionName" value="排班岗位" />

    <!--//用于表格展示的数据信息的标题-->
                        <text name="PbPosition.PbTitleId" value="值班标题" />
                        <text name="PbPosition.PositionId" value="岗位ID" />
                        <text name="PbPosition.Position" value="岗位" />
                        <text name="PbPosition.IsTrue" value="是否已排班" />
                        <text name="PbPosition.Month" value="月份" />
                        <text name="PbPosition.PositionPbs" value="PositionPbs" />


        <text name="PbPosition" value="排班岗位管理" />
        <text name="CreatePbPosition" value="添加排班岗位" />
        <text name="EditPbPosition" value="编辑排班岗位" />
        <text name="DeletePbPosition" value="删除排班岗位" />
    */

    /*
        <!-- 排班岗位english管理 -->
                <text name="	PbPositionHeaderInfo" value="排班岗位List" />


        <text name="PbPosition" value="ManagementPbPosition" />
        <text name="CreatePbPosition" value="CreatePbPosition" />
        <text name="EditPbPosition" value="EditPbPosition" />
        <text name="DeletePbPosition" value="DeletePbPosition" />
    */
}