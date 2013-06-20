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

namespace scheduleApp
{
    public partial class OtherClassInfo : PhoneApplicationPage
    {
        private string strWeek;
        public OtherClassInfo()
        {
            InitializeComponent();                    
        }
        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
  
        }
        
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey("id"))
            {
                //string week = this.NavigationContext.QueryString["id"];
                //strWeek = week;
            }
            if (this.NavigationContext.QueryString.ContainsKey("type"))
            {
                string week = this.NavigationContext.QueryString["type"];
                strWeek = week;
            }
            switch(strWeek)
            {
                case "周一":
                    this.ApplicationTitle.Text = "周一课程设置";
                    break;
                case "周二":
                    this.ApplicationTitle.Text = "周二课程设置";
                    break;
                case "周三":
                    this.ApplicationTitle.Text = "周三课程设置";
                    break;
                case "周四":
                    this.ApplicationTitle.Text = "周四课程设置";
                    break;
                case "周五":
                    this.ApplicationTitle.Text = "周五课程设置";
                    break;
                case "周六":
                    this.ApplicationTitle.Text = "周六课程设置";
                    break;
                case "周日":
                    this.ApplicationTitle.Text = "周日课程设置";
                    break;
            }
            
        }
        //ListItem 列表信息点击事件
        private void FirstBox_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            int id = MainPage.getNode((sender as ListBoxItem).Content.ToString());
            int week = 0;// = Int32.Parse(strWeek);
            switch (strWeek)
            { 
                case "周一":
                    week = 1;
                    break;
                case "周二":
                    week = 2;
                    break;
                case "周三":
                    week = 3;
                    break;
                case "周四":
                    week = 4;
                    break;
                case "周五":
                    week = 5;
                    break;
                case "周六":
                    week = 6;
                    break;
                case "周日":
                    week = 7;
                    break;
            }
            string uriText = String.Format("/SettingInfo.xaml?id={0}&type={1}", id, week);
            switch ((sender as ListBoxItem).Name)
            {
                case "FirstBox":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "SecondBox":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "ThirdBox":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "FourthBox":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
                case "FifthBox":
                    this.NavigationService.Navigate(new Uri(uriText, UriKind.Relative));
                    break;
            }

        }
        private void OtherExit_Click(object sender, EventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

    }
}