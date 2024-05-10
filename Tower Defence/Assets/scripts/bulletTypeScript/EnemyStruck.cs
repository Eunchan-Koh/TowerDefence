using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStruck : MonoBehaviour
{
    void Start(){
        Destroy(gameObject, .4f);
    }
}
