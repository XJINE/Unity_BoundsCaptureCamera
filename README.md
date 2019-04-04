# Unity_BoundsCaptureCamera

<img src="https://github.com/XJINE/Unity_BoundsCaptureCamera/blob/master/Screenshot.png" width="100%" height="auto" />

Set orthographic camera viewport rect to capture all of the selected bounds.

## Import to Your Project

You can import this asset from UnityPackage.

- [BoundsCaptureCamera.unitypackage](https://github.com/XJINE/Unity_BoundsCaptureCamera/blob/master/BoundsCaptureCamera.unitypackage)

### Dependencies

You have to import following assets to use this asset.

- [Unity_BoundsMonoBehaviour](https://github.com/XJINE/Unity_BoundsMonoBehaviour)

## How to Use

Add ``BoundsCaptureCamera.cs`` to camera and set some Bounds which inherit ``BoundsMonoBehaviour.cs`` in Inspector.

And, set ``BoundsCaptureCamera.UpdateCaptureArea()`` method to ``BoundsMonoBehaviour.BoundsUpdateEvent`` if you need.
