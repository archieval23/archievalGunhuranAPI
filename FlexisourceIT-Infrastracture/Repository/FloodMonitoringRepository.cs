using FlexisourceIT_Domain.Contracts;
using FlexisourceIT_Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlexisourceIT_Infrastructure.Repository
{
    public class FloodMonitoringRepository : IFloodMonitoringRepository
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<FloodMonitoringRepository> _logger;

        public FloodMonitoringRepository(HttpClient httpClient, ILogger<FloodMonitoringRepository> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<FloodMonitoringEntities>> GetAllFloodMonitoring()
        {
            try
            {
                _httpClient.BaseAddress = new Uri("https://environment.data.gov.uk/flood-monitoring/id/stations?parameter=rainfall&_limit=50");
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await _httpClient.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync())
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };

                        RootObject root = await JsonSerializer.DeserializeAsync<RootObject>(responseStream, options);
                        var floodMonitoringEntities = new List<FloodMonitoringEntities>();
                        if (root.Items != null)
                        {
                            foreach (var item in root.Items)
                            {
                                var floodMonitoringEntity = new FloodMonitoringEntities
                                {
                                    Id = item.Id,
                                    Easting = item.Easting,
                                    GridReference = item.GridReference,
                                    Label = item.Label,
                                    Lat = item.Lat,
                                    Long = item.Long,
                                    Northing = item.Northing,
                                    Notation = item.Notation,
                                    StationReference = item.StationReference
                                };
                                floodMonitoringEntities.Add(floodMonitoringEntity);
                            }
                        }
                        else
                        {
                            _logger.LogWarning("Items array is null.");
                        }
                        _logger.LogWarning("Success");
                        return floodMonitoringEntities;
                    }
                }
                else
                {
                    _logger.LogError($"Error: {response.StatusCode}");
                    return new List<FloodMonitoringEntities>();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }
    }
}
