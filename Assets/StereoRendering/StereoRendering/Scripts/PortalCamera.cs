// https://steamcommunity.com/app/358720/discussions/0/405694031550581171/#c405694031552884526

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public bool isLeftEye = true;
    public Camera vrCam;
    public Camera portalCam;

    private void Awake() {
        if (portalCam == null) portalCam = GetComponent<Camera>();
    }

    private void Start() {
        Valve.VR.EVREye eye;
        if (isLeftEye) {
            eye = Valve.VR.EVREye.Eye_Left;
        } else {
            eye = Valve.VR.EVREye.Eye_Right;
        }

        portalCam.projectionMatrix = HMDMatrix4x4ToMatrix4x4(SteamVR.instance.hmd.GetProjectionMatrix(eye, vrCam.nearClipPlane, vrCam.farClipPlane));//Valve.VR.EGraphicsAPIConvention.API_DirectX));

        portalCam.nearClipPlane = vrCam.nearClipPlane;
        portalCam.farClipPlane = vrCam.farClipPlane;
        portalCam.fieldOfView = vrCam.fieldOfView;

        portalCam.depth = vrCam.depth + 1;

        //portalCam.stereoConvergence = vrCam.stereoConvergence;
        //portalCam.stereoSeparation = vrCam.stereoSeparation;
    }

    private Matrix4x4 HMDMatrix4x4ToMatrix4x4(Valve.VR.HmdMatrix44_t input) {
        var m = Matrix4x4.identity;

        m[0, 0] = input.m0;
        m[0, 1] = input.m1;
        m[0, 2] = input.m2;
        m[0, 3] = input.m3;

        m[1, 0] = input.m4;
        m[1, 1] = input.m5;
        m[1, 2] = input.m6;
        m[1, 3] = input.m7;

        m[2, 0] = input.m8;
        m[2, 1] = input.m9;
        m[2, 2] = input.m10;
        m[2, 3] = input.m11;

        m[3, 0] = input.m12;
        m[3, 1] = input.m13;
        m[3, 2] = input.m14;
        m[3, 3] = input.m15;

        return m;
    }

    public void Render() {
        if (Camera.current == vrCam) {
            Vector3 eyeOffset = Vector3.zero;
            if (isLeftEye) {
                eyeOffset = SteamVR.instance.eyes[0].pos;
            } else {
                eyeOffset = SteamVR.instance.eyes[1].pos;
            }

            transform.localPosition = vrCam.transform.position + vrCam.transform.TransformVector(eyeOffset);
            transform.localRotation = vrCam.transform.localRotation;

            portalCam.Render(); 
        }
    }

}
