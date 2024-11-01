//
// AuditsApi.cs
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
/// An audit log stores events that are security-relevant and should be stored for auditing. For example, an audit log should be generated when a user logs into a gateway. <br />
/// An audit log extends an event through: <br />
/// <list type="bullet">
/// 	<item>
/// 		<description>A username of the user that carried out the activity. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>An application that was used to carry out the activity. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>The actual activity. <br />
/// 		</description>
/// 	</item>
/// 	<item>
/// 		<description>A severity. <br />
/// 		</description>
/// 	</item>
/// </list>
/// ⓘ Info: The Accept header should be provided in all POST requests, otherwise an empty response body will be returned. <br />
/// </summary>
///
public sealed class AuditsApi : IAuditsApi
{
	private readonly HttpClient _httpClient;

	public AuditsApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<AuditRecordCollection<TAuditRecord>?> GetAuditRecords<TAuditRecord>(string? application = null, int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, string? source = null, string? type = null, string? user = null, bool? withTotalElements = null, bool? withTotalPages = null, CancellationToken cToken = default) where TAuditRecord : AuditRecord
	{
		const string resourcePath = $"audit/auditRecords";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
		queryString.TryAdd("application", application);
		queryString.TryAdd("currentPage", currentPage);
		queryString.TryAdd("dateFrom", dateFrom);
		queryString.TryAdd("dateTo", dateTo);
		queryString.TryAdd("pageSize", pageSize);
		queryString.TryAdd("source", source);
		queryString.TryAdd("type", type);
		queryString.TryAdd("user", user);
		queryString.TryAdd("withTotalElements", withTotalElements);
		queryString.TryAdd("withTotalPages", withTotalPages);
		uriBuilder.Query = queryString.ToString();
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.auditrecordcollection+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<AuditRecordCollection<TAuditRecord>?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TAuditRecord?> CreateAuditRecord<TAuditRecord>(TAuditRecord body, CancellationToken cToken = default) where TAuditRecord : AuditRecord
	{
		var jsonNode = body.ToJsonNode<TAuditRecord>();
		jsonNode?.RemoveFromNode("severity");
		jsonNode?.RemoveFromNode("application");
		jsonNode?.RemoveFromNode("creationTime");
		jsonNode?.RemoveFromNode("c8y_Metadata");
		jsonNode?.RemoveFromNode("changes");
		jsonNode?.RemoveFromNode("self");
		jsonNode?.RemoveFromNode("id");
		jsonNode?.RemoveFromNode("source", "self");
		const string resourcePath = $"audit/auditRecords";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/vnd.com.nsn.cumulocity.auditrecord+json"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.auditrecord+json");
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.auditrecord+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TAuditRecord?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<TAuditRecord?> GetAuditRecord<TAuditRecord>(string id, CancellationToken cToken = default) where TAuditRecord : AuditRecord
	{
		string resourcePath = $"audit/auditRecords/{HttpUtility.UrlPathEncode(id.GetStringValue())}";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Method = HttpMethod.Get,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.auditrecord+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<TAuditRecord?>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
}
