namespace ProjetoP1MAUI;

public partial class DisciplinasInserir : ContentPage
{
    public DisciplinasInserir()
    {
        InitializeComponent();

        // cria um RadioButton para cada curso cadastrado
        foreach (Curso c in Dados.Cursos)
        {
            RadioButton rb = new RadioButton();
            rb.GroupName = "cursos";
            rb.Content = c.CurNome;
            rb.Value = c;
            stkCursos.Children.Add(rb);
        }
    }

    private Curso? CursoSelecionado()
    {
        foreach (RadioButton rb in stkCursos.Children)
        {
            if (rb.IsChecked)
                return rb.Value as Curso;
        }
        return null;
    }

    private async void btnSalvarOnClick(object sender, EventArgs e)
    {
        Curso? cur = CursoSelecionado();

        if (cur == null ||
            string.IsNullOrWhiteSpace(entNome.Text) ||
            string.IsNullOrWhiteSpace(entSigla.Text) ||
            string.IsNullOrWhiteSpace(edtObservacoes.Text))
        {
            await DisplayAlert("Aviso", "Preencha todos os campos (cadastre um curso antes, se não houver nenhum).", "OK");
            return;
        }

        Disciplina d = new Disciplina();
        d.DisId = Dados.ProxDisId;
        Dados.ProxDisId++;
        d.DisNome = entNome.Text;
        d.DisSigla = entSigla.Text;
        d.DsObservacoes = edtObservacoes.Text;
        d.CurId = cur.CurId;
        Dados.Disciplinas.Add(d);

        await DisplayAlert("Sucesso", "Disciplina salva!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnVoltarOnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}