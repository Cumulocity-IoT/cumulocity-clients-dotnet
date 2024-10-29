//
// ApplicationVersionTag.cs
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

public sealed class ApplicationVersionTag 
{

	/// <summary> 
	/// Tag assigned to the version. Version tags must be unique across all versions and version fields of application versions. <br />
	/// </summary>
	///
	[JsonPropertyName("tags")]
	public List<string> Tags { get; set; } = new List<string>();

	public ApplicationVersionTag() 
	{
	}

	public ApplicationVersionTag(List<string> tags)
	{
		this.Tags = tags;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
