﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
   public void exitGame()
   {
       Application.Quit();
       Debug.Log("Exit game successful");

   }
   
}
