///
/// IUsageStatisticsApi.cs
/// CumulocityCoreLibrary
///
/// Copyright (c) 2014-2022 Software AG, Darmstadt, Germany and/or Software AG USA Inc., Reston, VA, USA, and/or its subsidiaries and/or its affiliates and/or their licensors.
/// Use, reproduction, transfer, publication or disclosure is prohibited except as specifically provided for in your License Agreement with Software AG.
///

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Com.Cumulocity.Client.Model;

namespace Com.Cumulocity.Client.Api 
{
	/// <summary>
	/// Days are counted according to server timezone, so be aware that the tenant usage statistics displaying/filtering may not work correctly when the client is not in the same timezone as the server. However, it is possible to send a request with a time range (using the query parameters `dateFrom` and `dateTo`) in zoned format (for example, `2020-10-26T03:00:00%2B01:00`). Statistics from past days are stored with daily aggregations, which means that for a specific day you get either the statistics for the whole day or none at all.
	/// 
	/// ### Request counting in SmartREST and MQTT
	/// 
	/// * SmartREST: Each row in a SmartREST request is transformed into a separate HTTP request. For example, if one SmartREST request contains 10 rows, then 10 separate calls are executed, meaning that request count is increased by 10.
	/// * MQTT: Each row/line counts as a separate request. Creating custom template counts as a single request.
	/// 
	/// ### REST specific counting details
	/// 
	/// * All counters increase also when the request is invalid, for example, wrong payload or missing permissions.
	/// * Bulk measurements creation and bulk alarm status update are counted as a single "requestCount"/"deviceRequestCount" and multiple inbound data transfer count.
	/// 
	/// ### SmartREST 1.0 specific counting details
	/// 
	/// * Invalid SmartREST requests are not counted, for example, when the template doesn't exist.
	/// * A new template registration is treated as two separate requests. Create a new inventory object which increases "requestCount", "deviceRequestCount" and "inventoriesCreatedCount". There is also a second request which binds the template with X-ID, this increases "requestCount" and "deviceRequestCount".
	/// * Each row in a SmartREST request is transformed into a separate HTTP request. For example, if one SmartREST request contains 10 rows, then 10 separate calls are executed, meaning that both "requestCount" and "deviceRequestCount" are increased by 10.
	/// 
	/// ### MQTT specific counting details
	/// 
	/// * Invalid requests are counted, for example, when sending a message with a wrong template ID.
	/// * Device creation request and automatic device creation are counted.
	/// * Each row/line counts as a separate request.
	/// * Creating a custom template counts as a single request, no matter how many rows are sent in the request.
	/// * There is one special SmartREST 2.0 template (402 Create location update event with device update) which is doing two things in one call, that is, create a new location event and update the location of the device. It is counted as two separate requests.
	/// 
	/// ### JSON via MQTT specific counting details
	/// 
	/// * Invalid requests are counted, for example, when the message payload is invalid.
	/// * Bulk creation requests are counted as a single "requestCount"/"deviceRequestCount" and multiple inbound data transfer count.
	/// * Bulk creation requests with a wrong payload are not counted for inbound data transfer count.
	/// 
	/// ### Total inbound data transfer
	/// 
	/// Inbound data transfer refers to the total number of inbound requests performed to transfer data into the Cumulocity IoT platform. This includes sensor readings, alarms, events, commands and alike that are transferred between devices and the Cumulocity IoT platform using the REST and/or MQTT interfaces. Such an inbound request could also originate from a custom microservice, website or any other client.
	/// 
	/// See the table below for more information on how the counters are increased. Additionally, it shows how inbound data transfers are handled for both MQTT and REST:
	/// 
	/// |Type of transfer|MQTT counter information|REST counter information|
	/// |:---------------|:-----------------------|:-----------------------|
	/// |Creation of an **alarm** in one request|One alarm creation is counted.|One alarm creation is counted via REST.|
	/// |Update of an **alarm** (for example, status change)|One alarm update is counted.|One alarm update is counted via REST.|
	/// |Creation of **multiple alarms** in one request|Each alarm creation in a single MQTT request will be counted.|Not supported by C8Y (REST does not support creating multiple alarms in one call).|
	/// |Update of **multiple alarms** (for example, status change) in one request|Each alarm update in a single MQTT request will be counted.|Each alarm that matches the filter is counted as an alarm update (causing multiple updates).|
	/// |Creation of an **event** in one request|One event creation is counted.|One event creation is counted.|
	/// |Update of an **event** (for example, text change)|One event update is counted.|One event update is counted.|
	/// |Creation of **multiple events** in one request|Each event creation in a single MQTT request will be counted.|Not supported by C8Y (REST does not support creating multiple events in one call).|
	/// |Update of **multiple events** (for example, text change) in one request|Each event update in a single MQTT request will be counted.|Not supported by C8Y (REST does not support updating multiple events in one call).|
	/// |Creation of a **measurement** in one request|One measurement creation is counted. |One measurement creation is counted.|
	/// |Creation of **multiple measurements** in one request|Each measurement creation in a single MQTT request will be counted. Example: If MQTT is used to report 5 measurements, the measurementCreated counter will be incremented by five.|REST allows multiple measurements to be created by sending multiple measurements in one call. In this case, each measurement sent via REST is counted individually. The call itself is not counted. For example, if somebody sends 5 measurements via REST in one call, the corresponding counter will be increased by 5. Measurements with multiple series are counted as a singular measurement.|
	/// |Creation of a **managed object** in one request|One managed object creation is counted.|One managed object creation is counted.|
	/// |Update of one **managed object** (for example, status change)|One managed object update is counted.|One managed object update is counted.|
	/// |Update of **multiple managed objects** in one request|Each managed object update in a single MQTT request will be counted.|Not supported by C8Y (REST does not support updating multiple managed objects in one call).|
	/// |Creation/update of **multiple alarms/measurements/events/inventories** mixed in a single call.|Each MQTT line is processed separately. If it is a creation/update of an event/alarm/measurement/inventory, the corresponding counter is increased by one.|Not supported by the REST API.|
	/// |Assign/unassign of **child devices and child assets** in one request|One managed object update is counted.|One managed object update is counted.|
	/// 
	/// ### Microservice usage statistics
	/// 
	/// The microservice usage statistics gathers information on the resource usage for tenants for each subscribed application which are collected on a daily base.
	/// 
	/// The microservice usage's information is stored in the `resources` object.
	/// 
	/// </summary>
	#nullable enable
	public interface IUsageStatisticsApi
	{
	
