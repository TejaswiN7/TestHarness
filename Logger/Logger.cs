/////////////////////////////////////////////////////////////////////
//               //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                      //
//  Author:        Tejaswi Nimmagadda                //
/////////////////////////////////////////////////////////////////////


/*
Module Operations:
==================
This Package is used to log the test results.


Maintenance History:
====================
ver 1.0

*/



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class FileLogger
    {
        public void writeMessageTo(string toFileName,string message)
        {
            File.WriteAllText(toFileName, message);

        }
        public string readAllMessagesFrom(string fromFileName)
        {
            return File.ReadAllText(fromFileName);
        }
    }
}
