using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour, InterfaceInteractable
{

    public string NPCName;

    private Animator animator;
    public Transform playerGirl;
    public Transform playerBoy;
    private bool isLookingAtPlayer = false;
    Quaternion m_MyQuaternion;
    private Transform playerTransform = null;
    float m_Speed = 1.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        m_MyQuaternion = new Quaternion();

        //npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform)
    {
        //float playerHeight = 1f;
        //sLookingAtPlayer = !isLookingAtPlayer;

        //if (isLookingAtPlayer)
        //{
        //LookAtPlayer();
        //}
        //else
        //{
        //LookBack();
        //}
        //m_MyQuaternion.SetFromToRotation(transform.position, playerTransform.position);
        //transform.rotation = m_MyQuaternion * transform.rotation;
        if (playerGirl != null) {
            playerTransform = playerGirl; }
        else
        {
            playerTransform = playerBoy;
        }
        GetTransform().LookAt(playerTransform);
    }

    public string GetInteractText()
    {
        return "talk with " + NPCName;
    }

    public Transform GetTransform()
    {
        return transform;
    }
    void LookAtPlayer()
    {
        if (playerTransform != null)
        {
            // Calculate the direction to the player
            Vector3 lookDirection = playerTransform.position - transform.position; 
            //lookDirection.y = 0f; // Keep the NPC looking level

            // Rotate the NPC to face the player
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }
    void LookBack()
    {
        // Set the NPC's rotation to its original rotation
        // You might want to adjust this based on your initial NPC orientation
        transform.rotation = Quaternion.identity;
    }
}