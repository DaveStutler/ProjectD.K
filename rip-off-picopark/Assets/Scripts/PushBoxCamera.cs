using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <citing>
/// reference from exercise 2, from dr. McKoy
/// </citing>

namespace CameraMovement
{
    public class PushBoxCamera : AbstractCamera
    {
        [SerializeField] public Vector2 topLeft;
        [SerializeField] public Vector2 bottomRight;
        private Camera managedCamera;
        private LineRenderer cameraLineRenderer;

        private void Awake()
        {
            managedCamera = gameObject.GetComponent<Camera>();
            cameraLineRenderer = gameObject.GetComponent<LineRenderer>();
        }

        //Use the LateUpdate message to avoid setting the camera's position before
        //GameObject locations are finalized.
        void LateUpdate()
        {
            var target1Position = this.Target1.transform.position;
            var target2Position = this.Target2.transform.position;
            var target3Position = this.Target3.transform.position;

            var cameraPosition = managedCamera.transform.position;

            // player 1
            if (target1Position.y >= cameraPosition.y + topLeft.y)
            {
                cameraPosition = new Vector3(cameraPosition.x, target1Position.y - topLeft.y, cameraPosition.z);
            }

            if (target1Position.y <= cameraPosition.y + bottomRight.y)
            {
                cameraPosition = new Vector3(cameraPosition.x, target1Position.y- bottomRight.y, cameraPosition.z);
            }

            if (target1Position.x >= cameraPosition.x + bottomRight.x)
            {
                cameraPosition = new Vector3(target1Position.x - bottomRight.x, cameraPosition.y, cameraPosition.z);
            }

            if (target1Position.x <= cameraPosition.x + topLeft.x)
            {
                cameraPosition = new Vector3(target1Position.x- topLeft.x, cameraPosition.y, cameraPosition.z);
            }
            // player 2
            if (target2Position.y >= cameraPosition.y + topLeft.y) 
            {
                cameraPosition = new Vector3(cameraPosition.x, target2Position.y - topLeft.y, cameraPosition.z);
            }

            if (target2Position.y <= cameraPosition.y + bottomRight.y)
            {
                cameraPosition = new Vector3(cameraPosition.x, target2Position.y- bottomRight.y, cameraPosition.z);
            }

            if (target2Position.x >= cameraPosition.x + bottomRight.x)
            {
                cameraPosition = new Vector3(target2Position.x - bottomRight.x, cameraPosition.y, cameraPosition.z);
            }

            if (target2Position.x <= cameraPosition.x + topLeft.x)
            {
                cameraPosition = new Vector3(target2Position.x- topLeft.x, cameraPosition.y, cameraPosition.z);
            }
            if (target3Position.y >= cameraPosition.y + topLeft.y)
            {
                cameraPosition = new Vector3(cameraPosition.x, target3Position.y - topLeft.y, cameraPosition.z);
            }
            //player 3
            if (target3Position.y <= cameraPosition.y + bottomRight.y)
            {
                cameraPosition = new Vector3(cameraPosition.x, target3Position.y- bottomRight.y, cameraPosition.z);
            }

            if (target3Position.x >= cameraPosition.x + bottomRight.x)
            {
                cameraPosition = new Vector3(target3Position.x - bottomRight.x, cameraPosition.y, cameraPosition.z);
            }

            if (target3Position.x <= cameraPosition.x + topLeft.x)
            {
                cameraPosition = new Vector3(target3Position.x- topLeft.x, cameraPosition.y, cameraPosition.z);
            }

            managedCamera.transform.position = cameraPosition;

            if (this.DrawLogic)
            {
                cameraLineRenderer.enabled = true;
                DrawCameraLogic();
            }
            else
            {
                cameraLineRenderer.enabled = false;
            }
        }

        public override void DrawCameraLogic()
        {
            var z = this.Target1.transform.position.z - this.managedCamera.transform.position.z;

            cameraLineRenderer.positionCount = 5;
            cameraLineRenderer.useWorldSpace = false;
            cameraLineRenderer.SetPosition(0, new Vector3(topLeft.x, topLeft.y, z));
            cameraLineRenderer.SetPosition(1, new Vector3(bottomRight.x, topLeft.y, z));
            cameraLineRenderer.SetPosition(2, new Vector3(bottomRight.x, bottomRight.y, z));
            cameraLineRenderer.SetPosition(3, new Vector3(topLeft.x, bottomRight.y, z));
            cameraLineRenderer.SetPosition(4, new Vector3(topLeft.x, topLeft.y, z));
        }
    }
}
