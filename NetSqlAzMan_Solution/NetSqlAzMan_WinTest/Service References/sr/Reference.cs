﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4016
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetSqlAzMan_WinTest.sr {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="sr.ICacheService")]
    public interface ICacheService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithAttributesRetrieve" +
            "", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithAttributesRetrieve" +
            "Response")]
        NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForWindowsUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithoutAttributesRetri" +
            "eve", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForWindowsUsersWithoutAttributesRetri" +
            "eveResponse")]
        NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForWindowsUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithAttributesRetriev" +
            "e", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithAttributesRetriev" +
            "eResponse")]
        NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForDatabaseUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithoutAttributesRetr" +
            "ieve", ReplyAction="http://tempuri.org/ICacheService/CheckAccessForDatabaseUsersWithoutAttributesRetr" +
            "ieveResponse")]
        NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForDatabaseUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/InvalidateCache", ReplyAction="http://tempuri.org/ICacheService/InvalidateCacheResponse")]
        void InvalidateCache();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/InvalidateCacheOnServicePartners", ReplyAction="http://tempuri.org/ICacheService/InvalidateCacheOnServicePartnersResponse")]
        void InvalidateCacheOnServicePartners([System.ServiceModel.MessageParameterAttribute(Name="invalidateCacheOnServicePartners")] bool invalidateCacheOnServicePartners1);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetItemNames", ReplyAction="http://tempuri.org/ICacheService/GetItemNamesResponse")]
        string[] GetItemNames(string storeName, string applicationName, NetSqlAzMan.Interfaces.ItemType type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetAllItems", ReplyAction="http://tempuri.org/ICacheService/GetAllItemsResponse")]
        System.Collections.Generic.KeyValuePair<string, NetSqlAzMan.Interfaces.ItemType>[] GetAllItems(string storeName, string applicationName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetAuthorizedItemsForDatabaseUsers", ReplyAction="http://tempuri.org/ICacheService/GetAuthorizedItemsForDatabaseUsersResponse")]
        NetSqlAzMan.Cache.AuthorizedItem[] GetAuthorizedItemsForDatabaseUsers(string storeName, string applicationName, string DBuserSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICacheService/GetAuthorizedItemsForWindowsUsers", ReplyAction="http://tempuri.org/ICacheService/GetAuthorizedItemsForWindowsUsersResponse")]
        NetSqlAzMan.Cache.AuthorizedItem[] GetAuthorizedItemsForWindowsUsers(string storeName, string applicationName, string userSSid, string[] groupsSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICacheServiceChannel : NetSqlAzMan_WinTest.sr.ICacheService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
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
        
        public NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForWindowsUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForWindowsUsersWithAttributesRetrieve(out attributes, storeName, applicationName, itemName, userSSid, groupsSSid, validFor, operationsOnly, contextParameters);
        }
        
        public NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForWindowsUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string userSSid, string[] groupsSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForWindowsUsersWithoutAttributesRetrieve(storeName, applicationName, itemName, userSSid, groupsSSid, validFor, operationsOnly, contextParameters);
        }
        
        public NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForDatabaseUsersWithAttributesRetrieve(out System.Collections.Generic.KeyValuePair<string, string>[] attributes, string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForDatabaseUsersWithAttributesRetrieve(out attributes, storeName, applicationName, itemName, DBuserSSid, validFor, operationsOnly, contextParameters);
        }
        
        public NetSqlAzMan.Interfaces.AuthorizationType CheckAccessForDatabaseUsersWithoutAttributesRetrieve(string storeName, string applicationName, string itemName, string DBuserSSid, System.DateTime validFor, bool operationsOnly, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.CheckAccessForDatabaseUsersWithoutAttributesRetrieve(storeName, applicationName, itemName, DBuserSSid, validFor, operationsOnly, contextParameters);
        }
        
        public void InvalidateCache() {
            base.Channel.InvalidateCache();
        }
        
        public void InvalidateCacheOnServicePartners(bool invalidateCacheOnServicePartners1) {
            base.Channel.InvalidateCacheOnServicePartners(invalidateCacheOnServicePartners1);
        }
        
        public string[] GetItemNames(string storeName, string applicationName, NetSqlAzMan.Interfaces.ItemType type) {
            return base.Channel.GetItemNames(storeName, applicationName, type);
        }
        
        public System.Collections.Generic.KeyValuePair<string, NetSqlAzMan.Interfaces.ItemType>[] GetAllItems(string storeName, string applicationName) {
            return base.Channel.GetAllItems(storeName, applicationName);
        }
        
        public NetSqlAzMan.Cache.AuthorizedItem[] GetAuthorizedItemsForDatabaseUsers(string storeName, string applicationName, string DBuserSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.GetAuthorizedItemsForDatabaseUsers(storeName, applicationName, DBuserSSid, validFor, contextParameters);
        }
        
        public NetSqlAzMan.Cache.AuthorizedItem[] GetAuthorizedItemsForWindowsUsers(string storeName, string applicationName, string userSSid, string[] groupsSSid, System.DateTime validFor, System.Collections.Generic.KeyValuePair<string, object>[] contextParameters) {
            return base.Channel.GetAuthorizedItemsForWindowsUsers(storeName, applicationName, userSSid, groupsSSid, validFor, contextParameters);
        }
    }
}
