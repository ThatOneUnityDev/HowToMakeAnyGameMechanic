using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform playerVisual;

    private Vector3 playerScale;

    private const string WALK_PARAM = "IsWalking";
    private const string ATTACK_PARAM = "IsAttacking";
    // Start is called before the first frame update
    void Start()
    {
        playerScale = playerVisual.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        anim.SetBool(WALK_PARAM, x != 0);

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.SetTrigger(ATTACK_PARAM);
        }

        if (x > 0)
        {
            playerVisual.transform.localScale = playerScale;
        }
        else if (x < 0)
        {
            playerVisual.transform.localScale = new Vector3(-playerScale.x, playerScale.y, playerScale.z);
        }
    }
}
