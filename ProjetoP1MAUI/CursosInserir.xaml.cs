namespace ProjetoP1MAUI;

public partial class CursosInserir : ContentPage
{
    public CursosInserir()
    {
        InitializeComponent();
        pckPeriodo.ItemsSource = Dados.Periodos;
    }

    private async void btnSalvarOnClick(object sender, EventArgs e)
    {
        if (pckPeriodo.SelectedItem == null ||
            string.IsNullOrWhiteSpace(entNome.Text) ||
            string.IsNullOrWhiteSpace(entSigla.Text) ||
            string.IsNullOrWhiteSpace(edtObservacoes.Text))
        {
            await DisplayAlert("Aviso", "Preencha todos os campos (cadastre um período antes, se a lista estiver vazia).", "OK");
            return;
        }

        Periodo per = (Periodo)pckPeriodo.SelectedItem;

        Curso c = new Curso();
        c.CurId = Dados.ProxCurId;
        Dados.ProxCurId++;
        c.CurNome = entNome.Text;
        c.CurSigla = entSigla.Text;
        c.CurObservacoes = edtObservacoes.Text;
        c.PerId = per.PerId;
        Dados.Cursos.Add(c);

        await DisplayAlert("Sucesso", "Curso salvo!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnVoltarOnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}