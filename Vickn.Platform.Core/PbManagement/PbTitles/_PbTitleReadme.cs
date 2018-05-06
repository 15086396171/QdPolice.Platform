/*
* 命名空间 :     Vickn.Platform.PbManagement.PbTitles
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _PbTitleReadme.cs
* 描      述 :     排班标题Readme文件
* 创建时间 :     2018/5/6 14:40:35
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.PbManagement.PbTitles
{
    // 1.Core层权限配置
    // 2.Core层本地化
    // 3.EntityFrame层数据映射配置
    // 4.Application层注入权限
    // 5.Web层菜单配置
    //TODO:admin后端的导航栏目设计

    /*
	//无次级导航属性
	   var pbTitle=new MenuItemDefinition(
                PbTitleAppPermissions.PbTitle,
                L("PbTitle"),
				url:"pbTitleInfo",
				icon:"icon-grid",
				 requiredPermissionName: PbTitleAppPermissions.PbTitle
				);

*/
    //有下级菜单
    /*

       var pbTitle=new MenuItemDefinition(
        PbTitleAppPermissions.PbTitle,
        L("PbTitle"),			
        icon:"icon-grid"				
        );

        pbTitle.AddItem(
    new MenuItemDefinition(
    PbTitleAppPermissions.PbTitle,
    L("PbTitle"),
    "icon-star",
    "pbTitle",
    requiredPermissionName: PbTitleAppPermissions.PbTitle));



    */




    //配置权限模块初始化

    //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
    //   Configuration.Authorization.Providers.Add<PbTitleAppAuthorizationProvider>();




    //TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
    /*
        <!-- 排班标题管理 -->


            <text name="	PbTitleHeaderInfo" value="排班标题信息列表" />
                <text name="PbTitleDeleteWarningMessage" value="排班标题名称: {0} 将被删除,是否确定删除它。" />

                    <text name="PbTitleName" value="排班标题" />

    <!--//用于表格展示的数据信息的标题-->
                        <text name="PbTitle.Title" value="排班标题" />
                        <text name="PbTitle.Month" value="排班时间" />
                        <text name="PbTitle.IsPb" value="是否排班" />
                        <text name="PbTitle.PbPositions" value="当月下所有岗位标题集合" />
                        <text name="PbTitle.LastModificationTime" value="最后编辑时间" />
                        <text name="PbTitle.CreationTime" value="创建时间" />


        <text name="PbTitle" value="排班标题管理" />
        <text name="CreatePbTitle" value="添加排班标题" />
        <text name="EditPbTitle" value="编辑排班标题" />
        <text name="DeletePbTitle" value="删除排班标题" />
    */

    /*
        <!-- 排班标题english管理 -->
                <text name="	PbTitleHeaderInfo" value="排班标题List" />


        <text name="PbTitle" value="ManagementPbTitle" />
        <text name="CreatePbTitle" value="CreatePbTitle" />
        <text name="EditPbTitle" value="EditPbTitle" />
        <text name="DeletePbTitle" value="DeletePbTitle" />
    */
}