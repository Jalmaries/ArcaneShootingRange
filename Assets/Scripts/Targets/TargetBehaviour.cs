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


    private void Awake()
    {
        this.gameObject.transform.DOPath(path, duration, pathType, pathMode, 5, Color.red)
            .SetLoops(-1);


    }



}
