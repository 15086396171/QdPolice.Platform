/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _DataDictionaryItemReadme.cs
* 描      述 :     数据字典项Readme文件
* 创建时间 :     2017/6/12 16:57:19
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.DataDictionaries
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var dataDictionaryItem=new MenuItemDefinition(
                DataDictionaryItemAppPermissions.DataDictionaryItem,
                L("DataDictionaryItem"),
				url:"dataDictionaryItemInfo",
				icon:"icon-grid",
				 requiredPermissionName: DataDictionaryItemAppPermissions.DataDictionaryItem
				);

*/
				//有下级菜单
            /*

			   var dataDictionaryItem=new MenuItemDefinition(
                DataDictionaryItemAppPermissions.DataDictionaryItem,
                L("DataDictionaryItem"),			
				icon:"icon-grid"				
				);

				dataDictionaryItem.AddItem(
			new MenuItemDefinition(
			DataDictionaryItemAppPermissions.DataDictionaryItem,
			L("DataDictionaryItem"),
			"icon-star",
			"dataDictionaryItem",
			requiredPermissionName: DataDictionaryItemAppPermissions.DataDictionaryItem));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<DataDictionaryItemAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 数据字典项管理 -->


	    <text name="	DataDictionaryItemHeaderInfo" value="数据字典项信息列表" />
		    <text name="DataDictionaryItemDeleteWarningMessage" value="数据字典项名称: {0} 将被删除,是否确定删除它。" />

			    <text name="DataDictionaryItemName" value="数据字典项" />

<!--//用于表格展示的数据信息的标题-->
					<text name="DataDictionaryItem.Value" value="值" />
				 	<text name="DataDictionaryItem.DataDictionaryId" value="键Id" />
				 

    <text name="DataDictionaryItem" value="数据字典项管理" />
    <text name="CreateDataDictionaryItem" value="添加数据字典项" />
    <text name="UpdateDataDictionaryItem" value="更新数据字典项" />
    <text name="DeleteDataDictionaryItem" value="删除数据字典项" />
*/

/*
    <!-- 数据字典项english管理 -->
		    <text name="	DataDictionaryItemHeaderInfo" value="数据字典项List" />


    <text name="DataDictionaryItem" value="ManagementDataDictionaryItem" />
    <text name="CreateDataDictionaryItem" value="CreateDataDictionaryItem" />
    <text name="UpdateDataDictionaryItem" value="EditDataDictionaryItem" />
    <text name="DeleteDataDictionaryItem" value="DeleteDataDictionaryItem" />
*/
}