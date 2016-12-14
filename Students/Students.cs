using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Students
{
    public partial class StudentsApplication: Form
    {
        public StudentsApplication()
        {
            InitializeComponent();
        }

        public static DataTable Table = new DataTable();
        private int _indexRow;
        // keeps data of every enrolled student ever
        protected static List<Student> StudentRecord = new List<Student>();
   
        private void StudentsApplication_Load(object sender, EventArgs e)
        {
            Table.TableName = "Enrolled Students";
            Table.Columns.Add("ID", typeof(int));         
            Table.Columns.Add("IMEI", typeof(string));
            Table.Columns.Add("Phone number", typeof(string));
            Table.PrimaryKey = new[] { Table.Columns["ID"] };


            dataGridViewStudents.DataSource = Table;
            dataGridViewStudents.AllowUserToAddRows = false;
            dataGridViewStudents.AllowUserToDeleteRows = false;
        }
       
        //
        // CREATE
        //
        private void buttonAddStudent_Click(object sender, EventArgs e)
        {
            if (!ValidateStudentInformation(textBoxImei.Text, textBoxPhoneNumber.Text))
                return;

            var student = new Student
            {
              
                Imei = textBoxImei.Text,
                PhoneNumber = textBoxPhoneNumber.Text == @" "
                    ? "-"
                    : textBoxPhoneNumber.Text
            };

            // keeps a copy of the student in case of data loss
            StudentRecord.Add(student);
            // adds the student to the table
            AddStudentToTable(student);
            textBoxImei.Text = "";
            textBoxPhoneNumber.Text = "";
        }
        public void AddStudentToTable(Student ip)
        {
            var row = Table.NewRow();
            row.ItemArray = new object[]
            {
                ip.Id,
                ip.Imei,
                ip.PhoneNumber
            };
            
            Table.Rows.Add(row);
        }
        
        //
        // UPDATE
        //
        private void dataGridViewStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _indexRow = e.RowIndex;
            if (e.RowIndex == -1) return;
            DataGridViewRow row = dataGridViewStudents.Rows[_indexRow];

            textBoxImei.Text = row.Cells["IMEI"].Value.ToString();
            textBoxPhoneNumber.Text = row.Cells["Phone number"].Value.ToString();
        }

        //
        // DELETE
        //
        private void buttonDeleteStudent_Click(object sender, EventArgs e)
        {
            DeleteStudent();
        }
        private void dataGridViewStudents_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode & Keys.Delete) != Keys.Delete)
                return;
            DeleteStudent();
        }
        private void DeleteStudent()
        {
            var validate =
                MessageBox.Show(@"Вы уверены что хотите удалить выбранную ячейку?", @"Подтвердить удаление",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (validate == DialogResult.No)
                return;
            var selected = dataGridViewStudents.SelectedRows;
            if (selected.Count == 0) return;
            int i = 0;
            for (; i < selected.Count; i++)
            {
                DataGridViewRow row = selected[i];
                dataGridViewStudents.Rows.Remove(row);
            }
            
            MessageBox.Show($@"Удалена {i} ячейка", @"Удалено",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonClearFields_Click(object sender, EventArgs e)
        {
           
            textBoxImei.Text = "";
            textBoxPhoneNumber.Text = "";
        }
        
        //
        // VALIDATE INPUT
        //
        private bool ValidateStudentInformation(string imei, string phoneNumber)
        {
            // Empty entry

            if (imei == "")
            {
                MessageBox.Show(@"Поле IMEI не может быть пустым!", @"Пустое поле IMEI",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            

            if (phoneNumber.Length != phoneNumber.Count(char.IsDigit) || phoneNumber.Length > 13)
            {
                MessageBox.Show(@"Введенный номер не соответствует формату!", @"Неправильный номер телефона",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // duplicate entry
            
            var rows_imei = dataGridViewStudents.Rows;
            //var rows_phone = dataGridViewStudents.Rows;



            for (int i = 0; i < rows_imei.Count; i++)
            {
                if (rows_imei[i].Cells["IMEI"].Value.ToString() != imei || 
                    (rows_imei[i].State & DataGridViewElementStates.Selected) != 0) continue;

                MessageBox.Show(@"Такой IMEI уже есть!", @"Уже существует",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        
        //
        // EXPORT
        //
        private void buttonExport_Click(object sender, EventArgs e)
        {
            ImportExport.ExportMain();
        }

        //
        // IMPORT
        //
        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (!ImportExport.ImportMain())
                return;
            dataGridViewStudents.Columns.Clear();
            dataGridViewStudents.DataSource = Table;
        }

        private void StudentsApplication_FormClosed(object sender, FormClosedEventArgs e)
        {
            Table.Dispose();
            dataGridViewStudents.Dispose();
        }

        private void inputLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control.GetType() == typeof(RadioButton))
                {
                    RadioButton rbControl = (RadioButton)control;

                    if (rbControl.Checked)
                    {
                        if (saleFL.Checked) //Продажи физ лицам (без скидки)
                        {
                            var xmlFile1 = File.OpenText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlTemplate/" + rbControl.Text.Substring(0, 1) + ".txt");
                            var textFromXmlDocumen = xmlFile1.ReadToEnd();

                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(textFromXmlDocumen);

                            XmlElement rootElementOriginal = (XmlElement)xmlDocument.LastChild;
                            XmlElement rootElementForChange = (XmlElement)xmlDocument.LastChild.Clone();
                            XmlNodeList rootElementFromOriginalChildren = rootElementOriginal.ChildNodes;

                            for (int i = 0; i < Table.Rows.Count - 1; i++)
                            {
                                foreach (XmlElement child in rootElementFromOriginalChildren)
                                    rootElementForChange.AppendChild((XmlElement)child.Clone());
                            }

                            xmlDocument.ReplaceChild(rootElementForChange, rootElementOriginal);

                            int j = 0;
                            XmlNodeList xmlNodesFromQueryIMEIs = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormTable/FormField/inputText");
                            XmlNodeList xmlNodesFromQueryNumPhones = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormGroup/FormGroup/FormField/inputText");
                            foreach (XmlNode xmlNode in xmlNodesFromQueryIMEIs)
                            {
                                string imei = dataGridViewStudents.Rows[j].Cells[1].Value.ToString();
                                XmlAttribute attributeImei = xmlNode.Attributes["text"];
                                attributeImei.Value = imei;
                                j++;
                            }

                            j = 0;
                            foreach (XmlNode xmlNode in xmlNodesFromQueryNumPhones)
                            {
                                string numPhone = dataGridViewStudents.Rows[j].Cells[2].Value.ToString();
                                XmlAttribute attributeNumPhone = xmlNode.Attributes["text"];
                                attributeNumPhone.Value = numPhone;
                                j++;
                            }

                            string outerXml = xmlDocument.FirstChild.OuterXml + "\n" + XDocument.Parse(xmlDocument.OuterXml).ToString();
                            
                            File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlOut/" + rbControl.Text.Substring(0) + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss") + ".txt", outerXml, Encoding.UTF8);
                            
                            MessageBox.Show("Complete.");
                        }


                        else if(saleYL.Checked)   //Продажи юр лицам (без скидки)
                        {
                            var xmlFile2 = File.OpenText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlTemplate/" + rbControl.Text.Substring(0, 1) + ".txt");
                            var textFromXmlDocumen = xmlFile2.ReadToEnd();

                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(textFromXmlDocumen);

                            XmlElement rootElementOriginal = (XmlElement)xmlDocument.LastChild;
                            XmlElement rootElementForChange = (XmlElement)xmlDocument.LastChild.Clone();
                            XmlNodeList rootElementFromOriginalChildren = rootElementOriginal.ChildNodes;

                            for (int i = 0; i < Table.Rows.Count - 1; i++)
                            {
                                foreach (XmlElement child in rootElementFromOriginalChildren)
                                    rootElementForChange.AppendChild((XmlElement)child.Clone());
                            }

                            xmlDocument.ReplaceChild(rootElementForChange, rootElementOriginal);

                            int j = 0;
                            XmlNodeList xmlNodesFromQueryIMEIs2 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormTable/FormField/inputText");
                            XmlNodeList xmlNodesFromQueryNumPhones2 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormGroup/FormGroup/FormField/inputText");
                            foreach (XmlNode xmlNode in xmlNodesFromQueryIMEIs2)
                            {
                                string imei2 = dataGridViewStudents.Rows[j].Cells[1].Value.ToString();
                                XmlAttribute attributeImei = xmlNode.Attributes["text"];
                                attributeImei.Value = imei2;
                                j++;
                            }

                            j = 0;
                            foreach (XmlNode xmlNode in xmlNodesFromQueryNumPhones2)
                            {
                                string numPhone2 = dataGridViewStudents.Rows[j].Cells[2].Value.ToString();
                                XmlAttribute attributeNumPhone = xmlNode.Attributes["text"];
                                attributeNumPhone.Value = numPhone2;
                                j++;
                            }

                            string outerXml = xmlDocument.FirstChild.OuterXml + "\n" + XDocument.Parse(xmlDocument.OuterXml).ToString();

                            File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlOut/" + rbControl.Text.Substring(0) + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss") + ".txt", outerXml, Encoding.UTF8);

                            MessageBox.Show("Complete.");
                        }

                        else if (sale_cpec_YL.Checked) //3 Продажи юр лицам по спец цене (Особая цена) 

                        {
                            var xmlFile3 = File.OpenText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlTemplate/" + rbControl.Text.Substring(0, 1) + ".txt");
                            var textFromXmlDocumen = xmlFile3.ReadToEnd();

                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(textFromXmlDocumen);

                            XmlElement rootElementOriginal = (XmlElement)xmlDocument.LastChild;
                            XmlElement rootElementForChange = (XmlElement)xmlDocument.LastChild.Clone();
                            XmlNodeList rootElementFromOriginalChildren = rootElementOriginal.ChildNodes;

                            for (int i = 0; i < Table.Rows.Count - 1; i++)
                            {
                                foreach (XmlElement child in rootElementFromOriginalChildren)
                                    rootElementForChange.AppendChild((XmlElement)child.Clone());
                            }

                            xmlDocument.ReplaceChild(rootElementForChange, rootElementOriginal);

                            int j = 0;
                            XmlNodeList xmlNodesFromQueryIMEIs3 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormTable/FormField/inputText");
                            XmlNodeList xmlNodesFromQueryNumPhones3 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormGroup/FormGroup/FormField/inputText");
                            foreach (XmlNode xmlNode in xmlNodesFromQueryIMEIs3)
                            {
                                string imei3 = dataGridViewStudents.Rows[j].Cells[1].Value.ToString();
                                XmlAttribute attributeImei = xmlNode.Attributes["text"];
                                attributeImei.Value = imei3;
                                j++;
                            }

                            j = 0;
                            foreach (XmlNode xmlNode in xmlNodesFromQueryNumPhones3)
                            {
                                string numPhone3 = dataGridViewStudents.Rows[j].Cells[2].Value.ToString();
                                XmlAttribute attributeNumPhone = xmlNode.Attributes["text"];
                                attributeNumPhone.Value = numPhone3;
                                j++;
                            }

                            string outerXml = xmlDocument.FirstChild.OuterXml + "\n" + XDocument.Parse(xmlDocument.OuterXml).ToString();

                            File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlOut/" + rbControl.Text.Substring(0) + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss") + ".txt", outerXml, Encoding.UTF8);

                            MessageBox.Show("Complete.");
                        }

                        else if(sale_spec_FL.Checked)   //4 Продажи физ лицам по спец цене (Особая цена) 
                        {
                            var xmlFile4 = File.OpenText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlTemplate/" + rbControl.Text.Substring(0, 1) + ".txt");
                            var textFromXmlDocumen = xmlFile4.ReadToEnd();

                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(textFromXmlDocumen);

                            XmlElement rootElementOriginal = (XmlElement)xmlDocument.LastChild;
                            XmlElement rootElementForChange = (XmlElement)xmlDocument.LastChild.Clone();
                            XmlNodeList rootElementFromOriginalChildren = rootElementOriginal.ChildNodes;

                            for (int i = 0; i < Table.Rows.Count - 1; i++)
                            {
                                foreach (XmlElement child in rootElementFromOriginalChildren)
                                    rootElementForChange.AppendChild((XmlElement)child.Clone());
                            }

                            xmlDocument.ReplaceChild(rootElementForChange, rootElementOriginal);

                            int j = 0;
                            XmlNodeList xmlNodesFromQueryIMEIs4 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormTable/FormField/inputText");
                            XmlNodeList xmlNodesFromQueryNumPhones4 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormGroup/FormGroup/FormField/inputText");

                            foreach (XmlNode xmlNode in xmlNodesFromQueryIMEIs4)
                            {
                                string imei4 = dataGridViewStudents.Rows[j].Cells[1].Value.ToString();
                                XmlAttribute attributeImei = xmlNode.Attributes["text"];
                                attributeImei.Value = imei4;
                                j++;
                            }

                            j = 0;
                            foreach (XmlNode xmlNode in xmlNodesFromQueryNumPhones4)
                            {
                                string numPhone3 = dataGridViewStudents.Rows[j].Cells[2].Value.ToString();
                                XmlAttribute attributeNumPhone = xmlNode.Attributes["text"];
                                attributeNumPhone.Value = numPhone3;
                                j++;
                            }

                            string outerXml = xmlDocument.FirstChild.OuterXml + "\n" + XDocument.Parse(xmlDocument.OuterXml).ToString();

                            File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlOut/" + rbControl.Text.Substring(0) + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss") + ".txt", outerXml, Encoding.UTF8);

                            MessageBox.Show("Complete.");
                        }

                        else if(sale6_month_YL.Checked)  // 2_Продажа в рассрочку 6 мес ЮЛ
                        {
                            var xmlFile5 = File.OpenText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlTemplate/" + rbControl.Text.Substring(0, 1) + ".txt");
                            var textFromXmlDocumen = xmlFile5.ReadToEnd();

                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(textFromXmlDocumen);

                            XmlElement rootElementOriginal = (XmlElement)xmlDocument.LastChild;
                            XmlElement rootElementForChange = (XmlElement)xmlDocument.LastChild.Clone();
                            XmlNodeList rootElementFromOriginalChildren = rootElementOriginal.ChildNodes;

                            for (int i = 0; i < Table.Rows.Count - 1; i++)
                            {
                                foreach (XmlElement child in rootElementFromOriginalChildren)
                                    rootElementForChange.AppendChild((XmlElement)child.Clone());
                            }

                            xmlDocument.ReplaceChild(rootElementForChange, rootElementOriginal);

                            int j = 0;
                            XmlNodeList xmlNodesFromQueryIMEIs5 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormTable/FormField/inputText");
                            XmlNodeList xmlNodesFromQueryNumPhones5 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormGroup/FormGroup/FormField/inputText");

                            foreach (XmlNode xmlNode in xmlNodesFromQueryIMEIs5)
                            {
                                string imei5 = dataGridViewStudents.Rows[j].Cells[1].Value.ToString();
                                XmlAttribute attributeImei = xmlNode.Attributes["text"];
                                attributeImei.Value = imei5;
                                j++;
                            }

                            j = 0;
                            foreach (XmlNode xmlNode in xmlNodesFromQueryNumPhones5)
                            {
                                string numPhone5 = dataGridViewStudents.Rows[j].Cells[2].Value.ToString();
                                XmlAttribute attributeNumPhone = xmlNode.Attributes["text"];
                                attributeNumPhone.Value = numPhone5;
                                j++;
                            }

                            string outerXml = xmlDocument.FirstChild.OuterXml + "\n" + XDocument.Parse(xmlDocument.OuterXml).ToString();

                            File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlOut/" + rbControl.Text.Substring(0) + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss") + ".txt", outerXml, Encoding.UTF8);

                            MessageBox.Show("Complete.");
                        }
                    

                    else if(sales_6_month_FL.Checked)
                    {
                        var xmlFile6 = File.OpenText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlTemplate/" + rbControl.Text.Substring(0, 1) + ".txt");
                        var textFromXmlDocumen = xmlFile6.ReadToEnd();

                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(textFromXmlDocumen);

                        XmlElement rootElementOriginal = (XmlElement)xmlDocument.LastChild;
                        XmlElement rootElementForChange = (XmlElement)xmlDocument.LastChild.Clone();
                        XmlNodeList rootElementFromOriginalChildren = rootElementOriginal.ChildNodes;

                        for (int i = 0; i < Table.Rows.Count - 1; i++)
                        {
                            foreach (XmlElement child in rootElementFromOriginalChildren)
                                rootElementForChange.AppendChild((XmlElement)child.Clone());
                        }

                        xmlDocument.ReplaceChild(rootElementForChange, rootElementOriginal);

                        int j = 0;
                        XmlNodeList xmlNodesFromQueryIMEIs6 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormTable/FormField/inputText");
                        XmlNodeList xmlNodesFromQueryNumPhones6 = xmlDocument.SelectNodes("/uilog/ClientApplicationWindow/Form/FormGroup/FormGroup/FormGroup/FormField/inputText");

                        foreach (XmlNode xmlNode in xmlNodesFromQueryIMEIs6)
                        {
                            string imei6 = dataGridViewStudents.Rows[j].Cells[1].Value.ToString();
                            XmlAttribute attributeImei = xmlNode.Attributes["text"];
                            attributeImei.Value = imei6;
                            j++;
                        }

                        j = 0;
                        foreach (XmlNode xmlNode in xmlNodesFromQueryNumPhones6)
                        {
                            string numPhone6 = dataGridViewStudents.Rows[j].Cells[2].Value.ToString();
                            XmlAttribute attributeNumPhone = xmlNode.Attributes["text"];
                            attributeNumPhone.Value = numPhone6;
                            j++;
                        }

                        string outerXml = xmlDocument.FirstChild.OuterXml + "\n" + XDocument.Parse(xmlDocument.OuterXml).ToString();

                        File.WriteAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + "/../" + "/xmlOut/" + rbControl.Text.Substring(0) + DateTime.Now.ToString("_dd.MM.yyyy_HH.mm.ss") + ".txt", outerXml, Encoding.UTF8);

                        MessageBox.Show("Complete.");
                    }

                    }
                }
            }
        }

        private void buttonsLayout2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sale_cpec_YL_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void sale_spec_FL_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}