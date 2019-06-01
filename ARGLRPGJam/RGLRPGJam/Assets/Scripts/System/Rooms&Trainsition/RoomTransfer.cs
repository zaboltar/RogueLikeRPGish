using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public Vector3 cameraChange;
    public Vector3 playerChange;
    private CameraController cam;
    public BoxCollider2D newBoundBox;

    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D (Collider2D other )
    {
        if (other.CompareTag("Player"))
        {
            
            //cam.boundBox = newBoundBox;
            //cam.minPosition += cameraChange;
            //cam.maxPosition += cameraChange;

            cam.minBounds += cameraChange;
            cam.maxBounds += cameraChange;

            other.transform.position += playerChange;

            cam.boundBox = newBoundBox;
            cam.SetBounds(newBoundBox);
           
           if (needText)
           {
               StartCoroutine(PlaceNameCo());
           }
        }
    }

    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(4f);
        text.SetActive(false);
    }
}
