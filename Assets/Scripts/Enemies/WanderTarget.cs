using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(Collider))]
public class WanderTarget : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Wanderer>() == null) return;
        
        // Delete self when touched by AiCharacterController
        var character = other.GetComponent<AICharacterControl>();

        if (character)
        {
            Destroy(gameObject);
        }
    }
}
