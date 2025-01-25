using UnityEngine;

public class WallController : MonoBehaviour {

    private enum Dir {
        Right = 1,
        Left = -1
    }

    [SerializeField]
    private Dir wallPosition;

    void Start() {
        Vector3 cameraCenter = Camera.main.transform.position;
        float cameraSize = Camera.main.GetComponent<Camera>().orthographicSize;
        float cameraSizeHeight = Camera.main.orthographicSize * 2;
        float cameraSizeWidt = cameraSizeHeight * Screen.width / Screen.height;

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        transform.position = new Vector3(cameraCenter.x, cameraCenter.y + (cameraSizeWidt * (float) wallPosition), 0);
        boxCollider.size = new Vector2(cameraSizeHeight, 6);
    }
}
