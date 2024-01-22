using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class ExtensionChangeForm : Form
    {
        /// <summary>
        /// Форма изменения информации о телефонных номерах
        /// </summary>
        public ExtensionChangeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Форма изменения информации о телефонных номерах
        /// </summary>
        /// <param name="extension">Номер телефона формата xxxxx (н-р: 52100)</param>
        public ExtensionChangeForm(string extension) : this()
        {
            textBoxExtension.Text = extension;
        }

        private void ExtensionChangeForm_Load(object sender, EventArgs e)
        {
            //Заполняем все comboBox соответствующими данными из БД
            Program.UpdateRailroadStationComboBox(comboBoxRailroadStation);
            Program.UpdateRailroadStationComboBox(comboBoxLocationRailroadStation);
            Program.UpdatePBXComboBox(comboBoxPBXModel);
            Program.UpdatePhonesComboBox(comboBoxPhoneModel);
            Program.UpdateCategoriesComboBox(comboBoxCategory);

            using (var db = new ExtInfoEntities())
            {
                //Достаём из БД телефон, который будет модифицироваться
                Subscribers selectedSubscriber = db.Subscribers.Where(s => s.Extension == textBoxExtension.Text)
                    .FirstOrDefault();

                //Заполнение текстовых полей и comboBox формы данными выбранного телефона
                comboBoxRailroadStation.Text = selectedSubscriber.PBX.RailroadStations.Name;
                comboBoxPBXModel.Text = selectedSubscriber.PBX.PBXModels.Name;
                textBoxPort.Text = selectedSubscriber.Port;

                //Т.к. это nullable параметр - проверяем на наличие значения в нём
                if (selectedSubscriber.CategoryId.HasValue)
                    comboBoxCategory.Text = selectedSubscriber.Categories.Name;

                //Этот параметр обязателен к заполнению - проверка на наличие значения не нужна
                comboBoxPhoneModel.Text = selectedSubscriber.Phones.Model;

                textBoxSubscriberName.Text = selectedSubscriber.Name;

                //Ещё один nullable параметр
                if (selectedSubscriber.LocationId.HasValue)
                {
                    comboBoxLocationRailroadStation.Text = selectedSubscriber.Locations.RailroadStations.Name;
                    textBoxLocationPosition.Text = selectedSubscriber.Locations.Position;
                }
                textBoxAddInfo.Text = selectedSubscriber.AddInfo;
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            using (var db = new ExtInfoEntities())
            {
                //UNDONE: подумать над остальными комбо-боксами - не будет ли так лучше и проще?
                //
                //Categories cat = comboBoxCategory.SelectedItem as Categories;
                //changingExtension.CategoryId = cat.Id;
                //Phones phone = comboBoxPhoneModel.SelectedItem as Phones;
                //changingExtension.PhoneId = phone.Id;

                //Достаём из БД телефон, в который будем вносить изменения
                var changingExtension = db.Subscribers.Where(s => s.Extension == textBoxExtension.Text).
                    FirstOrDefault();
                
                int tempPBXId = db.PBX.Where(p => p.RailroadStations.Name == comboBoxRailroadStation.Text).
                    Where(m => m.PBXModels.Name == comboBoxPBXModel.Text).Select(c => c.Id).FirstOrDefault();
                if (tempPBXId == 0)
                {
                    MessageBox.Show("Такой АТС с таким адресом установки не существует в БД");
                    return; //HACK: получится ли переделать, чтобы не отображалось несуществующих комбинаций
                            //АТС + узел?
                }

                //Вносим новую информацию в телефон с проверками на наличие данных в nullable полях
                changingExtension.PBXId = tempPBXId;
                changingExtension.Port = textBoxPort.Text;

                if (comboBoxCategory.Text.Length > 0)
                    changingExtension.CategoryId = db.Categories.Where(c => c.Name == comboBoxCategory.Text).
                        Select(s => s.Id).FirstOrDefault();
                else
                    changingExtension.CategoryId = null;

                changingExtension.Name = textBoxSubscriberName.Text;

                //Структура таблицы Locations в БД состоит из двух полей: RailroadStation и Position.
                //Идея была такая: чтобы при изменении адреса установки телефона на другой, но который
                //уже есть в системе, пользователю сообщалось, что, вероятно, он допустил ошибку
                //и того адреса, что он ввёл нет в БД. Сохранение новой локации происходит только после
                //согласия пользователя.
                if (comboBoxLocationRailroadStation.Text.Length > 0 && textBoxLocationPosition.Text.Length > 0)
                {
                    int tempLocationId = db.Locations.Where(l => l.RailroadStations.Name == 
                        comboBoxLocationRailroadStation.Text).Where(c => c.Position == textBoxLocationPosition.Text).
                        Select(x => x.Id).FirstOrDefault();
                    if (tempLocationId == 0)
                    {
                        DialogResult res = MessageBox.Show("В БД не существует комбинации такого узла и адреса " +
                            "установки телефона.\nЖелаете занести новую локацию?", "Отсутствуют данные в БД", 
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (res == DialogResult.Cancel)
                            return;
                        else
                        {
                            int tempRailroadStationId = db.RailroadStations.Where(r => r.Name == 
                                comboBoxLocationRailroadStation.Text).Select(c => c.Id).FirstOrDefault();

                            AddNewLocationToDB(tempRailroadStationId, textBoxLocationPosition.Text);
                            changingExtension.LocationId = db.Locations.Max(l => l.Id);
                        }
                    }
                    else
                        changingExtension.LocationId = tempLocationId;
                }
                else
                    changingExtension.LocationId = null;
                
                if (comboBoxPhoneModel.Text.Length > 0)
                    changingExtension.PhoneId = db.Phones.Where(r => r.Model == comboBoxPhoneModel.Text).
                        Select(c => c.Id).FirstOrDefault();
                
                changingExtension.AddInfo = textBoxAddInfo.Text;
                db.SaveChanges();

                DialogResult = DialogResult.OK; //TODO: при закрытии формы с OK, данные родительской
                                                //формы обновляются. Сейчас обновление данных занимает
                                                //много времени, поэтому данный функционал отключен 
                                                //(нет соотв. кода в родительской форме). При оптимизации
                                                // - данную функцию вернуть.
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Добавление нового объекта Locations в БД.
        /// </summary>
        /// <param name="railroadStationId">Id ЖД станции в БД</param>
        /// <param name="position">Адрес установки телефона</param>
        private void AddNewLocationToDB(int railroadStationId, string position)
        {
            using (var db = new ExtInfoEntities())
            {
                try
                {
                    db.Locations.Add(new Locations
                    {
                        RailroadStationId = railroadStationId,
                        Position = position
                    });
                    db.SaveChanges();
                    MessageBox.Show("Успешно добавлено!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Очищение всех nullable данных телефона при переводе телефона в статус "FREE" (свободен)
        private void comboBoxPhoneModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxPhoneModel.SelectedItem.ToString() == "FREE")
            {
                textBoxPort.Clear();
                comboBoxCategory.ResetText();
                textBoxSubscriberName.Clear();
                    comboBoxLocationRailroadStation.ResetText();
                    textBoxLocationPosition.Clear();
                textBoxAddInfo.Clear();
            }
        }
    }
}