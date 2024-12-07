namespace Cae.DotNet.Framework.MappedExceptions
{
    public class MappedException : Exception
    {
        public string BriefPublicMessage { get; private set; }
        public string Details { get; private set; }
        public Exception? OriginalException { get; private set; }

        public MappedException(string briefPublicMessage, string? details, Exception? originalException) : base($"{briefPublicMessage} | {details}")
        {
            BriefPublicMessage = briefPublicMessage;
            Details = details ?? string.Empty;
            OriginalException = originalException ?? null;
        }

        public IEnumerable<string> GetLinesFromStackTraceFromOriginalException(int lines)
        {
            if (OriginalException == null)
                return [];

            return GetLinesFromStackTraceAsString(OriginalException, lines);
        }

        public IEnumerable<string> GetLinesFromStackTrace(int lines)
        {
            return GetLinesFromStackTraceAsString(this, lines);
        }

        public IEnumerable<string> GetLinesFromStackTraceAsString(Exception exception,int lines)
        {
            if (exception == null)
                return [];

            var linesToReturn = new List<string>();
            var linesCount = 0;
            foreach (var line in exception.StackTrace?.Split('\n') ?? [])
            {
                linesToReturn.Add(line);
                linesCount++;
                if (linesCount >= lines)
                    break;
            }
            return linesToReturn;
        }
    }
}
