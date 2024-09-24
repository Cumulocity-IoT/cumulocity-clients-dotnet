//
// TenantTfaStrategy.cs
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

public sealed class TenantTfaStrategy 
{

	/// <summary> 
	/// Two-factor authentication strategy. <br />
	/// </summary>
	///
	[JsonPropertyName("strategy")]
	public Strategy? PStrategy { get; set; }

	public TenantTfaStrategy() 
	{
	}

	public TenantTfaStrategy(Strategy strategy)
	{
		this.PStrategy = strategy;
	}

	/// <summary> 
	/// Two-factor authentication strategy. <br />
	/// </summary>
	///
	[JsonConverter(typeof(EnumConverterFactory))]
	public enum Strategy 
	{
		[EnumMember(Value = "SMS")]
		SMS,
		[EnumMember(Value = "TOTP")]
		TOTP
	}


	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
