using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Vickn.Platform.Authorization.Roles;
using Vickn.Platform.DataDictionaries;
using Vickn.Platform.DataDictionaries.EntityMapper;
using Vickn.Platform.FileRecords;
using Vickn.Platform.FileRecords.EntityMapper;
using Vickn.Platform.HandheldTerminals.Devices;
using Vickn.Platform.HandheldTerminals.Devices.EntityMapper;
using Vickn.Platform.MultiTenancy;
using Vickn.Platform.Users;

namespace Vickn.Platform.EntityFramework
{
    public class PlatformDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public IDbSet<DataDictionary> DataDictionaries { get; set; }

        public IDbSet<DataDictionaryItem> DataDictionaryItems { get; set; }

        public IDbSet<FileRecord> FileRecords { get; set; }


        public IDbSet<Device> Devices { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public PlatformDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in PlatformDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of PlatformDbContext since ABP automatically handles it.
         */
        public PlatformDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public PlatformDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

        /// <summary>
        /// 在完成对派生上下文的模型的初始化后，并在该模型已锁定并用于初始化上下文之前，将调用此方法。虽然此方法的默认实现不执行任何操作，但可在派生类中重写此方法，这样便能在锁定模型之前对其进行进一步的配置。
        /// </summary>
        /// <param name="modelBuilder">定义要创建的上下文的模型的生成器。</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("basic");
            modelBuilder.ChangeAbpTablePrefix<Tenant, Role, User>("Platform");

            PlatformConfiguration(modelBuilder);
        }

        private void PlatformConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FileRecordCfg());
            modelBuilder.Configurations.Add(new DataDictionaryCfg());
            modelBuilder.Configurations.Add(new DataDictionaryItemCfg());
            modelBuilder.Configurations.Add(new DeviceCfg());

        }
    }
}
