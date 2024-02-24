using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using MelonLoader;
using HarmonyLib;
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using VelocidroneQoL;



namespace VelocidroneQoL
{
    public class VelocidroneQoLClass : MelonMod
    {
        //CAMERA CONTROL CameraContoller.fpvFieldOfView
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Scene {sceneName} with build index {buildIndex} has been loaded!");
        }


        public override void OnUpdate()
        {
            CameraContoller Camera = GameObject.Find("Camera").GetComponent<CameraContoller>();
            //hffkblekiic
            if (Input.GetKeyUp(KeyCode.LeftBracket))
            {
                Camera.fpvFieldOfView += 2;
                Camera.setFpvFOVMinus();
            }
        }
    }
}

