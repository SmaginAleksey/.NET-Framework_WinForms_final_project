using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class AddRailroadStationForm : Form
    {
        public AddRailroadStationForm()
        {
            InitializeComponent();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxRailroadStation.Text == "")
            {
                MessageBox.Show("Не введено значение для добавления", "Внимание");
                return;
            }
            if (!IsRailroadStationExist())
            {
                using (var db = new ExtInfoEntities())
                {
                    db.RailroadStations.Add(new RailroadStations { Name = textBoxRailroadStation.Text });
                    db.SaveChanges();
                    MessageBox.Show("Успешно", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
        }

        /// <summary>
        /// Проверка на наличие ЖД станции в БД
        /// </summary>
        /// <returns>true - такая ЖД станция есть в БД, иначе - false</returns>
        private bool IsRailroadStationExist()
        {
            using (var db = new ExtInfoEntities())
            {
                var newRailroadStation = db.RailroadStations.Where(rs => rs.Name == textBoxRailroadStation.Text).
                    FirstOrDefault();
                if (newRailroadStation != null)
                {
                    MessageBox.Show("Такой ЖД узел уже существует в базе", "Объект существует", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return true;
                }
                return false;
            }
        }

    }
}
