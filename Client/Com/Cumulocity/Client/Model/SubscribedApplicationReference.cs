//
// SubscribedApplicationReference.cs
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

public sealed class SubscribedApplicationReference 
{

	/// <summary> 
	/// The application to be subscribed to. <br />
	/// </summary>
	///
	[JsonPropertyName("application")]
	public Application? PApplication { get; set; }

	public SubscribedApplicationReference() 
	{
	}

	public SubscribedApplicationReference(Application application)
	{
		this.PApplication = application;
	}

	/// <summary> 
	/// The application to be subscribed to. <br />
	/// </summary>
	///
	public sealed class Application 
	{
	
		/// <summary> 
		/// A URL linking to this resource. <br />
		/// </summary>
		///
		[JsonPropertyName("self")]
		public string? Self { get; set; }
	
		public Application() 
		{
		}
	
		public Application(string self)
		{
			this.Self = self;
		}
	
		public override string ToString()
		{
			return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
		}
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
