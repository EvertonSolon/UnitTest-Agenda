﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Agenda.UIDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            string nome = txtContatoNovo.Text;

            string strCon = @"Server=.\SQLEXPRESS;Database=Agenda;Trusted_Connection=True";
            string id = Guid.NewGuid().ToString();

            SqlConnection con = new SqlConnection(strCon);
            con.Open();

            string sql = string.Format("Insert into Contato (Id, Nome) Values ('{0}', '{1}');", id, nome);

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.ExecuteNonQuery();

            sql = string.Format("Select Nome from Contato where Id = '{0}';", id);

            cmd = new SqlCommand(sql, con); 

            txtContatoSalvo.Text = cmd.ExecuteScalar().ToString();

            con.Close();

        }
    }
}
