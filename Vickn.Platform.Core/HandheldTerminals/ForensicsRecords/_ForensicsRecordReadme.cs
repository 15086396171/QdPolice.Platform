/*
* 命名空间 :     Vickn.Platform.HandheldTerminals
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _ForensicsRecordReadme.cs
* 描      述 :     取证记录Readme文件
* 创建时间 :     2018/2/5 17:40:07
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.HandheldTerminals
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var forensicsRecord=new MenuItemDefinition(
                ForensicsRecordAppPermissions.ForensicsRecord,
                L("ForensicsRecord"),
				url:"forensicsRecordInfo",
				icon:"icon-grid",
				 requiredPermissionName: ForensicsRecordAppPermissions.ForensicsRecord
				);

*/
				//有下级菜单
            /*

			   var forensicsRecord=new MenuItemDefinition(
                ForensicsRecordAppPermissions.ForensicsRecord,
                L("ForensicsRecord"),			
				icon:"icon-grid"				
				);

				forensicsRecord.AddItem(
			new MenuItemDefinition(
			ForensicsRecordAppPermissions.ForensicsRecord,
			L("ForensicsRecord"),
			"icon-star",
			"forensicsRecord",
			requiredPermissionName: ForensicsRecordAppPermissions.ForensicsRecord));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<ForensicsRecordAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 取证记录管理 -->


	    <text name="	ForensicsRecordHeaderInfo" value="取证记录信息列表" />
		    <text name="ForensicsRecordDeleteWarningMessage" value="取证记录名称: {0} 将被删除,是否确定删除它。" />

			    <text name="ForensicsRecordName" value="取证记录" />

<!--//用于表格展示的数据信息的标题-->
					<text name="ForensicsRecord.Src" value="路径" />
				 	<text name="ForensicsRecord.Mode" value="模式" />
				 	<text name="ForensicsRecord.Des" value="描述" />
				 	<text name="ForensicsRecord.ForensicsRecordType" value="文件类型" />
				 	<text name="ForensicsRecord.Device" value="Device" />
				 	<text name="ForensicsRecord.DeviceId" value="DeviceId" />
				 	<text name="ForensicsRecord.CreationTime" value="创建时间" />
				 

    <text name="ForensicsRecord" value="取证记录管理" />
    <text name="CreateForensicsRecord" value="添加取证记录" />
    <text name="EditForensicsRecord" value="编辑取证记录" />
    <text name="DeleteForensicsRecord" value="删除取证记录" />
*/

/*
    <!-- 取证记录english管理 -->
		    <text name="	ForensicsRecordHeaderInfo" value="取证记录List" />


    <text name="ForensicsRecord" value="ManagementForensicsRecord" />
    <text name="CreateForensicsRecord" value="CreateForensicsRecord" />
    <text name="EditForensicsRecord" value="EditForensicsRecord" />
    <text name="DeleteForensicsRecord" value="DeleteForensicsRecord" />
*/
}