/*
* 命名空间 :     Vickn.Platform.FileRecords
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _FileRecordReadme.cs
* 描      述 :     文件记录Readme文件
* 创建时间 :     2017/8/13 22:00:22
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.FileRecords
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var fileRecord=new MenuItemDefinition(
                FileRecordAppPermissions.FileRecord,
                L("FileRecord"),
				url:"fileRecordInfo",
				icon:"icon-grid",
				 requiredPermissionName: FileRecordAppPermissions.FileRecord
				);

*/
				//有下级菜单
            /*

			   var fileRecord=new MenuItemDefinition(
                FileRecordAppPermissions.FileRecord,
                L("FileRecord"),			
				icon:"icon-grid"				
				);

				fileRecord.AddItem(
			new MenuItemDefinition(
			FileRecordAppPermissions.FileRecord,
			L("FileRecord"),
			"icon-star",
			"fileRecord",
			requiredPermissionName: FileRecordAppPermissions.FileRecord));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<FileRecordAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 文件记录管理 -->


	    <text name="	FileRecordHeaderInfo" value="文件记录信息列表" />
		    <text name="FileRecordDeleteWarningMessage" value="文件记录名称: {0} 将被删除,是否确定删除它。" />

			    <text name="FileRecordName" value="文件记录" />

<!--//用于表格展示的数据信息的标题-->
					<text name="FileRecord.FileId" value="标记在其他文件中的文件id" />
				 	<text name="FileRecord.Url" value="文件本地保存地址" />
				 	<text name="FileRecord.Name" value="文件名称" />
				 	<text name="FileRecord.LastModificationTime" value="最后编辑时间" />
				 	<text name="FileRecord.CreationTime" value="创建时间" />
				 

    <text name="FileRecord" value="文件记录管理" />
    <text name="CreateFileRecord" value="添加文件记录" />
    <text name="UpdateFileRecord" value="更新文件记录" />
    <text name="DeleteFileRecord" value="删除文件记录" />
*/

/*
    <!-- 文件记录english管理 -->
		    <text name="	FileRecordHeaderInfo" value="文件记录List" />


    <text name="FileRecord" value="ManagementFileRecord" />
    <text name="CreateFileRecord" value="CreateFileRecord" />
    <text name="UpdateFileRecord" value="UpdateFileRecord" />
    <text name="DeleteFileRecord" value="DeleteFileRecord" />
*/
}