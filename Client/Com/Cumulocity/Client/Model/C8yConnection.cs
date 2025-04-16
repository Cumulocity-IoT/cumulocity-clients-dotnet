//
// C8yConnection.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The connection information computed by Cumulocity is stored in fragments <c>c8y_Connection</c> of the device. <br />
/// </summary>
///
public sealed class C8yConnection 
{

	/// <summary> 
	/// The current status of connection, one of <c>CONNECTED</c>, <c>DISCONNECTED</c>, <c>MAINTENANCE</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("status")]
	public C8yAvailabilityConnectionStatus? Status { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
