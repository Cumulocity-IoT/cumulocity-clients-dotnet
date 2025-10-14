//
// ICertificateAuthorityApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
//

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Client.Com.Cumulocity.Client.Model;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// API to create a new CA certificate for tenant in Cumulocity. <br />
/// </summary>
///
public interface ICertificateAuthorityApi
{

	/// <summary> 
	/// Create Certificate Authority(CA) for a tenant with CN as tenantID <br />
	/// Create a key pair and self-sign a certificate with <tenantID> as the Common Name (CN).Store the private key in an encrypted tenant option.Store the certificate in the trusted certificate repository with auto-registration checked by default. The devices can be registered automatically.If the CA certificate is removed from the trusted certificate list, corresponding public and private key removed automatically from the database collection.If a CA is already present, return a message indicating the CA is already present. <br />
	/// ⚠️ Important: Note that it is possible to call this endpoint without the ROLE_TENANT_MANAGEMENT_ADMIN or ROLE_TENANT_ADMIN role. Otherwise, if the the user does not have the required role, an HTTP response 403 will be returned.<section><h5>Required roles</h5>ROLE_TENANT_MANAGEMENT_ADMINROLE_TENANT_ADMIN</section> <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 The tenant's CA certificate was added to the tenant. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Tenant Certificate Authority (CA) object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 409 Duplicate – Tenant CA is already exists. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 422 Unprocessable Entity – Invalid key pair configuration. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> CreateCertificateAuthority(CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Renew Certificate Authority(CA) for a tenant with existing public and private keys. <br />
	/// Renew the Certificate Authority (CA) for a tenant using existing public and private keys.The renewal will fail if either the public or private key is missing.If no CA exists, or if the current CA has more than 18 months remaining before expiration, a message will be returned indicating that the CA is either not present or not eligible for renewal. <br />
	/// ⚠️ Important: Note that it is possible to call this endpoint without the ROLE_TENANT_MANAGEMENT_ADMIN or ROLE_TENANT_ADMIN role. Otherwise, if the the user does not have the required role, an HTTP response 403 will be returned.<section><h5>Required roles</h5>ROLE_TENANT_MANAGEMENT_ADMINROLE_TENANT_ADMIN</section> <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 The tenant's CA certificate renewed successfully. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 401 Authentication information is missing or invalid. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 403 Not enough permissions/roles to perform this operation. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>HTTP 404 Tenant Certificate Authority (CA) object not found. <br /> <br />
	/// 		</description>
	/// 	</item>
	/// </list>
	/// </summary>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<TrustedCertificate?> RenewCertificateAuthority(CancellationToken cToken = default) ;
}
