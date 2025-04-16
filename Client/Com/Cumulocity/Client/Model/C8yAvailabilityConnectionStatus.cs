//
// C8yAvailabilityConnectionStatus.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
//

using Client.Com.Cumulocity.Client.Converter;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The current status of connection, one of <c>CONNECTED</c>, <c>DISCONNECTED</c>, <c>MAINTENANCE</c>. <br />
/// </summary>
///
[JsonConverter(typeof(EnumConverterFactory))]
public enum C8yAvailabilityConnectionStatus 
{
	[EnumMember(Value = "CONNECTED")]
	CONNECTED,
	[EnumMember(Value = "DISCONNECTED")]
	DISCONNECTED,
	[EnumMember(Value = "MAINTENANCE")]
	MAINTENANCE
}
