//
// PreviousMeasurementFragment.cs
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
/// The read only fragment which contains the previous to latest measurements series reported by the device. <br />
/// ⚠️ Feature Preview: The feature is part of the Latest Measurement feature which is still under public feature preview. <br />
/// </summary>
///
public sealed class PreviousMeasurementFragment 
{

	[JsonPropertyName("additionalProperties")]
	public IDictionary<string, PreviousMeasurementValue?> AdditionalProperties { get; set; } = new Dictionary<string, PreviousMeasurementValue?>();
	
	[JsonIgnore]
	public PreviousMeasurementValue? this[string key]
	{
		get => AdditionalProperties[key];
		set => AdditionalProperties[key] = value;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
