using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Linq;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Text = "Panel";
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            this.Controls.OfType<Button>().ToList().ForEach(button =>// για όλα τα κουμπιά:
            {
                button1.Tag = new Stopwatch();//δημιουργεί stopwatch κλάση
                button1.MouseDown += new MouseEventHandler(button1_MouseDown);//η οποία λειτουργεί μαζι με τις 2 event κλάσεις
                button1.MouseUp += new MouseEventHandler(button1_MouseUp);// mousedown και mouseup για το κάθε κουμπί
                button2.Tag = new Stopwatch();
                button2.MouseDown += new MouseEventHandler(button2_MouseDown);
                button2.MouseUp += new MouseEventHandler(button2_MouseUp);
            });

            result =//το κείμενο που εμφανίζεται στο richtextbox
                "-The button 'coordinates' times clicked: " + button1events[0].ToString() + Environment.NewLine
                + "-The button 'coordinates' time clicked: " + (button1events[1] / 1000).ToString() + " sec" + Environment.NewLine
                + "-The button 'coordinates' mouse enter:" + button1events[2].ToString() + Environment.NewLine
                + "-The button 'coordinates' mouse hover: " + button1events[3].ToString() + Environment.NewLine
                + "-Radio button change choice: " + (radio1events[0] + radio2events[0]).ToString() + Environment.NewLine
                + "-Option 1 clicked: " + radio1events[1].ToString() + Environment.NewLine
                + "-Option 2 clicked: " + radio2events[1].ToString() + Environment.NewLine
                + "-Option 1 mouse enter:" + radio1events[2].ToString() + Environment.NewLine
                + "-Option 1 mouse hover: " + radio1events[3].ToString() + Environment.NewLine
                + "-Option 2 mouse enter:" + radio1events[2].ToString() + Environment.NewLine
                + "-Option 2 mouse hover: " + radio1events[3].ToString() + Environment.NewLine
                + "-text box times changed: " + textboxevents[0].ToString() + Environment.NewLine
                + "-text box times enter: " + textboxevents[1].ToString() + Environment.NewLine
                + "-text box times hover: " + textboxevents[2].ToString() + Environment.NewLine
                + "-combo box times clicked: " + textboxevents[3].ToString() + Environment.NewLine
                + "-combo box times changed: " + comboevents[3].ToString() + Environment.NewLine
                + "-combo box times enter: " + comboevents[1].ToString() + Environment.NewLine
                + "-combo box times hover: " + comboevents[2].ToString() + Environment.NewLine
                + "-combo box times clicked: " + comboevents[0].ToString() + Environment.NewLine
                + "-panel times clicked: " + panelevents[2].ToString() + Environment.NewLine
                + "-panel times color changed: " + panelevents[1].ToString() + Environment.NewLine
                + "-panel times enter: " + panelevents[0].ToString() + Environment.NewLine
                + "-The button 'change color' times clicked: " + button2events[0].ToString() + Environment.NewLine
                + "-The button 'change color' time clicked: " + (button2events[1] / 1000).ToString() + " sec" + Environment.NewLine
                + "-The button 'change color' mouse enter: " + button2events[2].ToString() + Environment.NewLine
                + "-The button 'change color' mouse hover: " + button2events[3].ToString() + Environment.NewLine
                + "-The label 'click me' times clicked: " + labelevents[0].ToString() + Environment.NewLine
                + "-The label 'click me' mouse enter: " + labelevents[1].ToString() + Environment.NewLine
                + "-The label 'click me' mouse hover: " + labelevents[2].ToString();

            richTextBox1.Text = result;
        }

        private Random rnd = new Random();//για το χρώμα random κλάση
        bool a;//για το κουμπί coordinate
        string result;
        string c;
        
        //για κάθε ένα αντικείμενο της φόρμας δημιουργώ array με τα events 
        double[] button1events = new double[4] {0, 0, 0, 0};
        double[] button2events = new double[4] { 0, 0, 0, 0};
        double[] textboxevents = new double[4] { 0, 0, 0, 0};
        double[] panelevents = new double[3] { 0, 0, 0};
        double[] radio1events = new double[4] { 0, 0, 0, 0};
        double[] radio2events = new double[4] { 0, 0, 0, 0};
        double[] comboevents = new double[4] { 0, 0, 0, 0};
        double[] labelevents = new double[3] { 0, 0, 0};
        

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (a)//αν έχει πατηθεί το κουμπί coordinates 
            {
                //στις ετικέτες θα εμφανίζονται οι συντεταγμένες του κέρσορα
                label1.Text = e.X.ToString();
                label2.Text = e.Y.ToString();
            }
        }
        
