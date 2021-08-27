#!/usr/bin/env bash

# Post Build Script

##################################################
# Run UI Tests in Test Cloud
##################################################

set -e # Exit immediately if a command exits with a non-zero status (failure)

# variables
shouldRunUITestsInTestCloud=$RunUITestsInTestCloud # yes/no flag
appCenterLoginApiToken=$appCenterLoginApiToken # these all come from the build environment variables
appName="Crew.Mock/Crew.Mock"
deviceSetName=$UITestDeviceSet
testSeriesName="smoke-tests"

echo 
echo "**************************************************************************************************"
echo "Run Xamarin.UITests in Test Cloud"
echo "**************************************************************************************************"
echo "Source directory: $APPCENTER_SOURCE_DIRECTORY"
echo "Output directory: $APPCENTER_OUTPUT_DIRECTORY"
echo "    Run UI Tests: $RunUITestsInTestCloud"
echo "        App Name: $appName"
echo "      Device Set: $deviceSetName"
echo "     Test Series: $testSeriesName"
echo 

if [ $shouldRunUITestsInTestCloud != "yes" ]
then
    echo "> Should run UI tests in Test Cloud:" $shouldRunUITestsInTestCloud
else
    echo "> Build UI Test project"
    echo "Command: find $APPCENTER_SOURCE_DIRECTORY -regex '.*UITest.*\.csproj' -exec msbuild {} /t:Build \;"
    echo

    # using msbuild, build the "Build" target
    find $APPCENTER_SOURCE_DIRECTORY -regex '.*UITest.*\.csproj' -exec msbuild {} /t:Build \;

    echo
    echo "> UI test command to run:"
    echo "appcenter test run uitest" 
    echo "--app $appName" 
    echo "--devices $deviceSetName"
    echo "--app-path $APPCENTER_OUTPUT_DIRECTORY/*.ipa"
    echo "--test-series $testSeriesName"
    echo "--locale \"en_US\"" 
    echo "--build-dir $APPCENTER_SOURCE_DIRECTORY/Crew.Mock.UITests/bin/Debug"
    echo "--uitest-tools-dir $APPCENTER_SOURCE_DIRECTORY/Crew.Mock.UITests/bin/Debug"
    echo "--token $appCenterLoginApiToken"

    echo ""
    echo "> Run UI test command"
    # Note: must put a space after each parameter/value pair
    appcenter test run uitest \
    --app $appName \
    --devices $deviceSetName \
    --app-path $APPCENTER_OUTPUT_DIRECTORY/*.ipa \
    --test-series $testSeriesName \
    --locale "en_US" \
    --build-dir $APPCENTER_SOURCE_DIRECTORY/Crew.Mock.UITests/bin/Debug \
    --uitest-tools-dir $APPCENTER_SOURCE_DIRECTORY/Crew.Mock.UITests/bin/Debug \
    --token $appCenterLoginApiToken 
fi

echo ""
echo "**************************************************************************************************"
echo "Post Build Script complete"
echo "**************************************************************************************************"
