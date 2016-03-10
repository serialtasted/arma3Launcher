using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arma3Launcher
{
    public static class GlobalVar
    {
        // INT


        // STRING
        static string _gameArtifact = "";
        public static string gameArtifact
        {
            get
            {
                return _gameArtifact;
            }
            set
            {
                _gameArtifact = value;
            }
        }

        // BOOL
        static bool _isUpdateAvailable = false;
        public static bool isUpdateAvailable
        {
            get
            {
                return _isUpdateAvailable;
            }
            set
            {
                _isUpdateAvailable = value;
            }
        }

        static bool _isDownloading = false;
        public static bool isDownloading
        {
            get
            {
                return _isDownloading;
            }
            set
            {
                _isDownloading = value;
            }
        }

        static bool _isInstalling = false;
        public static bool isInstalling
        {
            get
            {
                return _isInstalling;
            }
            set
            {
                _isInstalling = value;
            }
        }

        static bool _isServer = false;
        public static bool isServer
        {
            get
            {
                return _isServer;
            }
            set
            {
                _isServer = value;
            }
        }

        static bool _autoPilot = false;
        public static bool autoPilot
        {
            get
            {
                return _autoPilot;
            }
            set
            {
                _autoPilot = value;
            }
        }

        static bool _isAnimating = false;
        public static bool isAnimating
        {
            get
            {
                return _isAnimating;
            }
            set
            {
                _isAnimating = value;
            }
        }

        static bool _isDebug = false;
        public static bool isDebug
        {
            get
            {
                return _isDebug;
            }
            set
            {
                _isDebug = value;
            }
        }
    }
}
