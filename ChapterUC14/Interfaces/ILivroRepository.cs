using ChapterUC14.Models;

namespace ChapterUC14.Interfaces
{
    public interface ILivroRepository
    {
        List<Livro> Ler();

        void Cadastrar(Livro livro);

        void Atualizar(int id, Livro livro);

        void Deletar(int id);

        Livro BuscarPorId(int id);

        
    }
}
