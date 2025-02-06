//
// C8yAvailability.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The availability information computed by Cumulocity is stored in fragments <c>c8y_Availability</c> of the device. <br />
/// </summary>
///
public sealed class C8yAvailability 
{

	/// <summary> 
	/// The current status of availability, one of <c>AVAILABLE</c>, <c>UNAVAILABLE</c>, <c>MAINTENANCE</c>. <br />
	/// </summary>
	///
	[JsonPropertyName("status")]
	public C8yAvailabilityDataStatus? Status { get; set; }

	/// <summary> 
	/// The time when the device sent the last message to Cumulocity. <br />
	/// </summary>
	///
	[JsonPropertyName("lastMessage")]
	public System.DateTime? LastMessage { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
