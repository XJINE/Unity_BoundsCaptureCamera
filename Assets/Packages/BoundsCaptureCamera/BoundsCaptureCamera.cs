using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class BoundsCaptureCamera : TransformMonoBehaviour
{
    // NOTE:
    // If you want to call UpdateCaptureArea() when bounds update,
    // register UpdateCaptureArea() to BoundsMonoBehaviour.boundsUpdateEvent in Inspector.

    #region Field

    public BoundsMonoBehaviour[] bounds;

    public Vector4 margin;

    protected Vector4 prevMargin;

    protected new Camera camera;

    #endregion Field

    #region Method

    protected virtual void Update()
    {
        if (this.margin != this.prevMargin) 
        {
            UpdateCaptureArea();
            this.prevMargin = this.margin;
        }
    }

    public override bool Initialize()
    {
        if (!base.Initialize()) 
        {
            return false;
        }

        this.prevMargin = this.margin;

        // CAUTION:
        // UpdateCaptureArea() may called from outside before this.Awake() called.
        // For example, BoundsMonoBehaviour.BoundsUpdateEvent sometimes call it.
        // To avoid NullReferenceException, keep camera reference in here.

        this.camera = base.GetComponent<Camera>();

        // CAUTION:
        // BoundsMonoBehaviour will be initialized in Awake().
        // So need to manually initialize to avoid a NullReferenceException when a scene starts.

        foreach (var bounds in this.bounds) 
        {
            bounds.Initialize();
        }
      
        UpdateCaptureArea();

        return true;
    }

    public virtual void UpdateCaptureArea()
    {
        if (!base.IsInitialized)
        {
            Initialize();
            return;
        }

        float minX = this.bounds[0].Min.x;
        float minY = this.bounds[0].Min.y;
        float maxX = this.bounds[0].Max.x;
        float maxY = this.bounds[0].Max.y;

        for (int i = 1; i < this.bounds.Length; i++)
        {
            if (this.bounds[i].Min.x < minX) { minX = this.bounds[i].Min.x; }
            if (this.bounds[i].Min.y < minY) { minY = this.bounds[i].Min.y; }

            if (this.bounds[i].Max.x > maxX) { maxX = this.bounds[i].Max.x; }
            if (this.bounds[i].Max.y > maxY) { maxY = this.bounds[i].Max.y; }
        }

        this.camera.orthographic = true;

        this.camera.rect = new Rect(this.camera.rect.x,
                                    this.camera.rect.y,
                                    (maxX - minX) + margin.x + margin.z,
                                    (maxY - minY) + margin.y + margin.w);

        this.camera.orthographicSize = this.camera.rect.height / 2;

        this.camera.aspect = this.camera.rect.width / this.camera.rect.height;

        base.transform.position = new Vector3((minX + maxX) / 2 + (margin.z - margin.x) / 2,
                                              (minY + maxY) / 2 + (margin.y - margin.w) / 2,
                                              base.transform.position.z);

        // WARNING:
        // Need to do following setup. If not, output image will not show in fullscreen.

        if (this.camera.rect.width < 1 || this.camera.rect.height < 1)
        {
            this.camera.rect = new Rect(this.camera.rect.x, this.camera.rect.y, 1, 1);
        }
    }

    #endregion Method
}