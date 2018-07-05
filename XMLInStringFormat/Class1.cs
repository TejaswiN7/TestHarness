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
This Package is used to convert the Test requests to string format. The code required to parse the
test requests is contained in this package.


Required files:
==============


Maintenance History:
====================
ver 1.0

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace XMLInStringFormat
{

   
    public class XmlTest
    {
        private XDocument doc_;
        private List<Test> testList_;
       public  XmlTest()
        {
            doc_ = new XDocument();
            testList_ = new List<Test>();
        }
        public List<Test> parse(String xml)
        {
            doc_ = XDocument.Parse(xml);
            if (doc_ == null)
                return testList_;
            string author = doc_.Descendants("author").First().Value;
            Test test = null;

            XElement[] xtests = doc_.Descendants("test").ToArray();
            int numTests = xtests.Count();

            for (int i = 0; i < numTests; ++i)
            {
                test = new Test();
                test.testCode = new List<string>();
                test.author = author;
                test.timeStamp = DateTime.Now;
                test.testName = xtests[i].Attribute("name").Value;
                test.testDriver = xtests[i].Element("testDriver").Value;
                IEnumerable<XElement> xtestCode = xtests[i].Elements("library");
                foreach (var xlibrary in xtestCode)
                {
                    test.testCode.Add(xlibrary.Value);
                }
                testList_.Add(test);
            }
            return testList_;
        }
        static void Main(string[] args)
        {
            XmlTest demo = new XmlTest();
            try
            {
                string path = "../../../TestExecutive/ForStoringTests/TestRequest.xml";
                string xml = File.ReadAllText(path);
                demo.parse(xml);
                foreach (Test test in demo.testList_)
                {
                  //  test.show();
                }
            }
            catch (Exception ex)
            {
                Console.Write("\n\n  {0}", ex.Message);
            }
        }
    }
}
