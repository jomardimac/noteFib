//Name: Jomar Dimaculangan
//ID:   11422439
//Notepad Fibonacci Assignment

using System;
using System.IO;
using System.Windows.Forms;

namespace dimaculangan_hw3 {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
        }

        private void Form1_Load (object sender, EventArgs e) {

        }


        private void loadFibonacciNumbersfirst50ToolStripMenuItem_Click (object sender, EventArgs e) {
            //techincally a textreader because inherits from it. just overload it with 50.
            FibonacciTextReader num = new FibonacciTextReader(50);
            Loadtext(num);
        }

        private void loadFibonacciNumbersfirst100ToolStripMenuItem_Click (object sender, EventArgs e) {
            //literally same as first50
            FibonacciTextReader num = new FibonacciTextReader(100);
            Loadtext(num);
        }

        private void loadFromFileToolStripMenuItem_Click (object sender, EventArgs e) {
            //used MSDN for help: https://msdn.microsoft.com/en-us/library/system.windows.forms.openfiledialog(v=vs.110).aspx

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                //grab file from the user:
                StreamReader file = new StreamReader(openFileDialog1.FileName);
                //open, load, close.
                openFileDialog1.OpenFile();
                Loadtext(file);
                file.Close();

            }
        }

        //again, used msdn: https://msdn.microsoft.com/en-us/library/system.windows.forms.savefiledialog(v=vs.110).aspx
        private void saveToFileToolStripMenuItem_Click (object sender, EventArgs e) {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            //GRAB ITEMS FROM TEXTBOX:
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
            }
        }

        //Generic Loading function:
        private void Loadtext (TextReader sr) {
            //the parameter textreader needs to be read and grab its text by each line
            using (sr) {
                //reset the textbox: 
                textBox1.ResetText();
                //grab each line from the textreader
                string text = sr.ReadToEnd();
                //output the line to the textbox
                textBox1.Text = text;
            }
        }

        private void textBox1_TextChanged (object sender, EventArgs e) {

        }

        private void openFileDialog1_FileOk (object sender, System.ComponentModel.CancelEventArgs e) {

        }

        private void saveFileDialog1_FileOk (object sender, System.ComponentModel.CancelEventArgs e) {

        }
    }
}
