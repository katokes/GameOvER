using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefab; // Prefab of the cube to be spawned
    private ARRaycastManager raycastManager; // ARRaycastManager to perform raycasting
                                             //   private XROrigin xrOrigin; // XROrigin to handle AR tracking
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); // List to store raycast hits


    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        //       xrOrigin = GetComponent<XROrigin>();
        CheckXRStatus();
    }

    private void Update()
    {
        //       if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))
        {
            //    Vector2 touchPosition = Input.GetTouch(0).position;
            Vector2 clickPosition = Input.mousePosition;

            if (raycastManager.Raycast(clickPosition, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                Instantiate(cubePrefab, hitPose.position, hitPose.rotation);//.transform.SetParent(xrOrigin.transform);
            }
        }
    }

    public void CheckXRStatus()
    {
        if (UnityEngine.XR.XRSettings.enabled)
        {
            Debug.Log("XR is active.");
        }
        else
        {
            Debug.Log("XR is not available.");
        }
    }
}
