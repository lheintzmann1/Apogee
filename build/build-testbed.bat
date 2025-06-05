@ECHO OFF

cd ../src/Apogee.Testbed
ECHO "Building Apogee.Testbed"
dotnet build --configuration Debug --output ./bin/
IF %ERRORLEVEL% NEQ 0 (
    ECHO "Testbed build failed!"
    EXIT /B %ERRORLEVEL%
)
ECHO "Testbed built successfully."