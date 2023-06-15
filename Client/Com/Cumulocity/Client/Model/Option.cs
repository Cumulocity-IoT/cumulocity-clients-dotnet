//
// Option.cs
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
/// A tuple storing tenant configuration. <br />
/// </summary>
///
public sealed class Option 
{

	/// <summary> 
	/// Name of the option category. <br />
	/// </summary>
	///
	[JsonPropertyName("category")]
	public string? Category { get; set; }

	/// <summary> 
	/// A unique identifier for this option. <br />
	/// </summary>
	///
	[JsonPropertyName("key")]
	public string? Key { get; set; }

	/// <summary> 
	/// Value of this option. <br />
	/// </summary>
	///
	[JsonPropertyName("value")]
	public string? Value { get; set; }

	/// <summary> 
	/// A URL linking to this resource. <br />
	/// </summary>
	///
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
