using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(!other.CompareTag("Area"))
            return;
        Vector3 PlayerPos = GameManager.I.CurrentPlayer.transform.position;
        Vector3 MyPos = transform.position;
        float diffX = Mathf.Abs(PlayerPos.x - MyPos.x);
        float diffY = Mathf.Abs(PlayerPos.y - MyPos.y);

        Vector3 PlayerDir = GameManager.I.CurrentPlayer.inputVec;

        float dirX = PlayerDir.x < 0 ? -1 : 1;
        float dirY = PlayerDir.y < 0 ? -1 : 1;
        switch(transform.tag)
        {
            case "Ground":
                if(diffX > diffY)
                    transform.Translate(Vector3.right  * dirX * 40);
                 else if(diffX < diffY)
                    transform.Translate(Vector3.up * dirY * 40);
                break;
            case "Enemy":

                break;

        }
    }
}
