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
using RLD;

namespace VelocidroneQoL
{
    public class VelocidroneQoLClass : MelonMod
    {
        // Print Scene and index on every scene change
        public override void OnSceneWasLoaded(int buildIndex, string trackName)
        {
            LoggerInstance.Msg($"Scene {trackName} with build index {buildIndex}  has been loaded!");
        }

        //CAMERA CONTROL Camera.fpvFieldOfView
        public override void OnUpdate()
        {
            CameraContoller Camera = GameObject.Find("Camera").GetComponent<CameraContoller>();
            if (Input.GetKeyUp(KeyCode.LeftBracket))
            {
                Camera.fpvFieldOfView += 2;
                Camera.setFpvFOVMinus();

                
            }


            VisualiseSticks TxSticks = GameObject.Find("TxSticks").GetComponent<VisualiseSticks>();
            if (buildIndex != 0)
            {
                LoggerInstance.Msg($"{TxSticks.enabled}OŁ SZIT");
            }
            
        }

        //HUD CONTROL 

        // On join session turn on stick movement osd


    }
}

