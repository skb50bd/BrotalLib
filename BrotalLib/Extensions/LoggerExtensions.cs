using System;

namespace Microsoft.Extensions.Logging
{
    public static class LoggerExtensions
    {
        #region TRACE
        public static void Trace<T>(
            this ILogger<T> logger,
            string message,
            params object[] parameters) =>
            logger.LogTrace(message, parameters);

        public static void Trace<T>(
            this ILogger<T> logger,
            EventId eventId,
            string message,
            params object[] parameters) =>
            logger.LogTrace(eventId, message, parameters);

        public static void Trace<T>(
            this ILogger<T> logger,
            EventId eventId,
            Exception exception,
            string message,
            params object[] parameters) =>
            logger.LogTrace(eventId, exception, message, parameters);

        public static void Trace<T>(
            this ILogger<T> logger,
            Exception exception,
            string message,
            params object[] parameters) =>
            logger.LogTrace(exception, message, parameters);
        #endregion

        #region DEBUG
        public static void Debug<T>(
            this ILogger<T> logger,
            string message,
            params object[] parameters) =>
            logger.LogDebug(message, parameters);

        public static void Debug<T>(
            this ILogger<T> logger,
            EventId eventId,
            string message,
            params object[] parameters) =>
            logger.LogDebug(eventId, message, parameters);

        public static void Debug<T>(
            this ILogger<T> logger,
            EventId eventId,
            Exception exception,
            string message,
            params object[] parameters) =>
            logger.LogDebug(eventId, exception, message, parameters);

        public static void Debug<T>(
            this ILogger<T> logger,
            Exception exception,
            string message,
            params object[] parameters) =>
            logger.LogDebug(exception, message, parameters);
        #endregion

        #region INFO
        public static void Info<T>(
            this ILogger<T> logger,
            string message,
            params object[] parameters) =>
            logger.LogInformation(message, parameters);

        public static void Info<T>(
            this ILogger<T> logger,
            EventId eventId,
            string message,
            params object[] parameters) =>
            logger.LogInformation(eventId, message, parameters);

        public static void Info<T>(
            this ILogger<T> logger,
            EventId eventId,
            Exception exception,
            string message,
            params object[] parameters) =>
            logger.LogInformation(eventId, exception, message, parameters);

        public static void Info<T>(
            this ILogger<T> logger,
            Exception exception,
            string message,
            params object[] parameters) =>
            logger.LogInformation(exception, message, parameters);
        #endregion

        #region WARNING
        public static void Warning<T>(
            this ILogger<T> logger,
            string          message,
            params object[] parameters) =>
            logger.LogWarning(message, parameters);

        public static void Warning<T>(
            this ILogger<T> logger,
            EventId         eventId,
            string          message,
            params object[] parameters) =>
            logger.LogWarning(eventId, message, parameters);

        public static void Warning<T>(
            this ILogger<T> logger,
            EventId         eventId,
            Exception       exception,
            string          message,
            params object[] parameters) =>
            logger.LogWarning(eventId, exception, message, parameters);

        public static void Warning<T>(
            this ILogger<T> logger,
            Exception       exception,
            string          message,
            params object[] parameters) =>
            logger.LogWarning(exception, message, parameters);
        #endregion

        #region ERROR
        public static void Error<T>(
            this ILogger<T> logger,
            string          message,
            params object[] parameters) =>
            logger.LogError(message, parameters);

        public static void Error<T>(
            this ILogger<T> logger,
            EventId         eventId,
            string          message,
            params object[] parameters) =>
            logger.LogError(eventId, message, parameters);

        public static void Error<T>(
            this ILogger<T> logger,
            EventId         eventId,
            Exception       exception,
            string          message,
            params object[] parameters) =>
            logger.LogError(eventId, exception, message, parameters);

        public static void Error<T>(
            this ILogger<T> logger,
            Exception       exception,
            string          message,
            params object[] parameters) =>
            logger.LogError(exception, message, parameters);
        #endregion

        #region CRITICAL
        public static void Critical<T>(
            this ILogger<T> logger,
            string          message,
            params object[] parameters) =>
            logger.LogCritical(message, parameters);

        public static void Critical<T>(
            this ILogger<T> logger,
            EventId         eventId,
            string          message,
            params object[] parameters) =>
            logger.LogCritical(eventId, message, parameters);

        public static void Critical<T>(
            this ILogger<T> logger,
            EventId         eventId,
            Exception       exception,
            string          message,
            params object[] parameters) =>
            logger.LogCritical(eventId, exception, message, parameters);

        public static void Critical<T>(
            this ILogger<T> logger,
            Exception       exception,
            string          message,
            params object[] parameters) =>
            logger.LogCritical(exception, message, parameters);
        #endregion
    }
}
