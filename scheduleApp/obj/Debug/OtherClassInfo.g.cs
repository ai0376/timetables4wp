﻿#pragma checksum "C:\Users\mjrao\Desktop\wp7\20130614\scheduleApp\scheduleApp\OtherClassInfo.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D0831BB695E37B92D90EE58EC4B7F26A"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace scheduleApp {
    
    
    public partial class OtherClassInfo : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.ListBox listBox1;
        
        internal System.Windows.Controls.ListBoxItem FirstBox;
        
        internal System.Windows.Controls.ListBoxItem SecondBox;
        
        internal System.Windows.Controls.ListBoxItem ThirdBox;
        
        internal System.Windows.Controls.ListBoxItem FourthBox;
        
        internal System.Windows.Controls.ListBoxItem FifthBox;
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton OtherExit;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/scheduleApp;component/OtherClassInfo.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.listBox1 = ((System.Windows.Controls.ListBox)(this.FindName("listBox1")));
            this.FirstBox = ((System.Windows.Controls.ListBoxItem)(this.FindName("FirstBox")));
            this.SecondBox = ((System.Windows.Controls.ListBoxItem)(this.FindName("SecondBox")));
            this.ThirdBox = ((System.Windows.Controls.ListBoxItem)(this.FindName("ThirdBox")));
            this.FourthBox = ((System.Windows.Controls.ListBoxItem)(this.FindName("FourthBox")));
            this.FifthBox = ((System.Windows.Controls.ListBoxItem)(this.FindName("FifthBox")));
            this.OtherExit = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("OtherExit")));
        }
    }
}
