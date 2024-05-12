using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyController : MonoBehaviour
{

    [SerializeField] private Animator anim;

    private const string HIT_PARAM = "IsHit";
    private const string PLAYER_HITBOX_TAG = "PlayerHitBox";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == PLAYER_HITBOX_TAG)
        {
            anim.SetTrigger(HIT_PARAM);
        }
    }
}
