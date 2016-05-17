using Primer.Infrastracture;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Primer.Controllers
{
    public class PageSizeController : ApiController, ICustomController
    {
        private static string TargetUrl = "http://www.apress.com/";

        ///// <summary>
        ///// If the request does not need to return a value.
        ///// </summary>
        ///// <param name="cToken"></param>
        ///// <returns></returns>
        //public async System.Threading.Tasks.Task<long> GetPageSize(CancellationToken cToken)
        //{
        //   WebClient wc = new WebClient(); 
        //    Stopwatch sw = Stopwatch.StartNew();
        //    List<long> results = new List<long>();

        //    for (int i = 0; i < 10; i++) 
        //    { 
        //        if (!cToken.IsCancellationRequested) 
        //        {
        //            Debug.WriteLine("Making Request: {0}", i); 
        //            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl); 
        //            results.Add(apressData.LongLength);
        //            sw.Stop();
        //        } 
        //        else 
        //        {
        //            sw.Stop();
        //            Debug.WriteLine("Cancelled");  
        //            return 0;
        //        }
              
        //    }
        //    Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds); 
        //return (long)results.Average();
        //}

        ///// <summary>
        ///// Using asynchronous call using async and await when the method does not return a value.
        ///// </summary>
        ///// <param name="cToken"></param>
        ///// <returns></returns>
        //public Task<long> GetPageSize(CancellationToken cToken)
        //{
        //    return Task<long>.Factory.StartNew(() =>
        //    {
        //        WebClient wc = new WebClient(); 
        //        Stopwatch sw = Stopwatch.StartNew();
        //        List<long> results = new List<long>();

        //        for (int i = 0; i < 10; i++) 
        //        { 
        //            if (!cToken.IsCancellationRequested) 
        //            { 
        //                Debug.WriteLine("Making Request: {0}", i); 
        //                results.Add(wc.DownloadData(TargetUrl).LongLength); 
        //            } 
        //            else 
        //            { 
        //                Debug.WriteLine("Cancelled"); 
        //                return 0; 
        //            } 
        //        }

        //        Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds); 
        //        return (long)results.Average();
        //    });
        //}

        public async Task<long> GetPageSize(CancellationToken cToken) 
        { 
            WebClient wc = new WebClient(); 
            Stopwatch sw = Stopwatch.StartNew(); 
            byte[] apressData = await wc.DownloadDataTaskAsync(TargetUrl); 
            Debug.WriteLine("Elapsed ms: {0}", sw.ElapsedMilliseconds); 
            
            return apressData.LongLength; 
        }

        /// <summary>
        ///  Task.FromResult allows you to generate Task wrappers around results that you generated synchronously   
        ///  the evaluation of code happens synchronously and is wrapped in the Task that yields this value immediately. 
        ///  There is no asynchronous work performed when you use the FromResult method.
        /// </summary>
        /// <param name="newUrl"></param>
        /// <param name="cToken"></param>
        /// <returns></returns>
        public Task PostUrl(string newUrl, CancellationToken cToken) 
        { 
            TargetUrl = newUrl; 
            
            return Task.FromResult<object>(null); 
        } 
    }
}
