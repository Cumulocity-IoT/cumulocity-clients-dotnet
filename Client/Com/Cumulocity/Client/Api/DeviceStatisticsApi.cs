//
// DeviceStatisticsApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-2023 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Client.Com.Cumulocity.Client.Model;
using Client.Com.Cumulocity.Client.Supplementary;

namespace Client.Com.Cumulocity.Client.Api;

/// <summary> 
/// Device statistics are collected for each inventory object with at least one measurement, event or alarm. There are no additional checks if the inventory object is marked as device using the <c>c8y_IsDevice</c> fragment. When the first measurement, event or alarm is created for a specific inventory object, Cumulocity IoT is always considering this as a device and starts counting. <br />
/// Device statistics are counted with daily and monthy rate. All requests are considered when counting device statistics, no matter which processing mode is used. <br />
/// The following requests are counted: <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>Alarm creation and update <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Event creation and update <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Measurement creation <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Bulk measurement creation is counted as multiple requests <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>Bulk alarm status update is counted as multiple requests <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>MQTT and SmartREST requests with multiple rows are counted as multiple requests <br />
/// 		</description>
/// 	</item>
/// </list>
/// <br /> Frequently asked questions <br />
/// <br /> Are operations on device firmware counted? <br />
/// No, device configuration and firmware update operate on inventory objects, hence they are not counted. <br />
/// <br /> Are requests done by the UI applications, for example, when browsing device details, counted? <br />
/// No, viewing device details performs only GET requests which are not counted. <br />
/// <br /> Is the clear alarm operation done from the UI counted? <br />
/// Yes, a clear alarm operation in fact performs an alarm update operation and it will be counted as device request. <br />
/// <br /> Is there any operation performed on the device which is counted? <br />
/// Yes, retrieving device logs requires from the device to create an event and attach a binary with logs to it. Those are two separate requests and both are counted. <br />
/// <br /> When I have a device with children are the requests counted always to the root device or separately for each child? <br />
/// Separately for each child. <br />
/// <br /> Why do device statistics show significantly smaller request numbers than the total number of created and updated request from usage statistics? <br />
/// The important aspect here is the moment of recording values for the counters. For inbound data usage statistics we count every request that passed authorization, including invalid requests, as stated in usage statistics description. <br />
/// For device statistics it is different. We count requests after data is successfully stored in the database (or transient), which means the request was valid and there was no problem with persistence. <br />
/// In summary, if you observe that your usage statistics counters are significantly larger than your device statistics counters, there is a good chance that some devices or microservices in your tenant are constantly sending invalid requests. In such a situation, the client should check the state of theirs tenant. <br />
/// </summary>
///
public sealed class DeviceStatisticsApi : IDeviceStatisticsApi
{
	private readonly HttpClient _httpClient;

	public DeviceStatisticsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<DeviceStatisticsCollection?> GetMonthlyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"tenant/statistics/device/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/monthly/{HttpUtility.UrlPathEncode(date.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("deviceId", deviceId);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<DeviceStatisticsCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<DeviceStatisticsCollection?> GetDailyDeviceStatistics(string tenantId, System.DateTime date, int? currentPage = null, string? deviceId = null, int? pageSize = null, bool? withTotalPages = null, CancellationToken cToken = default) 
	{
		string resourcePath = $"tenant/statistics/device/{HttpUtility.UrlPathEncode(tenantId.GetStringValue())}/daily/{HttpUtility.UrlPathEncode(date.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("deviceId", deviceId);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<DeviceStatisticsCollection?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
}
