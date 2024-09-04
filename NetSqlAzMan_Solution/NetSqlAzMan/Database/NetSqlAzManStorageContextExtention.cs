using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using NetSqlAzMan.Database;
using NetSqlAzMan.DbExt;
using System;
using System.Collections.Generic;
using System.Data;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
using System.Linq;
//using System.Net;
//using System.Reflection;
//using System.Threading.Tasks;
//using System.Windows.Forms;


namespace NetSqlAzMan.Database
{
    /// <summary>
    /// 
    /// </summary>
    public partial class NetSqlAzManStorageContext
    {
        public static NetSqlAzManStorageContext CreateNetSqlAzManStorageContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NetSqlAzManStorageContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new NetSqlAzManStorageContext(optionsBuilder.Options);
        }

        private static Dictionary<KeyValuePair<string, string>, int?> dbUsersCheckSum = new Dictionary<KeyValuePair<string, string>, int?>();
        /// <summary>
        /// Gets the DB users ex.
        /// </summary>
        /// <param name="storeName">Name of the store.</param>
        /// <param name="applicationName">Name of the application.</param>
        /// <param name="dBUserSid">The d B user sid.</param>
        /// <param name="dBUserName">Name of the d B user.</param>
        /// <returns></returns>
        public DataTable GetDBUsersEx(string storeName, string applicationName, byte[] dBUserSid, string dBUserName)
        {
            DataTable result = new DataTable("DBUsers");
            using (var da = new SqlDataAdapter("select * from dbo.netsqlazman_GetDBUsers(@StoreName, @ApplicationName, @DBUserSID, @DBUserName)", (SqlConnection)this.Database.GetDbConnection()))
            {
                SqlParameter pStoreName = new SqlParameter("@StoreName", SqlDbType.NVarChar, 255);
                SqlParameter pApplicationName = new SqlParameter("@ApplicationName", SqlDbType.NVarChar, 255);
                SqlParameter pDBUserSID = new SqlParameter("@DBUserSID", SqlDbType.VarBinary, 85);
                SqlParameter pDBUserName = new SqlParameter("@DBUserName", SqlDbType.NVarChar, 255);
                pStoreName.Value = !String.IsNullOrEmpty(storeName) ? (object)storeName : DBNull.Value;
                pApplicationName.Value = !String.IsNullOrEmpty(applicationName)
                                             ? (object)applicationName
                                             : DBNull.Value;
                pDBUserSID.Value = dBUserSid != null ? (object)dBUserSid : DBNull.Value;
                pDBUserName.Value = !String.IsNullOrEmpty(dBUserName) ? (object)dBUserName : DBNull.Value;
                da.SelectCommand.Parameters.Add(pStoreName);
                da.SelectCommand.Parameters.Add(pApplicationName);
                da.SelectCommand.Parameters.Add(pDBUserSID);
                da.SelectCommand.Parameters.Add(pDBUserName);
                //da.SelectCommand.Transaction = this.Database.CurrentTransaction.GetDbTransaction() as SqlTransaction;
                da.Fill(result);
            }
            return result;
        }

        //partial void OnCreated()
        //{
        //    this.ObjectTrackingEnabled = true;
        //}

