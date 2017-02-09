﻿using EPiServer.ServiceLocation;
using System;
using System.Net;
using System.Net.Http;

namespace EPiServer.Reference.Commerce.Shared.Services
{
    [ServiceConfiguration(typeof(IHtmlDownloader), Lifecycle = ServiceInstanceScope.Singleton)]
    public class HtmlDownloader : IHtmlDownloader
    {
        public string Download(string baseUrl, string relativeUrl)
        {
            var client = new HttpClient {BaseAddress = new Uri(baseUrl)};
            var fullUrl = client.BaseAddress + relativeUrl;

            var response = client.GetAsync(fullUrl).Result;
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(
                    string.Format("Request to '{0}' was unsuccessful. Content:\n{1}",
                                    fullUrl, response.Content.ReadAsStringAsync().Result));
            }
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}