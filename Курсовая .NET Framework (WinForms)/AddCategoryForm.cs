using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class AddCategoryForm : Form
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxCategory.Text == "")
            {
                MessageBox.Show("Не введено значение для добавления", "Внимание");
                return;
            }
            if (!IsCategoryExist())
            {
                using (var db = new ExtInfoEntities())
                {
                    db.Categories.Add(new Categories { Name = textBoxCategory.Text });
                    db.SaveChanges();
                    MessageBox.Show("Успешно", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
        }

        /// <summary>
        /// Проверка на наличие добавляемой категории в БД
        /// </summary>
        /// <returns>true - категория существует, false - категории нет в БД</returns>
        private bool IsCategoryExist()
        {
            using (var db = new ExtInfoEntities())
            {
                var newCategory = db.Categories.Where(c => c.Name == textBoxCategory.Text).FirstOrDefault();
                if (newCategory != null)
                {
                    MessageBox.Show("Такая категория уже существует в базе", "Объект существует", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return true;
                }
                return false;
            }
        }
    }
}
