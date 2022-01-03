using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetBehaviour : MonoBehaviour
{
    public float duration;
    public PathType pathType;
    public PathMode pathMode;
    public Vector3[] path;

    public Ease targetMoveAnimation;

    //public Vector3 startPosition;

    public int HP = 5;//Use for editor Only.
    public int scriptOnlyHp;//Use for script only. Will equal public HP.


    private void Awake()
    {
        scriptOnlyHp = HP;
        Debug.Log(scriptOnlyHp + "Awake");

        this.gameObject.transform.DOPath(path, duration, pathType, pathMode, 30, Color.red)
            .SetEase(targetMoveAnimation)
            .SetLoops(-1);
    }

    /*
    private void OnDisable()
    {
        gameObject.transform.position = startPosition;
    }
    */
}
