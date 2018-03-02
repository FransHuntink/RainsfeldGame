using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CameraBehaviour : MonoBehaviour {
    private float defaultZ = -10;
    private float heightOffset = 1.5f;
    [Header("Camera settings (multipliers)")]
    [SerializeField]
    private float cameraSpeed;

    void Awake()
    {
        ColorManager.instance.mainCamera = this.gameObject;
    }


	// Update is called once per frame
	void Update () {
        Vector3 targetPos;
        targetPos.x = PlayerManager.instance.playerObject.transform.position.x;
        targetPos.y = PlayerManager.instance.playerObject.transform.position.y + heightOffset;
        targetPos.z = defaultZ;
        gameObject.transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * cameraSpeed);
	}

    //this function passes values to the coroutine
    public void PassUpdateColor(Color color)
    {
        StartCoroutine((UpdateColor((color))));
    }

    //update color of background color of the sky
    private IEnumerator UpdateColor(Color targetColor)
    {
        float t = 0;

            while (t < 1)
            {
                gameObject.GetComponent<Camera>().backgroundColor = Color.Lerp(gameObject.GetComponent<Camera>().backgroundColor, targetColor, t);
                t += 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
            t = 0;
         
    }
}
