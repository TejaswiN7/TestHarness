
/////////////////////////////////////////////////////////////////////
//               //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                 //
//  Author:        Tejaswi Nimmagadda           //
//                              //
/////////////////////////////////////////////////////////////////////

/*
Module Operations:
==================
This Package his used to obtain files through the method getFilesInSpecifiedPath and it display the names
using the displayNames method.



Maintenance History:
====================
ver 1.0

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerversion2
{
    using System.IO;
    public class FileManager
    {
        public string[] getFilesInSpecifiedPath(string directory, string wildCardFileExtention)
        {
            string[] files = Directory.GetFiles(directory, wildCardFileExtention, SearchOption.AllDirectories);
            return files;
        }
        public void displayNames(string[] files)
        {
            foreach (string file in files)
            {
                Console.Write("file" + file);
            }
        }
    }
}
