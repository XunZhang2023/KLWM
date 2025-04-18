using System;
using System.Configuration;

namespace ProcessControlSystem
{
    /*===================================================
    * 类名称: DbContext
    * 类描述: 数据库，所有数据库连接都要放在这里，不能随便放，可以多创建
    * 创建人: cp
    * 修改人:
    * 修改时间:
    * 版本： 1.0
    =====================================================*/
    public class DbContext
    {
        private static Lazy<IFreeSql> mysqlLazy = new Lazy<IFreeSql>(() => 
                                                  new FreeSql.FreeSqlBuilder().
                                                  UseConnectionString(FreeSql.DataType.MySql, ConfigurationManager.AppSettings["mySqlStr"]).
                                                  UseAutoSyncStructure(false).Build());

        public static IFreeSql MySql => mysqlLazy.Value;
    }
}
