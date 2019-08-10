// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Hosting
{
    internal static class LoggerEventIds
    {
        public const EventId RequestStarting = new EventId(1, "RequestStarting");
        public const EventId RequestFinished = new EventId(2, "RequestFinished");
        public const EventId Starting = new EventId(3, "Starting");
        public const EventId Started = new EventId(4, "Started");
        public const EventId Shutdown = new EventId(5, "Shutdown");
        public const EventId ApplicationStartupException = new EventId(6, "ApplicationStartupException");
        public const EventId ApplicationStoppingException = new EventId(7, "ApplicationStoppingException");
        public const EventId ApplicationStoppedException = new EventId(8, "ApplicationStoppedException");
        public const EventId HostedServiceStartException = new EventId(9, "HostedServiceStartException");
        public const EventId HostedServiceStopException = new EventId(10, "HostedServiceStopException");
        public const EventId HostingStartupAssemblyException = new EventId(11, "HostingStartupAssemblyException");
        public const EventId ServerShutdownException = new EventId(12, "ServerShutdownException");
    }
}
