using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            assignicon();
        }
        //تعريف ليبل و اعطائه قيمه نال
        Label firstclick = null;
        Label secondclick = null;
        //تعريف عنصر للقيم العشوائية
        Random r = new Random();
        //تعريف ليست بوكس واعطائها قيم
        List<string> icons = new List<string>()
        { "!","!","N","N",",",",","K","K","b","b","v","v","w","w","z","z"};

        private void assignicon()
        {
            //انشاء فور حتي تمر علي كل العناصر الموجده في تيبل لي اوت
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                //اعطاء قيمه تيبل لي اوت لمتغير من نوع ليبل
                Label iconlabel = control as Label;
                //شرط لو المتغير ده مبيساويش نل هينفذ اللي تحت
                if (iconlabel !=null)
                {
                    //هنعطي رقم عشوائي للمتغير 
                    int randomnumber = r.Next(icons.Count);
                    //العنصر اللي في الايكون بالرقم العشوائي هياخد قيمة الايكون ليبل
                       iconlabel.Text = icons[randomnumber];
                    //هيتم توحيداللون في الليبل
                        iconlabel.ForeColor = iconlabel.BackColor;
                    //هحذف الرقم اللي تم اختياره بالفعل
                    icons.RemoveAt(randomnumber);
                }
            }
        }

        private void lable_click(object sender, EventArgs e)
        {
            //لو التايمر واخد قيمه ترو ارجع فاضي
            if (timer1.Enabled == true)
                return;
            //انشاءعنصر من النوع ليبل و اعطاءه قسمه سيندر
            Label clickedlabel = sender as Label;
            //لو المتغير ده مبيساويش نال كملا
            if (clickedlabel != null)
            {
                //لو الفور  كولور = اسود ارجع
                if (clickedlabel.ForeColor == Color.Black)
                    return;
                //لو المتغير ده قيمته نال
                if(firstclick==null)
                {
                    //تبديل قيم
                    firstclick = clickedlabel;
                    //غير اللون خليه اسود
                    firstclick.ForeColor = Color.Black;
                    return;
                }
                //تبديل قيم
                secondclick = clickedlabel;
                //خلي اللون اسود
                secondclick.ForeColor = Color.Black;
                checkforwinner();
                if(firstclick.Text==secondclick.Text)
                {
                    //هنرجع كل حاجه زي م  كانت
                    firstclick = null;
                    secondclick = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            //هغير اللون
            firstclick.ForeColor = firstclick.BackColor;
            //هغير اللون
            secondclick.ForeColor = secondclick.BackColor;
            //هرجع كل حاجه زي الاول
            firstclick = null;
            secondclick = null;
        }
        private void checkforwinner()//داله هتعرفني مين الفائز
        {
            //فور هتمشي علي كل العناصر اللي ف تيبل لي اوت
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                //هعرف متغير من النوع ليبل
                Label iconlabel = control as Label;
                //لو المتغير ده مبيساويش نال
                if (iconlabel != null)
                {
                    //لو الفور كولور = الباك كولور
                    if (iconlabel.ForeColor == iconlabel.BackColor)
                        return;
                }
            }
            //مسدج هتظهرلي التيكست دي
            MessageBox.Show("you matched all the icons !", "congratulations!");
        }
    }
}
