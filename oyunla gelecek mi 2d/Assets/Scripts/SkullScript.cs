using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthBarScripts.health -= 10f;
    }
}
