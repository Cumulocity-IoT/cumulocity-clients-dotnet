//
// FeatureToggle.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;
using Client.Com.Cumulocity.Client.Converter;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Model;

public sealed class FeatureToggle 
{

	/// <summary> 
	/// A unique key of the feature toggle. <br />
	/// </summary>
	///
	[JsonPropertyName("key")]
	public string? Key { get; set; }

	/// <summary> 
	/// Current phase of feature toggle rollout. <br />
	/// </summary>
	///
	[JsonPropertyName("phase")]
	public Phase? PPhase { get; set; }

	/// <summary> 
	/// Current value of the feature toggle marking whether the feature is active or not. <br />
	/// </summary>
	///
	[JsonPropertyName("active")]
	public bool? Active { get; set; }

	/// <summary> 
	/// The source of the feature toggle value - either it's feature toggle definition provided default, or per tenant provided override. <br />
	/// </summary>
	///
	[JsonPropertyName("strategy")]
	public Strategy? PStrategy { get; set; }

	/// <summary> 
	/// Current phase of feature toggle rollout. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Phase 
	{
		[EnumMember(Value = "IN_DEVELOPMENT")]
		INDEVELOPMENT,
		[EnumMember(Value = "PRIVATE_PREVIEW")]
		PRIVATEPREVIEW,
		[EnumMember(Value = "PUBLIC_PREVIEW")]
		PUBLICPREVIEW,
		[EnumMember(Value = "GENERALLY_AVAILABLE")]
		GENERALLYAVAILABLE
	}

	/// <summary> 
	/// The source of the feature toggle value - either it's feature toggle definition provided default, or per tenant provided override. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Strategy 
	{
		[EnumMember(Value = "DEFAULT")]
		DEFAULT,
		[EnumMember(Value = "TENANT")]
		TENANT
	}



	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
