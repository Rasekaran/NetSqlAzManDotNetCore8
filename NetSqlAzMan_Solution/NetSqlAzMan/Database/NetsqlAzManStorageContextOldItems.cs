using System.Runtime.Serialization;
using System.Security;

namespace NetSqlAzMan.Database
{
    using System;
    using System.Data.SqlTypes;

    public partial class BuildUserPermissionCacheResult1
    {

        private string _ItemName;

        private string _ParentItemName;

        public BuildUserPermissionCacheResult1()
        {
        }
        public string ItemName
        {
            get
            {
                return this._ItemName;
            }
            set
            {
                if ((this._ItemName != value))
                {
                    this._ItemName = value;
                }
            }
        }
        public string ParentItemName
        {
            get
            {
                return this._ParentItemName;
            }
            set
            {
                if ((this._ParentItemName != value))
                {
                    this._ParentItemName = value;
                }
            }
        }
    }
    public partial class BuildUserPermissionCacheResult2
    {

        private string _ItemName;

        private System.Nullable<System.DateTime> _ValidFrom;

        private System.Nullable<System.DateTime> _ValidTo;

        public BuildUserPermissionCacheResult2()
        {
        }
        public string ItemName
        {
            get
            {
                return this._ItemName;
            }
            set
            {
                if ((this._ItemName != value))
                {
                    this._ItemName = value;
                }
            }
        }

        public System.Nullable<System.DateTime> ValidFrom
        {
            get
            {
                return this._ValidFrom;
            }
            set
            {
                if ((this._ValidFrom != value))
                {
                    this._ValidFrom = value;
                }
            }
        }
        public System.Nullable<System.DateTime> ValidTo
        {
            get
            {
                return this._ValidTo;
            }
            set
            {
                if ((this._ValidTo != value))
                {
                    this._ValidTo = value;
                }
            }
        }
    }

    [Serializable()]
    public partial class BuildUserPermissionCacheResult2 : ISerializable
    {
        #region ISerializable Members

        /// <summary>
        /// Initializes a new instance of the <see cref="BuildUserPermissionCacheResult2"/> class.
        /// </summary>
        /// <param name="info">The info.</param>
        /// <param name="context">The context.</param>
        public BuildUserPermissionCacheResult2(SerializationInfo info, StreamingContext context)
        {
            this._ItemName = info.GetString("_ItemName");
            this._ValidFrom = (System.Nullable<System.DateTime>)info.GetValue("_ValidFrom", typeof(System.Nullable<System.DateTime>));
            this._ValidTo = (System.Nullable<System.DateTime>)info.GetValue("_ValidTo", typeof(System.Nullable<System.DateTime>));
        }

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data needed to serialize the target object.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
        /// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
        /// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
        [SecurityCritical()]
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("_ItemName", this._ItemName);
            info.AddValue("_ValidFrom", this._ValidFrom);
            info.AddValue("_ValidTo", this._ValidTo);
        }

        #endregion
    }

    public partial class GetDBUsersResult
    {

        private byte[] _DBUserSid;

        private string _DBUserName;

        public GetDBUsersResult()
        {
        }

        public byte[] DBUserSid
        {
            get
            {
                return this._DBUserSid;
            }
            set
            {
                if ((this._DBUserSid != value))
                {
                    this._DBUserSid = value;
                }
            }
        }

        public string DBUserName
        {
            get
            {
                return this._DBUserName;
            }
            set
            {
                if ((this._DBUserName != value))
                {
                    this._DBUserName = value;
                }
            }
        }
    }
}
