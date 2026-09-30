namespace ProjetoP1MAUI;

public partial class DisciplinasAlterar : ContentPage
{
    Disciplina disciplina;

    public DisciplinasAlterar(Disciplina d)
    {
        InitializeComponent();
        disciplina = d;

        foreach (Curso c in Dados.Cursos)
        {
            RadioButton rb = new RadioButton();
            rb.GroupName = "cursos";
            rb.Content = c.CurNome;
            rb.Value = c;
            rb.IsChecked = (c.CurId == d.CurId);   // marca o curso atual
            stkCursos.Children.Add(rb);
        }

        entNome.Text = d.DisNome;
        entSigla.Text = d.DisSigla;
        edtObservacoes.Text = d.DsObservacoes;
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
            await DisplayAlert("Aviso", "Preencha todos os campos.", "OK");
            return;
        }

        disciplina.DisNome = entNome.Text;
        disciplina.DisSigla = entSigla.Text;
        disciplina.DsObservacoes = edtObservacoes.Text;
        disciplina.CurId = cur.CurId;

        await DisplayAlert("Sucesso", "Disciplina alterada!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnVoltarOnClick(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}