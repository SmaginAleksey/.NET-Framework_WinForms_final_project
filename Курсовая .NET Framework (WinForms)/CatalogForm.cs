using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class CatalogForm : Form
    {
        //Т.к. из родительской формы можно попасть в текущую форму из различных пунктов меню -
        //то используя данное свойство можно сразу подгрузить нужную вкладку элемента tabControl
        private readonly string startPage;

        public CatalogForm(string tabPage)
        {
            InitializeComponent();
            IsAdminStateIsActive();
            startPage = tabPage;
        }

        //Отображение вкладки tabControl в зависимости от пункта меню, через которое была загружена
        //данная форма
        private void CatalogForm_Load(object sender, EventArgs e)
        {
            ShowRailroadStationsInfo();
            if (startPage == "RailroadStations") 
            {
                tabControl1.SelectedTab = tabPageRailroadStations;
                tabPageRailroadStations.Select();
            }
            else if (startPage == "PBX")
            {
                tabControl1.SelectedTab = tabPagePBX;
                tabPagePBX.Select();
            }
            else if (startPage == "Phones")
            {
                tabControl1.SelectedTab = tabPagePhones;
                tabPagePhones.Select();
            }
            else
            {
                tabControl1.SelectedTab = tabPageCategories;
                tabPageCategories.Select();
            }
        }

        //Отображение данных БД в зависимости от выбранной вкладки tabControl
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageRailroadStations)
            {
                ShowRailroadStationsInfo();
            }
            else if (tabControl1.SelectedTab == tabPagePBX)
            {
                ShowPBXInfo();
            }
            else if (tabControl1.SelectedTab == tabPagePhones)
            {
                ShowPhonesInfo();
            }
            else if (tabControl1.SelectedTab == tabPageCategories)
            {
                ShowCateroriesInfo();
            }
        }

        /// <summary>
        /// Отображение информации о ЖД станциях, имеющихся в БД
        /// </summary>
        private void ShowRailroadStationsInfo()
        {
            using (var db = new ExtInfoEntities())
            {
                var stations = db.RailroadStations.Select(rs => new
                {
                    ЖД_станция = rs.Name
                }).OrderBy(rs => rs.ЖД_станция);
                dataGridView1.DataSource = stations.ToList();
                ShowRowCount();
            }
        }

        /// <summary>
        /// Отображение информации об АТС, имеющихся в БД
        /// </summary>
        private void ShowPBXInfo()
        {
            using (var db = new ExtInfoEntities())
            {
                var pbxs = db.PBX.Select(p => new
                {
                    ЖД_узел = p.RailroadStations.Name,
                    АТС = p.PBXModels.Name
                }).OrderBy(p => p.АТС).ThenBy(p => p.ЖД_узел);
                dataGridView1.DataSource = pbxs.ToList();
                ShowRowCount();
            }
        }

        /// <summary>
        /// Отображение информации о телефонах, имеющихся в БД
        /// </summary>
        private void ShowPhonesInfo()
        {
            using (var db = new ExtInfoEntities())
            {
                var phones = db.Phones.Select(p => new
                {
                    Производитель = p.PhoneVendors.Name,
                    Модель = p.Model,
                    Тип_телефона = p.PhoneTypes.Name
                }).OrderBy(p => p.Производитель).ThenBy(p => p.Модель);
                dataGridView1.DataSource = phones.ToList();
                ColorizeGrid(db);
                ShowRowCount();
            }
        }

        /// <summary>
        /// Отображение информации о категориях, имеющихся в БД
        /// </summary>
        private void ShowCateroriesInfo()
        {
            using (var db = new ExtInfoEntities())
            {
                var categories = db.Categories.Select(c => new
                {
                    Категория_выхода = c.Name
                }).OrderBy(c => c.Категория_выхода);
                dataGridView1.DataSource = categories.ToList();
                ShowRowCount();
            }
        }

        /// <summary>
        /// Показывает количество строк в текущем запросе в БД
        /// </summary>
        private void ShowRowCount()
        {
            toolStripStatusLabelRowCount.Text = "Строк отображено: " + dataGridView1.RowCount;
        }

        /// <summary>
        /// Определяет видимость элементов формы на основе учетной записи пользователя. Под администратором
        /// отображаются дополнительные элементы и доступно больше функций
        /// </summary>
        private void IsAdminStateIsActive()
        {
            if (Program.isAdmin)
            {
                toolStripStatusLabelAdminIndicator.Visible = true;
                toolStripButtonDelete.Enabled = true;
                toolStripButtonEdit.Enabled = true;
            }
        }

        /// <summary>
        /// Применяет цветовую раскраску таблицы, основанную на типе телефона
        /// </summary>
        /// <param name="db">Экземпляр БД в EntityFramework</param>
        private void ColorizeGrid(ExtInfoEntities db)
        {
            string phoneType;
            DataGridViewRow row;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                //[2, i] - во 2 столбце текущей строки отображается тип телефона. Так же если телефон
                //свободен в этом поле присутствует запись "FREE"
                phoneType = (string)dataGridView1[2, i].Value;
                row = dataGridView1.Rows[i];
                var cells = row.Cells;
                //Далее красятся все ячейки в i-той строке с типом телефона на основании фактического типа телефона
                foreach (DataGridViewCell cell in cells)
                {
                    if (phoneType == "ISDN")
                    {
                        cell.Style.BackColor = Color.LightCoral;
                    }
                    else if (phoneType == "SIP")
                    {
                        cell.Style.BackColor = Color.PaleTurquoise;
                    }
                    else if (phoneType == "Analog")
                    {
                        cell.Style.BackColor = Color.PaleGreen;
                    }
                    else if (phoneType == "Virtual")
                    {
                        cell.Style.BackColor = Color.Goldenrod;
                    }
                }
            }
        }

        //Вызывает форму добавления элементов БД в зависимости от выбранной вкладки TabControl
        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageRailroadStations)
            {
                AddRailroadStationForm addRailroadStationForm = new AddRailroadStationForm();
                addRailroadStationForm.ShowDialog();
                ShowRailroadStationsInfo();
            }
            else if (tabControl1.SelectedTab == tabPagePBX)
            {
                AddPBXForm addPBXForm = new AddPBXForm();
                addPBXForm.ShowDialog();
                ShowPBXInfo();
            }
            else if (tabControl1.SelectedTab == tabPagePhones)
            {
                AddPhoneForm addPhoneForm = new AddPhoneForm();
                addPhoneForm.ShowDialog();
                ShowPhonesInfo();
            }
            else if (tabControl1.SelectedTab == tabPageCategories)
            {
                AddCategoryForm addCategoryForm = new AddCategoryForm();
                addCategoryForm.ShowDialog();
                ShowCateroriesInfo();
            }
        }

        //Вызывает форму изменения элементов БД в зависимости от выбранной вкладки TabControl
        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            //TODO: реализовать процесс редактирования объектов (админские права)
        }

        //Вызывает форму удаления элементов БД в зависимости от выбранной вкладки TabControl
        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            //TODO: реализовать процесс удаления объектов (админские права)
        }
    }
}
