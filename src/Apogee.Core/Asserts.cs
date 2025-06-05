using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Apogee.Core
{
    public static class Asserts
    {
        // Enable/disable assertions - controlled by AASSERTIONS_ENABLED conditional compilation symbol

        [Conditional("AASSERTIONS_ENABLED")]
        public static void AAssert(bool expression,
                                  [CallerArgumentExpression("expression")] string expr = "",
                                  [CallerFilePath] string file = "",
                                  [CallerLineNumber] Int32 line = 0)
        {
#if AASSERTIONS_ENABLED
            if (!expression)
            {
                Logger.ReportAssertionFailure(expr, "", file, line);
                DebugBreak();
            }
#endif
        }

        [Conditional("AASSERTIONS_ENABLED")]
        public static void AAssertMsg(bool expression,
                                     string message,
                                     [CallerArgumentExpression("expression")] string expr = "",
                                     [CallerFilePath] string file = "",
                                     [CallerLineNumber] Int32 line = 0)
        {
#if AASSERTIONS_ENABLED
            if (!expression)
            {
                Logger.ReportAssertionFailure(expr, message, file, line);
                DebugBreak();
            }
#endif
        }

        [Conditional("DEBUG")]
        [Conditional("AASSERTIONS_ENABLED")]
        public static void AAssertDebug(bool expression,
                                       [CallerArgumentExpression("expression")] string expr = "",
                                       [CallerFilePath] string file = "",
                                       [CallerLineNumber] Int32 line = 0)
        {
#if DEBUG && AASSERTIONS_ENABLED
            if (!expression)
            {
                Logger.ReportAssertionFailure(expr, "", file, line);
                DebugBreak();
            }
#endif
        }

        private static void DebugBreak()
        {
            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }
            else
            {
                // Alternative for non-attached debugger scenarios
                System.Environment.FailFast("Assertion failed");
            }
        }
    }
}