/////////////////////////////////////////////////////////////////////
//  Test           //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                     //
//  Author:        Tejaswi Nimmagadda                //
/////////////////////////////////////////////////////////////////////

/*
Module Operations:
==================
This Package serves asthe entry point of the application , several important methods are 
called from this package.
  

Build Process:
==============
Required files
- BlockingQueue,Loader,TestHarness

Maintenance History:
====================
ver 1.0

*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SWTools;
using System.IO;
using TestHarness;
using Loader;

namespace TestExecutive
{
    public class Class1
    {
        static void Main(string[] args)
        {
            string[] AllTestRequestfiles = Directory.GetFiles(args[0]);
            Console.Write("-----------------------------------------------\n");
            Console.Write(" Test requests from Client \n");
            Console.Write("-----------------------------------------------\n");

            BlockingQueue<String> b1 = new BlockingQueue<String>();
                 Program program = new Program();
                foreach (string file in AllTestRequestfiles)
                {
                    try
                    {
                        Console.Write("\n-------------- Test Requests---------------------- \n ");
                        string StringVersionOfTestRequests = File.ReadAllText(file);
                        Console.Write("\n" + StringVersionOfTestRequests+ "\n");
                        Console.Write("\n--------------- Enqueuing  test requests----------- \n ");
                    Console.Write("\n---------------Test Harness starts processing-------\n");
                        b1.enQ(StringVersionOfTestRequests);
                    program.XMLRquestHandling(b1);
                    
                    BlockingQueue<List<TestResults>> result = program.getResultsQueue();
                    Class1 classs  = new Class1();
                    classs.showResults(result);

                }

                catch (Exception e)
                    {
                        Console.Write("\n File not found" + e.Message);
                    }

                }
            testHarnessRepository t = new testHarnessRepository();
            Console.Write(t.getLog());
            Console.ReadKey();
        }
        
        private  void showResults(BlockingQueue<List<TestResults>> result)
        {

            Console.Write("\n------------------Printing Test Results----------------\n");
            for (int i = 0; i < result.size(); i++)
            {
                foreach (TestResults s in result.deQ())
                {
                    Console.Write("\n Test Name-" + s.testName);
                    Console.Write("\n Test Result -" + s.testResult);
                }
            }
           
        }
    }
}