//-------------Button1 Events---------------

        private void button1_MouseClick(object sender, MouseEventArgs e)//Κουμπί για τις συντεταγμένες του κέρσορα
        {
            a = !a;
            button1events[0] += 1;

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)//μόλις πατηθεί το κουμπί
        {
            ((sender as Button).Tag as Stopwatch).Start();//ξεκινάει η χρονομέτρηση
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)//όταν σταματήσει να πατάει το κουμπί
        {
            Stopwatch watch = ((sender as Button).Tag as Stopwatch);//σταματάει η χρονομέτρηση
            watch.Stop();//το αποτέλεσμα είναι σε milliseconds
            button1events[1] += watch.Elapsed.TotalMilliseconds;//προσθέτω τους χρόνους
            watch.Reset();//επαναφορά της χρονομέτρησης σε 0

        }
       
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1events[2] += 1;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1events[3] += 1;

        }
//------------------------------------------


//-------------Radio Buttons Events---------------
        //-----1st Radio Button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton1.Checked)
            {
                radio1events[0] += 1;//συνολικά πόσες φορές άλλαξα επιλογή

            }
        }
        private void radioButton1_Click(object sender, EventArgs e)
        {
            radio1events[1] += 1;//πόσες φορές πάτησα την 1η επιλογή
            c = "Option1";
        }
        private void radioButton1_MouseEnter(object sender, EventArgs e)
        {
            radio1events[2] += 1;

        }

        private void radioButton1_MouseHover(object sender, EventArgs e)
        {
            radio1events[3] += 1;

        }

        //-----2nd Radio Button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton2.Checked)//συνολικά πόσες φορές άλλαξα επιλογή
                radio1events[0] += 1;//στο τέλος προσθέτω τα radio1events[0] και radio2events[0]
                                     //για να δω πόσες φορές συνολικά άλλαξα επιλογή 

        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            radio2events[1] += 1;//πόσες φορές πάτησα την 2η επιλογή
            c = "Option 2";
        }
        private void radioButton2_MouseEnter(object sender, EventArgs e)
        {
            radio2events[2] += 1;

        }

        private void radioButton2_MouseHover(object sender, EventArgs e)
        {
            radio2events[3] += 1;

        }
//------------------------------------------

//----------------Text Box Events--------------------
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textboxevents[0] += 1;

        }
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textboxevents[1] += 1;

        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            textboxevents[2] += 1;

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textboxevents[3] += 1;

        }
//------------------------------------------

//-------------Combo Box Events----------------
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            comboevents[3] += 1;

        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            comboevents[1] += 1;

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboevents[0] += 1;

        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            comboevents[2] += 1;

        }
//------------------------------------------

//--------------Panel Events----------------
        private void panel1_MouseEnter(object sender, EventArgs e)
        {

            label4.Text = "Inside";
            panelevents[0] += 1;


        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            label4.Text = "Outside";
            
        }
       
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panelevents[2] += 1;

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panelevents[1] += 1;

        }
//------------------------------------------

//-------------------Button 2 Events---------------------

        private void button2_Click(object sender, EventArgs e)//change color button
        {
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            panel1.BackColor = randomColor;
            button2events[0] += 1;

        }
        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            Stopwatch watch = ((sender as Button).Tag as Stopwatch);//σταματάει η χρονομέτρηση
            watch.Stop();//το αποτέλεσμα είναι σε milliseconds
            button2events[1] += watch.Elapsed.TotalMilliseconds;//προσθέτω τους χρόνους
            watch.Reset();//επαναφορά της χρονομέτρησης σε 0
  
        }
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            ((sender as Button).Tag as Stopwatch).Start();//ξεκινάει η χρονομέτρηση
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2events[2] += 1;

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2events[3] += 1;

        }
//--------------------------------------------

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

