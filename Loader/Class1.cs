/////////////////////////////////////////////////////////////////////
//              //
//  ver 1.0                                                        //
//  Language:      Visual C#  2015                                 //
//  Platform:      Dell, Windows 10                                //
//  Application:   TestHarness                                     //
//  Author:        Tejaswi Nimmagadda              //
/////////////////////////////////////////////////////////////////////

/*
Module Operations:
==================
This Package is used to load assemblies and test results through methods executeTestcases 
also some methods in Logger are called from the methods in this package.
  

Build Process:
==============
Required files
- ITest, XMLParser

Maintenance History:
====================
ver 1.0

*/


using iTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XMLInStringFormat;

namespace Loader
{
    public class Loader : MarshalByRefObject
    {

        static void Main(string[] args)
        {
            Loader loader = new Loader();
            List<TestData> testDriver = loader.executeTestCases();

           loader.run(testDriver);
        }
        [Serializable]
        public struct TestData
        {
            public string Name;
            public ITest testDriver;
        }

        
        public void getAssemblies(List<Test> testList_)
        {

            foreach (Test test in testList_)
            {

                Assembly.LoadFrom(test.testDriver);
                foreach (string library in test.testCode)
                {
                    Assembly.LoadFrom(library);

                }
            }
        }

        public List<TestData> executeTestCases()
        {
            List<TestData> testDriver = new List<TestData>();
            Assembly[] a = AppDomain.CurrentDomain.GetAssemblies();
            Console.Write("\n--------------Loading Assemblies---------------\n");
            foreach (Assembly assembly in a)
            {
                Console.Write(assembly.FullName+"\n");
                Type[] types = assembly.GetExportedTypes();
                if(assembly.FullName.IndexOf("mscorlib")!=-1)
                    continue;
                foreach (Type t in types)
                {
                    
                    if (t.IsClass && typeof(ITest).IsAssignableFrom(t))  // does this type derive from ITest ?
                    {
                        ITest tdr = (ITest)Activator.CreateInstance(t);    // create instance of test driver

                        // save type name and reference to created type on managed heap

                        TestData td = new TestData();
                        td.Name = t.Name;
                        Console.Write("\n s" + td.Name);
                        td.testDriver = tdr;
                        
                        Console.Write(td.testDriver.test());
                        testDriver.Add(td);
                    }
                }
            }
            return testDriver;
        }
        public List<TestResults> run(List<TestData>  testDriver)
        {
            List<TestResults> results = new List<TestResults>();
            if (testDriver.Count == 0)
                return results;
            foreach (TestData td in testDriver)  // enumerate the test list
            {
                Console.Write("\n--------Logging Test Results---------------------\n");
                TestResults testResult = new TestResults();
                try
                {
                    td.testDriver.test();
                    Console.Write("\n  testing {0}", td.Name);
                    testResult.testName = td.Name;
                    if (td.testDriver.test() == true)
                    {
                        Console.Write("\n  test passed");
                        testResult.testResult = "Test passed";

                    }
                    else
                    {
                        Console.Write("\n  test failed");
                        testResult.testResult = " test failed";
                    }
                        
                }
                catch (Exception ex)
                {
                    Console.Write("\n  {0}", ex.Message);
                }
                results.Add(testResult);
            }
            return results;
        }
    }
    [Serializable]
    public class TestResults
    {
        public string testName { get; set; }
        public string testResult { get; set; }
        public string testLogs { get; set; }
    }
}
