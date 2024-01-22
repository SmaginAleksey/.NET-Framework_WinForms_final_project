using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class accountsManagementForm : Form
    {
        public accountsManagementForm()
        {
            InitializeComponent();
        }

        private void accountsManagementForm_Load(object sender, EventArgs e)
        {
            Program.UpdateSecurityComboBox(comboBoxLogins);
        }

        private void buttonConfirmAction_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.TextLength == 0 || textBoxPassword.TextLength == 0 
                || textBoxConfirmPassword.TextLength == 0)
            {
                MessageBox.Show("Все поля обязательны к заполнению");
                return;
            }
            if (textBoxPassword.Text != textBoxConfirmPassword.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            try
            {
                using (var db = new ExtInfoEntities())
                {
                    if (buttonConfirmAction.Text == "Добавить")
                    {
                        var newLogin = db.Security.Where(s => s.Login == textBoxLogin.Text).
                            FirstOrDefault();
                        if (newLogin != null)
                        {
                            MessageBox.Show("Такой пользователь уже существует!");
                            return;
                        }
                        db.Security.Add(new Security
                        {
                            Login = textBoxLogin.Text,
                            Password = textBoxPassword.Text
                        });
                        db.SaveChanges();
                        MessageBox.Show("Успешно добавлено!");
                        Program.UpdateSecurityComboBox(comboBoxLogins);
                    }
                    else if (buttonConfirmAction.Text == "Изменить")
                    {
                        var existingLogin = db.Security.Where(s => s.Login == textBoxLogin.Text).
                            FirstOrDefault();
                        existingLogin.Login = textBoxLogin.Text;
                        existingLogin.Password = textBoxPassword.Text;
                        db.SaveChanges();
                        MessageBox.Show("Успешно изменено!");
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (comboBoxLogins.Text == "")
            {
                MessageBox.Show("Не выбрана учётная запись для редактирования!");
                return;
            }
            else
            {
                EditButtonClicked();
            }
        }

        /// <summary>
        /// Изменяет элементы интерфейса формы при нажатии на кнопку "Редактировать"
        /// </summary>
        private void EditButtonClicked()
        {
            groupBox1.Text = "Изменить учётную запись";
            buttonConfirmAction.Text = "Изменить";
            comboBoxLogins.Enabled = false;
            buttonDelete.Enabled = false;

            //Запрет на изменение имени пользователя у учётных записей "user" и "admin"
            if (comboBoxLogins.Text == "user" || comboBoxLogins.Text == "admin")
            {
                textBoxLogin.Enabled = false;
            }

            using (var db = new ExtInfoEntities())
            {
                var existingLogin = db.Security.Where(s => s.Login == comboBoxLogins.Text).
                    FirstOrDefault();
                textBoxLogin.Text = existingLogin.Login;
                textBoxPassword.Text = existingLogin.Password;
                textBoxConfirmPassword.Text = existingLogin.Password;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxLogins.Text == "")
            {
                MessageBox.Show("Не выбрана учётная запись для удаления!");
                return;
            }
            else if (comboBoxLogins.Text == "user" || comboBoxLogins.Text == "admin")
            {
                MessageBox.Show("Нельзя удалить этого пользователя!");
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show($"Уверены, что хотите удалить пользователя " +
                    $"{comboBoxLogins.Text}?","Подтверждение",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        using (var db = new ExtInfoEntities())
                        {
                            var existingLogin = db.Security.Where(s => s.Login == comboBoxLogins.Text).
                                FirstOrDefault();
                            db.Security.Remove(existingLogin);
                            db.SaveChanges();
                            MessageBox.Show("Удалено!");
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        //Определяет видимость вводимых символов при установке checkBox рядом с полем
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBoxConfirmPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxConfirmPassword.UseSystemPasswordChar = true;
            }
        }
    }
}