using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Курсовая.NET_Framework__WinForms_
{
    public partial class AddPhoneForm : Form
    {
        public AddPhoneForm()
        {
            InitializeComponent();
            Program.UpdatePhoneTypesComboBox(comboBoxTypes);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxModel.Text == "")
            {
                MessageBox.Show("Укажите модель телефона", "Внимание");
                return;
            }
            if (comboBoxTypes.Text == "")
            {
                MessageBox.Show("Укажите тип телефона", "Внимание");
                return;
            }
            if (textBoxVendor.Text == "")
            {
                DialogResult res = MessageBox.Show("Не указан производитель телефона. Желаете оставить это поле пустым?",
                    "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (!IsPhoneExist())
            {
                using (var db = new ExtInfoEntities())
                {
                    db.Phones.Add(new Phones
                    {
                        Model = textBoxModel.Text,
                        PhoneVendorId = GetVendorId(textBoxVendor.Text),
                        PhoneTypeId = GetTypeId(comboBoxTypes.Text)
                    });
                    db.SaveChanges();
                    MessageBox.Show("Успешно", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Close();
            }
        }

        /// <summary>
        /// Проверка на наличие телефона в БД. Телефон (class Phones) состоит из трёх сущностей:
        /// PhoneVendor - производитель телефона, Model - модель телефонного аппарата, PhoneType - тип
        /// телефонного аппарата
        /// </summary>
        /// <returns>true - такой телефон есть в БД, false - такого телефона нет в БД</returns>
        private bool IsPhoneExist()
        {
            using (var db = new ExtInfoEntities())
            {
                var newPhone = db.Phones.Where(p => p.PhoneVendors.Name == textBoxVendor.Text).
                    Where(p => p.Model == textBoxModel.Text).
                    Where(p => p.PhoneTypes.Name == comboBoxTypes.Text).FirstOrDefault();
                if (newPhone != null)
                {
                    MessageBox.Show("Такой телефон уже существует в базе", "Объект существует", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return true;
                }
                return false; 
            }
        }

        /// <summary>
        /// Получает Id производителя телефона из БД
        /// </summary>
        /// <param name="vendor">Имя производителя телефона</param>
        /// <returns>Числовое значение Id PhoneVendor из БД</returns>
        private int GetVendorId(string vendor)
        {
            using (var db = new ExtInfoEntities())
            {
                PhoneVendors phoneVendor = db.PhoneVendors.Where(pv => pv.Name == vendor).FirstOrDefault();
                if (phoneVendor != null)
                {
                    return phoneVendor.Id;
                }
                //Если такого производителя телефонных аппаратов нет в БД, то он заносится в БД
                //и следующим вызовом метода GetVenndorId получаем новый Id только что добавленного
                //объекта
                else
                {
                    AddVendor(db, vendor);
                    GetVendorId(vendor);
                    return -1;
                }
            }
        }

        /// <summary>
        /// Добавляет нового производителя телефонных аппаратов в БД
        /// </summary>
        /// <param name="db">Экзмепляр БД в EntityFramework</param>
        /// <param name="vendor">Имя производителя телефона</param>
        private void AddVendor(ExtInfoEntities db, string vendor)
        {
            db.PhoneVendors.Add(new PhoneVendors
            {
                Name = vendor
            });
            db.SaveChanges();
        }

        /// <summary>
        /// Получает тип телефонного аппарата из БД
        /// </summary>
        /// <param name="type">Название типа телефонного аппарата</param>
        /// <returns>Id типа телефонного аппарата</returns>
        private int GetTypeId(string type)
        {
            using (var db = new ExtInfoEntities())
            {
                PhoneTypes phoneType = db.PhoneTypes.Where(pt => pt.Name == type).FirstOrDefault();
                return phoneType.Id;
            }
        }
    }
}
