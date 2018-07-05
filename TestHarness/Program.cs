/////////////////////////////////////////////////////////////////////
//              //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                        //
//  Application:   TestHarness                        //
//  Author:        Tejaswi Nimmagadda                //
/////////////////////////////////////////////////////////////////////

/*
Module Operations:
==================
This Package has been created to deque the test requests as well as parse them. The end results are queued. 
The method XMLRequestHandling performs the dequeing and parsing the test requests , it calls the appropriate
methods in other files such as methods in BlockingQueue.cs.

References:
==============
Required files
- BlockingQueue , Loader, AppDomain, Logger 

Maintenance History:
====================
ver 1.0

*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using XMLInStringFormat;


using SWTools;
using AppDomainDemo;
using Loader;

namespace TestHarness
{
    public class Program
    {
        private BlockingQueue<List<TestResults>> resultsBlockingQueue = new BlockingQueue<List<TestResults>>();
        public void XMLRquestHandling(BlockingQueue<string> b )
        {
            XmlTest x = new XmlTest();
            Creator c = new Creator();


            for (int i=0;i< b.size();i++)
            {
                Console.Write("\n------------Dequeueing Test Requests---------------\n");
                string TestRequest=b.deQ();
                List<Test>  testList_=x.parse(TestRequest);
                c.AppDomainCreator(testList_);
                List<TestResults> results =c.getResults();
                resultsBlockingQueue.enQ(results);
            }
        
        }
        public BlockingQueue<List<TestResults>> getResultsQueue()
        {
            return resultsBlockingQueue;
        }
        static void Main(string[] args)
        {
        }
    }
}
