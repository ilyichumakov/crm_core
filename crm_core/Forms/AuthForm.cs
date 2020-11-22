using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace crm_core
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = username_input.Text;
            string password = password_input.Text;

            if (username == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль для входа!", "Учетные данные", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using(crmContext db = new crmContext())
                {
                    var target_user = db.Users.FirstOrDefault(u => u.Username == username);
                    if (target_user is null)
                    {
                        MessageBox.Show("Пользователь не найден", "Неудача", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (target_user.validate_password(password))
                    {
                        var owner = this.Owner as Form1;
                        owner.User = target_user;
                        this.Dispose();
                        return;
                    } 
                    else
                    {
                        var user_decision = MessageBox.Show(
                            "Неверный пароль, повторите попытку авторизации",
                            "Неверный пароль",
                            MessageBoxButtons.OKCancel,
                            MessageBoxIcon.Warning
                        );
                        if (user_decision != DialogResult.OK)
                        {
                            this.Owner.Dispose();
                        }
                    }
                }
            }
            catch(InvalidOperationException){
                var res = MessageBox.Show("Сервер недоступен", "Сетевые неполадки", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (res == DialogResult.Cancel)
                {
                    this.Owner.Dispose();
                }
            }
        }

        private void AuthForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                this.Owner.Dispose();
            }
        }
    }
}
