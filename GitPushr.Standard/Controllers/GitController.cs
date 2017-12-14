/*
 * GitPushr.Standard
 *
 * This file was automatically generated by APIMATIC v2.0 ( https://apimatic.io )
 */
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;
using GitPushr.Standard;
using GitPushr.Standard.Utilities;
using GitPushr.Standard.Http.Request;
using GitPushr.Standard.Http.Response;
using GitPushr.Standard.Http.Client;
using GitPushr.Standard.Exceptions;

namespace GitPushr.Standard.Controllers
{
    public partial class GitController: BaseController
    {
        #region Singleton Pattern

        //private static variables for the singleton pattern
        private static object syncObject = new object();
        private static GitController instance = null;

        /// <summary>
        /// Singleton pattern implementation
        /// </summary>
        internal static GitController Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (null == instance)
                    {
                        instance = new GitController();
                    }
                }
                return instance;
            }
        }

        #endregion Singleton Pattern

        /// <summary>
        /// Commits a file immediately and waits for the job to complete before returning
        /// </summary>
        /// <param name="body">Required parameter: Job Details</param>
        /// <return>Returns the Models.JobStatus response from the API call</return>
        public Models.JobStatus CreateCommitNow(Models.GitJob body)
        {
            Task<Models.JobStatus> t = CreateCommitNowAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Commits a file immediately and waits for the job to complete before returning
        /// </summary>
        /// <param name="body">Required parameter: Job Details</param>
        /// <return>Returns the Models.JobStatus response from the API call</return>
        public async Task<Models.JobStatus> CreateCommitNowAsync(Models.GitJob body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/git/pushnow");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };
            _headers.Add("x-username", Configuration.XUsername);
            _headers.Add("x-password", Configuration.XPassword);

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);
            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.JobStatus>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

        /// <summary>
        /// Commits a file to the repo
        /// </summary>
        /// <param name="body">Required parameter: Job Details</param>
        /// <return>Returns the Models.NewJobDetails response from the API call</return>
        public Models.NewJobDetails CreateCommit(Models.GitJob body)
        {
            Task<Models.NewJobDetails> t = CreateCommitAsync(body);
            APIHelper.RunTaskSynchronously(t);
            return t.Result;
        }

        /// <summary>
        /// Commits a file to the repo
        /// </summary>
        /// <param name="body">Required parameter: Job Details</param>
        /// <return>Returns the Models.NewJobDetails response from the API call</return>
        public async Task<Models.NewJobDetails> CreateCommitAsync(Models.GitJob body)
        {
            //the base uri for api requests
            string _baseUri = Configuration.BaseUri;

            //prepare query string for API call
            StringBuilder _queryBuilder = new StringBuilder(_baseUri);
            _queryBuilder.Append("/git/push");


            //validate and preprocess url
            string _queryUrl = APIHelper.CleanUrl(_queryBuilder);

            //append request with appropriate headers and parameters
            var _headers = new Dictionary<string,string>()
            {
                { "user-agent", "APIMATIC 2.0" },
                { "accept", "application/json" },
                { "content-type", "application/json; charset=utf-8" }
            };
            _headers.Add("x-username", Configuration.XUsername);
            _headers.Add("x-password", Configuration.XPassword);

            //append body params
            var _body = APIHelper.JsonSerialize(body);

            //prepare the API call request to fetch the response
            HttpRequest _request = ClientInstance.PostBody(_queryUrl, _headers, _body);

            //invoke request and get response
            HttpStringResponse _response = (HttpStringResponse) await ClientInstance.ExecuteAsStringAsync(_request).ConfigureAwait(false);
            HttpContext _context = new HttpContext(_request,_response);
            //handle errors defined at the API level
            base.ValidateResponse(_response, _context);

            try
            {
                return APIHelper.JsonDeserialize<Models.NewJobDetails>(_response.Body);
            }
            catch (Exception _ex)
            {
                throw new APIException("Failed to parse the response: " + _ex.Message, _context);
            }
        }

    }
} 