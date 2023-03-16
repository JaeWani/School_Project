using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public enum dir
    {
        Left,
        Right,
        Up,
        Down
    }
    [SerializeField] List<GameObject> Objects = new List<GameObject>();
    public void _Flame(dir d)
    {
        StartCoroutine(start());
        IEnumerator start()
        {
            Vector2 pos = transform.position;
            switch(d)
            {
            case dir.Right: 
            for(int i = 0; i < Objects.Count; i++)
            {
               Objects[i].SetActive(true);
               Objects[i].transform.position = new Vector2(i + 1 + pos.x,0.5f + pos.y);
               yield return new WaitForSeconds(0.1f);
            }
            break;
            case dir.Left:
            for(int i = 0; i < Objects.Count; i++)
            {
                Objects[i].SetActive(true);
                Objects[i].transform.position = new Vector2(-i - 1 + pos.x,0.5f + pos.y);
                yield return new WaitForSeconds(0.1f);
            }
            break;
            case dir.Up:
            for(int i = 0; i < Objects.Count; i++)
            {
                Objects[i].SetActive(true);
                Objects[i].transform.position = new Vector2(0 + pos.x,i+1 + pos.y);
                yield return new WaitForSeconds(0.1f);
            }
            break;
            case dir.Down:
            for(int i = 0; i < Objects.Count; i++)
            {
                Objects[i].SetActive(true);
                Objects[i].transform.position = new Vector2(0 + pos.x,-i-1 + pos.y);
                yield return new WaitForSeconds(0.1f);
            }
            break;
            
            }
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }
    private void OnDisable()
    {
        ObjectPooler.ReturnToPool(gameObject);
    }
}
