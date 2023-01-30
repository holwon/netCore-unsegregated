using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 富客户端应用_Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //new Thread(Work2).Start();
            new Task(Work3).Start();
        }

        // 错误方案
        private void Work2()
        {
            Thread.Sleep(5000);// 模拟一些耗时工作
            textBox1.Text += "work2"; // {"线程间操作无效: 从不是创建控件“textBox1”的线程访问它。"}
        }

        // 解决方案 1
        private void Work()
        {
            Thread.Sleep(5000);// 模拟一些耗时工作
            UpdateMessage_BeginInvoke("开始工作");
        }

        private void UpdateMessage_BeginInvoke(string message)
        {
            Action action = () => textBox1.Text += message;
            // 判断线程是否在主线程中，如果不在则为false
            // if (this.InvokeRequired)
            // {
            //     this.Invoke(action);
            // }
            // else
            // {
            //     action();
            // }
            // 使用 winform 自带的异步方案 
            BeginInvoke(action);
        }

        // 解决方案 2
        private void Work3()
        {
            Thread.Sleep(5000);
            this.Invoke(new EventHandler(delegate
            {
                textBox1.Text += "Work3";
            }));

            this.Invoke(new Action(() =>
            {
                textBox1.Text += "Work3";
            }));

        }
    }
}
