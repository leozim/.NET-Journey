using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace LinQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            var generos = new List<Genero>
            {
                new Genero { Id = 1, Nome = "Rock"},
                new Genero { Id = 2, Nome = "Reggae"},
                new Genero { Id = 3, Nome = "Rock Progessivo"},
                new Genero { Id = 4, Nome = "Jazz"},
                new Genero { Id = 5, Nome = "Punk Rock"},
                new Genero { Id = 6, Nome = "Classica"}
            };

            IList<Musica> musicas = new List<Musica>
            {
                new Musica { Id = 1, Nome = "Sweet Child O'Mine", GeneroId = 1 },
                new Musica { Id = 2, Nome = "I Shot The Sheriff", GeneroId = 2 },
                new Musica { Id = 3, Nome = "Danúbio Azul", GeneroId = 6 }
            };

            Console.WriteLine("IMPRIMINDO A LISTA DE GENEROS");

            generos.ForEach(g =>
            {
                Console.WriteLine("{0}\t{1}", g.Id, g.Nome);
            });
            Console.ReadKey();

            IEnumerable<Genero> queryGeneros = from g in generos
                                                where g.Nome == "Rock"
                                                select g;
            Console.WriteLine("IMPRIMINDO UMA CONSULTA POR NOME DO GENERO");

            foreach (var genero in queryGeneros)
            {
                Console.WriteLine("{0}\t{1}", genero.Id, genero.Nome);
            }
            Console.ReadKey();

            Console.WriteLine("IMPRIMINDO CONSULTA POR ID");

            var musicaQuery = from m in musicas
                where m.GeneroId == 1
                select m;

            foreach (var musica in musicaQuery)
            {
                Console.WriteLine("{0}\t{1}", musica.Id, musica.Nome, musica.GeneroId);
            }
            Console.ReadKey();

            Console.WriteLine("IMPRIMINDO CONSULTA COM JOIN");
            var query = from m in musicas
                join g in generos on m.GeneroId equals g.Id
                select new {m, g};
            foreach (var q in query)
            {
                Console.WriteLine("{0}\t{1}\t{2}", q.m.Id, q.m.Nome, q.g.Nome);
            }

            Console.ReadKey();
            Console.WriteLine("THIS IS IT!");

        }

    }

    public class Genero
    {
        public int Id { get; set; }
        public string Nome { get; set; }

    }

    public class Musica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GeneroId { get; set; }
    }
}
