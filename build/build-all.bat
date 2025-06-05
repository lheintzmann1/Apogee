@ECHO OFF

ECHO "Building everything..."

CALL build-core.bat
IF %ERRORLEVEL% NEQ 0 (echo Error:%ERRORLEVEL% && exit)

CALL build-testbed.bat
IF %ERRORLEVEL% NEQ 0 (echo Error:%ERRORLEVEL% && exit)

ECHO "All assemblies built successfully."