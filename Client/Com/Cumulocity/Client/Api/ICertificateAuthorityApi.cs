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
	/// Create a key pair and self-sign a certificate with <tenantID> as the Common Name (CN).Store the private key in an encrypted tenant option.Store the certificate in the trusted certificate repository with auto-registration unchecked by default. The devices can be registered automatically only when device administrator checks this option ON.If the CA certificate is removed from the trusted certificate list, corresponding public and private key removed automatically from the database collection.If a CA is already present, return a message indicating the CA is already present. <br />
	/// ⚠️ Important: Note that it is possible to call this endpoint without the ROLE_TENANT_MANAGEMENT_ADMIN or ROLE_TENANT_MANAGEMENT_READ role, but only when user is a service user. Otherwise, if the the user does not have the required role, an HTTP response 403 will be returned.<section><h5>Required roles</h5>ROLE_TENANT_MANAGEMENT_ADMINROLE_TENANT_MANAGEMENT_READ</section> <br />
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
	/// 		<description>HTTP 404 Tenant not found. <br /> <br />
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
}
