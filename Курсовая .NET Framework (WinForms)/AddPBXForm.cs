using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class AddPBXForm : Form
    {
        public AddPBXForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxPBXModel.Text == "" || textBoxRailroadStation.Text == "")
            {
                MessageBox.Show("Оба поля обязательны к заполнению", "Не указан ЖД узел и(или) модель АТС");
                return;
            }
            //АТС (PBX) состоит из 2х компонентов (модель + ЖД станция), которые могут существовать
            //отдельно от АТС. Поэтому при отсутствии такой АТС в БД проверяется наличие каждого
            //компонента отдельно. 
            if (!IsPBXExist())
            {
                using (var db = new ExtInfoEntities())
                {
                    //Добавляется модель АТС при отсутствии таковой в БД
                    if (!IsPBXModelExist())
                    {
                        db.PBXModels.Add(new PBXModels
                        {
                            Name = textBoxPBXModel.Text
                        });
                    }
                    //Добавляется ЖД станция при отсутствии таковой в БД
                    if (!IsRailroadStationExist())
                    {
                        db.RailroadStations.Add(new RailroadStations
                        {
                            Name = textBoxRailroadStation.Text
                        });
                    }
                    //Добавляется новая АТС из тех экземпляров, что добавили выше
                    db.PBX.Add(new PBX
                    {
                        PBXModelId = GetPBXModelId(),
                        RailroadStationId = GetRailroadStationId()
                    });
                    db.SaveChanges();
                    MessageBox.Show("Успешно", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
        }

        /// <summary>
        /// Проверка на наличие АТС (PBX) в БД
        /// </summary>
        /// <returns>true - такая АТС существует в БД, false - такой АТС нет в БД</returns>
        private bool IsPBXExist()
        {
            using (var db = new ExtInfoEntities())
            {
                var newPBX = db.PBX.Where(p => p.PBXModels.Name == textBoxPBXModel.Text).
                    Where(p => p.RailroadStations.Name == textBoxRailroadStation.Text).FirstOrDefault();
                if (newPBX != null)
                {
                    MessageBox.Show("Такая АТС уже существует в базе", "Объект существует", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Проверка на наличие ЖД станции в БД
        /// </summary>
        /// <returns>true - такая ЖД станция существует в БД, false - такой ЖД станции нет в БД</returns>
        private bool IsRailroadStationExist()
        {
            using(var db = new ExtInfoEntities())
            {
                var newRailroadStation = db.RailroadStations.Where(rs => rs.Name == textBoxRailroadStation.Text).FirstOrDefault();
                if (newRailroadStation != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Проверка на наличие модели АТС в БД
        /// </summary>
        /// <returns>true - такая модель АТС существует в БД, false - такой мдели АТС нет в БД</returns>
        private bool IsPBXModelExist()
        {
            using (var db = new ExtInfoEntities())
            {
                var newPBXModel = db.PBXModels.Where(p => p.Name == textBoxPBXModel.Text).FirstOrDefault();
                if (newPBXModel != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Получает модель АТС из БД
        /// </summary>
        /// <returns>Id модели АТС</returns>
        private int GetPBXModelId()
        {
            using (var db = new ExtInfoEntities())
            {
                var PBXModel = db.PBXModels.Where(p => p.Name == textBoxPBXModel.Text).FirstOrDefault();
                return PBXModel.Id;
            }
        }

        /// <summary>
        /// Получает ЖД станцию из БД
        /// </summary>
        /// <returns>Id ЖД станции</returns>
        private int GetRailroadStationId()
        {
            using (var db = new ExtInfoEntities())
            {
                var RailroadStation = db.RailroadStations.Where(p => p.Name == textBoxRailroadStation.Text).FirstOrDefault();
                return RailroadStation.Id;
            }
        }
    }
}
