//
// DevicePermissions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

/// <summary> 
/// An object with a list of the user's device permissions. <br />
/// </summary>
///
public sealed class DevicePermissions 
{

	[JsonPropertyName("additionalProperties")]
	public IDictionary<string, List<string>?> AdditionalProperties { get; set; } = new Dictionary<string, List<string>?>();
	
	[JsonIgnore]
	public List<string>? this[string key]
	{
		get => AdditionalProperties[key];
		set => AdditionalProperties[key] = value;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
