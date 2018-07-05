
/////////////////////////////////////////////////////////////////////
//               //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                  //
//  Author:        Tejaswi Nimmagadda                //
/////////////////////////////////////////////////////////////////////

/*
Module Operations:
==================
This Package is used to generate the test related data


Maintenance History:
====================
ver 1.0

*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLInStringFormat
{
    [Serializable]
    public class Test
    {
        public string testName { get; set; }
        public string author { get; set; }
        public DateTime timeStamp { get; set; }
        public String testDriver { get; set; }
        public List<string> testCode { get; set; }

    }

}
