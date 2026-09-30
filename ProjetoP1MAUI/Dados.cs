using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoP1MAUI;

public class Periodo
{
    public int PerId { get; set; }
    public string PerNome { get; set; } = "";
    public string PerSigla { get; set; } = "";
}

public class Curso
{
    public int CurId { get; set; }
    public string CurNome { get; set; } = "";
    public string CurSigla { get; set; } = "";
    public string CurObservacoes { get; set; } = "";
    public int PerId { get; set; }

    // usado para mostrar o nome do período no grid
    public string PerNome
    {
        get
        {
            Periodo p = Dados.Periodos.FirstOrDefault(x => x.PerId == PerId);
            if (p == null)
                return "";
            return p.PerNome;
        }
    }
}

public class Disciplina
{
    public int DisId { get; set; }
    public string DisNome { get; set; } = "";
    public string DisSigla { get; set; } = "";
    public string DsObservacoes { get; set; } = "";
    public int CurId { get; set; }

    // usado para mostrar o nome do curso no grid
    public string CurNome
    {
        get
        {
            Curso c = Dados.Cursos.FirstOrDefault(x => x.CurId == CurId);
            if (c == null)
                return "";
            return c.CurNome;
        }
    }
}

public static class Dados
{
    public static List<Periodo> Periodos = new List<Periodo>();
    public static List<Curso> Cursos = new List<Curso>();
    public static List<Disciplina> Disciplinas = new List<Disciplina>();

    public static int ProxPerId = 1;
    public static int ProxCurId = 1;
    public static int ProxDisId = 1;
}
