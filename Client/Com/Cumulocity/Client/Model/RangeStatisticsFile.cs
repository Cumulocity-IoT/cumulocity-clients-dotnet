//
// RangeStatisticsFile.cs
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

public sealed class RangeStatisticsFile 
{

	/// <summary> 
	/// Statistics generation start date. <br />
	/// </summary>
	///
	[JsonPropertyName("dateFrom")]
	public System.DateTime? DateFrom { get; set; }

	/// <summary> 
	/// Statistics generation end date. <br />
	/// </summary>
	///
	[JsonPropertyName("dateTo")]
	public System.DateTime? DateTo { get; set; }

	public RangeStatisticsFile() 
	{
	}

	public RangeStatisticsFile(System.DateTime dateFrom, System.DateTime dateTo)
	{
		this.DateFrom = dateFrom;
		this.DateTo = dateTo;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
