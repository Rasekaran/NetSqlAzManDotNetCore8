﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetSqlAzMan_WinTest.sr {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ItemType", Namespace="http://NetSqlAzMan/ServiceModel")]
    public enum ItemType : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Role = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Task = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Operation = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthorizationType", Namespace="http://NetSqlAzMan/ServiceModel")]
    public enum AuthorizationType : byte {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Neutral = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Allow = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deny = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AllowWithDelegation = 3,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthorizedItem", Namespace="http://schemas.datacontract.org/2004/07/NetSqlAzMan.Cache")]
    [System.SerializableAttribute()]
    public partial class AuthorizedItem : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.KeyValuePair<string, string>[] AttributesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NetSqlAzMan_WinTest.sr.AuthorizationType AuthorizationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NetSqlAzMan_WinTest.sr.ItemType TypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.KeyValuePair<string, string>[] Attributes {
            get {
                return this.AttributesField;
            }
            set {
                if ((object.ReferenceEquals(this.AttributesField, value) != true)) {
                    this.AttributesField = value;
                    this.RaisePropertyChanged("Attributes");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NetSqlAzMan_WinTest.sr.AuthorizationType Authorization {
            get {
                return this.AuthorizationField;
            }
            set {
                if ((this.AuthorizationField.Equals(value) != true)) {
                    this.AuthorizationField = value;
                    this.RaisePropertyChanged("Authorization");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NetSqlAzMan_WinTest.sr.ItemType Type {
            get {
                return this.TypeField;
            }
            set {
                if ((this.TypeField.Equals(value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="sr.ICacheService")]
    public interface ICacheService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithAttributesRetrieve" +
            "", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithAttributesRetrieve" +
            "Response")]
        NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForWindowsUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithoutAttributesRetri" +
            "eve", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithoutAttributesRetri" +
            "eveResponse")]
        NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForWindowsUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithAttributesRetriev" +
            "e", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithAttributesRetriev" +
            "eResponse")]
        NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForDatabaseUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithoutAttributesRetr" +
            "ieve", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithoutAttributesRetr" +
            "ieveResponse")]
        NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForDatabaseUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/InvalidateCache", ReplyAction="http://tempuri.org/ICacheService/InvalidateCacheResponse")]
        void InvalidateCache();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/InvalidateCacheOnServicePartners", ReplyAction="http://tempuri.org/ICacheService/InvalidateCacheOnServicePartnersResponse")]
        void InvalidateCacheOnServicePartners([System.ServiceModel.MessageParameterAttribute(Name="invalidateCacheOnServicePartners")] bool invalidateCacheOnServicePartners1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetItemNames", ReplyAction="http://tempuri.org/ICacheService/GetItemNamesResponse")]
        string[] GetItemNames(string storeName, string applicationName, NetSqlAzMan_WinTest.sr.ItemType type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetAllItems", ReplyAction="http://tempuri.org/ICacheService/GetAllItemsResponse")]
        System.Collections.Generic.KeyValuePair<string, NetSqlAzMan_WinTest.sr.ItemType>[] GetAllItems(string storeName, string applicationName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetAuthorizedItemsForDatabaseUsers", ReplyAction="http://tempuri.org/ICacheService/GetAuthorizedItemsForDatabaseUsersResponse")]
        NetSqlAzMan_WinTest.sr.AuthorizedItem[] GetAuthorizedItemsForDatabaseUsers(string storeName, string applicationName, string DBuserSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetAuthorizedItemsForWindowsUsers", ReplyAction="http://tempuri.org/ICacheService/GetAuthorizedItemsForWindowsUsersResponse")]
        NetSqlAzMan_WinTest.sr.AuthorizedItem[] GetAuthorizedItemsForWindowsUsers(string storeName, string applicationName, string userSSid, string[] groupsSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICacheServiceChannel : NetSqlAzMan_WinTest.sr.ICacheService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CacheServiceClient : System.ServiceModel.ClientBase<NetSqlAzMan_WinTest.sr.ICacheService>, NetSqlAzMan_WinTest.sr.ICacheService {
        
        public CacheServiceClient() {
        }
        
        public CacheServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CacheServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CacheServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CacheServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForWindowsUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForWindowsUsersWithAttributesRetrieve(out attributes, storeName, applicationName, itemName, userSSid, groupsSSid, validFor, operationsOnly, contextParameters);
        }
        
        public NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForWindowsUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForWindowsUsersWithoutAttributesRetrieve(storeName, applicationName, itemName, userSSid, groupsSSid, validFor, operationsOnly, contextParameters);
        }
        
        public NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForDatabaseUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForDatabaseUsersWithAttributesRetrieve(out attributes, storeName, applicationName, itemName, DBuserSSid, validFor, operationsOnly, contextParameters);
        }
        
        public NetSqlAzMan_WinTest.sr.AuthorizationType CheckAccessForDatabaseUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForDatabaseUsersWithoutAttributesRetrieve(storeName, applicationName, itemName, DBuserSSid, validFor, operationsOnly, contextParameters);
        }
        
        public void InvalidateCache() {
            base.Channel.InvalidateCache();
        }
        
        public void InvalidateCacheOnServicePartners(bool invalidateCacheOnServicePartners1) {
            base.Channel.InvalidateCacheOnServicePartners(invalidateCacheOnServicePartners1);
        }
        
        public string[] GetItemNames(string storeName, string applicationName, NetSqlAzMan_WinTest.sr.ItemType type) {
            return base.Channel.GetItemNames(storeName, applicationName, type);
        }
        
        public System.Collections.Generic.KeyValuePair<string, NetSqlAzMan_WinTest.sr.ItemType>[] GetAllItems(string storeName, string applicationName) {
            return base.Channel.GetAllItems(storeName, applicationName);
        }
        
        public NetSqlAzMan_WinTest.sr.AuthorizedItem[] GetAuthorizedItemsForDatabaseUsers(string storeName, string applicationName, string DBuserSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.GetAuthorizedItemsForDatabaseUsers(storeName, applicationName, DBuserSSid, validFor, contextParameters);
        }
        
        public NetSqlAzMan_WinTest.sr.AuthorizedItem[] GetAuthorizedItemsForWindowsUsers(string storeName, string applicationName, string userSSid, string[] groupsSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.GetAuthorizedItemsForWindowsUsers(storeName, applicationName, userSSid, groupsSSid, validFor, contextParameters);
        }
    }
}
