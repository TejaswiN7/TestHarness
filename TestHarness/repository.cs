/////////////////////////////////////////////////////////////////////
//              //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                        //
//  Author:        Tejaswi Nimmagadda           //
//                              //
/////////////////////////////////////////////////////////////////////



/*
Module Operations:
==================
This package uses the getLog method to retrieve the log information. It implements the interface
repository which contains the getLog method.

 

Maintenance History:
====================
ver 1.0

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Logger;


namespace TestHarness
{
    public interface repository
    {
        string getLog();
    }
   public class testHarnessRepository : repository
    {
        public string getLog()
        {
            FileLogger f = new FileLogger();
            Console.Write("\n----------------Obtaining Log Information------------------\n");
            
            return f.readAllMessagesFrom("Jim Fawcett131202807375715300");

           }

        static void Main(string[] args)
        {
            testHarnessRepository t = new testHarnessRepository();
            Console.Write(t.getLog());
            Console.ReadKey();
        }
    }
}
