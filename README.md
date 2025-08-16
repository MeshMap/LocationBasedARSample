# Location-based AR sample project for Unity 6

An AR sample project that demonstrates how to position objects around a map and localize on site with fiducial marker tracking.

> [!WARNING]
> The first time you open this Unity project on your computer, you may get two popups:<br>
>  1. An error saying that a package (e.g., XREAL) experienced a problem. Click **Continue**. Our `UPMWrapper` feature will resolve the issue once the project is open.<br>
>  2. A notification about Meta OVR Settings having changed and Unity Editor needing to restart. Click **Restart** and the project will work when Unity opens again.

> [!WARNING]
> On Meta Quest 3, do **NOT** click "Fix All" in the Project Validation and Meta XR project settings tabs! **This will override crucial settings** and **break camera passthrough** access when marker tracking. Follow the instructions in our [docs](https://docs.meshmap.com/unity-sdk/xr/cross-platform-management/meta-quest-3#id-6.-project-settings-greater-than-xr-plug-in-management-greater-than-project-validation) instead.

## Device Support

Magic Leap 2 ✅ | Meta Quest 3 ✅ | XREAL Air 2 Ultra (in development)

## Requirements

- Unity **6000.0.50f1 LTS** or later
- Android Build Support
- Universal Render Pipeline (URP)

## Getting Started

Clone the repository and open the project using [Unity Hub](https://unity.com/unity-hub).

Follow the [documentation](https://docs.meshmap.com/unity-sdk/overview) and [device guides](https://docs.meshmap.com/unity-sdk/xr/cross-platform-management) to configure settings, permissions, and installation of the app to your target device.
