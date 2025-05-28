using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject Sword;
    public float attackDuration = 0.3f;
    public float moveForce = 5f;

    private Rigidbody rb;
    private PlayerMovementJump PlayerScript;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Sword.SetActive(false);
        PlayerScript = GetComponent<PlayerMovementJump>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 inputDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if (PlayerScript.isGrounded)
            {
                if (inputDir == Vector3.zero)
                {
                    StartCoroutine(Attack("GroundAttack1", Vector3.zero));
                }
                else
                {
                    StartCoroutine(Attack("GroundMoveDiagonalAttack", inputDir));
                }
            }
            else
            {
                StartCoroutine(Attack("AirAttack", Vector3.zero));
            }
        }
    }

    private IEnumerator Attack(string attackName, Vector3 forceDir)
    {
        Debug.Log("Attack started: " + attackName);
        Sword.SetActive(true);

        if (forceDir != Vector3.zero)
        {
            rb.AddForce(forceDir.normalized * moveForce, ForceMode.Impulse);
        }

        yield return new WaitForSeconds(attackDuration);

        Sword.SetActive(false);
        Debug.Log("Attack finished: " + attackName);
    }
}
