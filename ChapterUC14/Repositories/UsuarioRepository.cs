﻿using ChapterUC14.Contexts;
using ChapterUC14.Interfaces;
using ChapterUC14.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChapterUC14.Repositories
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ChapterContext _chapterContext;
        public UsuarioRepository(ChapterContext context)
        {
            _chapterContext = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioBuscado = _chapterContext.Usuarios.Find(id);

            if(usuarioBuscado != null)
            {
                usuarioBuscado.Email = usuario.Email;
                usuarioBuscado.Senha = usuario.Senha;
                usuarioBuscado.Tipo = usuario.Tipo;

                _chapterContext.Usuarios.Update(usuarioBuscado);
                _chapterContext.SaveChanges();
            }

        }

        public Usuario BuscarPorId(int id)
        {
            return _chapterContext.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _chapterContext.Usuarios.Add(usuario);
            _chapterContext.SaveChanges();        
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _chapterContext.Usuarios.Find(id);
            _chapterContext.Usuarios.Remove(usuarioBuscado);
            _chapterContext.SaveChanges();
        }

       public List<Usuario> Listar()
        {
            return _chapterContext.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            throw new NotImplementedException();
        }
    }
}
