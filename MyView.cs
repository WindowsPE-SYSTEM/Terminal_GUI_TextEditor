using Terminal.Gui;
using System.IO;
using System;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;
//------------------------------------------------------------------------------

//  <auto-generated>
//      This code was generated by:
//        TerminalGuiDesigner v1.0.17.0
//      You can make changes to this file and they will not be overwritten when saving.
//  </auto-generated>
// -----------------------------------------------------------------------------
namespace TEXT_EDITOR
{
    public partial class MyView
    {
        public string path = "";
        public void PictureDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "选择文件";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                textField.Text = file;
            }
        }
        public MyView()
        {
            InitializeComponent();
            button2.Clicked += () => {
                try
                {
                    using (StreamReader sr = new StreamReader(Convert.ToString(textField.Text)))
                    {
                        textView.Text = sr.ReadToEnd();
                    }
                }catch(Exception e) {
                    Terminal.Gui.MessageBox.ErrorQuery("ERROR", "Failed to read file:\n"+Convert.ToString(e), "OK");
                }
            };
            button.Clicked += () =>
            {
                try
                {
                    using (StreamWriter sr = new StreamWriter(Convert.ToString(textField.Text)))
                    {
                        sr.Write(textView.Text);
                    }
                }
                catch (Exception e)
                {
                    Terminal.Gui.MessageBox.ErrorQuery("ERROR", "Failed to save file:\n"+Convert.ToString(e), "OK");
                }
            };
            button3.Clicked += () =>
            {
                Thread thread = new Thread(new ThreadStart(PictureDialog));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            };
        }
    }
}
