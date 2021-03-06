#!/bin/bash
# Call this script with the component's build number

echo "build #$1"

mono xamarin-component.exe create-manually ViewShaker-$1.xam --name="View Shaker animation" --summary="An animation helper which adds a shaking effect to your views." --publisher="Robert Waggott" --website="https://github.com/robert-waggott/Xamarin.ViewShaker" --details="Details.md" --license="License.md" --getting-started="GettingStarted.md" --icon="icons/ViewShaker_128x128.png" --icon="icons/ViewShaker_512x512.png" --library="ios-unified":"lib/ViewShaker.Unified.dll" --library="ios":"lib/ViewShaker.Classic.dll" --sample="iOS Sample. Sample of how to use the component in your iOS application.":"samples/Sample.sln"