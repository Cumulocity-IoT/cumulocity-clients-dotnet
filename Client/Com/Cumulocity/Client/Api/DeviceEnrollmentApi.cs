//
// DeviceEnrollmentApi.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
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
/// Device enroll API to be used by a device to issue an X509 certificate signed by tenant's <see href="#operation/postBulkNewDeviceRequestCollectionResource" langword="certificate authority" />. The identifier and enrollment OTP for a device must be first shared as a pre-shared-key (PSK) with Cumulocity using the <see href="#operation/postBulkNewDeviceRequestCollectionResource" langword="bulkNewDeviceRequests" /> endpoint for certificate provisioning.Internally, ID and ENROLLMENT_OTP fields will be added to the NewDeviceRegistration list with a status of Accepted, serving as temporary device credentials for device authentication. <br />
/// Device re-enroll API to be used by a device to renew its certificate or replace its certificate with its current credentials (being a password or a JWT token). <br />
/// </summary>
///
public sealed class DeviceEnrollmentApi : IDeviceEnrollmentApi
{
	private readonly HttpClient _httpClient;

	public DeviceEnrollmentApi(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	/// <inheritdoc />
	public async Task<string> SimpleEnrollDevice(byte[] body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<byte[]>();
		const string resourcePath = $".well_known/est/simpleenroll";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/pkcs10"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/pkcs10");
		request.Headers.TryAddWithoutValidation("Accept", "application/pkcs7-mime;smime-type=certs-only, application/vnd.com.nsn.cumulocity.error+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<string>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
	
	/// <inheritdoc />
	public async Task<byte[]> SimpleReEnrollDevice(byte[] body, CancellationToken cToken = default) 
	{
		var jsonNode = body.ToJsonNode<byte[]>();
		const string resourcePath = $".well_known/est/simplereenroll";
		var uriBuilder = new UriBuilder(new Uri(_httpClient.BaseAddress ?? new Uri(resourcePath), resourcePath));
		using var request = new HttpRequestMessage 
		{
			Content = new StringContent(jsonNode?.ToString() ?? string.Empty, Encoding.UTF8, "application/pkcs10"),
			Method = HttpMethod.Post,
			RequestUri = new Uri(uriBuilder.ToString())
		};
		request.Headers.TryAddWithoutValidation("Content-Type", "application/pkcs10");
		request.Headers.TryAddWithoutValidation("Accept", "application/pkcs7-mime;smime-type=certs-only, application/vnd.com.nsn.cumulocity.error+json");
		using var response = await _httpClient.SendAsync(request: request, cancellationToken: cToken).ConfigureAwait(false);
		await response.EnsureSuccessStatusCodeWithContentInfo().ConfigureAwait(false);
		await using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
		return await JsonSerializerWrapper.DeserializeAsync<byte[]>(responseStream, cancellationToken: cToken).ConfigureAwait(false);
	}
}
