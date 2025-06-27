//
// PasswordChange.cs
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

public sealed class PasswordChange 
{

	/// <summary> 
	/// The current password of the user performing the request. <br />
	/// </summary>
	///
	[JsonPropertyName("currentUserPassword")]
	public string? CurrentUserPassword { get; set; }

	/// <summary> 
	/// The new password to be set for the user performing the request. <br />
	/// By default, the password must meet the following conditions: <br />
	/// <list type="bullet">
	/// 	<item>
	/// 		<description>Consist of at least eight characters (this parameter can be configured by the management tenant.) <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>It must not have been used previously by user. <br />
	/// 		</description>
	/// 	</item>
	/// 	<item>
	/// 		<description>Include each of the following character types: <br />
	/// 		<list type="bullet">
	/// 			<item>
	/// 				<description>uppercase letters: <c>[A-Z]</c>, for example <c>ABCDEF</c>. <br />
	/// 				</description>
	/// 			</item>
	/// 			<item>
	/// 				<description>lowercase letters: <c>[a-z]</c>, for example <c>abcdef</c>. <br />
	/// 				</description>
	/// 			</item>
	/// 			<item>
	/// 				<description>numbers: <c>[0-9]</c>, for example: <c>123456</c>. <br />
	/// 				</description>
	/// 			</item>
	/// 			<item>
	/// 				<description>any other symbol from following list <c> `~!@#$%^&*()_|+-=?;:'",.<>{}[]\/</c> as a special character, for example <c>!@#$%^</c>. <br />
	/// 				</description>
	/// 			</item>
	/// 		</list>
	/// 		</description>
	/// 	</item>
	/// </list>
	/// ⓘ Info: The password rules can be configured by the administrator, that means, your administrator can configure your account to enforce a password policy. You may be required to pick a strong password for example or to change your password regularly. <br />
	/// </summary>
	///
	[JsonPropertyName("newPassword")]
	public string? NewPassword { get; set; }

	public PasswordChange() 
	{
	}

	public PasswordChange(string currentUserPassword, string newPassword)
	{
		this.CurrentUserPassword = currentUserPassword;
		this.NewPassword = newPassword;
	}

	public override string ToString()
	{
		return JsonSerializerWrapper.Serialize(this, JsonSerializerWrapper.ToStringJsonSerializerOptions);
	}
}
