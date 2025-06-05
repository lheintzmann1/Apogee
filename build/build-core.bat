@ECHO OFF
SET ORIGINAL_DIR=%CD%
cd ../src/Apogee.Core
ECHO "Building Apogee.Core"
dotnet build --configuration Debug --output ./bin/
IF %ERRORLEVEL% NEQ 0 (
    ECHO "Engine build failed!"
    CD %ORIGINAL_DIR%
    EXIT /B %ERRORLEVEL%
)
ECHO "Engine built successfully."
CD %ORIGINAL_DIR%