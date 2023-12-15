using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowMechanics : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private Transform grenadeParent;
    [SerializeField] private Rigidbody grenadePrefab, currentGrenade;


    private void Start()
    {
        Destroy(currentGrenade.gameObject);
    }
    void Update()
    {
        HoldCheck();
    }

    private float lastHoldValue;
    private void HoldCheck()
    {
        bool leftClickHold = Input.GetMouseButton(0);
        bool rightClickHold = Input.GetMouseButton(1);

        bool holding = leftClickHold || rightClickHold;
        animator.SetBool("hold", holding);

        float holdValue = 0f;
        if (leftClickHold && rightClickHold)
        {
            holdValue = 0.5f;
        }
        else if (leftClickHold)
        {
            holdValue = 1f;
        }
        else if (rightClickHold)
        {
            holdValue = 0f;
        }

        float currentHoldValue = Mathf.MoveTowards(lastHoldValue, holdValue, Time.deltaTime * 3f);
        if (!holding)
        {
            ThrowCheck(lastHoldValue);
        }

        animator.SetFloat("holdValue", holdValue);
        lastHoldValue = currentHoldValue;
    }

    public void CreateGrenade()
    {
        currentGrenade = Instantiate(grenadePrefab, grenadeParent);
        currentGrenade.transform.localPosition = new Vector3(0.809427917f, 1.39534819f, -1.07923508f);
        currentGrenade.transform.localRotation = Quaternion.Euler(180f, 10f, -237f);
        currentGrenade.transform.localScale = new Vector3(40f, 40f, 40f);
    }

    [SerializeField] private Transform cameraTransform;
    private void ThrowCheck(float holdValue)
    {
        bool throwing = Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1);
        if (!throwing)
        {
            return;
        }


        currentGrenade.transform.SetParent(null);
        currentGrenade.transform.localScale *= 1.6f;
        currentGrenade.isKinematic = false;


        float multiplier = 1f + holdValue;
        Vector3 direction = cameraTransform.forward * 0.7f + cameraTransform.up * 0.4f;
        Vector3 force = direction * 500f * multiplier;
        currentGrenade.AddForce(force, ForceMode.Force);


    }



}
