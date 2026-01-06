using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchToPlaceTarget : MonoBehaviour
{
    public GameObject targetPrefab;
    private GameObject spawnedTarget;

    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (raycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedTarget == null)
                {
                    spawnedTarget = Instantiate(targetPrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedTarget.transform.position = hitPose.position;
                }
            }
        }
    }
}
