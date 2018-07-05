/////////////////////////////////////////////////////////////////////
//             //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                       //
//  Application:   TestHarness                         //
//  Author:        Tejaswi Nimmagadda              //
/////////////////////////////////////////////////////////////////////


/*
Module Operations:
==================
This package creates a child app domain it also uses the file manager to retrieve files , it also contains the 
StoreResultsInFile method which as the name indicates is used to store the results. Methods in other files
such as logger are called to store the results.


Build Process:
==============
Required files
- iTest,Loader,Logger,XMLParser,FileManagerversion2

Maintenance History:
====================
ver 1.0

*/






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Policy;
using FileManagerversion2;
using iTest;
using System.Reflection;
using System.Runtime.Remoting;
using XMLInStringFormat;
using static Loader.Loader;
using Loader;
using Logger;

namespace AppDomainDemo
{
   

    public class Creator
    {
        private List<TestResults> results;

        public void AppDomainCreator(List<Test> testList_)
        {

            {
               
                FileManager file = new FileManager();
                try
                {
                    AppDomain main = AppDomain.CurrentDomain;
                    Console.Write("\n  Starting in AppDomain {0}\n", main.FriendlyName);

                    // Create application domain setup information for new AppDomain
                    AppDomainSetup domaininfo = new AppDomainSetup();
                    domaininfo.ApplicationBase
                      = System.Environment.CurrentDirectory;  // defines search path for assemblies

                    //Create evidence for the new AppDomain from evidence of current
                    Evidence adevidence = AppDomain.CurrentDomain.Evidence;

                    // Create Child AppDomain
                    AppDomain ad
                      = AppDomain.CreateDomain("ChildDomain", adevidence, domaininfo);

                    /////////////////////////////////////////////////////////////////////
                    //  Way to create ChildDomain using default evidence and domaininfo
                    //    AppDomain ad = AppDomain.CreateDomain("ChildDomain", null);
                    //Assembly assembly =Assembly.LoadFrom("TestDrive");
                    //Type names = assembly.GetType();
                    //Console.Write("jkdhfkjsdh"+names.FullName);
                    //Type type =(Type) assembly.GetExportedType();
                   
                    Console.Write("\n\n");


                    ad.Load("Loader");
                    ObjectHandle oh
                      = ad.CreateInstance("Loader", "Loader.Loader");
                    object ob = oh.Unwrap();    // unwrap creates proxy to ChildDomain
                   // Console.Write("\n  {0}", ob);

                    Loader.Loader loader = (Loader.Loader)ob;
                    loader.getAssemblies(testList_);
                    List<TestData> testDriver =  loader.executeTestCases();
                    
                    results = loader.run(testDriver);
                    string fileName = testList_[0].author + DateTime.Now.ToFileTime();
                    StoreResultsInFile(fileName,results);


                    AppDomain.Unload(ad);
                    Console.Write("\n\n");
                }
                catch (Exception except)
                {
                    Console.Write("\n  {0}\n\n", except.Message);
                }
            }
        }
        public List<TestResults> getResults()
        {
            return results;
        }
        private void StoreResultsInFile(string fileName, List<TestResults> results)
        {
            Console.Write("\n------Storing Test Results into " + fileName);
            StringBuilder sb = new StringBuilder();
            FileLogger logger = new FileLogger();
            foreach(TestResults result in results)
            {
                sb.Append("\n Test Name-" + result.testName);
                sb.Append("\n Test Result -" + result.testResult);
            }
            logger.writeMessageTo(fileName+".txt", sb.ToString());
        }
    }
    
   
}
