using Leap.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPoseDetector : MonoBehaviour
{

    public LeapProvider leapProvider;
    public GameObject pSelectedIdentifier;

    private Transform selectedObject;
    private GameObject createdSelectedIdentifier;

    private bool isZooming = false;
    private float originalDistance = -1;


    void Start()
    {


    }

    void Update()
    {

        Debug.Log(selectedObject);

        Leap.Hand[] hands = new Leap.Hand[2] { leapProvider.GetHand(Chirality.Left), leapProvider.GetHand(Chirality.Right) };

        // Selecting object when pinching
        foreach (Leap.Hand hand in hands)
        {
            DeselectObject();

            if (hand == null || !hand.IsPinching() || selectedObject != null) break;
            Collider[] hitColliders = Physics.OverlapSphere(hand.GetPinchPosition(), 0.2f);


            // Looking at all hits and finding a new selectable when pinching
            foreach (Collider hitCollider in hitColliders)
                if (hitCollider.CompareTag("Selectable"))
                    SelectObject(hitCollider.transform);
        }

        if (hands[0] != null && hands[1] != null && hands[0].IsPinching() && hands[1].IsPinching())
        {
            float _pinchDistance = Vector3.Distance(hands[0].GetPredictedPinchPosition(), hands[1].GetPredictedPinchPosition());
            if (isZooming)
            {
                float _distance = _pinchDistance - originalDistance;

                Debug.Log(_distance);

                float x = Mathf.Clamp(_distance, 0.02f, 0.12f);
                float y = Mathf.Clamp(_distance, 0.02f, 0.12f);
                float z = Mathf.Clamp(_distance, 0.02f, 0.12f);

                selectedObject.localScale = new Vector3(x * 2.2f, y * 2.2f, z * 2.2f);
            }
            else
            {
                isZooming = true;
                originalDistance = _pinchDistance;
            }
        }



    }

    void SelectObject(Transform _selectedObject)
    {
        selectedObject = _selectedObject;
        if (createdSelectedIdentifier != null) Destroy(createdSelectedIdentifier);
        createdSelectedIdentifier = Instantiate(pSelectedIdentifier, _selectedObject);
        createdSelectedIdentifier.transform.position = _selectedObject.position;
    }

    void DeselectObject()
    {
        Destroy(createdSelectedIdentifier);
        createdSelectedIdentifier = null;
        selectedObject = null;
    }

}
