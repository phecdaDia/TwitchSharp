using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwitchGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                TwitchGame t = new TwitchGame();
            }
            catch (Exception e)
            {
                String xcb = String.Format("http://stackoverflow.com/search?q=[c%23]+{0}", e.Message);
            }
            
        }
    }
}
