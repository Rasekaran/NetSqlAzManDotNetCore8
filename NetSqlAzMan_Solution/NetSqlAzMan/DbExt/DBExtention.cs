using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetSqlAzMan.DbExt
{
    // Copied the code from here
    // https://www.codeproject.com/Articles/5384522/Return-Multiple-Result-Sets-or-DataSet-Using-Entit

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using System.Reflection;

    public static class DbContextExtensions
    {
        public static DataSet DataSet(this DbContext context, string sqlQuery, params DbParameter[] parameters)
        {
            return context.Database.DataSet(sqlQuery, parameters);
        }

        public static DataSet DataSet(this DatabaseFacade database, string sqlQuery, params DbParameter[] parameters)
        {
            DataSet data = new DataSet();
            DbConnection connection = database.GetDbConnection();
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(data);
                }
            }
            return data;
        }
    }


    public static class DataTableExtensions
    {
        /*Converts DataTable To List*/
        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new { aProp.Name, Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType }).ToList();
            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();
            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var aTSource = new TSource();
                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    var value = dataRow[aField.Name] == DBNull.Value ? null : dataRow[aField.Name]; //if database field is nullable
                    propertyInfos.SetValue(aTSource, value, null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }
    }
}
