using HorasHombre.AppWin.Helpers;
using HorasHombre.AppWin.Presenters;
using HorasHombre.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HorasHombre.AppWin.Views.QueryForms
{
    public partial class frmConsultaPersona : HerenciaVisual.frmGeneral
    {
        private IList Source;
        private IPersonaService mPersonaService;
        public frmConsultaPersona()
        {
            InitializeComponent();
            this.mPersonaService = PersonaService.Instance;
            this.dgvListado.AutoGenerateColumns = false;
        }

        private void IniciarDatos(object sender, EventArgs e)
        {
            CargarDatos();
            dgvListado.DataSource = Source;
        }

        private void CargarDatos()
        {
            this.Source = mPersonaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            cboLista.DataSource = new BindingSource(ReflectionUtil.GetTitleAttibute(new Persona()), null);
            cboLista.DisplayMember = "Value";
            cboLista.ValueMember = "Key";
        }

        protected override void OnSortAction()
        {
            KeyValuePair<string, string> value = ((KeyValuePair<string, string>)cboLista.SelectedItem);
            TipoOrden sortType = rbAsc.Checked ? TipoOrden.Ascendente : TipoOrden.Descendente;
            var list = (List<Persona>)this.Source;
            GenericEntityAction<Persona>.Sort(ref list, sortType, value.Key);
            this.Source = list;
            dgvListado.DataSource = null;
            dgvListado.DataSource = this.Source;
        }

        protected override void OnFilterAction()
        {
            KeyValuePair<string, string> value = ((KeyValuePair<string, string>)cboLista.SelectedItem);
            TipoFiltro filterType = TipoFiltro.Contiene;
            if (rbEmpieza.Checked)
                filterType = TipoFiltro.Empieza;
            else if (rbTermina.Checked)
                filterType = TipoFiltro.Termina;
            this.Source = mPersonaService.ObtenerTodo().Where(c => c.EstaActivo == true).ToList();
            var list = (List<Persona>)this.Source;

            GenericEntityAction<Persona>.Filter(ref list, value.Key, txtBuscar.Text, filterType);
            this.Source = list;
            dgvListado.DataSource = null;
            dgvListado.DataSource = this.Source;
        }
    }
}
