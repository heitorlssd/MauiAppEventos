using MauiAppEventos.Models;

namespace MauiAppEventos.Views;

public partial class CadastroEvento : ContentPage
{
	public CadastroEvento()
	{
		InitializeComponent();

        dtpck_inicio.MinimumDate = DateTime.Now;
        dtpck_inicio.MaximumDate = DateTime.Now.AddYears(2);
        dtpck_termino.MinimumDate = dtpck_inicio.Date.Value.AddDays(0);
        dtpck_termino.MaximumDate = dtpck_inicio.Date.Value.AddDays(14);
    }

    private void dtpck_inicio_DateSelected(object sender, DateChangedEventArgs e)
    {
        dtpck_termino.MinimumDate = e.NewDate.Value.AddDays(0);
        dtpck_termino.MaximumDate = e.NewDate.Value.AddDays(14);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Evento evento = new Evento();

            evento.NomeEvento = txt_nome.Text;
            evento.DataInicio = dtpck_inicio.Date;
            evento.DataTermino = dtpck_termino.Date;
            evento.NumeroParticipantes = Convert.ToInt32(txt_participantes.Text);
            evento.LocalEvento = txt_local.Text;
            evento.CustoPorParticipante = Convert.ToDouble(txt_preco.Text);

            Navigation.PushAsync(
                new EventoCadastrado()
                {
                    BindingContext = evento
                });
        }

        catch (Exception ex)
        {
            DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}