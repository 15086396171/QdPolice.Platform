/*
* 命名空间 :     Vickn.Platform.HandheldTerminals.Devices
* 类 名  称 :     
* 版      本 :      v1.0.0.0
* 文 件  名 :     _DeviceReadme.cs
* 描      述 :     设备Readme文件
* 创建时间 :     2018/2/4 16:27:02
* ===============================================================================
* Copyright © Vickn 2017 . All rights reserved.
* ===============================================================================
*/

namespace Vickn.Platform.HandheldTerminals.Devices
{
    // 1.Core层权限配置
	// 2.Core层本地化
	// 3.EntityFrame层数据映射配置
	// 4.Application层注入权限
	// 5.Web层菜单配置
	//TODO:admin后端的导航栏目设计

	/*
	//无次级导航属性
	   var device=new MenuItemDefinition(
                DeviceAppPermissions.Device,
                L("Device"),
				url:"deviceInfo",
				icon:"icon-grid",
				 requiredPermissionName: DeviceAppPermissions.Device
				);

*/
				//有下级菜单
            /*

			   var device=new MenuItemDefinition(
                DeviceAppPermissions.Device,
                L("Device"),			
				icon:"icon-grid"				
				);

				device.AddItem(
			new MenuItemDefinition(
			DeviceAppPermissions.Device,
			L("Device"),
			"icon-star",
			"device",
			requiredPermissionName: DeviceAppPermissions.Device));
	

			
			*/
			
	
	
	
	//配置权限模块初始化
	
 //TODO:★需要到请将以下内容剪切到AuthorizationProvider.AddAuthorizationProviders	中
 //   Configuration.Authorization.Providers.Add<DeviceAppAuthorizationProvider>();


 

//TODO:★请将以下内容剪切到CORE类库的Localization/Source/zh-cn.xml
/*
    <!-- 设备管理 -->


	    <text name="	DeviceHeaderInfo" value="设备信息列表" />
		    <text name="DeviceDeleteWarningMessage" value="设备名称: {0} 将被删除,是否确定删除它。" />

			    <text name="DeviceName" value="设备" />

<!--//用于表格展示的数据信息的标题-->
					<text name="Device.User" value="User" />
				 	<text name="Device.Imei" value="IMEI" />
				 	<text name="Device.No" value="编号" />
				 	<text name="Device.Battery" value="电量" />
				 	<text name="Device.LastModificationTime" value="最后编辑时间" />
				 	<text name="Device.CreationTime" value="创建时间" />
				 

    <text name="Device" value="设备管理" />
    <text name="CreateDevice" value="添加设备" />
    <text name="EditDevice" value="编辑设备" />
    <text name="DeleteDevice" value="删除设备" />
*/

/*
    <!-- 设备english管理 -->
		    <text name="	DeviceHeaderInfo" value="设备List" />


    <text name="Device" value="ManagementDevice" />
    <text name="CreateDevice" value="CreateDevice" />
    <text name="EditDevice" value="EditDevice" />
    <text name="DeleteDevice" value="DeleteDevice" />
*/
}