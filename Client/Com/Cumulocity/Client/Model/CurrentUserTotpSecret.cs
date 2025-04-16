//
// CurrentUserTotpSecret.cs
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

public sealed class CurrentUserTotpSecret 
{

	/// <summary> 
	/// Secret used by two-factor authentication applications to generate the TFA codes. <br />
	/// </summary>
	///
	[JsonPropertyName("rawSecret")]
	public string? RawSecret { get; set; }

	/// <summary> 
	/// URL used to set the two-factor authentication secret for the TFA application. <br />
	/// </summary>
	///
	[JsonPropertyName("secretQrUrl")]
	public string? SecretQrUrl { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
