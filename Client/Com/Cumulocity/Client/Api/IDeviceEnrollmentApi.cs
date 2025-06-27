//
// IDeviceEnrollmentApi.cs
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
/// Device enroll API to be used by a device to issue an X509 certificate signed by tenant's <see href="#operation/postBulkNewDeviceRequestCollectionResource" langword="certificate authority" />. The identifier and enrollment OTP for a device must be first shared as a pre-shared-key (PSK) with Cumulocity using the <see href="#operation/postBulkNewDeviceRequestCollectionResource" langword="bulkNewDeviceRequests" /> endpoint or <see href="#operation/postNewDeviceRequestCollectionResource" langword="NewDeviceRequests" /> endpoint for certificate provisioning. Internally, ID and ENROLLMENT_OTP fields will be added to the NewDeviceRegistration list with a status of Accepted, serving as temporary device credentials for device authentication. <br />
/// Device re-enroll API to be used by a device to renew its certificate or replace its certificate with its current credentials (being a password or a JWT token). <br />
/// </summary>
///
public interface IDeviceEnrollmentApi
{

	/// <summary> 
	/// Create Device certificate which is signed by tenant's Certificate Authority(CA) <br />
	/// A device already registered for certificate provisioning by sharing <c>PSK</c>(as mentioned above) can request for a new X509 certificateusing the PSK as basic auth realm, along with a Certificate Sigining Request (CSR) using enroll API. Upon successfull validation andcertificate generation, a certificate in <c>PKCS#7</c> will be returned. <br />
	/// ⚠️ Important: CSR must be a valid <c>PKCS#10</c> with deviceID as Common Name (CN). <br />
	/// ⓘ Info: CSR request with <c>CA:TRUE</c> constraint is not supported. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 A device certificate was created. <br /> <br />
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
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<string> SimpleEnrollDevice(byte[] body, CancellationToken cToken = default) ;
	
	/// <summary> 
	/// Re-Issue certificates to Devices which is signed by tenant's Certificate Authority(CA) <br />
	/// 
	/// <br /> Required roles <br />
	///  ROLE_DEVICE 
	/// 
	/// A device using existing authentication mechanism (Basic or JWT) along with a Certificate Sigining Request, can request re-issue using reenroll API.Upon successfull validation and certificate generation, a certificate in <c>PKCS#7</c> will be returned. <br />
	/// ⚠️ Important: CSR must be a valid <c>PKCS#10</c> with deviceID as Common Name (CN). <br />
	/// ⓘ Info: CSR request with <c>CA:TRUE</c> constraint is not supported. <br />
	/// <br /> Response Codes <br />
	/// The following table gives an overview of the possible response codes and their meanings: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>HTTP 201 A device certificate was created. <br /> <br />
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
	/// </list>
	/// </summary>
	/// <param name="body"></param>
	/// <param name="cToken">Propagates notification that operations should be canceled. <br /></param>
	///
	Task<byte[]> SimpleReEnrollDevice(byte[] body, CancellationToken cToken = default) ;
}
