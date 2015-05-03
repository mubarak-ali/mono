/*
 * Created by SharpDevelop.
 * User: Mubarak - Date: 5/2/2015 - Time: 3:11 AM
 */
using System;
using Spring.Context.Attributes;
using Spring.Http.Converters.Json;
using Spring.Rest.Client;

namespace waveletclient.app.Config
{
	
//	[Configuration]
    public class RestTemplateConfig
    {
    	
    	public const string BASE_URL = "http://bigledger.db.wavelet.net/";
    	
        public virtual IRestOperations MyRestClient()
        {
            RestTemplate restTemplate = new RestTemplate(BASE_URL);
            restTemplate.MessageConverters.Add(new NJsonHttpMessageConverter());
            return restTemplate;
        }
    }
}
