using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Основная форма программы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                IsAdminStateIsActive();
                ShowMainWindowQuery();
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Определяет видимость элементов формы на основе учетной записи пользователя.
        /// Под администратором отображаются дополнительные элементы.
        /// </summary>
        private void IsAdminStateIsActive()
        {
            if (Program.isAdmin)
            {
                toolStripStatusLabelAdminIndicator.Visible = true;
                настройкиToolStripMenuItem.Visible = true;
            }
        }

        /// <summary>
        /// Отображает подробную информацию о всех телефонах
        /// </summary>
        private void ShowMainWindowQuery()
        {
            using (var db = new ExtInfoEntities())
            {
                var subs = from s in db.Subscribers
                           orderby s.Extension
                           select new
                           {
                               Узел = s.PBX.RailroadStations.Name,
                               АТС = s.PBX.PBXModels.Name,
                               Номер = s.Extension,
                               Порт = s.Port,
                               Категория = s.Categories.Name,
                               Тип = s.Phones.Model,
                               Абонент = s.Name,
                               Адрес = s.Locations.RailroadStations.Name + " " + s.Locations.Position,
                               Примечание = s.AddInfo
                           };
                dataGridView1.DataSource = subs.ToList();
                toolStripStatusLabelRowCount.Text = "Строк отображено: " + dataGridView1.RowCount.
                    ToString();
                ColorizeGrid(db);
            }
        }

        /// <summary>
        /// Применяет цветовую раскраску таблицы, основанную на статусе и типе телефона
        /// </summary>
        private void ColorizeGrid(ExtInfoEntities db)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //[5, i] - в 5 столбце текущей строки отображается тип телефона. Так же если телефон
                //свободен в этом поле присутствует запись "FREE"
                var cellInColumn5 = dataGridView1[5, i];

                //Т.о. если телефон не свободен - каждая ячейка строки этого телефона красится в соотв. цвет
                if ((string)cellInColumn5.Value != "FREE")
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    var cells = row.Cells;
                    foreach (DataGridViewCell cell in cells)
                    {
                        cell.Style.BackColor = Color.LightGoldenrodYellow;
                    }
                }

                //Далее красится ячейка с типом телефона на основании фактического типа телефона
                if (GetPhoneType((string)cellInColumn5.Value) == "ISDN")
                {
                    cellInColumn5.Style.BackColor = Color.LightCoral;
                }
                else if (GetPhoneType((string)cellInColumn5.Value) == "SIP")
                {
                    cellInColumn5.Style.BackColor = Color.PaleTurquoise;
                }
                else if (GetPhoneType((string)cellInColumn5.Value) == "Analog")
                {
                    cellInColumn5.Style.BackColor = Color.PaleGreen;
                }
                else if (GetPhoneType((string)cellInColumn5.Value) == "Virtual")
                {
                    cellInColumn5.Style.BackColor = Color.Goldenrod;
                }
            }
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            ShowMainWindowQuery();
        }

        private void toolStripButtonHistory_Click(object sender, EventArgs e)
        {
            //Если не выделена строка с телефоном - вывести историю по всем телефонам за последнее время
            if (dataGridView1.SelectedRows.Count == 0)
            {
                ExtensionHistoryForm latestHistoryForm = new ExtensionHistoryForm();
                latestHistoryForm.Show();
                return;
            }

            //В противном случае выводится история по выбранному телефону - в этом случае
            //используется конструктор с одним параметром

            //Для начала достаём из выделенной строки номер телефона
            string ext = GetExtension();

            ExtensionHistoryForm extensionHistoryForm = new ExtensionHistoryForm(ext);
            extensionHistoryForm.Show();
        }

        private void toolStripButtonModifySubscriber_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбрана строка для внесения изменений", "Не выбрана строка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ext = GetExtension();
            ExtensionChangeForm extensionChangeForm = new ExtensionChangeForm(ext);
            extensionChangeForm.ShowDialog();
        }

        private void toolStripButtonFreedExtension_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Не выбрана строка для снятия телефона", "Не выбрана строка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult res = MessageBox.Show($"Уверены, что хотите снять телефон {GetExtension()}?",
                    "Подтверждение",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.OK)
                {
                    FreeExtension(GetExtension());
                }
            }
        }

        
        private void атсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogForm catalogForm = new CatalogForm("PBX");
            catalogForm.ShowDialog();
        }

        private void узлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogForm catalogForm = new CatalogForm("RailroadStations");
            catalogForm.ShowDialog();
        }

        private void телефоныToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogForm catalogForm = new CatalogForm("Phones");
            catalogForm.ShowDialog();
        }

        private void категорииВыходаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CatalogForm catalogForm = new CatalogForm("Categories");
            catalogForm.ShowDialog();
        }

        private void операторОтчётовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
        }

        private void учетныеЗаписиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accountsManagementForm accountsManagementForm = new accountsManagementForm();
            accountsManagementForm.ShowDialog();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Определяет тип телефона по его модели
        /// </summary>
        /// <param name="phoneModel">Поле класса Phones, хранящее в себе модель телефона</param>
        /// <returns>Тип телефона (н-р SIP, analog  и пр.)</returns>
        private string GetPhoneType(string phoneModel)
        {
            using (var db = new ExtInfoEntities())
            {
                string phoneType = db.Phones.Where(p => p.Model == phoneModel).Select(c => c.PhoneTypes.Name).
                    FirstOrDefault();
                return phoneType;
            }
        }

        /// <summary>
        /// Получает номер телефона из выделенной строки на основной форме
        /// </summary>
        /// <returns></returns>
        private string GetExtension()
        {
            var rows = dataGridView1.SelectedRows;
            var dataGridViewRow = rows[0];
            return dataGridView1[2, dataGridViewRow.Index].Value.ToString();
        }

        /// <summary>
        /// Переводит номер телефона в статус "Свободен"
        /// </summary>
        /// <param name="selectedExtension">Номер телефона для присвоения статуса "FREE"</param>
        internal void FreeExtension(string selectedExtension)
        {
            using (var db = new ExtInfoEntities())
            {
                var freeingExtension = db.Subscribers.Where(s => s.Extension == selectedExtension).
                    FirstOrDefault();
                freeingExtension.Port = null;
                freeingExtension.CategoryId = null;
                freeingExtension.PhoneId = 1;   //PhoneId == 1 - телефон со статусом FREE
                freeingExtension.Name = null;
                freeingExtension.LocationId = null;
                freeingExtension.AddInfo = null;
                db.SaveChanges();
            }
        }
    }
}
