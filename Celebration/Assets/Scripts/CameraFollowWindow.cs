using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowWindow : MonoBehaviour
{

    public Vector3 zOffset = new Vector3(0, 0, -10);
    public Rect window = new Rect(0, 0, 1, 1);
    Vector3[] cameraCornerCoords = { new Vector3(0,1,0), new Vector3(1,1,0), new Vector3(0,1,0), new Vector3(0,0,0)};
    public Transform target;

    public Transform topLeft;
    public Transform topRight;
    public Transform bottomRight;
    public Transform bottomleft;

    Vector4 whichSideHit = new Vector4(0, 0, 0, 0);     //left = x, top = y, right = z, bottom = w

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < 4; i++)
        {
            Vector3 f = Camera.main.ViewportToWorldPoint(window.Corner(i)) - zOffset;
            Vector3 t = Camera.main.ViewportToWorldPoint(window.Corner(i + 1)) - zOffset;
            Gizmos.DrawLine(f, t);
        }

        Gizmos.color = Color.green;

        Gizmos.DrawLine(topRight.position, topLeft.position);
        Gizmos.DrawLine(topLeft.position, bottomleft.position);
        Gizmos.DrawLine(topRight.position, bottomRight.position);
        Gizmos.DrawLine(bottomRight.position, bottomleft.position);
    }


    void Update()
    {
        whichSideHit = new Vector4(0, 0, 0, 0);

        //Vector4 whichSideHit = new Vector4(0, 0, 0, 0);     //left = x, top = y, right = z, bottom = w

        //get pos of target
        Vector3 targetPos = target.position; //world coords

        //convert to viewport
        Vector2 targetViewPos = Camera.main.WorldToViewportPoint(targetPos);

        //Clamp this position to the closest point inside the window
        Vector2 goalViewPos = window.Clamp(targetViewPos);

        //convert back to world coordinates
        Vector3 goalpos = Camera.main.ViewportToWorldPoint(goalViewPos);

        //convert both points into the local coordinate sys. of cam
        targetPos = transform.InverseTransformPoint(targetPos);
        goalpos = transform.InverseTransformPoint(goalpos);

        //if (BoundsCheck(topLeft, bottomRight, cameraCornerCoords) == true)
        //{
        //    Debug.Log("InBounds");

        //    //compute the necessary camera movement in the xy plane for the target to appear at the goal

        Vector3 move = targetPos - goalpos;
        move.z = 0;

        transform.Translate(move);

        //}
        //else
        //{
        //    Vector3 move = targetPos - goalpos;
        //    move.z = 0;

        //    if (whichSideHit.x == 1)
        //    {
        //        if (move.x <= 0)
        //            move.x = 0;
        //    }

        //    if (whichSideHit.z == 1)
        //    {
        //        if (move.x >= 0)
        //            move.x = 0;
        //    }

        //    if (whichSideHit.y == 1)
        //    {
        //        if (move.y >= 0)
        //            move.y = 0;
        //    }

        //    if (whichSideHit.w == 1)
        //    {
        //        if (move.y <= 0)
        //            move.y = 0;
        //    }

        //transform.Translate(move);
        //}

        Debug.Log(whichSideHit);
    }

    /// <summary>
    /// Bounds Check for an array of points forming a box
    /// </summary>
    bool BoundsCheck(Vector3 topLeft, Vector3 bottomRight, Vector3[] cameraCornerCoords)
    {
        for (int i = 0; i < cameraCornerCoords.Length; i++)
        {
            Vector3 pointCheck = Camera.main.ViewportToWorldPoint(cameraCornerCoords[i]);
            bool b1 = pointCheck.x <= topLeft.x;
            bool b2 = bottomRight.x <= pointCheck.x;
            bool b3 = topLeft.y <= pointCheck.y;
            bool b4 = pointCheck.y <= bottomRight.y;

            if (b1 || b2 || b3 || b4)
            {
                if (b1)
                    whichSideHit.x = 1;

                if (b3)
                    whichSideHit.y = 1;

                if (b2)
                    whichSideHit.z = 1;

                if (b4)
                    whichSideHit.w = 1;

                Debug.LogError("Not In bounds");
                // Corners are not in bounding box
                return false;
            }
        }

        return true;
    }


    /// <summary>
    /// Bounds Check for a point
    /// </summary>
    bool BoundsCheck(Vector2 topLeft, Vector2 bottomRight, Vector3 pointCoords)
    {
            Vector3 pointCheck = Camera.main.ViewportToWorldPoint(pointCoords);
            bool b1 = pointCheck.x <= topLeft.x;
            bool b2 = bottomRight.x <= pointCheck.x;
            bool b3 = topLeft.y <= pointCheck.y;
            bool b4 = pointCheck.y <= bottomRight.y;

            if (b1 || b2 || b3 || b4)
            {
                if (b1)
                    whichSideHit.x = 1;

                if (b3)
                    whichSideHit.y = 1;

                if (b2)
                    whichSideHit.z = 1;

                if (b4)
                    whichSideHit.w = 1;

                Debug.LogError("Not In bounds");
                // Point is not in bounding box
                return false;
            }

        return true;
    }
}
