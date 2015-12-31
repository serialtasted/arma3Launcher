using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arma3Launcher
{
    public static class GlobalVar
    {
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
    }
}
