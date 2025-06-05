using Apogee.Core;

namespace Apogee.Testbed
{
    class Program
    {
        static int Main()
        {
            Logger.AFatal("This is a fatal message with a float: {0}", 3.14f);
            Logger.AError("This is an error message with a float: {0}", 3.14f);
            Logger.AWarn("This is a warn message with a float: {0}", 3.14f);
            Logger.AInfo("This is an info message with a float: {0}", 3.14f);
            Logger.ADebug("This is a debug message with a float: {0}", 3.14f);
            Logger.ATrace("This is a trace message with a float: {0}", 3.14f);
            Asserts.AAssert(true);
            Asserts.AAssertMsg(42 > 0, "Number should be positive");
            Asserts.AAssert(1 == 0);
            return 0;
        }
    }
}