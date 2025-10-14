//
// C8yPreviousMeasurements.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// The read only fragment which contains the previous to latest measurements reported by the device.The returned optionally only if the query parameter <c>withLatestValues=true</c> is used. <br />
/// ⚠️ Feature Preview: The feature is part of the Latest Measurement feature which is still under public feature preview. <br />
/// </summary>
///
public sealed class C8yPreviousMeasurements 
{

	[JsonPropertyName("additionalProperties")]
	public IDictionary<string, PreviousMeasurementFragment?> AdditionalProperties { get; set; } = new Dictionary<string, PreviousMeasurementFragment?>();
	
	[JsonIgnore]
	public PreviousMeasurementFragment? this[string key]
	{
		get => AdditionalProperties[key];
		set => AdditionalProperties[key] = value;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
