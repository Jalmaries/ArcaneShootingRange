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

    public Vector3 startPosition;

    private void Awake()
    {
        this.gameObject.transform.DOPath(path, duration, pathType, pathMode, 5, Color.red)
            .SetLoops(-1);
    }

    private void OnDisable()
    {
        gameObject.transform.position = startPosition;
    }

}