        public int ApplicationAttributeDelete(int? applicationId, int? applicationAttributeId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationAttributeDelete {applicationId}, {applicationAttributeId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationAttributeDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationAttributeDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationAttributeId", DbType = "Int")] System.Nullable<int> applicationAttributeId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, applicationAttributeId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationAttributeInsert(int? applicationId, string attributeKey, string attributeValue)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationAttributeInsert {applicationId}, {attributeKey}, {attributeValue}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationAttributeInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationAttributeInsert([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, attributeKey, attributeValue);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationAttributes", IsComposable = true)]
        //public IQueryable<ApplicationAttributesResult> ApplicationAttributes()
        //{
        //    return this.CreateMethodCallQuery<ApplicationAttributesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int ApplicationAttributeUpdate(int? applicationId, string attributeKey, string attributeValue, int original_ApplicationAttributeId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationAttributeUpdate {applicationId}, {attributeKey}, {attributeValue}, {original_ApplicationAttributeId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationAttributeUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationAttributeUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_ApplicationAttributeId", DbType = "Int")] System.Nullable<int> original_ApplicationAttributeId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, attributeKey, attributeValue, original_ApplicationAttributeId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationDelete(int? storeId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationDelete {storeId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationGroupDelete(int? applicationGroupId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationGroupDelete {applicationGroupId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationGroupDelete([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationGroupId", DbType = "Int")] System.Nullable<int> applicationGroupId, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationGroupId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationGroupInsert( int applicationId, byte[] objectSid, string name, string description, string lDapQuery, byte groupType)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationGroupInsert {applicationId}, {objectSid}, {name}, {description}, {lDapQuery}, {groupType}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationGroupInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDapQuery", DbType = "NVarChar(4000)")] string lDapQuery, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "GroupType", DbType = "TinyInt")] System.Nullable<byte> groupType)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, objectSid, name, description, lDapQuery, groupType);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationGroupMemberDelete(int applicationGroupMemberId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationGroupMemberDelete {applicationGroupMemberId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupMemberDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationGroupMemberDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationGroupMemberId", DbType = "Int")] System.Nullable<int> applicationGroupMemberId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationGroupMemberId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationGroupMemberInsert(int applicationGroupId, byte[] objectSid, byte whereDefined, bool isMember, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationGroupMemberInsert {applicationGroupId}, {objectSid}, {whereDefined}, {isMember}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupMemberInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationGroupMemberInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationGroupId", DbType = "Int")] System.Nullable<int> applicationGroupId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "WhereDefined", DbType = "TinyInt")] System.Nullable<byte> whereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IsMember", DbType = "Bit")] System.Nullable<bool> isMember, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationGroupId, objectSid, whereDefined, isMember, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupMembers", IsComposable = true)]
        //public IQueryable<ApplicationGroupMembersResult> ApplicationGroupMembers()
        //{
        //    return this.CreateMethodCallQuery<ApplicationGroupMembersResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int ApplicationGroupMemberUpdate(int applicationGroupId, byte[] objectSid, byte whereDefined, bool isMember, int original_ApplicationGroupMemberId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationGroupMemberUpdate {applicationGroupId}, {objectSid}, {whereDefined}, {isMember}, {original_ApplicationGroupMemberId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupMemberUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationGroupMemberUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationGroupId", DbType = "Int")] System.Nullable<int> applicationGroupId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "WhereDefined", DbType = "TinyInt")] System.Nullable<byte> whereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IsMember", DbType = "Bit")] System.Nullable<bool> isMember, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_ApplicationGroupMemberId", DbType = "Int")] System.Nullable<int> original_ApplicationGroupMemberId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationGroupId, objectSid, whereDefined, isMember, original_ApplicationGroupMemberId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroups", IsComposable = true)]
        //public IQueryable<ApplicationGroupsResult> ApplicationGroups()
        //{
        //    return this.CreateMethodCallQuery<ApplicationGroupsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int ApplicationGroupUpdate( byte[] objectSid, string name, string description, string lDapQuery, byte groupType, int original_ApplicationGroupId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationGroupUpdate {objectSid}, {name}, {description}, {lDapQuery}, {groupType}, {original_ApplicationGroupId}, {applicationId}"
            );

            return result;
        }


        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationGroupUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationGroupUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDapQuery", DbType = "NVarChar(4000)")] string lDapQuery, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "GroupType", DbType = "TinyInt")] System.Nullable<byte> groupType, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_ApplicationGroupId", DbType = "Int")] System.Nullable<int> original_ApplicationGroupId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), objectSid, name, description, lDapQuery, groupType, original_ApplicationGroupId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationInsert(int storeId, string name, string description)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationInsert {storeId}, {name}, {description}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, name, description);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationPermissionDelete(int applicationPermissionId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationPermissionDelete {applicationPermissionId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationPermissionDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationPermissionDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationPermissionId", DbType = "Int")] System.Nullable<int> applicationPermissionId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationPermissionId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ApplicationPermissionInsert(int applicationId, string sqlUserOrRole, bool isSqlRole, byte netSqlAzManFixedServerRole)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationPermissionInsert {applicationId}, {sqlUserOrRole}, {isSqlRole}, {netSqlAzManFixedServerRole}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationPermissionInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationPermissionInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SqlUserOrRole", DbType = "NVarChar(128)")] string sqlUserOrRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IsSqlRole", DbType = "Bit")] System.Nullable<bool> isSqlRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NetSqlAzManFixedServerRole", DbType = "TinyInt")] System.Nullable<byte> netSqlAzManFixedServerRole)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, sqlUserOrRole, isSqlRole, netSqlAzManFixedServerRole);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationPermissions", IsComposable = true)]
        //public IQueryable<ApplicationPermissionsResult> ApplicationPermissions()
        //{
        //    return this.CreateMethodCallQuery<ApplicationPermissionsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_Applications", IsComposable = true)]
        //public IQueryable<ApplicationsResult> Applications()
        //{
        //    return this.CreateMethodCallQuery<ApplicationsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int ApplicationUpdate(string name, string description, int original_ApplicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ApplicationUpdate {name}, {description}, {original_ApplicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ApplicationUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ApplicationUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_ApplicationId", DbType = "Int")] System.Nullable<int> original_ApplicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, description, original_ApplicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int AuthorizationAttributeDelete(int authorizationAttributeId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_AuthorizationAttributeDelete {authorizationAttributeId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationAttributeDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int AuthorizationAttributeDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AuthorizationAttributeId", DbType = "Int")] System.Nullable<int> authorizationAttributeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), authorizationAttributeId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int AuthorizationAttributeInsert(int authorizationId, string attributeKey, string attributeValue, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_AuthorizationAttributeInsert {authorizationId}, {attributeKey}, {attributeValue}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationAttributeInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int AuthorizationAttributeInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AuthorizationId", DbType = "Int")] System.Nullable<int> authorizationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), authorizationId, attributeKey, attributeValue, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationAttributes", IsComposable = true)]
        //public IQueryable<AuthorizationAttributesResult> AuthorizationAttributes()
        //{
        //    return this.CreateMethodCallQuery<AuthorizationAttributesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int AuthorizationAttributeUpdate( string attributeKey, string attributeValue, int original_AuthorizationAttributeId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_AuthorizationAttributeUpdate {attributeKey}, {attributeValue}, {original_AuthorizationAttributeId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationAttributeUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int AuthorizationAttributeUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_AuthorizationAttributeId", DbType = "Int")] System.Nullable<int> original_AuthorizationAttributeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), attributeKey, attributeValue, original_AuthorizationAttributeId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int AuthorizationDelete(int authorizationId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_AuthorizationDelete {authorizationId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int AuthorizationDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AuthorizationId", DbType = "Int")] System.Nullable<int> authorizationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), authorizationId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int AuthorizationInsert(int itemId, byte[] ownerId, byte ownerSidWhereDefined, byte[] objectSid, byte objectSidWhereDefined, byte authorizationType, DateTime validFrom, DateTime validTo, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_AuthorizationInsert {itemId}, {ownerId}, {ownerSidWhereDefined}, {objectSid}, {objectSidWhereDefined}, {authorizationType}, {validFrom}, {validTo}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int AuthorizationInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary ownerSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "TinyInt")] System.Nullable<byte> ownerSidWhereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "TinyInt")] System.Nullable<byte> objectSidWhereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AuthorizationType", DbType = "TinyInt")] System.Nullable<byte> authorizationType, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ValidFrom", DbType = "DateTime")] System.Nullable<System.DateTime> validFrom, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ValidTo", DbType = "DateTime")] System.Nullable<System.DateTime> validTo, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, ownerSid, ownerSidWhereDefined, objectSid, objectSidWhereDefined, authorizationType, validFrom, validTo, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_Authorizations", IsComposable = true)]
        //public IQueryable<AuthorizationsResult> Authorizations()
        //{
        //    return this.CreateMethodCallQuery<AuthorizationsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int AuthorizationUpdate(int itemId, byte[] ownerId, byte ownerSidWhereDefined, byte[] objectSid, byte objectSidWhereDefined, byte authorizationType, DateTime validFrom, DateTime validTo, int original_AuthorizationId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_AuthorizationUpdate {itemId}, {ownerId}, {ownerSidWhereDefined}, {objectSid}, {objectSidWhereDefined}, {authorizationType}, {validFrom}, {validTo}, {original_AuthorizationId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_AuthorizationUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int AuthorizationUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary ownerSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "TinyInt")] System.Nullable<byte> ownerSidWhereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "TinyInt")] System.Nullable<byte> objectSidWhereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AuthorizationType", DbType = "TinyInt")] System.Nullable<byte> authorizationType, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ValidFrom", DbType = "DateTime")] System.Nullable<System.DateTime> validFrom, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ValidTo", DbType = "DateTime")] System.Nullable<System.DateTime> validTo, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_AuthorizationId", DbType = "Int")] System.Nullable<int> original_AuthorizationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, ownerSid, ownerSidWhereDefined, objectSid, objectSidWhereDefined, authorizationType, validFrom, validTo, original_AuthorizationId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int BizRuleDelete(int bizRuleId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_BizRuleDelete {bizRuleId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_BizRuleDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int BizRuleDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleId", DbType = "Int")] System.Nullable<int> bizRuleId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), bizRuleId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int BizRuleInsert(string bizRuleSource, byte bizRuleLanguage, byte[] compiledAssembly)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_BizRuleInsert {bizRuleSource}, {bizRuleLanguage}, {compiledAssembly}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_BizRuleInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int BizRuleInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleSource", DbType = "Text")] string bizRuleSource, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleLanguage", DbType = "TinyInt")] System.Nullable<byte> bizRuleLanguage, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "CompiledAssembly", DbType = "Image")] System.Data.Linq.Binary compiledAssembly)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), bizRuleSource, bizRuleLanguage, compiledAssembly);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_BizRules", IsComposable = true)]
        //public IQueryable<BizRulesResult> BizRules()
        //{
        //    return this.CreateMethodCallQuery<BizRulesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int BizRuleUpdate(string bizRuleSource, byte bizRuleLanguage, byte[] compiledAssembly, int original_BizRuleId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_BizRuleUpdate {bizRuleSource}, {bizRuleLanguage}, {compiledAssembly}, {original_BizRuleId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_BizRuleUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int BizRuleUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleSource", DbType = "Text")] string bizRuleSource, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleLanguage", DbType = "TinyInt")] System.Nullable<byte> bizRuleLanguage, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "CompiledAssembly", DbType = "Image")] System.Data.Linq.Binary compiledAssembly, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_BizRuleId", DbType = "Int")] System.Nullable<int> original_BizRuleId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), bizRuleSource, bizRuleLanguage, compiledAssembly, original_BizRuleId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //public int BuildUserPermissionCache(string sTORENAME, string aPPLICATIONNAME)
        //{
        //    var result = this.Database.ExecuteSqlInterpolated(
        //        $"EXEC dbo.netsqlazman_BuildUserPermissionCache {sTORENAME}, {aPPLICATIONNAME}"
        //    );

        //    return result;
        //}


        public class BuildUserPermissionCacheResults
        {
            List<BuildUserPermissionCacheResult1> _Result1;
            List<BuildUserPermissionCacheResult2> _Result2;
            public BuildUserPermissionCacheResults(
                List<BuildUserPermissionCacheResult1> Result1,
                List<BuildUserPermissionCacheResult2> Result2
            )
            {
                _Result1 = Result1;
                _Result2 = Result2;
            }

            public List<T> GetResult<T>()
            {
                if(typeof(T) == typeof(BuildUserPermissionCacheResult1))
                {
                    return _Result1 as List<T>;
                }
                if (typeof(T) == typeof(BuildUserPermissionCacheResult2))
                {
                    return _Result2 as List<T>;
                }
                return null;
            }
        }

        //public DbSet<BuildUserPermissionCacheResult2> BuildUserPermissionCacheResult2 { get; set; }

        public BuildUserPermissionCacheResults BuildUserPermissionCache(string sTORENAME, string aPPLICATIONNAME) {
            DataSet result = this.DataSet($"EXEC dbo.netsqlazman_BuildUserPermissionCache @storeName @applicationName",
                        new SqlParameter("storeName", sTORENAME), 
                        new SqlParameter("applicationName", aPPLICATIONNAME));
            List<BuildUserPermissionCacheResult1> cacheResult1 = result.Tables[0].ToList<BuildUserPermissionCacheResult1>();
            List<BuildUserPermissionCacheResult2> cacheResult2 = result.Tables[1].ToList<BuildUserPermissionCacheResult2>();
            return new BuildUserPermissionCacheResults(cacheResult1, cacheResult2);
            //var result = this.BuildUserPermissionCacheResult2.FromSqlInterpolated (
            //    $"EXEC dbo.netsqlazman_BuildUserPermissionCache {sTORENAME}, {aPPLICATIONNAME}"
            //);
            //return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_BuildUserPermissionCache")]
        //[global::System.Data.Linq.Mapping.ResultTypeAttribute(typeof(BuildUserPermissionCacheResult1))]
        //[global::System.Data.Linq.Mapping.ResultTypeAttribute(typeof(BuildUserPermissionCacheResult2))]
        //public IMultipleResults BuildUserPermissionCache(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "STORENAME", DbType = "NVarChar(255)")] string sTORENAME, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "APPLICATIONNAME", DbType = "NVarChar(255)")] string aPPLICATIONNAME)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sTORENAME, aPPLICATIONNAME);
        //    return ((IMultipleResults)(result.ReturnValue));
        //}

        public class CheckApplicationPermissionsResult
        {
            public bool HasApplicationPermission { get; set; }
        }

        public virtual DbSet<CheckApplicationPermissionsResult> CheckApplicationPermissionsDbSet { get; set; }

        public Nullable<bool> CheckApplicationPermissions(int aPPLICATIONID, byte rOLEID)
        {
            return CheckApplicationPermissionsDbSet
                .FromSqlInterpolated($"SELECT dbo.netsqlazman_CheckApplicationPermissions({aPPLICATIONID},{rOLEID}) as HasApplicationPermission")
                .FirstOrDefault().HasApplicationPermission;
        }

        //[DbFunction("netsqlazman_CheckApplicationPermissions", "dbo")]
        //public bool netsqlazman_CheckApplicationPermissions(int aPPLICATIONID, byte rOLEID) => throw new NotSupportedException();

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_CheckApplicationPermissions", IsComposable = true)]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")]
        //public System.Nullable<bool> CheckApplicationPermissions(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "APPLICATIONID", DbType = "Int")] System.Nullable<int> aPPLICATIONID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ROLEID", DbType = "TinyInt")] System.Nullable<byte> rOLEID)
        //{
        //    return ((System.Nullable<bool>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), aPPLICATIONID, rOLEID).ReturnValue));
        //}

        //public int CheckStorePermissions(int sTOREID, byte rOLEID)
        //{
        //    var result = this.Database.ExecuteSqlInterpolated(
        //        $"EXEC dbo.netsqlazman_CheckStorePermissions {sTOREID}, {rOLEID}"
        //    );

        //    return result;
        //}

        public class CheckStorePermissionsResult
        {
            public bool HasStorePermissions { get; set; }
        }

        public virtual DbSet<CheckStorePermissionsResult> CheckStorePermissionsDbSet { get; set; }

        public Nullable<bool> CheckStorePermissions(int sTOREID, byte rOLEID)
        {
            return CheckStorePermissionsDbSet
                .FromSqlInterpolated($"SELECT dbo.netsqlazman_CheckStorePermissions({sTOREID},{rOLEID}) as HasApplicationPermission")
                .FirstOrDefault().HasStorePermissions;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_CheckStorePermissions", IsComposable = true)]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")]
        //public System.Nullable<bool> CheckStorePermissions(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "STOREID", DbType = "Int")] System.Nullable<int> sTOREID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ROLEID", DbType = "TinyInt")] System.Nullable<byte> rOLEID)
        //{
        //    return ((System.Nullable<bool>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sTOREID, rOLEID).ReturnValue));
        //}

        public int ClearBizRule(int itemId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ClearBizRule {itemId}, {applicationId}"
            );

            return result;
        }

        /**
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ClearBizRule")]
        [return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        public int ClearBizRule(
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        {
            IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, applicationId);
            return ((int)(result.ReturnValue));
        }
        */

        public int CreateDelegate(int iTEMID, byte[] oWNERSID, byte oWNERSIDWHEREDEFINED, byte[] dELEGATEDUSERSID, byte sIDWHEREDEFINED, byte aUTHORIZATIONTYPE, DateTime vALIDFROM, DateTime vALIDTO, out int aUTHORIZATIONID)
        {
            var authId = new SqlParameter("@AUTHORIZATIONID", SqlDbType.Int);
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_CreateDelegate {iTEMID}, {oWNERSID}, {oWNERSIDWHEREDEFINED}, {dELEGATEDUSERSID}, {sIDWHEREDEFINED}, {aUTHORIZATIONTYPE}, {vALIDFROM}, {vALIDTO}, {authId} out"
            );
            aUTHORIZATIONID = (int)authId.Value;

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_CreateDelegate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int CreateDelegate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ITEMID", DbType = "Int")] System.Nullable<int> iTEMID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "OWNERSID", DbType = "VarBinary(85)")] System.Data.Linq.Binary oWNERSID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "OWNERSIDWHEREDEFINED", DbType = "TinyInt")] System.Nullable<byte> oWNERSIDWHEREDEFINED, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "DELEGATEDUSERSID", DbType = "VarBinary(85)")] System.Data.Linq.Binary dELEGATEDUSERSID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SIDWHEREDEFINED", DbType = "TinyInt")] System.Nullable<byte> sIDWHEREDEFINED, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTHORIZATIONTYPE", DbType = "TinyInt")] System.Nullable<byte> aUTHORIZATIONTYPE, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "VALIDFROM", DbType = "DateTime")] System.Nullable<System.DateTime> vALIDFROM, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "VALIDTO", DbType = "DateTime")] System.Nullable<System.DateTime> vALIDTO, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTHORIZATIONID", DbType = "Int")] ref System.Nullable<int> aUTHORIZATIONID)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iTEMID, oWNERSID, oWNERSIDWHEREDEFINED, dELEGATEDUSERSID, sIDWHEREDEFINED, aUTHORIZATIONTYPE, vALIDFROM, vALIDTO, aUTHORIZATIONID);
        //    aUTHORIZATIONID = ((System.Nullable<int>)(result.GetParameterValue(8)));
        //    return ((int)(result.ReturnValue));
        //}

        public int DeleteDelegate(int aUTHORIZATIONID, byte[] oWNERSID)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_DeleteDelegate {aUTHORIZATIONID}, {oWNERSID}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_DeleteDelegate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int DeleteDelegate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTHORIZATIONID", DbType = "Int")] System.Nullable<int> aUTHORIZATIONID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "OWNERSID", DbType = "VarBinary(85)")] System.Data.Linq.Binary oWNERSID)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), aUTHORIZATIONID, oWNERSID);
        //    return ((int)(result.ReturnValue));
        //}

        public int DirectCheckAccess(string sTORENAME, string aPPLICATIONNAME, string iTEMNAME, bool oPERATIONSONLY, byte[] tOKEN, int uSERGROUPSCOUNT, DateTime vALIDFOR, string lDAPPATH, byte aUTHORIZATION_TYPE, bool rETRIEVEATTRIBUTES)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_DirectCheckAccess {sTORENAME}, {aPPLICATIONNAME}, {iTEMNAME}, {oPERATIONSONLY}, {tOKEN}, {uSERGROUPSCOUNT}, {vALIDFOR}, {lDAPPATH}, {aUTHORIZATION_TYPE}, {rETRIEVEATTRIBUTES}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_DirectCheckAccess")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int DirectCheckAccess(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "STORENAME", DbType = "NVarChar(255)")] string sTORENAME, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "APPLICATIONNAME", DbType = "NVarChar(255)")] string aPPLICATIONNAME, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ITEMNAME", DbType = "NVarChar(255)")] string iTEMNAME, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "OPERATIONSONLY", DbType = "Bit")] System.Nullable<bool> oPERATIONSONLY, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "TOKEN", DbType = "Image")] System.Data.Linq.Binary tOKEN, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "USERGROUPSCOUNT", DbType = "Int")] System.Nullable<int> uSERGROUPSCOUNT, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "VALIDFOR", DbType = "DateTime")] System.Nullable<System.DateTime> vALIDFOR, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDAPPATH", DbType = "NVarChar(4000)")] string lDAPPATH, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTHORIZATION_TYPE", DbType = "TinyInt")] ref System.Nullable<byte> aUTHORIZATION_TYPE, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "RETRIEVEATTRIBUTES", DbType = "Bit")] System.Nullable<bool> rETRIEVEATTRIBUTES)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sTORENAME, aPPLICATIONNAME, iTEMNAME, oPERATIONSONLY, tOKEN, uSERGROUPSCOUNT, vALIDFOR, lDAPPATH, aUTHORIZATION_TYPE, rETRIEVEATTRIBUTES);
        //    aUTHORIZATION_TYPE = ((System.Nullable<byte>)(result.GetParameterValue(8)));
        //    return ((int)(result.ReturnValue));
        //}

        public DbSet<GetDBUsersResult> GetDBUsersResult { get; set; }

        public IQueryable<GetDBUsersResult> GetDBUsers(string storeName, string applicationName, byte[] dBUserSid, string dBUserName)
        {
            var result = this.GetDBUsersResult.FromSqlInterpolated(
                $"EXEC dbo.netsqlazman_GetDBUsers {storeName}, {applicationName}, {dBUserSid}, {dBUserName}"
            );
            return result;
        }

        /**
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_GetDBUsers", IsComposable = true)]
        public IQueryable<GetDBUsersResult> GetDBUsers(
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreName", DbType = "NVarChar(255)")] string storeName, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationName", DbType = "NVarChar(255)")] string applicationName, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "DBUserSid", DbType = "VarBinary(85)")] System.Data.Linq.Binary dBUserSid, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "DBUserName", DbType = "NVarChar(255)")] string dBUserName)
        {
            return this.CreateMethodCallQuery<GetDBUsersResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeName, applicationName, dBUserSid, dBUserName);
        }
        */

        public class GetNameFromSidResult
        {
            public bool Name { get; set; }
        }

        public virtual DbSet<GetNameFromSidResult> GetNameFromSidResultDbSet { get; set; }

        public Nullable<bool> GetNameFromSid(string storeName, string applicationName, byte[] sid, byte sidWhereDefined)
        {
            return GetNameFromSidResultDbSet
                .FromSqlInterpolated($"SELECT dbo.netsqlazman_GetNameFromSid() as Name")
                .FirstOrDefault().Name;
        }

        /**
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_GetNameFromSid", IsComposable = true)]
        [return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(255)")]
        public string GetNameFromSid(
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreName", DbType = "NVarChar(255)")] string storeName, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationName", DbType = "NVarChar(255)")] string applicationName, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Sid", DbType = "VarBinary(85)")] System.Data.Linq.Binary sid, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SidWhereDefined", DbType = "TinyInt")] System.Nullable<byte> sidWhereDefined)
        {
            return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeName, applicationName, sid, sidWhereDefined).ReturnValue));
        }
        */

        public int GrantApplicationAccess(int applicationId, string sqlUserOrRole, byte netSqlAzManFixedServerRole)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_GrantApplicationAccess {applicationId}, {sqlUserOrRole}, {netSqlAzManFixedServerRole}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_GrantApplicationAccess")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int GrantApplicationAccess(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SqlUserOrRole", DbType = "NVarChar(128)")] string sqlUserOrRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NetSqlAzManFixedServerRole", DbType = "TinyInt")] System.Nullable<byte> netSqlAzManFixedServerRole)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, sqlUserOrRole, netSqlAzManFixedServerRole);
        //    return ((int)(result.ReturnValue));
        //}

        public int GrantStoreAccess(int applicationId, string sqlUserOrRole, byte netSqlAzManFixedServerRole)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_GrantStoreAccess {applicationId}, {sqlUserOrRole}, {netSqlAzManFixedServerRole}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_GrantStoreAccess")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int GrantStoreAccess(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SqlUserOrRole", DbType = "NVarChar(128)")] string sqlUserOrRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NetSqlAzManFixedServerRole", DbType = "TinyInt")] System.Nullable<byte> netSqlAzManFixedServerRole)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, sqlUserOrRole, netSqlAzManFixedServerRole);
        //    return ((int)(result.ReturnValue));
        //}

        public class IAmAdminResult
        {
            public bool AmIAdmin { get; set; }
        }

        public virtual DbSet<IAmAdminResult> IAmAdminDbSet { get; set; }

        public Nullable<bool> IAmAdmin()
        {
            return IAmAdminDbSet
                .FromSqlInterpolated($"SELECT dbo.netsqlazman_IAmAdmin() as AmIAdmin")
                .FirstOrDefault().AmIAdmin;
        }

        /**
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_IAmAdmin", IsComposable = true)]
        [return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Bit")]
        public System.Nullable<bool> IAmAdmin()
        {
            return ((System.Nullable<bool>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
        }
        */
        public int ItemAttributeDelete(int itemAttributeId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemAttributeDelete {itemAttributeId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemAttributeDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemAttributeDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemAttributeId", DbType = "Int")] System.Nullable<int> itemAttributeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemAttributeId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ItemAttributeInsert(int itemId, string attributeKey, string attributeValue, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemAttributeInsert {itemId}, {attributeKey}, {attributeValue}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemAttributeInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemAttributeInsert(
        //    global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, attributeKey, attributeValue, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemAttributes", IsComposable = true)]
        //public IQueryable<ItemAttributesResult> ItemAttributes()
        //{
        //    return this.CreateMethodCallQuery<ItemAttributesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int ItemAttributeUpdate(string attributeKey, string attributeValue, int original_ItemAttributeId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemAttributeUpdate {attributeKey}, {attributeValue}, {original_ItemAttributeId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemAttributeUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemAttributeUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_ItemAttributeId", DbType = "Int")] System.Nullable<int> original_ItemAttributeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), attributeKey, attributeValue, original_ItemAttributeId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ItemDelete(int itemId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemDelete {itemId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ItemInsert(string name, string description, byte itemType, Nullable<int> bizRoleId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemInsert {name}, {description}, {itemType}, {bizRoleId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemType", DbType = "TinyInt")] System.Nullable<byte> itemType, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleId", DbType = "Int")] System.Nullable<int> bizRuleId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, description, itemType, bizRuleId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_Items", IsComposable = true)]
        //public IQueryable<ItemsResult> Items()
        //{
        //    return this.CreateMethodCallQuery<ItemsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemsHierarchy", IsComposable = true)]
        //public IQueryable<ItemsHierarchyResult> ItemsHierarchy()
        //{
        //    return this.CreateMethodCallQuery<ItemsHierarchyResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int ItemsHierarchyDelete(int itemId, int memberOfItemId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemsHierarchyDelete {itemId}, {memberOfItemId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemsHierarchyDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemsHierarchyDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "MemberOfItemId", DbType = "Int")] System.Nullable<int> memberOfItemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, memberOfItemId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ItemsHierarchyInsert(int itemId, int memberOfItemId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemsHierarchyInsert {itemId}, {memberOfItemId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemsHierarchyInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemsHierarchyInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "MemberOfItemId", DbType = "Int")] System.Nullable<int> memberOfItemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, memberOfItemId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int ItemUpdate(string name, string description, byte itemType, int original_ItemId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ItemUpdate {name}, {description}, {itemType}, {original_ItemId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ItemUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ItemUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemType", DbType = "TinyInt")] System.Nullable<byte> itemType, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_ItemId", DbType = "Int")] System.Nullable<int> original_ItemId,
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, description, itemType, original_ItemId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public class MergeAuthorizationsResult
        {
            public bool IsMergeAuthorizations { get; set; }
        }

        public virtual DbSet<MergeAuthorizationsResult> MergeAuthorizationsDbSet{ get; set; }

        public Nullable<bool> MergeAuthorizations(byte aUTH1, byte aUTH2)
        {
            return MergeAuthorizationsDbSet
                .FromSqlInterpolated($"SELECT dbo.netsqlazman_MergeAuthorizations({aUTH1},{aUTH2}) as IsMergeAuthorizations")
                .FirstOrDefault().IsMergeAuthorizations;
        }

        //public bool MergeAuthorizations(byte aUTH1, byte aUTH2)
        //{
        //    return netsqlazman_MergeAuthorizations(aUTH1, aUTH2);
        //}
        //public bool netsqlazman_MergeAuthorizations(byte aUTH1, byte aUTH2) => throw new NotSupportedException();

        /**
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_MergeAuthorizations", IsComposable = true)]
        [return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "TinyInt")]
        public System.Nullable<byte> MergeAuthorizations(
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTH1", DbType = "TinyInt")] System.Nullable<byte> aUTH1, 
        [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTH2", DbType = "TinyInt")] System.Nullable<byte> aUTH2)
        {
            return ((System.Nullable<byte>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), aUTH1, aUTH2).ReturnValue));
        }
        */

        public class DBVersionResult
        {
            public string DBVersion { get; set; }
        }

        public virtual DbSet<DBVersionResult> DBVersionDbSet { get; set; }

        public string NetSqlAzMan_DBVersion()
        {
            return DBVersionDbSet
                .FromSqlInterpolated($"SELECT dbo.netsqlazman_DBVersion() as DBVersion")
                .FirstOrDefault().DBVersion;
        }

        /**
        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_DBVersion", IsComposable = true)]
        [return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(200)")]
        public string NetSqlAzMan_DBVersion()
        {
            return ((string)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
        }
        */

        public int ReloadBizRule(int itemId, int bizRuleId, int applicationId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ReloadBizRule {itemId}, {bizRuleId}, {applicationId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ReloadBizRule")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int ReloadBizRule(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ItemId", DbType = "Int")] System.Nullable<int> itemId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "BizRuleId", DbType = "Int")] System.Nullable<int> bizRuleId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), itemId, bizRuleId, applicationId);
        //    return ((int)(result.ReturnValue));
        //}

        public int RevokeApplicationAccess(int applicationId, string sqlUserOrRole, byte netSqlAzManFixedServerRole)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_RevokeApplicationAccess {applicationId}, {sqlUserOrRole}, {netSqlAzManFixedServerRole}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_RevokeApplicationAccess")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int RevokeApplicationAccess(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ApplicationId", DbType = "Int")] System.Nullable<int> applicationId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SqlUserOrRole", DbType = "NVarChar(128)")] string sqlUserOrRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NetSqlAzManFixedServerRole", DbType = "TinyInt")] System.Nullable<byte> netSqlAzManFixedServerRole)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), applicationId, sqlUserOrRole, netSqlAzManFixedServerRole);
        //    return ((int)(result.ReturnValue));
        //}

        public int RevokeStoreAccess(int applicationId, string sqlUserOrRole, byte netSqlAzManFixedServerRole)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_RevokeStoreAccess {applicationId}, {sqlUserOrRole}, {netSqlAzManFixedServerRole}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_RevokeStoreAccess")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int RevokeStoreAccess(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SqlUserOrRole", DbType = "NVarChar(128)")] string sqlUserOrRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NetSqlAzManFixedServerRole", DbType = "TinyInt")] System.Nullable<byte> netSqlAzManFixedServerRole)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, sqlUserOrRole, netSqlAzManFixedServerRole);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreAttributeDelete(int storeId, int storeAttributeId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreAttributeDelete {storeId}, {storeAttributeId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreAttributeDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreAttributeDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreAttributeId", DbType = "Int")] System.Nullable<int> storeAttributeId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, storeAttributeId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreAttributeInsert(int storeId, string storeAttributeId, string attributeValue)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreAttributeInsert {storeId}, {storeAttributeId}, {attributeValue}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreAttributeInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreAttributeInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, attributeKey, attributeValue);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreAttributes", IsComposable = true)]
        //public IQueryable<StoreAttributesResult> StoreAttributes()
        //{
        //    return this.CreateMethodCallQuery<StoreAttributesResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int StoreAttributeUpdate(int storeId, string storeAttributeId, string attributeValue, int original_StoreAttributeId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreAttributeUpdate {storeId}, {storeAttributeId}, {attributeValue}, {original_StoreAttributeId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreAttributeUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreAttributeUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeKey", DbType = "NVarChar(255)")] string attributeKey, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AttributeValue", DbType = "NVarChar(4000)")] string attributeValue, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_StoreAttributeId", DbType = "Int")] System.Nullable<int> original_StoreAttributeId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, attributeKey, attributeValue, original_StoreAttributeId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreDelete(int original_StoreId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreDelete {original_StoreId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_StoreId", DbType = "Int")] System.Nullable<int> original_StoreId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), original_StoreId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreGroupDelete(int original_StoreGroupId, int storeId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreGroupDelete {original_StoreGroupId}, {storeId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreGroupDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_StoreGroupId", DbType = "Int")] System.Nullable<int> original_StoreGroupId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), original_StoreGroupId, storeId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreGroupInsert(int storeId, byte[] objectSid, string name, string description, string lDapQuery, byte groupType)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreGroupInsert {storeId}, {objectSid}, {name}, {description}, {lDapQuery}, {groupType}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreGroupInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDapQuery", DbType = "NVarChar(4000)")] string lDapQuery, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "GroupType", DbType = "TinyInt")] System.Nullable<byte> groupType)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, objectSid, name, description, lDapQuery, groupType);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreGroupMemberDelete(int storeId, int storeGroupMemberId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreGroupMemberDelete {storeId}, {storeGroupMemberId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupMemberDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreGroupMemberDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreGroupMemberId", DbType = "Int")] System.Nullable<int> storeGroupMemberId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, storeGroupMemberId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreGroupMemberInsert(int storeId, int storeGroupId, byte[] objectSid, byte whereDefined, bool isMember)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreGroupMemberInsert {storeId}, {storeGroupId}, {objectSid}, {whereDefined}, {isMember}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupMemberInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreGroupMemberInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreGroupId", DbType = "Int")] System.Nullable<int> storeGroupId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "WhereDefined", DbType = "TinyInt")] System.Nullable<byte> whereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IsMember", DbType = "Bit")] System.Nullable<bool> isMember)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, storeGroupId, objectSid, whereDefined, isMember);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupMembers", IsComposable = true)]
        //public IQueryable<StoreGroupMembersResult> StoreGroupMembers()
        //{
        //    return this.CreateMethodCallQuery<StoreGroupMembersResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int StoreGroupMemberUpdate(int storeId, int storeGroupId, byte[] objectSid, byte whereDefined, bool isMember, int original_StoreGroupMemberId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreGroupMemberUpdate {storeId}, {storeGroupId}, {objectSid}, {whereDefined}, {isMember}, {original_StoreGroupMemberId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupMemberUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreGroupMemberUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreGroupId", DbType = "Int")] System.Nullable<int> storeGroupId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "WhereDefined", DbType = "TinyInt")] System.Nullable<byte> whereDefined, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IsMember", DbType = "Bit")] System.Nullable<bool> isMember, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_StoreGroupMemberId", DbType = "Int")] System.Nullable<int> original_StoreGroupMemberId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, storeGroupId, objectSid, whereDefined, isMember, original_StoreGroupMemberId);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroups", IsComposable = true)]
        //public IQueryable<StoreGroupsResult> StoreGroups()
        //{
        //    return this.CreateMethodCallQuery<StoreGroupsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int StoreGroupUpdate(int storeId, byte[] objectSid, string name, string description, string lDapQuery, byte groupType, int original_StoreGroupId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreGroupUpdate {storeId}, {objectSid}, {name}, {description}, {lDapQuery}, {groupType}, {original_StoreGroupId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreGroupUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreGroupUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "VarBinary(85)")] System.Data.Linq.Binary objectSid, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDapQuery", DbType = "NVarChar(4000)")] string lDapQuery, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "GroupType", DbType = "TinyInt")] System.Nullable<byte> groupType, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_StoreGroupId", DbType = "Int")] System.Nullable<int> original_StoreGroupId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, objectSid, name, description, lDapQuery, groupType, original_StoreGroupId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StoreInsert(string name, string description)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreInsert {name}, {description}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, description);
        //    return ((int)(result.ReturnValue));
        //}

        public int StorePermissionDelete(int storePermissionId, int storeId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StorePermissionDelete {storePermissionId}, {storeId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StorePermissionDelete")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StorePermissionDelete(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StorePermissionId", DbType = "Int")] System.Nullable<int> storePermissionId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storePermissionId, storeId);
        //    return ((int)(result.ReturnValue));
        //}

        public int StorePermissionInsert(int storeId, int sqlUserOrRole, bool isSqlRole, byte netSqlAzManFixedServerRole)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StorePermissionInsert {storeId}, {sqlUserOrRole}, {isSqlRole}, {netSqlAzManFixedServerRole}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StorePermissionInsert")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StorePermissionInsert(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "StoreId", DbType = "Int")] System.Nullable<int> storeId, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "SqlUserOrRole", DbType = "NVarChar(128)")] string sqlUserOrRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "IsSqlRole", DbType = "Bit")] System.Nullable<bool> isSqlRole, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NetSqlAzManFixedServerRole", DbType = "TinyInt")] System.Nullable<byte> netSqlAzManFixedServerRole)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), storeId, sqlUserOrRole, isSqlRole, netSqlAzManFixedServerRole);
        //    return ((int)(result.ReturnValue));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StorePermissions", IsComposable = true)]
        //public IQueryable<StorePermissionsResult> StorePermissions()
        //{
        //    return this.CreateMethodCallQuery<StorePermissionsResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_Stores", IsComposable = true)]
        //public IQueryable<StoresResult> Stores()
        //{
        //    return this.CreateMethodCallQuery<StoresResult>(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
        //}

        public int StoreUpdate(string name, string description, int original_StoreId)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_StoreUpdate {name}, {description}, {original_StoreId}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_StoreUpdate")]
        //[return: global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")]
        //public int StoreUpdate(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Name", DbType = "NVarChar(255)")] string name, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Description", DbType = "NVarChar(1024)")] string description, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "Original_StoreId", DbType = "Int")] System.Nullable<int> original_StoreId)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, description, original_StoreId);
        //    return ((int)(result.ReturnValue));
        //}

        public int CheckAccess(int iTEMID, byte[] uSERSID, DateTime vALIDFOR, string lDAPPATH, byte aUTHORIZATION_TYPE, bool nETSQLAZMANMODE, bool rETRIEVEATTRIBUTES)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_CheckAccess {iTEMID}, {uSERSID}, {vALIDFOR}, {lDAPPATH}, {aUTHORIZATION_TYPE}, {nETSQLAZMANMODE}, {rETRIEVEATTRIBUTES}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_CheckAccess")]
        //public int CheckAccess(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "ITEMID", DbType = "Int")] System.Nullable<int> iTEMID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "USERSID", DbType = "VarBinary(85)")] System.Data.Linq.Binary uSERSID, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "VALIDFOR", DbType = "DateTime")] System.Nullable<System.DateTime> vALIDFOR, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDAPPATH", DbType = "NVarChar(4000)")] string lDAPPATH, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "AUTHORIZATION_TYPE", DbType = "TinyInt")] ref System.Nullable<byte> aUTHORIZATION_TYPE, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "NETSQLAZMANMODE", DbType = "Bit")] System.Nullable<bool> nETSQLAZMANMODE, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "RETRIEVEATTRIBUTES", DbType = "Bit")] System.Nullable<bool> rETRIEVEATTRIBUTES)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), iTEMID, uSERSID, vALIDFOR, lDAPPATH, aUTHORIZATION_TYPE, nETSQLAZMANMODE, rETRIEVEATTRIBUTES);
        //    aUTHORIZATION_TYPE = ((System.Nullable<byte>)(result.GetParameterValue(4)));
        //    return ((int)(result.ReturnValue));
        //}

        public int helplogins(string rolename)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_helplogins {rolename}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_helplogins")]
        //public int helplogins(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "NVarChar(128)")] string rolename)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), rolename);
        //    return ((int)(result.ReturnValue));
        //}

        public int ExecuteLDAPQuery(string lDAPPATH, string lDAPQUERY, int members_cur)
        {
            var result = this.Database.ExecuteSqlInterpolated(
                $"EXEC dbo.netsqlazman_ExecuteLDAPQuery {lDAPQUERY}, {lDAPPATH}, {members_cur}"
            );

            return result;
        }

        //[global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.netsqlazman_ExecuteLDAPQuery")]
        //public int ExecuteLDAPQuery(
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDAPPATH", DbType = "NVarChar(4000)")] string lDAPPATH, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "LDAPQUERY", DbType = "NVarChar(4000)")] string lDAPQUERY, 
        //    [global::System.Data.Linq.Mapping.ParameterAttribute(DbType = "Int")] ref System.Nullable<int> members_cur)
        //{
        //    IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), lDAPPATH, lDAPQUERY, members_cur);
        //    members_cur = ((System.Nullable<int>)(result.GetParameterValue(2)));
        //    return ((int)(result.ReturnValue));
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDbFunction(typeof(NetSqlAzManStorageContext)
            //    .GetMethod(nameof(netsqlazman_CheckApplicationPermissions), new Type[] { typeof(int), typeof(byte) }))
            //    .HasName("netsqlazman_CheckApplicationPermissions")
            //    .HasSchema("dbo");
            //modelBuilder.HasDbFunction(typeof(NetSqlAzManStorageContext)
            //    .GetMethod(nameof(netsqlazman_CheckStorePermissions), new Type[] { typeof(int), typeof(byte) }))
            //    .HasName("netsqlazman_CheckStorePermissions");
            //modelBuilder.HasDbFunction(typeof(NetSqlAzManStorageContext)
            //    .GetMethod(nameof(netsqlazman_DBVersion), new Type[] { }))
            //    .HasName("netsqlazman_DBVersion");
            //modelBuilder.HasDbFunction(typeof(NetSqlAzManStorageContext)
            //    .GetMethod(nameof(netsqlazman_GetNameFromSid), new Type[] { typeof(string), typeof(string), typeof(byte[]), typeof(byte) }))
            //    .HasName("netsqlazman_GetNameFromSid");
            //modelBuilder.HasDbFunction(typeof(NetSqlAzManStorageContext)
            //    .GetMethod(nameof(netsqlazman_IAmAdmin), new Type[] { }))
            //    .HasName("netsqlazman_IAmAdmin");
            //modelBuilder.HasDbFunction(typeof(NetSqlAzManStorageContext)
            //    .GetMethod(nameof(netsqlazman_MergeAuthorizations), new Type[] { typeof(byte), typeof(byte) }))
            //    .HasName("netsqlazman_MergeAuthorizations");

            modelBuilder.Entity<CheckApplicationPermissionsResult>(e => e.HasNoKey());
            modelBuilder.Entity<IAmAdminResult>(e => e.HasNoKey());
            modelBuilder.Entity<MergeAuthorizationsResult>(e => e.HasNoKey());
            modelBuilder.Entity<GetNameFromSidResult>(e => e.HasNoKey());
            modelBuilder.Entity<CheckStorePermissionsResult>(e => e.HasNoKey());
            modelBuilder.Entity<DBVersionResult>(e => e.HasNoKey());

            // Stored procedures
            //modelBuilder.Entity<BuildUserPermissionCacheResult2>()
            //    .HasNoKey()
            //    .ToTable("netsqlazman_BuildUserPermissionCache", t => t.ExcludeFromMigrations());

            modelBuilder.Entity<BuildUserPermissionCacheResult2>()
                .HasNoKey()
                .ToTable("netsqlazman_BuildUserPermissionCache", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<GetDBUsersResult>()
                .HasNoKey()
                .ToTable("netsqlazman_GetDBUsers", t => t.ExcludeFromMigrations());
        }
    }
}