//------------Label 6 Events-------------
        private void label6_Click(object sender, EventArgs e)
        //στο label6 εμφανίζω κάποια στοιχεία της φόρμας
        {
            string x, y, t;

            labelevents[0] += 1;
            if (label1.Text == "X")//αν δεν έχει πατηθεί το κουμπί coordinates
            {
                x = "X";
                y = "Y";
            }
            else
            {
                x = label1.Text;
                y = label2.Text;
            }

            if (!radioButton1.Checked && !radioButton2.Checked)
                c = "No option";
            else if (radioButton1.Checked)
                c = radioButton1.Text;
            else if (radioButton2.Checked)
                c = radioButton2.Text;


         
            t = comboBox1.Text;
           

            MessageBox.Show("Coordinates: " + x + " . " + y + "\n" 
                + "The Choice is: " + c + "\n" 
                + "The text of the textbox is: " + textBox1.Text + "\n" 
                + "The text style chosen is: " + t +"\n"
                );
        }
        private void label6_MouseEnter(object sender, EventArgs e)
        {
            labelevents[1] += 1;

        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            labelevents[2] += 1;

        }
//------------------------------------

        //στο πάτημα του result button μετά το reset η φόρμα έχει αλλάξει το χρώμα της
        //άρα για το πάτημα του κουμπιου θα αφαιρώ μια επανάληψη αυτού του event
        //αρχικοποιώ μια μεταβλητή για αυτόν τον σκοπό
        bool fresult = true;

        private void button3_Click(object sender, EventArgs e)//reset button
        {
            fresult = true;
            panel1.BackColor = DefaultBackColor;
            label4.Text = "Panel";
            label1.Text = "X";
            label2.Text = "Y";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            comboBox1.SelectedItem = null;
            a = false;
            Array.Clear(button1events, 0, button1events.Length);
            Array.Clear(button2events, 0, button2events.Length);
            Array.Clear(textboxevents, 0, textboxevents.Length);
            Array.Clear(panelevents, 0, panelevents.Length);
            Array.Clear(radio1events, 0, radio1events.Length);
            Array.Clear(radio2events, 0, radio2events.Length);
            Array.Clear(comboevents, 0, comboevents.Length);
            Array.Clear(labelevents, 0, labelevents.Length);

            result =
                "-The button 'coordinates' times clicked: " + button1events[0].ToString() + Environment.NewLine
                + "-The button 'coordinates' time clicked: " + (button1events[1] / 1000).ToString() + " sec" + Environment.NewLine
                + "-The button 'coordinates' mouse enter:" + button1events[2].ToString() + Environment.NewLine
                + "-The button 'coordinates' mouse hover: " + button1events[3].ToString() + Environment.NewLine
                + "-Radio button change choice: " + (radio1events[0] + radio2events[0]).ToString() + Environment.NewLine
                + "-Option 1 clicked: " + radio1events[1].ToString() + Environment.NewLine
                + "-Option 2 clicked: " + radio2events[1].ToString() + Environment.NewLine
                + "-Option 1 mouse enter:" + radio1events[2].ToString() + Environment.NewLine
                + "-Option 1 mouse hover: " + radio1events[3].ToString() + Environment.NewLine
                + "-Option 2 mouse enter:" + radio1events[2].ToString() + Environment.NewLine
                + "-Option 2 mouse hover: " + radio1events[3].ToString() + Environment.NewLine
                + "-text box times changed: " + textboxevents[0].ToString() + Environment.NewLine
                + "-text box times enter: " + textboxevents[1].ToString() + Environment.NewLine
                + "-text box times hover: " + textboxevents[2].ToString() + Environment.NewLine
                + "-combo box times clicked: " + textboxevents[3].ToString() + Environment.NewLine
                + "-combo box times changed: " + comboevents[3].ToString() + Environment.NewLine
                + "-combo box times enter: " + comboevents[1].ToString() + Environment.NewLine
                + "-combo box times hover: " + comboevents[2].ToString() + Environment.NewLine
                + "-combo box times clicked: " + comboevents[0].ToString() + Environment.NewLine
                + "-panel times clicked: " + panelevents[2].ToString() + Environment.NewLine
                + "-panel times color changed: " + panelevents[1].ToString() + Environment.NewLine
                + "-panel times enter: " + panelevents[0].ToString() + Environment.NewLine
                + "-The button 'change color' times clicked: " + button2events[0].ToString() + Environment.NewLine
                + "-The button 'change color' time clicked: " + (button2events[1] / 1000).ToString() + " sec" + Environment.NewLine
                + "-The button 'change color' mouse enter: " + button2events[2].ToString() + Environment.NewLine
                + "-The button 'change color' mouse hover: " + button2events[3].ToString() + Environment.NewLine
                + "-The label 'click me' times clicked: " + labelevents[0].ToString() + Environment.NewLine
                + "-The label 'click me' mouse enter: " + labelevents[1].ToString() + Environment.NewLine
                + "-The label 'click me' mouse hover: " + labelevents[2].ToString();

            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
            richTextBox1.Text = result;
        }


        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        

        private void button4_Click(object sender, EventArgs e)//result button
        {
            if(fresult == true)
            {
                panelevents[1] = 0;
                fresult = false;
            }

            Font defaultFont = SystemFonts.DefaultFont;
            result =
                "-The button 'coordinates' times clicked: " + button1events[0].ToString() + Environment.NewLine
                + "-The button 'coordinates' time clicked: " + (button1events[1] / 1000).ToString() + " sec" + Environment.NewLine
                + "-The button 'coordinates' mouse enter:" + button1events[2].ToString() + Environment.NewLine
                + "-The button 'coordinates' mouse hover: " + button1events[3].ToString() + Environment.NewLine
                + "-Radio button change choice: " + (radio1events[0] + radio2events[0]).ToString() + Environment.NewLine
                + "-Option 1 clicked: " + radio1events[1].ToString() + Environment.NewLine
                + "-Option 2 clicked: " + radio2events[1].ToString() + Environment.NewLine
                + "-Option 1 mouse enter:" + radio1events[2].ToString() + Environment.NewLine
                + "-Option 1 mouse hover: " + radio1events[3].ToString() + Environment.NewLine
                + "-Option 2 mouse enter:" + radio1events[2].ToString() + Environment.NewLine
                + "-Option 2 mouse hover: " + radio1events[3].ToString() + Environment.NewLine
                + "-text box times changed: " + textboxevents[0].ToString() + Environment.NewLine
                + "-text box times enter: " + textboxevents[1].ToString() + Environment.NewLine
                + "-text box times hover: " + textboxevents[2].ToString() + Environment.NewLine
                + "-combo box times clicked: " + textboxevents[3].ToString() + Environment.NewLine
                + "-combo box times changed: " + comboevents[3].ToString() + Environment.NewLine
                + "-combo box times enter: " + comboevents[1].ToString() + Environment.NewLine
                + "-combo box times hover: " + comboevents[2].ToString() + Environment.NewLine
                + "-combo box times clicked: " + comboevents[0].ToString() + Environment.NewLine
                + "-panel times clicked: " + panelevents[2].ToString() + Environment.NewLine
                + "-panel times color changed: " + panelevents[1].ToString() + Environment.NewLine
                + "-panel times enter: " + panelevents[0].ToString() + Environment.NewLine
                + "-The button 'change color' times clicked: " + button2events[0].ToString() + Environment.NewLine
                + "-The button 'change color' time clicked: " + (button2events[1] / 1000).ToString() + " sec" + Environment.NewLine
                + "-The button 'change color' mouse enter: " + button2events[2].ToString() + Environment.NewLine
                + "-The button 'change color' mouse hover: " + button2events[3].ToString() + Environment.NewLine
                + "-The label 'click me' times clicked: " + labelevents[0].ToString() + Environment.NewLine
                + "-The label 'click me' mouse enter: " + labelevents[1].ToString() + Environment.NewLine
                + "-The label 'click me' mouse hover: " + labelevents[2].ToString();

            //άλλαγμα του text style ανάλογα την επιλογή στο combobox
            if (comboBox1.Text == "Normal" || comboBox1.SelectedItem == null)
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
                richTextBox1.Text = result;
            }
            else if (comboBox1.Text == "Bold")
            {
                richTextBox1.Text = result;
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);

            }
            else if (comboBox1.Text == "Italic")
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
                richTextBox1.Text = result;
            }
            else if (comboBox1.Text == "Underline")
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Underline);
                richTextBox1.Text = result;
            }
            else if (comboBox1.Text == "Strikeout")
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Strikeout);
                richTextBox1.Text = result;
            }
           
        }
    }



}