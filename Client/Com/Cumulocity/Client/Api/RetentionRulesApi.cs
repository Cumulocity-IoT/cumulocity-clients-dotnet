///
/// RetentionRulesApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Com.Cumulocity.Client.Model;
using Com.Cumulocity.Client.Supplementary;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// It is possible to define rules that make the platform remove certain data. A retention rule shows which data will be deleted. For example, a retention rule with `dataType=EVENT` and `maximumAge=30` removes from the system all events older than 30 days.
	/// 
	/// > **&#9432; Info:** The Accept header should be provided in all POST/PUT requests, otherwise an empty response body will be returned.
	/// 
	/// </summary>
	#nullable enable
	public class RetentionRulesApi : AdaptableApi, IRetentionRulesApi
	{
		public RetentionRulesApi(HttpClient httpClient) : base(httpClient)
		{
		}
	
		/// <inheritdoc />
		public async Task<RetentionRuleCollection?> GetRetentionRules(int? currentPage = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null) 
		{
			var client = HttpClient;
			var resourcePath = $"/retention/retentions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var queryString = HttpUtility.ParseQueryString(uriBuilder.Query);
			var allQueryParameter = new Dictionary<string, object>()
			{
				#pragma warning disable CS8604 // Possible null reference argument.
				{"currentPage", currentPage},
				{"pageSize", pageSize},
				{"withTotalElements", withTotalElements},
				{"withTotalPages", withTotalPages}
				#pragma warning restore CS8604 // Possible null reference argument.
			};
			allQueryParameter.Where(p => p.Value != null).ToList().ForEach(e => queryString.Add(e.Key, $"{e.Value}"));
			uriBuilder.Query = queryString.ToString();
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrulecollection+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<RetentionRuleCollection?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<RetentionRule?> CreateRetentionRule(RetentionRule body, string xCumulocityProcessingMode) 
		{
			var jsonNode = ToJsonNode<RetentionRule>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/retention/retentions";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.retentionrule+json"),
				Method = HttpMethod.Post,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.retentionrule+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrule+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<RetentionRule?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<RetentionRule?> GetRetentionRule(string id) 
		{
			var client = HttpClient;
			var resourcePath = $"/retention/retentions/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrule+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<RetentionRule?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<RetentionRule?> UpdateRetentionRule(RetentionRule body, string id, string xCumulocityProcessingMode) 
		{
			var jsonNode = ToJsonNode<RetentionRule>(body);
			jsonNode?.RemoveFromNode("self");
			jsonNode?.RemoveFromNode("id");
			var client = HttpClient;
			var resourcePath = $"/retention/retentions/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Content = new StringContent(jsonNode.ToString(), Encoding.UTF8, "application/vnd.com.nsn.cumulocity.retentionrule+json"),
				Method = HttpMethod.Put,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Content-Type", "application/vnd.com.nsn.cumulocity.retentionrule+json");
			request.Headers.TryAddWithoutValidation("Accept", "application/vnd.com.nsn.cumulocity.error+json, application/vnd.com.nsn.cumulocity.retentionrule+json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return await JsonSerializer.DeserializeAsync<RetentionRule?>(responseStream);
		}
		
		/// <inheritdoc />
		public async Task<System.IO.Stream> DeleteRetentionRule(string id, string xCumulocityProcessingMode) 
		{
			var client = HttpClient;
			var resourcePath = $"/retention/retentions/{id}";
			var uriBuilder = new UriBuilder(new Uri(HttpClient?.BaseAddress ?? new Uri(resourcePath), resourcePath));
			var request = new HttpRequestMessage 
			{
				Method = HttpMethod.Delete,
				RequestUri = new Uri(uriBuilder.ToString())
			};
			request.Headers.TryAddWithoutValidation("X-Cumulocity-Processing-Mode", xCumulocityProcessingMode);
			request.Headers.TryAddWithoutValidation("Accept", "application/json");
			var response = await client.SendAsync(request);
			response.EnsureSuccessStatusCode();
			using var responseStream = await response.Content.ReadAsStreamAsync();
			return responseStream;
		}
	}
	#nullable disable
}
