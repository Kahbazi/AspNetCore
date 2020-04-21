// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Microsoft.AspNetCore.Routing
{
    /// <summary>
    /// Represents HTTP method metadata used during routing.
    /// </summary>
    [DebuggerDisplay("{DebuggerToString(),nq}")]
    public sealed class HttpMethodMetadata : IHttpMethodMetadata
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMethodMetadata" /> class.
        /// </summary>
        /// <param name="httpMethods">
        /// The HTTP methods used during routing.
        /// An empty collection means any HTTP method will be accepted.
        /// </param>
        public HttpMethodMetadata(IEnumerable<string> httpMethods)
            : this(httpMethods, acceptCorsPreflight: false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpMethodMetadata" /> class.
        /// </summary>
        /// <param name="httpMethods">
        /// The HTTP methods used during routing.
        /// An empty collection means any HTTP method will be accepted.
        /// </param>
        /// <param name="acceptCorsPreflight">A value indicating whether routing accepts CORS preflight requests.</param>
        public HttpMethodMetadata(IEnumerable<string> httpMethods, bool acceptCorsPreflight)
        {
            if (httpMethods == null)
            {
                throw new ArgumentNullException(nameof(httpMethods));
            }

            HttpMethods = httpMethods.Select(GetHttpMethodInstance).ToArray();
            AcceptCorsPreflight = acceptCorsPreflight;
        }

        /// <summary>
        /// Returns a value indicating whether the associated endpoint should accept CORS preflight requests.
        /// </summary>
        public bool AcceptCorsPreflight { get; }

        /// <summary>
        /// Returns a read-only collection of HTTP methods used during routing.
        /// An empty collection means any HTTP method will be accepted.
        /// </summary>
        public IReadOnlyList<string> HttpMethods { get; }

        private static string GetHttpMethodInstance(string httpMethod)
        {
            if (AspNetCore.Http.HttpMethods.IsConnect(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Connect;
            }

            if (AspNetCore.Http.HttpMethods.IsDelete(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Delete;
            }

            if (AspNetCore.Http.HttpMethods.IsGet(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Get;
            }

            if (AspNetCore.Http.HttpMethods.IsHead(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Head;
            }

            if (AspNetCore.Http.HttpMethods.IsOptions(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Options;
            }

            if (AspNetCore.Http.HttpMethods.IsPatch(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Patch;
            }

            if (AspNetCore.Http.HttpMethods.IsPost(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Post;
            }

            if (AspNetCore.Http.HttpMethods.IsPut(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Put;
            }

            if (AspNetCore.Http.HttpMethods.IsTrace(httpMethod))
            {
                return AspNetCore.Http.HttpMethods.Trace;
            }

            return httpMethod;
        }
        
        private string DebuggerToString()
        {
            return $"HttpMethods: {string.Join(",", HttpMethods)} - Cors: {AcceptCorsPreflight}";
        }
    }
}
