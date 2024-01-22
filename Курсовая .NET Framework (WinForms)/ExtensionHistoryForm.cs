using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class ExtensionHistoryForm : Form
    {
        private readonly string selectedExtension;
        /// <summary>
        /// Форма отображения истории изменений данных о телефонах
        /// </summary>
        public ExtensionHistoryForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Форма отображения истории изменений данных о телефонах
        /// </summary>
        /// <param name="extension">Телефон, история изменений которого будет отображена. Указывается
        /// в формате xxxxx (н-р: 52100)</param>
        public ExtensionHistoryForm(string extension) :this()
        {
            selectedExtension = extension;
        }

        //В зависимости от выбора перегрузки формы - меняется текст шапки формы и 
        //загружается соответствующая информация из БД (если выбран конструктор
        //без параметров - информация о всех изменениях по всем телефонам за последнее
        //время; если с параметрам - история изменений по конкретному телефону)
        private void ExtensionHistoryForm_Load(object sender, EventArgs e)
        {
            if (selectedExtension !=null)
            {
                Text += "у " + selectedExtension;
                ShowHistory(selectedExtension);
            }
            else
            {
                Text += "ам";
                ShowHistory();
            }
                ShowRowCount();
        }

        //Отображает количество выведеных строк
        private void ShowRowCount()
        {
            toolStripStatusLabelRowCount.Text = "Строк отображено: " + dataGridView1.RowCount;
        }

        /// <summary>
        /// Отображает информацию о всех изменениях по всем телефонам за последнее
        ///время 
        /// </summary>
        private void ShowHistory()  //TODO: если будет время реализовать выбор диапазона дат и
                                    //отображасть историю в этот период
        {
            using (var db = new ExtInfoEntities())
            {
                var history = db.History.OrderByDescending(h => h.ChangeDate).Select(h => new
                {
                    Узел = h.PBX.RailroadStations.Name,
                    АТС = h.PBX.PBXModels.Name,
                    Номер = h.Extension,
                    Порт = h.Port,
                    Категория = h.Categories.Name,
                    Тип = h.Phones.Model,
                    Абонент = h.Name,
                    Адрес = h.Locations.RailroadStations.Name + " " + h.Locations.Position,
                    Примечание = h.AddInfo,
                    Операция = h.Operation,
                    Дата = h.ChangeDate,
                    Версия = h.Version
                }).Take(100);   //в данном случае выводим последние 100 изменений

                dataGridView1.DataSource = history.ToList();
            }
        }

        /// <summary>
        /// Отображает историю изменений по конкретному телефону
        /// </summary>
        /// <param name="extension">Номер телефона формата xxxxx (н-р: 52100)</param>
        private void ShowHistory(string extension)
        {
            using (var db = new ExtInfoEntities())
            {
                var history = db.History.Where(s => s.Extension == selectedExtension).Select(h => new
                {
                    Узел = h.PBX.RailroadStations.Name,
                    АТС = h.PBX.PBXModels.Name,
                    Номер = h.Extension,
                    Порт = h.Port,
                    Категория = h.Categories.Name,
                    Тип = h.Phones.Model,
                    Абонент = h.Name,
                    Адрес = h.Locations.RailroadStations.Name + " " + h.Locations.Position,
                    Примечание = h.AddInfo,
                    Операция = h.Operation,
                    Дата = h.ChangeDate,
                    Версия = h.Version
                });
                dataGridView1.DataSource = history.ToList();
            }
        }
    }
}