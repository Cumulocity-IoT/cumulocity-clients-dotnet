//
// ManagedObjectAvailability.cs
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

public sealed class ManagedObjectAvailability 
{

	/// <summary> 
	/// Identifier of the target device. <br />
	/// </summary>
	///
	[JsonPropertyName("deviceId")]
	public string? DeviceId { get; set; }

	/// <summary> 
	/// The identifier used in the external system that Cumulocity interfaces with. <br />
	/// </summary>
	///
	[JsonPropertyName("externalId")]
	public string? ExternalId { get; set; }

	/// <summary> 
	/// The time when the device sent the last message to Cumulocity. <br />
	/// </summary>
	///
	[JsonPropertyName("lastMessage")]
	public System.DateTime? LastMessage { get; set; }

	/// <summary> 
	/// Required interval of monitored device <br />
	/// </summary>
	///
	[JsonPropertyName("interval")]
	public int? Interval { get; set; }

	/// <summary> 
	/// The current status of availability, one of <c>AVAILABLE</c>, <c>UNAVAILABLE</c>, <c>MAINTENANCE</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("dataStatus")]
	public C8yAvailabilityDataStatus? DataStatus { get; set; }

	/// <summary> 
	/// The current status of connection, one of <c>CONNECTED</c>, <c>DISCONNECTED</c>, <c>MAINTENANCE</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("connectionStatus")]
	public C8yAvailabilityConnectionStatus? ConnectionStatus { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
