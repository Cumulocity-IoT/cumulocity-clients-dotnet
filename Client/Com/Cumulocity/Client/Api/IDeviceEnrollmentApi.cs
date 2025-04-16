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
/// Device enroll API to be used by a device to get a fresh new certificate. The device has to authenticate itself using its identifier and security token as the BasicAuth realm, user and password respectively. The tenant, identifier and security token must be shared with Cumulocity using the <see href="#tag/New-device-requests" langword="New-device-requests" /> onboarding endpoint to set the security token for a device.Device re-enroll API to be used by a device to renew its certificate or replace its certificate with its current credentials (being a password or a JWT token). <br />
/// </summary>
///
public interface IDeviceEnrollmentApi
{

	/// <summary> 
	/// Create Device certificate which is signed by tenant's Certificate Authority(CA) <br />
	/// Enable bulk device registration to the enrollment list through the existing <see href="#tag/New-device-requests" langword="New-device-requests" /> endpoint.To support the new enrollment process, each device record must specify both a secret and a certificate as the authentication type.These EST devices will be added to the NewDeviceRegistration list with a status of Accepted.The ID and CREDENTIALS fields will be mapped to deviceId and security token, respectively, in the NewDeviceRegistrationData model, serving as temporary device credentials for authentication. <br />
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
	/// Enable bulk device registration to the enrollment list through the existing <c>/devicecontrol/newDeviceRequests</c> endpoint.To support the new enrollment process, each device record must specify both a secret and a certificate as the authentication type.These EST devices will be added to the NewDeviceRegistration list with a status of Accepted.The ID and CREDENTIALS fields will be mapped to deviceId and security token, respectively, in the NewDeviceRegistrationData model, serving as temporary device credentials for authentication. <br />
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
