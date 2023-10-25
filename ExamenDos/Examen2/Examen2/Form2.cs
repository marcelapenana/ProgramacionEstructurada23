using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'diferido_exa2DataSet.notasEstudiantes' Puede moverla o quitarla según sea necesario.
            this.notasEstudiantesTableAdapter.Fill(this.diferido_exa2DataSet.notasEstudiantes);
            //Cargar datos bd al daGrid
            cargar();
        }

        private void cargar()
        {
            //instanciar BD...notasEst(table).
            diferido_exa2Entities2 contexto = new diferido_exa2Entities2();
            dataG.DataSource = contexto.notasEstudiantes.ToList();
        }

        private void dataG_Click(object sender, EventArgs e)
        {
            //EveClik
            this.txtId.Text = dataG.SelectedRows[0].Cells[0].Value.ToString();
            this.txtCarnet.Text = dataG.SelectedRows[0].Cells[1].Value.ToString();
            this.txtNombre.Text = dataG.SelectedRows[0].Cells[2].Value.ToString();
            this.txtMateria.Text = dataG.SelectedRows[0].Cells[3].Value.ToString();
            this.txtNota.Text = dataG.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtId.Text != "")
                {
                    string mesnaje = "seguro desea agregar?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    DialogResult result = MessageBox.Show(mesnaje, "agregado", buttons, icon);
                    MessageBox.Show("INSERTADO");

                    if (result == DialogResult.Yes)
                    {
                        //var de los texBox
                        //int id = int.Parse(txtId.Text); ID auto
                        int carnet = int.Parse(txtCarnet.Text);
                        string nombre = txtNombre.Text;
                        string materia = txtMateria.Text;
                        float nota = float.Parse(txtNota.Text);

                        using (diferido_exa2Entities2 contexto = new diferido_exa2Entities2())
                        {
                            notasEstudiantes n = new notasEstudiantes
                            {
                                //ID auto
                                carnet_estudiante = carnet,
                                nombre_completo = nombre,
                                nombre_materia = materia,
                                nota_materia = nota
                            };

                            contexto.notasEstudiantes.Add(n);
                            contexto.SaveChanges();
                            cargar();

                        }
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("error al insertar: " + err.Message, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text != "")
                {
                    string mesnaje = "seguro desea modificar?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    MessageBoxIcon icon = MessageBoxIcon.Question;
                    DialogResult result = MessageBox.Show(mesnaje, "modificado", buttons, icon);
                    MessageBox.Show("MODIFICADO");

                    if (result == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(this.txtId.Text);
                        int carnet = Convert.ToInt32(this.txtCarnet.Text);
                        string nombre = this.txtNombre.Text;
                        string materia = this.txtMateria.Text;
                        float nota = Convert.ToSingle(this.txtNota.Text);

                        using (diferido_exa2Entities2 contexto = new diferido_exa2Entities2())
                        {
                            notasEstudiantes n = contexto.notasEstudiantes.FirstOrDefault(x => x.ID == id);
                            n.carnet_estudiante = carnet;
                            n.nombre_completo = nombre;
                            n.nombre_materia = materia;
                            n.nota_materia = nota;
                            contexto.SaveChanges();
                            cargar();
                        }
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("error al modificar: " + err.Message, "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                string mesnaje = "seguro desea eliminar?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                DialogResult result = MessageBox.Show(mesnaje, "eliminado", buttons, icon);
                MessageBox.Show("ELIMINADO");

                if (result == DialogResult.Yes)
                {
                    //
                    int id = Convert.ToInt32(this.txtId.Text);
                    using (diferido_exa2Entities2 contexto = new diferido_exa2Entities2())
                    {
                        notasEstudiantes n = contexto.notasEstudiantes.FirstOrDefault(x => x.ID == id);
                        contexto.notasEstudiantes.Remove(n);
                        contexto.SaveChanges();
                        cargar();
                    }
                    //
                }
            }         
            
        }
    }
}
