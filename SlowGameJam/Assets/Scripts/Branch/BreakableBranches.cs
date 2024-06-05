using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBranches : MonoBehaviour
{
    public Collider2D branchCollider;
    public SpriteRenderer spriteRend;
    public Animator branchAnim;

    [SerializeField] float animTime;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="Player")
        {
            StartCoroutine("Crumble");
        }
    }
    IEnumerator Crumble()
    {
        branchAnim.Play("BreakableBranches");
        yield return new WaitForSeconds(animTime);
        Components(false);
    }
    private void Components(bool state)
    {
        spriteRend.enabled = state;
        branchCollider.enabled = state;
    }
}
