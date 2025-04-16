//
// TestConfigurationExtensions.cs
// CumulocityCoreLibrary
//
// Copyright (c) 2014-present Cumulocity GmbH, Duesseldorf, Germany and/or its affiliates and/or their licensors.
// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Cumulocity GmbH
//

using System.IO;
using Microsoft.Extensions.Configuration;

namespace Test.Com.Cumulocity.Client.Supplementary;

public static class TestConfigurationExtensions
{

    public static void Load(this TestConfiguration configuration)
    {
        var configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.test.json", false, false)
            .Build();
        var section = configurationRoot.GetSection("Configuration");
        section.Bind(configuration);
    }
}
