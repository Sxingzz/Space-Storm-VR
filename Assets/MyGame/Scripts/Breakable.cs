using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakablePieces;
    public float timeBreak = 2;
    private float timer = 0;
    public UnityEvent OnBreakEvent;

    private void Start()
    {
        foreach (var piece in breakablePieces)
        {
            piece.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if (timer > timeBreak)
        {
            foreach (var piece in breakablePieces)
            {
                piece.SetActive(true);
                piece.transform.parent = null;
            }

            OnBreakEvent.Invoke();

            gameObject.SetActive(false);
        }

        
    }

}
