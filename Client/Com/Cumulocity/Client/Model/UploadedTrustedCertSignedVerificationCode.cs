//
// UploadedTrustedCertSignedVerificationCode.cs
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
/// The signed verification code to prove the user's possession of the certificate. <br />
/// </summary>
///
public sealed class UploadedTrustedCertSignedVerificationCode 
{

	/// <summary> 
	/// A signed verification code that proves the right to use the certificate. <br />
	/// </summary>
	///
	[JsonPropertyName("proofOfPossessionSignedVerificationCode")]
	public string? ProofOfPossessionSignedVerificationCode { get; set; }

	public UploadedTrustedCertSignedVerificationCode() 
	{
	}

	public UploadedTrustedCertSignedVerificationCode(string proofOfPossessionSignedVerificationCode)
	{
		this.ProofOfPossessionSignedVerificationCode = proofOfPossessionSignedVerificationCode;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
