# Unity_BoundsCaptureCamera

<img src="https://github.com/XJINE/Unity_BoundsCaptureCamera/blob/master/Screenshot.png" width="100%" height="auto" />

Set orthographic camera viewport rect to capture all of the selected bounds.

## Import to Your Project

You can import this asset from UnityPackage.

- [BoundsCaptureCamera.unitypackage](https://github.com/XJINE/Unity_BoundsCaptureCamera/blob/master/BoundsCaptureCamera.unitypackage)

### Dependencies

You have to import following assets to use this asset.

- [Unity_IMonoBehaviour](https://github.com/XJINE/Unity_IMonoBehaviour)

## How to Use

Add ``BoundsCaptureCamera.cs`` to camera object and set Bounds which inherit ``TransformBoundsMonoBehaviour.cs`` in Inspector.

If you want to auto update when Bounds update, set ``BoundsCaptureCamera.UpdateCaptureArea()`` to ``TransformBoundsMonoBehaviour.BoundsUpdateEvent``.