		/// <summary>
		/// Retrieve statistics of the current tenant<br/>
		/// Retrieve usage statistics of the current tenant.  <section><h5>Required roles</h5> ROLE_TENANT_STATISTICS_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the tenant statistics are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the statistics.</param>
		/// <param name="dateTo">End date or date and time of the statistics.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalElements">When set to `true`, the returned result will contain in the statistics object the total number of elements. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<TenantUsageStatisticsCollection?> GetTenantUsageStatisticsCollectionResource(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? withTotalElements = null, bool? withTotalPages = null) ;
		
		/// <summary>
		/// Retrieve a usage statistics summary<br/>
		/// Retrieve a usage statistics summary of a tenant.
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the usage statistics summary is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="dateFrom">Start date or date and time of the statistics.</param>
		/// <param name="dateTo">End date or date and time of the statistics.</param>
		/// <param name="tenant">Unique identifier of a Cumulocity IoT tenant.</param>
		/// <returns></returns>
		Task<SummaryTenantUsageStatistics?> GetTenantUsageStatistics(System.DateTime? dateFrom = null, System.DateTime? dateTo = null, string? tenant = null) ;
		
		/// <summary>
		/// Retrieve a summary of all usage statistics<br/>
		/// Retrieve a summary of all tenants usage statistics.  <section><h5>Required roles</h5> ROLE_TENANT_MANAGEMENT_READ </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the usage statistics summary is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="dateFrom">Start date or date and time of the statistics.</param>
		/// <param name="dateTo">End date or date and time of the statistics.</param>
		/// <returns></returns>
		Task<List<SummaryAllTenantsUsageStatistics<TCustomProperties>>?> GetTenantsUsageStatistics<TCustomProperties>(System.DateTime? dateFrom = null, System.DateTime? dateTo = null) where TCustomProperties : CustomProperties;
		
