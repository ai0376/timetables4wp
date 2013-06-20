using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace scheduleApp
{
    public class CourseInfo
    {
        public string courseName { get; set; } //课程名
        public string courseTime { get;set; } //课程时间
        public string courseTeacer { get; set; }  //任课教师
        public string courseRoom { get; set; }  //教室
        public string courseDes { get; set; }   //课程描述
    }
}
