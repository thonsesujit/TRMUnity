using System;
using System.Runtime.InteropServices;
using UnityEngine;



public class MinimizeWindow : MonoBehaviour
{

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();


    public void OnMinimizeButtonClick()
    {
        ShowWindow(GetActiveWindow(), 2);
    }


    //    public void MimizeWindow()
    //    {

    //        Screen.fullScreen = !Screen.fullScreen;
    //        //if (Screen.fullScreen == true)
    //        //{
    //        //    Screen.fullScreen = false;
    //        //}
    //        //else
    //        //{
    //        //    Screen.fullScreen = true;
    //        //}
    //    }
}
