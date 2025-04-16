//
// ObjectExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
//

using System.Text.Json;
using System.Text.Json.Nodes;

namespace Client.Com.Cumulocity.Client.Supplementary;

public static class ObjectExtensions
{
    public static JsonNode? ToJsonNode<T>(this T body)
    {
        return JsonSerializerWrapper.ToJsonNode(body);
    }
}
