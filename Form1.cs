using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AWS_Cloud_Practitioner_Exam
{
    public partial class Form1 : Form
    {
        string Ruta="C:\\AWS_ExamFiles";

        public List<Question> List_Questions = new List<Question>();

        public int Index = 0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Reading files content

            lblQuestion.Text = "";
            lblTotal.Text = "";
            lblRespondiendo.Text = "";

            HideControls();


        }
        /// <summary>
        /// This method is used by several button associated with different files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCourse_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            HideControls();
           

            switch (btn.Tag.ToString())
            {
                case "1":
                  string[]  lines = System.IO.File.ReadAllLines(@Ruta + "\\File1.txt");

                  List_Questions = ProcessFileContent(lines);                    
                    break;

                case "2":
                    string[] lines2 = System.IO.File.ReadAllLines(@Ruta + "\\File2.txt");

                    List_Questions = ProcessFileContent(lines2);
                    break;
                case "3":
                    string[] lines3 = System.IO.File.ReadAllLines(@Ruta + "\\File3.txt");

                    List_Questions = ProcessFileContent(lines3);
                    break;
                case "4":
                    string[] lines4 = System.IO.File.ReadAllLines(@Ruta + "\\File4.txt");

                    List_Questions = ProcessFileContent(lines4);
                    break;
                case "5":
                    string[] lines5 = System.IO.File.ReadAllLines(@Ruta + "\\File5.txt");

                    List_Questions = ProcessFileContent(lines5);
                    break;
                case "6":
                    string[] lines6 = System.IO.File.ReadAllLines(@Ruta + "\\File6.txt");

                    List_Questions = ProcessFileContent(lines6);
                    break;
            }


            Index = 0;

            //mostrar el contenido
            lblTotal.Text ="Total: " + List_Questions.Count().ToString();
            lblRespondiendo.Text =  "1 of " + List_Questions.Count().ToString();

           
                lblQuestion.Text = List_Questions[0]._Question;

                if (List_Questions[0].Response.Length == 1)
                {
                                       
                    int index = 1;
                    foreach (String s in List_Questions[0].Responses)
                    {
                       
                        switch (index)
                        {
                            case 1:
                                rdbtnResponse1.Text = s;
                                rdbtnResponse1.Visible = true;
                                break;
                            case 2:
                                rdbtnResponse2.Visible = true;
                                rdbtnResponse2.Text = s;
                                break;
                            case 3:
                                rdbtnResponse3.Text = s;
                                rdbtnResponse3.Visible = true;
                                break;
                            case 4:
                                rdbtnResponse4.Text = s;
                                rdbtnResponse4.Visible = true;
                                break;

                        }
                        index++;
                    }
                }
                else
                {
                    //checkmark

                }
        }

        private List<Question> ProcessFileContent(string[] lines)
        {

            List<Question> _List_Questions = new List<Question>();

            int index = -1;

            /*
             *      Question
             *      *3
             *      a)
             *      b)
             *      c)
             *      d)
             * 
             * 
             * 
             * */

            foreach (string l in lines)
            {
                index++;
                if (l.Contains("--"))
                {
                    //encontrarmos la pregunta
                    Question q = new Question();
                             q._Question = l.Substring(2);

                    

                    for(int i=1;i<8;i++)
                    {
                       
                        
                        if((index+i)<lines.Length)
                        {

                            string line = lines[index + i];
                        
                        if (line.Contains('*'))
                        {
                            //encontramos la linea donde se dice la respuesta
                            if(line.Length==2){
                                //se encontro un numero *3 y es un radiobutton
                              //  q.Response = line.Substring(1);
                                int g = 0;
                                
                            }else{
                                //es un checkmark
                                int gd = 0;
                            }

                            q.Response = lines[index + i].Substring(1);
                        }
                        else
                        {
                            if (!lines[index + i].Contains("--")) 
                            {
                                q.Responses.Add(lines[index + i]);
                            }
                            else
                            {
                                //llegamos a la otra pregunta
                                i = 7;
                                //salimos del for
                            }
                        }

                        }
                    }

                    _List_Questions.Add(q);
                    //if(_List_Questions.Count()==45)
                    //{
                    //    int g = 9;
                    //}
                }
            }


          


            return _List_Questions;

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            RadioButton rdbtn = (RadioButton)sender;

            if (rdbtn.Tag.ToString() == List_Questions[Index].Response)
            {
                //poner verde la linea
                int g = 0;
                rdbtn.ForeColor = Color.DarkGreen;
               
            }
            Console.Out.WriteLine(List_Questions[Index].Response);
        }

        /// <summary>
        /// This Method hides all controls RadioButtons and CheckBoxes from UI
        /// </summary>
        private void HideControls()
        {
            //radiobutton

            chkboxResponse1.Visible = false;
            chkboxResponse2.Visible = false;
            chkboxResponse3.Visible = false;
            chkboxResponse4.Visible = false;
            chkboxResponse5.Visible = false;
            chkboxResponse6.Visible = false;
            chkboxResponse7.Visible = false;
            chkboxResponse8.Visible = false;
            chkboxResponse9.Visible = false;
            chkboxResponse10.Visible = false;

            //rdbtn
            rdbtnResponse1.Visible = false;
            rdbtnResponse2.Visible = false;
            rdbtnResponse3.Visible = false;
            rdbtnResponse4.Visible = false;
            rdbtnResponse5.Visible = false;
            rdbtnResponse6.Visible = false;
            rdbtnResponse7.Visible = false;
            rdbtnResponse8.Visible = false;
            rdbtnResponse9.Visible = false;
            rdbtnResponse10.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Index++;

           
          
            if (Index < List_Questions.Count())
            {
                lblRespondiendo.Text = Index + 1 + " of " + List_Questions.Count().ToString();


                lblQuestion.Text = List_Questions[Index]._Question;

                if (List_Questions[Index].Response.Length == 1)
                {
                    HideControls();



                    int index = 1;
                    foreach (String s in List_Questions[Index].Responses)
                    {





                        switch (index)
                        {
                            case 1:
                                rdbtnResponse1.Text = s;
                                rdbtnResponse1.Visible = true;
                                rdbtnResponse1.ForeColor = Color.Black;
                                rdbtnResponse1.Checked = false;
                                break;
                            case 2:
                                rdbtnResponse2.Text = s;
                                rdbtnResponse2.Visible = true;
                                rdbtnResponse2.ForeColor = Color.Black;
                                rdbtnResponse2.Checked = false;
                                break;
                            case 3:
                                rdbtnResponse3.Text = s;
                                rdbtnResponse3.Visible = true;
                                rdbtnResponse3.ForeColor = Color.Black;
                                rdbtnResponse3.Checked = false;
                                break;
                            case 4:
                                rdbtnResponse4.Text = s;
                                rdbtnResponse4.Visible = true;
                                rdbtnResponse4.ForeColor = Color.Black;
                                rdbtnResponse4.Checked = false;
                                break;
                            case 5:
                                rdbtnResponse5.Text = s;
                                rdbtnResponse5.Visible = true;
                                rdbtnResponse5.ForeColor = Color.Black;
                                rdbtnResponse5.Checked = false;
                                break;
                            case 6:
                                rdbtnResponse6.Text = s;
                                rdbtnResponse6.Visible = true;
                                rdbtnResponse6.ForeColor = Color.Black;
                                rdbtnResponse6.Checked = false;
                                break;
                            case 7:
                                rdbtnResponse7.Text = s;
                                rdbtnResponse7.Visible = true;
                                rdbtnResponse7.ForeColor = Color.Black;
                                rdbtnResponse7.Checked = false;
                                break;
                            case 8:
                                rdbtnResponse8.Text = s;
                                rdbtnResponse8.Visible = true;
                                rdbtnResponse8.ForeColor = Color.Black;
                                rdbtnResponse8.Checked = false;
                                break;
                            case 9:
                                rdbtnResponse9.Text = s;
                                rdbtnResponse9.Visible = true;
                                rdbtnResponse9.ForeColor = Color.Black;
                                rdbtnResponse9.Checked = false;
                                break;
                            case 10:
                                rdbtnResponse10.Text = s;
                                rdbtnResponse10.Visible = true;
                                rdbtnResponse10.ForeColor = Color.Black;
                                rdbtnResponse10.Checked = false;
                                break;
                                

                        }
                        index++;
                    }
                   
                   

                    
                   
                   
                   


                    //no checked
                  
                    
                   
                   


                   

                    
                }
                else
                {
                    HideControls();

                    int index = 1;
                    foreach (String s in List_Questions[Index].Responses)
                    {

                        switch (index)
                        {
                            case 1:
                                chkboxResponse1.Text = s;
                                chkboxResponse1.Location = new Point(122, 196);
                                chkboxResponse1.Visible = true;
                                chkboxResponse1.ForeColor = Color.Black;
                                chkboxResponse1.Checked = false;
                                break;
                            case 2:
                                chkboxResponse2.Text = s;
                                chkboxResponse2.Location = new Point(122, 228);
                                chkboxResponse2.Visible = true;
                                chkboxResponse2.ForeColor = Color.Black;
                                chkboxResponse2.Checked = false;
                                break;
                            case 3:
                                chkboxResponse3.Text = s;
                                chkboxResponse3.Location = new Point(122, 258);
                                chkboxResponse3.Visible = true;
                                chkboxResponse3.ForeColor = Color.Black;
                                chkboxResponse3.Checked = false;
                                break;
                            case 4:
                                chkboxResponse4.Text = s;
                                chkboxResponse4.Location = new Point(122, 288);
                                chkboxResponse4.Visible = true;
                                chkboxResponse4.ForeColor = Color.Black;
                                chkboxResponse4.Checked = false;
                                break;
                            case 5:
                                chkboxResponse5.Text = s;
                                chkboxResponse5.Location = new Point(522, 596);
                                chkboxResponse5.Visible = true;
                                chkboxResponse5.ForeColor = Color.Black;
                                chkboxResponse5.Checked = false;
                                break;
                            case 6:
                                chkboxResponse6.Text = s;
                                chkboxResponse6.Location = new Point(622, 696);
                                chkboxResponse6.Visible = true;
                                chkboxResponse6.ForeColor = Color.Black;
                                chkboxResponse6.Checked = false;
                                break;
                            case 7:
                                chkboxResponse7.Text = s;
                                chkboxResponse7.Location = new Point(722, 797);
                                chkboxResponse7.Visible = true;
                                chkboxResponse7.ForeColor = Color.Black;
                                chkboxResponse7.Checked = false;
                                break;
                            case 8:
                                chkboxResponse8.Text = s;
                                chkboxResponse8.Location = new Point(822, 898);
                                chkboxResponse8.Visible = true;
                                chkboxResponse8.ForeColor = Color.Black;
                                chkboxResponse8.Checked = false;
                                break;
                            case 9:
                                chkboxResponse9.Text = s;
                                chkboxResponse9.Location = new Point(922, 999);
                                chkboxResponse9.Visible = true;
                                chkboxResponse9.ForeColor = Color.Black;
                                chkboxResponse9.Checked = false;
                                break;
                            case 10:
                                chkboxResponse10.Text = s;
                                chkboxResponse10.Location = new Point(1022, 1010);
                                chkboxResponse10.Visible = true;
                                chkboxResponse10.ForeColor = Color.Black;
                                chkboxResponse10.Checked = false;
                                break;
                        }
                        index++;
                    }
                }
            }
        }

        private void chkboxResponse1_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = (CheckBox)sender;

            if ( List_Questions[Index].Response.Contains(chkbox.Tag.ToString()))
            {
                //poner verde la linea
                int g = 0;
                chkbox.ForeColor = Color.DarkGreen;
               
            }
           // Console.Out.WriteLine(List_Questions[Index].Response);
        }
    }
}
