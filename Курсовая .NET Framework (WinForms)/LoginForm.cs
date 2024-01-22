using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class LoginForm : Form
    {
        private int loginCount = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        //Для возвращения в основную форму отрицательного результата аутентификации при
        //ручном закрытии окна ввода логина/пароля
        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (DialogResult != DialogResult.OK) 
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Выполняет проверку аутентификационных данных для входа в программу
        /// </summary>
        /// <returns>true - аутентификаиця пройдена, иначе - false</returns>
        private bool CheckAutetnication()
        {
            using (var db = new ExtInfoEntities())
            {
                Security loginIsCorrect = db.Security.Where(s => s.Login == textBoxLogin.Text)
                    .Where(s => s.Password == textBoxPassword.Text).Where(s => s.IsAdmin == 
                    Program.isAdmin)
                    .FirstOrDefault();
                if (loginIsCorrect != null)
                {
                    return true;
                }
                return false;
            }
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if (loginCount == 2)
            {
                DialogResult = DialogResult.Cancel;
                MessageBox.Show("Превышен лимит ошибок авторизации", "Доступ запрещён", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else if (CheckAutetnication())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                loginCount++;
                MessageBox.Show("Неверные логин и(или) пароль", "Ошибка авторизации!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Заносит в программу информацию о выбранной роли и смещает фокус на ввод логина
        private void comboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRole.SelectedIndex == 0)
                Program.isAdmin = false;
            else
                Program.isAdmin = true;

            textBoxLogin.Focus();
        }

        //Смещает фокус на ввод пароля при нажатии клавиши Enter, находясь в поле ввода логина
        private void textBoxLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                textBoxPassword.Focus();
            }
        }

        //Выполняет имитацию нажатия кнопки ввода аутентификационных данных при нажатии клавиши Enter,
        //находясь в поле ввода пароля
        private void textBoxPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonLogIn.PerformClick();
            }
        }
    }
}