		/// <summary>
		/// Retrieve usage statistics files metadata<br/>
		/// Retrieve usage statistics summary files report metadata.  <section><h5>Required roles</h5> ROLE_TENANT_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the tenant statistics are sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="currentPage">The current page of the paginated results.</param>
		/// <param name="dateFrom">Start date or date and time of the statistics file generation.</param>
		/// <param name="dateTo">End date or date and time of the statistics file generation.</param>
		/// <param name="pageSize">Indicates how many entries of the collection shall be returned. The upper limit for one page is 2,000 objects.</param>
		/// <param name="withTotalPages">When set to `true`, the returned result will contain in the statistics object the total number of pages. Only applicable on [range queries](https://en.wikipedia.org/wiki/Range_query_(database)).</param>
		/// <returns></returns>
		Task<TenantUsageStatisticsFileCollection?> GetMetadata(int? currentPage = null, System.DateTime? dateFrom = null, System.DateTime? dateTo = null, int? pageSize = null, bool? withTotalPages = null) ;
		
		/// <summary>
		/// Generate a statistics file report<br/>
		/// Generate a TEST statistics file report for a given time range.  There are two types of statistics files: * REAL - generated by the system on the first day of the month and including statistics from the previous month. * TEST - generated by the user with a time range specified in the query parameters (`dateFrom`, `dateTo`). <section><h5>Required roles</h5> ROLE_TENANT_MANAGEMENT_ADMIN <b>OR</b> ROLE_TENANT_MANAGEMENT_CREATE </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 201</term>
		/// <description>A statistics file was generated.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 422</term>
		/// <description>Unprocessable Entity – invalid payload.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="body"></param>
		/// <returns></returns>
		Task<StatisticsFile?> GenerateStatisticsFile(RangeStatisticsFile body) ;
		
		/// <summary>
		/// Retrieve a usage statistics file<br/>
		/// Retrieve a specific usage statistics file (by a given ID).  <section><h5>Required roles</h5> ROLE_TENANT_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the file is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 404</term>
		/// <description>Statistics file not found.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="id">Unique identifier of the statistics file.</param>
		Task<System.IO.Stream> GetStatisticsFile(string id) ;
		
		/// <summary>
		/// Retrieve the latest usage statistics file<br/>
		/// Retrieve the latest usage statistics file with REAL data for a given month.  There are two types of statistics files: * REAL - generated by the system on the first day of the month and includes statistics for the previous month. * TEST - generated by the user with a time range specified in the query parameters (`dateFrom`, `dateTo`).  <section><h5>Required roles</h5> ROLE_TENANT_MANAGEMENT_ADMIN </section> 
		/// <br>The following table gives an overview of the possible response codes and their meanings:</br>
		/// <list type="bullet">
		/// <item>
		/// <term>HTTP 200</term>
		/// <description>The request has succeeded and the file is sent in the response.</description>
		/// </item>
		/// <item>
		/// <term>HTTP 401</term>
		/// <description>Authentication information is missing or invalid.</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="month">Date (format YYYY-MM-dd) specifying the month for which the statistics file will be downloaded (the day value is ignored).</param>
		Task<System.IO.Stream> GetLatestStatisticsFile(System.DateTime month) ;
	}
	#nullable disable
}
