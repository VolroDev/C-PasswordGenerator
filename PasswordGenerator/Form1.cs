using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int textLength = 0;
            try
            {
                textLength = Int32.Parse(textBox1.Text);

                Dictionary<int, string> paramsCode = new Dictionary<int, string>();
                int count = 0;

                if (checkBox1.Checked == true)
                {
                    count++;
                    paramsCode.Add(count, "UseUppercase");
                }
                if (checkBox2.Checked == true)
                {
                    count++;
                    paramsCode.Add(count, "UseSpecialCharacters");
                }
                if (checkBox3.Checked == true)
                {
                    count++;
                    paramsCode.Add(count, "UseNumbers");
                }

                count++;
                paramsCode.Add(count, "Standart");

                if (textBox1.TextLength != 0)
                {
                    string password = "";
                    var random = new Random();
                    int randomNumber = 0;
                    string newSymbol = "";
                    CharGenerate charGenerate = new CharGenerate();

                    while (password.Length != textLength)
                    {
                        randomNumber = random.Next(1, paramsCode.Count + 1);

                        if (paramsCode[randomNumber] == "UseUppercase")
                        {
                            newSymbol = charGenerate.StandartСharacter().ToUpper();
                        }
                        else if (paramsCode[randomNumber] == "UseSpecialCharacters")
                        {
                            newSymbol = charGenerate.UseSpecialCharacters();
                        }
                        else if (paramsCode[randomNumber] == "UseNumbers")
                        {
                            newSymbol = charGenerate.UseNumbers();
                        }
                        else if (paramsCode[randomNumber] == "Standart")
                        {
                            newSymbol = charGenerate.StandartСharacter();
                        }

                        bool repetition = false;
                        if (checkBox4.Checked == true) //Exclude duplicate characters
                        {

                            foreach (char symbol in password)
                            {
                                if (symbol.ToString() == newSymbol)
                                {
                                    repetition = true;
                                }
                            }
                        }

                        if (repetition == false)
                        {
                            password = password + newSymbol;
                        }
                    }

                    textBox2.Text = password;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите числовое значение в поле длина");

            }
        }

        public class CharGenerate
        {

            public string StandartСharacter()
            {
                string consonantsString = "aeioubcdfghjklmnpqrstvwxyz";

                char randChar = consonantsString[new Random().Next(1, consonantsString.Length)];

                return randChar.ToString();
            }

            public string UseSpecialCharacters()
            {
                string consonantsString = "!@#$%^&*()_+";

                char randChar = consonantsString[new Random().Next(1, consonantsString.Length)];

                return randChar.ToString();
            }

            public string UseNumbers()
            {
                string consonantsString = "1234567890";

                char randChar = consonantsString[new Random().Next(1, consonantsString.Length)];

                return randChar.ToString();
            }
        }

    }
}
