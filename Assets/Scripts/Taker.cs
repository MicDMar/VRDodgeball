using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Taker : MonoBehaviour
{

    public Transform handLocation;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        var cobject = other.collider.gameObject;
        if (cobject.CompareTag("claimedball") == false)
            return;
        
        
        var item = cobject.GetComponent<Carryable>();

        var wanderer = GetComponent<Wanderer>();
        // Don't take if it isn't ours
        if (other.gameObject.CompareTag("ball") == true) return;

        if (item != null && wanderer.heldBall == null)
        {
            /*item.tag = "heldball";

            wanderer.heldBall = other.gameObject;
            wanderer.targetBall = null;

            item.transform.parent = handLocation;
            item.transform.position = handLocation.position;

            var rigidbody = item.GetComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            */
            wanderer.TakeBall(other.transform);
        }
    }
}
