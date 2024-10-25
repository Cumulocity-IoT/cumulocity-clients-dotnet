//
// IFeatureTogglesApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Api;

public interface IFeatureTogglesApi
{

	/// <summary> 
	/// Retrieve list of feature toggles with values for current tenant. <br />
	/// Retrieve a list of all defined feature toggles with values calculated for a tenant of authenticated user. <br />
	/// 
	/// <br /> Required roles <br />
	///  none, any authenticated user can call this endpoint 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggles are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<List<FeatureToggle>?> ListCurrentTenantFeatures(CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve a specific feature toggle with value for current tenant. <br />
	/// Retrieve a specific feature toggles defined under given key, with value calculated for a tenant of authenticated user. <br />
	/// 
	/// <br /> Required roles <br />
	///  none, any authenticated user can call this endpoint 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggle is sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="featureKey">A unique key of the feature toggle. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<FeatureToggle?> GetCurrentTenantFeature(string featureKey, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Retrieve list of feature toggles values overrides of all tenants. <br />
	/// Retrieve a list of all existing feature toggle value overrides for all tenants. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_TENANT_MANAGEMENT_ADMIN AND current tenant is management 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggles are sent in the response. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="featureKey">A unique key of the feature toggle. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<List<TenantFeatureToggleValue>?> ListTenantFeatureToggleValues(string featureKey, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Sets the value of feature toggle override for the current tenant. <br />
	/// Sets the value of feature toggle override for a tenant of authenticated user. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_TENANT_MANAGEMENT_ADMIN AND (current tenant is management OR the feature toggle phase is PUBLIC_PREVIEW or GENERALLY_AVAILABLE) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggle value override was set. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="featureKey">A unique key of the feature toggle. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> SetCurrentTenantFeatureToggleValue(FeatureToggleValue body, string featureKey, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Removes the feature toggle override for the current tenant. <br />
	/// Removes the feature toggle override for a tenant of authenticated user. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_TENANT_MANAGEMENT_ADMIN AND (current tenant is management OR the feature toggle phase is PUBLIC_PREVIEW or GENERALLY_AVAILABLE) 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggle value override was removed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="featureKey">A unique key of the feature toggle. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> UnsetCurrentTenantFeatureToggleValue(string featureKey, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Sets the value of feature toggle override for a given tenant. <br />
	/// Sets the value of feature toggle override for a given tenant. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_TENANT_MANAGEMENT_ADMIN AND current tenant is management. 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggle value override was set. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="featureKey">A unique key of the feature toggle. <br /></param>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> SetGivenTenantFeatureToggleValue(FeatureToggleValue body, string featureKey, string tenantId, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Removes the feature toggle override for a given tenant. <br />
	/// Removes the feature toggle override for a given tenant. <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_TENANT_MANAGEMENT_ADMIN AND current tenant is management. 
	/// 
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 200 The request has succeeded and the feature toggle value override was removed. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not authorized to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Managed object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="featureKey">A unique key of the feature toggle. <br /></param>
	/// <param name="tenantId">Unique identifier of a Cumulocity IoT tenant. <br /></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string?> UnsetGivenTenantFeatureToggleValue(string featureKey, string tenantId, CancellationToken cToken = default) ;
}
