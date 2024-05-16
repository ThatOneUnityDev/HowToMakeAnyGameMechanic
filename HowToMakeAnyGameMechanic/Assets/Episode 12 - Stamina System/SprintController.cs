using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SprintController : MonoBehaviour
{
    [SerializeField] private float currentStamina;
    [SerializeField] private float maxStamina;

    [SerializeField] private int sprintSpeed;
    [SerializeField] private int walkSpeed;

    [SerializeField] private float staminaDrainRate;
    [SerializeField] private float staminaRecoverRate;

    [SerializeField] private bool isSprinting;

    [SerializeField] private Slider staminaBar;

    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        playerController.SetMoveSpeed(walkSpeed);

        staminaBar.value = currentStamina;
        staminaBar.maxValue = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.LeftShift) && x != 0)
        {
            if (currentStamina > 0)
            {
                isSprinting = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }

        if(isSprinting == true)
        {
            playerController.SetMoveSpeed(sprintSpeed);
        }
        else
        {
            playerController.SetMoveSpeed(walkSpeed);
        }

        staminaBar.value = currentStamina;
    }

    private void FixedUpdate() 
    {
        if(isSprinting == true && currentStamina>0)
        {
            //reduce our stamina
            currentStamina -= (Time.fixedDeltaTime + staminaDrainRate);
            if(currentStamina<=0)
            {
                isSprinting = false;
            }
        }
        else if(currentStamina<=maxStamina)
        {
            // increase our stamina
            currentStamina += (Time.fixedDeltaTime + staminaRecoverRate);
        }
    }
}
