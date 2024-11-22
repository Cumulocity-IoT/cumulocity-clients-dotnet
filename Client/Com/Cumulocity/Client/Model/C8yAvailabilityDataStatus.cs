//
// C8yAvailabilityDataStatus.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using Client.Com.Cumulocity.Client.Converter;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The current status of availability, one of <c>AVAILABLE</c>, <c>UNAVAILABLE</c>, <c>MAINTENANCE</c>. <br />
/// </summary>
///
[JsonConverter(typeof(EnumConverterFactory))]
public enum C8yAvailabilityDataStatus 
{
	[EnumMember(Value = "AVAILABLE")]
	AVAILABLE,
	[EnumMember(Value = "MAINTENANCE")]
	MAINTENANCE,
	[EnumMember(Value = "UNAVAILABLE")]
	UNAVAILABLE
}
