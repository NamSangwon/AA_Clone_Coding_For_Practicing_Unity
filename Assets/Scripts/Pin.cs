using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private bool isPinned = false;
    private bool isLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPinned == false 
        && isLaunched == true ){
            transform.position += Vector3.up * moveSpeed * Time.deltaTime; // deltaTime이 매번 다르므로 Pin이 꽂힐 때 완전한 원이 되지 않음 -> FixedUpdate()로 변경하여 해결
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isPinned = true;
        if (other.gameObject.tag == "Target"){
            // Target에 Pin 부착
            GameObject childObject = transform.Find("Square").gameObject; // pin의 자식 개체 불러오기 1
            // GameObject childObject = transform.GetChild(0).gameObject; // pin의 자식 개체 불러오기 1
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>(); // pin의 자식 개체 불러오기 2
            childSprite.enabled = true; // pin의 자식 개체 활성화 (unhide)

            transform.SetParent(other.gameObject.transform); // pin을 target의 자식으로 추가

            // Goal 숫자 감소
            GameManager.instance.DecreaseGoal();
        }

        if (other.gameObject.tag == "Pin"){
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch(){
        isLaunched = true;
    }
}
