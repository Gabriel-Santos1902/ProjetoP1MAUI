namespace ProjetoP1MAUI;

public partial class CursosPage : ContentPage
{
    public CursosPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Carregar();
    }

    private void Carregar()
    {
        string texto = entPesquisa.Text ?? "";
        cvCursos.ItemsSource = null;
        cvCursos.ItemsSource = Dados.Cursos
            .Where(c => c.CurNome.ToLower().Contains(texto.ToLower()))
            .ToList();
    }

    private void btnPesquisarOnClick(object sender, EventArgs e)
    {
        Carregar();
    }

    private async void btnInserirOnClick(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CursosInserir());
    }

    private async void btnAlterarOnClick(object sender, EventArgs e)
    {
        Curso c = (Curso)((Button)sender).BindingContext;
        await Navigation.PushAsync(new CursosAlterar(c));
    }

    private async void btnRemoverOnClick(object sender, EventArgs e)
    {
        Curso c = (Curso)((Button)sender).BindingContext;

        // não deixa remover se existir disciplina neste curso
        if (Dados.Disciplinas.Any(d => d.CurId == c.CurId))
        {
            await DisplayAlert("Aviso", "Não é possível remover, existem disciplinas neste curso.", "OK");
            return;
        }

        bool resposta = await DisplayAlert("Confirmação", "Deseja remover o curso " + c.CurNome + "?", "Sim", "Não");
        if (resposta)
        {
            Dados.Cursos.Remove(c);
            Carregar();
        }
    }
}