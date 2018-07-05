/////////////////////////////////////////////////////////////////////
//               //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                         //
//  Author:        Tejaswi Nimmagadda                //
/////////////////////////////////////////////////////////////////////


/*
Module Operations:
==================
This is a public interface which is used in Test Harness application.


Maintenance History:
====================
ver 1.0

*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTest

{
    public interface ITest
    {
        bool test();
    }
}
