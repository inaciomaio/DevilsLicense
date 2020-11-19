using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path : MonoBehaviour
{
    [SerializeField, HideInInspector]
    private List<Vector2> points;

    [SerializeField, HideInInspector]
    private List<Vector2> pointsR;

    [SerializeField, HideInInspector]
    private List<Vector2> pointsL;

    public Path(Vector2 centre)
    {
        pointsR = new List<Vector2>
        {
            centre + Vector2.left,
            centre + (Vector2.left+Vector2.up) * .5f,
            centre + (Vector2.right+Vector2.down) * .5f,
            centre + Vector2.right
        };

        pointsR = new List<Vector2>
        {
            centre + Vector2.left,
            centre + (Vector2.left+Vector2.up) * .5f,
            centre + (Vector2.right+Vector2.down) * .5f,
            centre + Vector2.right
        };

        pointsL = new List<Vector2>
        {
            centre + Vector2.left,
            centre + (Vector2.left+Vector2.up) * .5f,
            centre + (Vector2.right+Vector2.down) * .5f,
            centre + Vector2.right
        };
    }

    public void AddSegment(Vector2 anchorPos)
    {
        //Points
        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
        points.Add((points[points.Count - 1] + anchorPos * .5f));
        points.Add(anchorPos);

        //PointsR
        pointsR.Add(pointsR[pointsR.Count - 1] * 2 - pointsR[pointsR.Count - 2]);
        pointsR.Add((pointsR[pointsR.Count - 1] + anchorPos * .5f));
        pointsR.Add(anchorPos);

        //PointsL
        pointsL.Add(pointsR[pointsL.Count - 1] * 2 - pointsL[pointsL.Count - 2]);
        pointsL.Add((pointsR[pointsL.Count - 1] + anchorPos * .5f));
        pointsL.Add(anchorPos);
    }
}