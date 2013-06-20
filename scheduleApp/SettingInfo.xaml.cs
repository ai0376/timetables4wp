using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel;

namespace scheduleApp
{
    public partial class SettingInfo : PhoneApplicationPage
    {
        public static string classNodeNumber;
        public string thisWeek;
        public string strWeek;
        public SettingInfo()
        {
            InitializeComponent();
                        
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("id") && this.NavigationContext.QueryString.ContainsKey("type"))
            {
                string id =  this.NavigationContext.QueryString["id"];
                string type = this.NavigationContext.QueryString["type"];
                strWeek = type;
                classNodeNumber =(type + id); 
            }
            switch (Int32.Parse(strWeek))
            {
                case 1:
                    this.ApplicationTitle.Text = "周一";
                    break;
                case 2:
                    this.ApplicationTitle.Text = "周二";
                    break;
                case 3:
                    this.ApplicationTitle.Text = "周三";
                    break;
                case 4:
                    this.ApplicationTitle.Text = "周四";
                    break;
                case 5:
                    this.ApplicationTitle.Text = "周五";
                    break;
                case 6:
                    this.ApplicationTitle.Text = "周六";
                    break;
                case 7:
                    this.ApplicationTitle.Text = "周日";
                    break;
            }
           
            showClassInfo();
        }
        private void showClassInfo()
        {
            CourseInfo cinfo = new CourseInfo();
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {

                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("datacourse.xml", FileMode.Open, storage))
                {
                    XDocument doc = XDocument.Load(fileStream);
                    fileStream.SetLength(0);
                    // XElement xe = (from db in doc.Element("root").Element("class").Elements("node") where db.Attribute("id").Value.ToString() == "11" select db).Single();
                    XElement xe = (from db in doc.Element("root").Elements("class") where db.Attribute("id").Value.ToString() == strWeek select db).Single();
                    XElement fe = (from db in xe.Elements("node") where db.Attribute("id").Value.ToString() == classNodeNumber select db).Single();
                    try
                    {
                       
                        cinfo.courseName =  fe.Element("name").Value;
                        cinfo.courseTime =  fe.Element("time").Value;
                        cinfo.courseTeacer= fe.Element("teacher").Value;
                        cinfo.courseRoom = fe.Element("room").Value;
                        cinfo.courseDes = fe.Element("describle").Value;
                    }
                    catch
                    {
    
                    }
                    doc.Save(fileStream);
                    fileStream.Close();
                }
            }
            className.Text = cinfo.courseName;
            classTime.Text = cinfo.courseTime;
            classTeacher.Text = cinfo.courseTeacer;
            classRoom.Text = cinfo.courseRoom;
            classDescrible.Text = cinfo.courseDes;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {

             using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
             {
      
                    using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("datacourse.xml", FileMode.Open, storage))
                    {
                        XDocument doc = XDocument.Load(fileStream);
                        fileStream.SetLength(0);
                        XElement xe = (from db in doc.Element("root").Elements("class") where db.Attribute("id").Value.ToString() == strWeek select db).Single();
                        XElement fe = (from db in xe.Elements("node") where db.Attribute("id").Value.ToString() == classNodeNumber select db).Single();
                        try
                        {
                            fe.Attribute("id").SetValue(classNodeNumber);
                            fe.Element("name").SetValue(className.Text);
                            fe.Element("time").SetValue(classTime.Text);
                            fe.Element("teacher").SetValue(classTeacher.Text);
                            fe.Element("room").SetValue(classRoom.Text);
                            fe.Element("describle").SetValue(classDescrible.Text);

                        }
                        catch { 
                            
                        }
                        doc.Save(fileStream);
                        XElement me = (from db in doc.Element("root").Elements("class") where db.Attribute("id").Value.ToString() == strWeek select db).Single();
                        XElement ne = (from db in me.Elements("node") where db.Attribute("id").Value.ToString() == classNodeNumber select db).Single();
                        MessageBox.Show(ne.Element("name").Value);
                        
                        fileStream.Close();
                    }

             }
        }

        private void appbar_btnExit_Click(object sender, EventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

    }
}