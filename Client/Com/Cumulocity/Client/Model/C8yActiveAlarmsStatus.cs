//
// C8yActiveAlarmsStatus.cs
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
/// The number of currently active and acknowledged alarms is stored in this fragment. <br />
/// </summary>
///
public sealed class C8yActiveAlarmsStatus 
{

	[JsonPropertyName("critical")]
	public int? Critical { get; set; }

	[JsonPropertyName("major")]
	public int? Major { get; set; }

	[JsonPropertyName("minor")]
	public int? Minor { get; set; }

	[JsonPropertyName("warning")]
	public int? Warning { get; set; }

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
