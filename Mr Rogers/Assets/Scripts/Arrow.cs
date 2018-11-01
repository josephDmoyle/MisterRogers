using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
    float timer = 0f;
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer > 5f)
            Destroy(gameObject);
    }
}
