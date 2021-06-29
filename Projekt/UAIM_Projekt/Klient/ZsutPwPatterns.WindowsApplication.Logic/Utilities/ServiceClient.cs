﻿//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace ZsutPw.Patterns.WindowsApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.Net.Http;
  using System.Text.Json;
    using System.Net;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;

    public class ServiceClient
  {
    private static readonly HttpClient httpClient = new HttpClient( );
    private readonly string serviceHost;
    private readonly ushort servicePort;

    public ServiceClient( string serviceHost, int servicePort )
    {
      Debug.Assert( condition: !String.IsNullOrEmpty( serviceHost ) && servicePort > 0 );

      this.serviceHost = serviceHost;
      this.servicePort = (ushort)servicePort;
    }

    public R CallWebService<R>( HttpMethod httpMethod, string webServiceUri, object content=null )
    {
      Task<string> webServiceCall = this.CallWebService( httpMethod, webServiceUri, content );

      webServiceCall.Wait( );

      string jsonResponseContent = webServiceCall.Result;

      R result = this.ConvertJson<R>( jsonResponseContent );

      return result;
    }

    public async Task<R> CallWebServiceAsync<R>( HttpMethod httpMethod, string webServiceUri, object content =null )
    {
      string jsonResponseContent = await this.CallWebService( httpMethod, webServiceUri, content );

      R result = this.ConvertJson<R>( jsonResponseContent );

      return result;
    }

    public async Task<string> CallWebService( HttpMethod httpMethod, string callUri, object content = null )
    {

      Uri httpUri = new Uri(String.Format( "http://{0}:{1}/{2}", this.serviceHost, this.servicePort, callUri ));

      HttpRequestMessage httpRequestMessage = new HttpRequestMessage( httpMethod, httpUri );
            if (content != null)
                httpRequestMessage.Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add( "Accept", "application/json" );
       HttpResponseMessage httpResponseMessage = await httpClient.SendAsync( httpRequestMessage );

      httpResponseMessage.EnsureSuccessStatusCode( );

      string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync( );

      return httpResponseContent;
    }

    private T ConvertJson<T>( string json )
    {
      var options = new JsonSerializerOptions();
      options.PropertyNameCaseInsensitive = true;
      return JsonSerializer.Deserialize<T>( json , options);
    }
  }
}
