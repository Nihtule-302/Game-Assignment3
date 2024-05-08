using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // References
    Player player;

    // Movement parameters
    [SerializeField] float speed = 40f;
    int direction = 1;

    // Dash parameters
    private float dashDuration = 2f;
    private float dashElapsedTime;
    public float dashDistance = 50f;
    [SerializeField] private AnimationCurve curve;

    [SerializeField] GameObject returnPoint;
    Vector3 targetPos;

    // Dash status
    public bool playerIsDashing = false;

    

    private void Start()
    {
        targetPos = returnPoint.transform.position;
    }

    void Update()
    {
        // Regular movement
        transform.Translate(Vector3.forward * direction * speed * Time.deltaTime);

        // Check if player is dashing and execute dash behavior
        if (playerIsDashing)
        {
            performDash();
        }
    }

    public void playerNotLooking() => direction = 1;
    public void goBack() => direction = -1;
    public void stop() => direction = 0;

    void performDash()
    {
        // Update elapsed time for dash
        dashElapsedTime += Time.deltaTime;

        // Calculate percentage of completion for the dash
        float t = Mathf.Clamp01(dashElapsedTime / dashDuration);

        // Interpolate position using a curve
        transform.position = Vector3.Lerp(transform.position, targetPos, t);

        // If dash is complete, reset parameters
        if (t >= 1.0f)
        {
            playerIsDashing = false;
            dashElapsedTime = 0f;
        }
    }


}