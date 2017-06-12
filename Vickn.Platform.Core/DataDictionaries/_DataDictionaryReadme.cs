/*
* 命名空间 :     Vickn.Platform.DataDictionaries
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _DataDictionaryReadme.cs
* 描      述 :     数据字典Readme文件
* 创建时间 :     2017/6/12 16:41:30
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
	   var dataDictionary=new MenuItemDefinition(
                DataDictionaryAppPermissions.DataDictionary,
                L("DataDictionary"),
				url:"dataDictionaryInfo",
				icon:"icon-grid",
				 requiredPermissionName: DataDictionaryAppPermissions.DataDictionary
				);

*/
				//有下级菜单
            /*

			   var dataDictionary=new MenuItemDefinition(
                DataDictionaryAppPermissions.DataDictionary,
                L("DataDictionary"),			
				icon:"icon-grid"				
				);

				dataDictionary.AddItem(
			new MenuItemDefinition(
			DataDictionaryAppPermissions.DataDictionary,
			L("DataDictionary"),
			"icon-star",
			"dataDictionary",
			requiredPermissionName: DataDictionaryAppPermissions.DataDictionary));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<DataDictionaryAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 数据字典管理 -->


	    <text name="	DataDictionaryHeaderInfo" value="数据字典信息列表" />
		    <text name="DataDictionaryDeleteWarningMessage" value="数据字典名称: {0} 将被删除,是否确定删除它。" />

			    <text name="DataDictionaryName" value="数据字典" />

<!--//用于表格展示的数据信息的标题-->
					<text name="DataDictionary.Key" value="键名" />
				 	<text name="DataDictionary.DisplayName" value="显示名" />
				 	<text name="DataDictionary.DataDictionaryItems" value="项集合" />
				 

    <text name="DataDictionary" value="数据字典管理" />
    <text name="CreateDataDictionary" value="添加数据字典" />
    <text name="UpdateDataDictionary" value="更新数据字典" />
    <text name="DeleteDataDictionary" value="删除数据字典" />
*/

/*
    <!-- 数据字典english管理 -->
		    <text name="	DataDictionaryHeaderInfo" value="数据字典List" />


    <text name="DataDictionary" value="ManagementDataDictionary" />
    <text name="CreateDataDictionary" value="CreateDataDictionary" />
    <text name="UpdateDataDictionary" value="EditDataDictionary" />
    <text name="DeleteDataDictionary" value="DeleteDataDictionary" />
*/
}