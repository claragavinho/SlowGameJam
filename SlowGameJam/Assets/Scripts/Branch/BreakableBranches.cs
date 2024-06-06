using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBranches : MonoBehaviour
{
    public Collider2D branchCollider;
    public SpriteRenderer spriteRend;
    public Animator branchAnim;
    private Rigidbody2D rb;

    [SerializeField] float animTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("Crumble");
        }
    }

    IEnumerator Crumble()
    {
        branchAnim.SetTrigger("Break");
        yield return new WaitForSeconds(animTime);

        rb.constraints = RigidbodyConstraints2D.None;
        Components(false);
    }
    private void Components(bool state)
    {
        //spriteRend.enabled = state;
        branchCollider.enabled = state;
    }
}
