using Assets.Project2DExample.Hardware;
using Assets.Project2DExample.UI.MainMenu.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Project2DExample.UI.MainMenu.Objects
{
    public class Settings
    {
        int _screenWidth;
        public int ScreenWidth
        {
            get { return _screenWidth; }
            set
            { 
                _screenWidth = value;
                Screen.SetResolution(ScreenWidth, ScreenHeight, FullScreenMode);
            }
        }
        int _screenHeight;
        public int ScreenHeight
        {
            get { return _screenHeight; }
            set 
            { 
                _screenHeight = value;
                Screen.SetResolution(ScreenWidth, ScreenHeight, FullScreenMode);
            }
        }
        FullScreenMode _fullscreenMode;
        public FullScreenMode FullScreenMode
        {
            get { return _fullscreenMode; }
            set 
            { 
                _fullscreenMode = value;
                Screen.SetResolution(ScreenWidth, ScreenHeight, FullScreenMode);
            }
        }
        int _qualiteLevel;
        public int QualiteLevel
        {
            get { return _qualiteLevel; }
            set 
            { 
                _qualiteLevel = value;
                QualitySettings.SetQualityLevel(_qualiteLevel, true);
            }
        }
        ControllsType _controllsType;
        public ControllsType ControllsType
        {
            get { return _controllsType; }
            set
            {
                _controllsType = value;
            }
        }
        /*int _mouseSensitivity;
        public int MouseSensitivity
        {
            get { return _mouseSensitivity; }
            set
            {
                _mouseSensitivity = value;

            }
        }*/
        bool _mouseInverseX;
        public bool MouseInverseX
        {
            get { return _mouseInverseX; }
            set
            {
                _mouseInverseX = value;
            }
        }
        bool _mouseInverseY;
        public bool MouseInverseY
        {
            get { return _mouseInverseY; }
            set
            {
                _mouseInverseY = value;
            }
        }

        KeyboardControlls _keyboardControlls = new KeyboardControlls();
        public KeyboardControlls KeyboardControlls
        {
            get { return _keyboardControlls; }
            set { _keyboardControlls = value;}
        }
    }
}
