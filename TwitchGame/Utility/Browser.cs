using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ntrclient.Extra
{
    public static class Browser
    {
        private static string GetStandardBrowserPath()
        {
            string browserPath = string.Empty;

            try
            {
                //Read default browser path from Win XP registry key
                RegistryKey browserKey = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false) ??
                                         Registry.CurrentUser.OpenSubKey(
                                             @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http",
                                             false);

                //If browser path wasn't found, try Win Vista (and newer) registry key

                //If browser path was found, clean it
                if (browserKey != null)
                {
                    //Remove quotation marks
                    browserPath = (browserKey.GetValue(null) as string)?.ToLower().Replace("\"", "");

                    //Cut off optional parameters
                    if (browserPath != null && !browserPath.EndsWith("exe"))
                    {
                        browserPath = browserPath.Substring(0,
                            browserPath.LastIndexOf(".exe", StringComparison.Ordinal) + 4);
                    }

                    //Close registry key
                    browserKey.Close();
                }
            }
            catch
            {
                //Return empty string, if no path was found
                return string.Empty;
            }
            //Return default browsers path
            return browserPath;
        }

        public static void OpenUrl(string url)
        {
            string browserPath = GetStandardBrowserPath();
            if (string.IsNullOrEmpty(browserPath))
            {
                MessageBox.Show(@"No default browser found!");
            }
            else
            {
                Process.Start(browserPath, url);
            }
        }
    }
}