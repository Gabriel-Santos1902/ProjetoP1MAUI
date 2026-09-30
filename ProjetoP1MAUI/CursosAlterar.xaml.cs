namespace ProjetoP1MAUI;

public partial class CursosAlterar : ContentPage
{
    Curso curso;

    public CursosAlterar(Curso c)
    {
        InitializeComponent();
        curso = c;

        pckPeriodo.ItemsSource = Dados.Periodos;
        pckPeriodo.SelectedItem = Dados.Periodos.FirstOrDefault(p => p.PerId == c.PerId);
        entNome.Text = c.CurNome;
        entSigla.Text = c.CurSigla;
        edtObservacoes.Text = c.CurObservacoes;
    }

    private async void btnSalvarOnClick(object sender, EventArgs e)
    {
        if (pckPeriodo.SelectedItem == null ||
            string.IsNullOrWhiteSpace(entNome.Text) ||
            string.IsNullOrWhiteSpace(entSigla.Text) ||
            string.IsNullOrWhiteSpace(edtObservacoes.Text))
        {
            await DisplayAlert("Aviso", "Preencha todos os campos.", "OK");
            return;
        }

        Periodo per = (Periodo)pckPeriodo.SelectedItem;

        curso.CurNome = entNome.Text;
        curso.CurSigla = entSigla.Text;
        curso.CurObservacoes = edtObservacoes.Text;
        curso.PerId = per.PerId;

        await DisplayAlert("Sucesso", "Curso alterado!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnVoltarOnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}