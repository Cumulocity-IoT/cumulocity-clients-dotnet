//
// C8yAccelerationMeasurement.cs
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
/// Measurement of the acceleration sensor. <br />
/// </summary>
///
public sealed class C8yAccelerationMeasurement 
{

	/// <summary> 
	/// A measurement is a value with a unit. <br />
	/// </summary>
	///
	[JsonPropertyName("acceleration")]
	public C8yMeasurementValue? Acceleration { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
