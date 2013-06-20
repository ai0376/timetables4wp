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
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Phone.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO.IsolatedStorage;
using Microsoft.Phone.Shell;



namespace scheduleApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static DateTime thisDay = DateTime.Now;
        public static XDocument gdoc = new XDocument();
        //磁贴
        private ShellTileSchedule _schedule = new ShellTileSchedule();
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            // 将 listbox 控件的数据上下文设置为示例数据
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            ///////////////////////////////////////////////////////////
            ////更改磁贴上面的属性

            //_schedule.Recurrence = UpdateRecurrence.Interval; //更新模式：定时更新
            //_schedule.Interval = UpdateInterval.EveryHour; //定时更新的时间间隔：每小时更新
            //_schedule.StartTime = DateTime.Now; //开始更新时间
            //_schedule.RemoteImageUri = new Uri(@"http://image.sinajs.cn/newchart/small/nsh000300.gif");
            //_schedule.Start();  //开始更新


            //ShellTile firstTile = ShellTile.ActiveTiles.First();
            //var newData = new StandardTileData()
            //{
            //    Title = "Hello World",
            //    BackBackgroundImage = new Uri("PanoramaBackground2.png" , UriKind.Relative),
            //    Count = 6,
            //    BackContent = "This is New",
            //    BackTitle = "New BackTile",
            //    BackgroundImage = new Uri("PanoramaBackground1.png", UriKind.Relative),
            //};
            //firstTile.Update(newData);

            //////////////////////////////////////////////////////////

        }

        // 为 ViewModel 项加载数据
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
            this.TBlock.Text = thisDay.DayOfWeek.ToString();

            int week = getclass(thisDay.DayOfWeek.ToString());
            
            getNodeInfo(week.ToString());

            initOtherHubtile();
        }
        //得到当前周的详细信息
        private void getNodeInfo(string week)
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                Color colorRGB = new Color();
                colorRGB.A = (byte)(255);
                colorRGB.R = (byte)(27);
                colorRGB.G = (byte)(161);
                colorRGB.B = (byte)(226);

                using (IsolatedStorageFileStream fileStream = new IsolatedStorageFileStream("datacourse.xml", FileMode.Open, storage))
                {
                    XDocument doc = XDocument.Load(fileStream);
                    fileStream.SetLength(0);
                    // XElement xe = (from db in doc.Element("root").Element("class").Elements("node") where db.Attribute("id").Value.ToString() == "11" select db).Single();
                    XElement xe = (from db in doc.Element("root").Elements("class") where db.Attribute("id").Value.ToString() == week select db).Single();
                    for (int id = 1; id <= 5; id++)
                    {
                       
                        string strid = week + id.ToString();
                        XElement fe = (from db in xe.Elements("node") where db.Attribute("id").Value.ToString() == strid select db).Single();
                        try
                        {
                            if(id == 1)
                            {   
                                btnClass1.Message = fe.Element("name").Value + " " + fe.Element("describle").Value;
                                if (btnClass1.Message.Length == 1)      //当本节没有课程的内容的时候HubTile变灰色
                                {
                                    btnClass1.Background = new SolidColorBrush(Colors.Gray);
                                }
                                else 
                                {
                                    btnClass1.Background = new SolidColorBrush(colorRGB); //有内容的时候变回蓝色
                                }
                            }
                            if (id == 2)
                            {
                                btnClass2.Message = fe.Element("name").Value + " " + fe.Element("describle").Value;
                                if (btnClass2.Message.Length == 1)
                                {
                                    btnClass2.Background = new SolidColorBrush(Colors.Gray);
                                }
                                else
                                {
                                    btnClass2.Background = new SolidColorBrush(colorRGB);
                                }
                               
                            }
                            if (id == 3)
                            {
                                btnClass3.Message = fe.Element("name").Value + " " + fe.Element("describle").Value;
                                if (btnClass3.Message.Length == 1)
                                {
                                    btnClass3.Background = new SolidColorBrush(Colors.Gray);
                                }
                                else
                                {
                                    btnClass3.Background = new SolidColorBrush(colorRGB);
                                }
                            }
                            if (id == 4)
                            {
                                btnClass4.Message = fe.Element("name").Value + " " + fe.Element("describle").Value;
                                if (btnClass4.Message.Length == 1)
                                {
                                    btnClass4.Background = new SolidColorBrush(Colors.Gray);
                                }
                                else
                                {
                                    btnClass4.Background = new SolidColorBrush(colorRGB);
                                }
                            }
                            if (id == 5)
                            {
                                btnClass5.Message = fe.Element("name").Value + " " + fe.Element("describle").Value;
                                if (btnClass5.Message.Length == 1)
                                {
                                    btnClass5.Background = new SolidColorBrush(Colors.Gray);
                                }
                                else
                                {
                                    btnClass5.Background = new SolidColorBrush(colorRGB);
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                    doc.Save(fileStream);
                    fileStream.Close();
                }
            }
        }
        //获取对应节的值
        public static int getNode(string title)
        {
            int id = 0;
            switch (title)
            { 
                case "第一节":
                    id = 1;
                    break;
                case "第二节":
                    id = 2;
                    break;
                case "第三节":
                    id = 3;
                    break;
                case "第四节":
                    id = 4;
                    break;
                case "第五节":
                    id = 5;
                    break;
            }
            return id;
        }
        //获取对应周的值
        public static int getclass(string week)
        {
            int num = 0;
            switch (week)
            {
                case "Monday":
                    num = 1;
                    break;
                case "Tuesday":
                    num = 2;
                    break;
                case "Wednesday":
                    num = 3;
                    break;
                case "Thursday":
                    num = 4;
                    break;
                case "Friday":
                    num = 5;
                    break;
                case "Saturday":
                    num = 6;
                    break;
                case "Sunday":
                    num = 7;
                    break;
            }
            return num;
        }
        //通过判断今天的日期，然后初始化其他hubtile的Title值
        private void initOtherHubtile()
        {
            int week = getclass(thisDay.DayOfWeek.ToString());
            switch (week)
            { 
                case 1:
                    btnPost1.Title = "周二";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周二.png", UriKind.Relative));
                    btnPost2.Title = "周三";
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周三.png", UriKind.Relative));
                    btnPost3.Title = "周四";
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周四.png", UriKind.Relative));
                    btnPost4.Title = "周五";
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周五.png", UriKind.Relative));
                    btnPost5.Title = "周六";
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周六.png", UriKind.Relative));
                    btnPost6.Title = "周日";
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周日.png", UriKind.Relative));
                    break;
                case 2:
                    btnPost1.Title = "周一";
                    btnPost2.Title = "周三";
                    btnPost3.Title = "周四";
                    btnPost4.Title = "周五";
                    btnPost5.Title = "周六";
                    btnPost6.Title = "周日";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周一.png", UriKind.Relative));
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周三.png", UriKind.Relative));
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周四.png", UriKind.Relative));
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周五.png", UriKind.Relative));
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周六.png", UriKind.Relative));
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周日.png", UriKind.Relative));
                    break;
                case 3:
                    btnPost1.Title = "周一";
                    btnPost2.Title = "周二";
                    btnPost3.Title = "周四";
                    btnPost4.Title = "周五";
                    btnPost5.Title = "周六";
                    btnPost6.Title = "周日";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周一.png", UriKind.Relative));
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周二.png", UriKind.Relative));
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周四.png", UriKind.Relative));
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周五.png", UriKind.Relative));
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周六.png", UriKind.Relative));
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周日.png", UriKind.Relative));
                    break;
                case 4:
                    btnPost1.Title = "周一";
                    btnPost2.Title = "周二";
                    btnPost3.Title = "周三";
                    btnPost4.Title = "周五";
                    btnPost5.Title = "周六";
                    btnPost6.Title = "周日";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周一.png", UriKind.Relative));
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周二.png", UriKind.Relative));
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周三.png", UriKind.Relative));
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周五.png", UriKind.Relative));
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周六.png", UriKind.Relative));
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周日.png", UriKind.Relative));
                    break;
                case 5:
                    btnPost1.Title = "周一";
                    btnPost2.Title = "周二";
                    btnPost3.Title = "周三";
                    btnPost4.Title = "周四";
                    btnPost5.Title = "周六";
                    btnPost6.Title = "周日";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周一.png", UriKind.Relative));
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周二.png", UriKind.Relative));
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周三.png", UriKind.Relative));
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周四.png", UriKind.Relative));
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周六.png", UriKind.Relative));
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周日.png", UriKind.Relative));
                    break;
                case 6:
                    btnPost1.Title = "周一";
                    btnPost2.Title = "周二";
                    btnPost3.Title = "周三";
                    btnPost4.Title = "周四";
                    btnPost5.Title = "周五";
                    btnPost6.Title = "周日";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周一.png", UriKind.Relative));
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周二.png", UriKind.Relative));
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周三.png", UriKind.Relative));
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周四.png", UriKind.Relative));
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周五.png", UriKind.Relative));
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周日.png", UriKind.Relative));
                    break;
                case 7:
                    btnPost1.Title = "周一";
                    btnPost2.Title = "周二";
                    btnPost3.Title = "周三";
                    btnPost4.Title = "周四";
                    btnPost5.Title = "周五";
                    btnPost6.Title = "周六";
                    btnPost1.Source = new BitmapImage(new Uri("./Image/周一.png", UriKind.Relative));
                    btnPost2.Source = new BitmapImage(new Uri("./Image/周二.png", UriKind.Relative));
                    btnPost3.Source = new BitmapImage(new Uri("./Image/周三.png", UriKind.Relative));
                    btnPost4.Source = new BitmapImage(new Uri("./Image/周四.png", UriKind.Relative));
                    btnPost5.Source = new BitmapImage(new Uri("./Image/周五.png", UriKind.Relative));
                    btnPost6.Source = new BitmapImage(new Uri("./Image/周六.png", UriKind.Relative));
                    break;
            }
        }

        private void btnClass1_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int id = getNode((sender as HubTile).Title);
            int week = getclass(thisDay.DayOfWeek.ToString());
            string uriText = String.Format("/SettingInfo.xaml?id={0}&type={1}",id , week);
            switch ((sender as HubTile).Name)
            { 
                case "btnClass1":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnClass2":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnClass3":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnClass4":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnClass5":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
            }
        }
        //其他页面跳转(周)
        private void btnPost_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string uriText;
            switch ((sender as HubTile).Name)
            {
                case "btnPost1":
                    uriText = String.Format("/OtherClassInfo.xaml?id={0}&type={1}", 1, btnPost1.Title);
                    //this.NavigationService.Navigate(new Uri("/OtherClassInfo.xaml?id=1", UriKind.Relative));
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnPost2":
                    uriText = String.Format("/OtherClassInfo.xaml?id={0}&type={1}", 2, btnPost2.Title);
                   // this.NavigationService.Navigate(new Uri("/OtherClassInfo.xaml?id=2", UriKind.Relative));
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnPost3":
                    uriText = String.Format("/OtherClassInfo.xaml?id={0}&type={1}", 3, btnPost3.Title);
                   // this.NavigationService.Navigate(new Uri("/OtherClassInfo.xaml?id=3", UriKind.Relative));
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnPost4":
                    uriText = String.Format("/OtherClassInfo.xaml?id={0}&type={1}", 4, btnPost4.Title);
                   // this.NavigationService.Navigate(new Uri("/OtherClassInfo.xaml?id=4", UriKind.Relative));
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnPost5":
                    uriText = String.Format("//OtherClassInfo.xaml?id={0}&type={1}", 5, btnPost5.Title);
                   // this.NavigationService.Navigate(new Uri("/OtherClassInfo.xaml?id=5", UriKind.Relative));
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "btnPost6":
                    uriText = String.Format("/OtherClassInfo.xaml?id={0}&type={1}", 6, btnPost6.Title);
                   // this.NavigationService.Navigate(new Uri("/OtherClassInfo.xaml?id=6", UriKind.Relative));
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
            }
        }

        private void RemiderItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AddNotification.xaml", UriKind.Relative));
        }

        private void AboutItem_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/AboutApp.xaml", UriKind.Relative));
        }
    }
}