using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = -30f; // 음수 = 시계 방향 & 양수 = 반시계 방향

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameOver == false){
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime); // params = (x, y, z)
        }
    }
}
