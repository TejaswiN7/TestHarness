/////////////////////////////////////////////////////////////////////
//             //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                       //
//  Application:   TestHarness                    //
//  Author:        Tejaswi Nimmagadda                //
/////////////////////////////////////////////////////////////////////


/*
Module Operations:
==================
This Package implements the ITest interface. 
 

  
Build Process:
==============
Required files
- iTest,CodeToTest

Maintenance History:
====================
ver 1.0

*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTest;
using CodeToTest;

namespace TestDrive
{
    [Serializable]
    public class TestDrive  :  ITest
    {
       public bool test()
        {
            TestCase case1 = new TestCase();
            return case1.hello();
        }
    }
}
