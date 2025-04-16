//
// SupportedMeasurements.cs
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

public sealed class SupportedMeasurements 
{

	/// <summary> 
	/// An array containing all supported measurements of the specified managed object. <br />
	/// </summary>
	///
	[JsonPropertyName("c8y_SupportedMeasurements")]
	public List<string> C8ySupportedMeasurements { get; set; } = new List<string>();

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
