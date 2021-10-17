using System;

namespace APPseries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string opcaoUser = ObterOpcao();

           while(opcaoUser.ToUpper() != "X")
           {
               switch(opcaoUser)
               {
                   case "1": 
                            Inserir_serie();
                            break;
                   case "2":
                            Visualiza_serie();
                            break;
                   case "3":
                            Atualiza_serie();
                            break;
                   case "4":
                            Exclui_serie();
                            break;
                   case "5":
                            Listar_series();
                            break;
                   case "6":
                         Console.Clear();
                         break;
                   default:
                        throw new ArgumentOutOfRangeException();
               }
            opcaoUser = ObterOpcao();
           }
        }

        private static string ObterOpcao()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao cadastro de Series!");
            Console.WriteLine("Informe a opcao desejada:");

            Console.WriteLine("1 - Inserir nova Serie/Filme");
            Console.WriteLine("2 - Visualizar Serie/Filme");
            Console.WriteLine("3 - Atualizar Serie/Filme");
            Console.WriteLine("4 - Excluir Serie/Filme");
            Console.WriteLine("5 - Listar Series e Filmes");
            Console.WriteLine("6 - Limpar Tela");
            Console.WriteLine("X - Sair"); 
            
            string opcao = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcao;
        }

        private static void Inserir_serie()
        {
            Console.WriteLine("INSERIR NOVA SERIE");
            Console.WriteLine();

            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo), i));
            }
            Console.WriteLine("Digite o numero correspondente ao tipo: ");
            int enterTipo = int.Parse(Console.ReadLine());

            Console.WriteLine("Generos disponiveis:");
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int enterGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo:");
            string enterTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descricao:");
            string enterDescricao = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio:");
            int enterAno = int.Parse(Console.ReadLine());

            
            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          tipo: (Tipo)enterTipo,
                                          genero: (Genero)enterGenero,
                                          titulo: enterTitulo,
                                          descricao: enterDescricao,
                                          ano: enterAno);
            repositorio.Insere(novaSerie);
        }

        private static void Visualiza_serie()
        {
            Console.WriteLine("VISUALIZACAO - SERIE/FILME");
            Console.WriteLine();
            Console.Write("Digite o ID da serie que deseja visualizar: ");
            int IdSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(IdSerie);
            Console.WriteLine(serie);
        }

        private static void Atualiza_serie()
        {
            Console.WriteLine("ATUALIZACAO - SERIE/FILME");
            Console.WriteLine();
            Console.Write("Digite o ID da serie/filme que deseja atualizar: ");
            int IdSerie = int.Parse(Console.ReadLine());
             
            foreach(int i in Enum.GetValues(typeof(Tipo)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Tipo), i));
            }
            Console.WriteLine("Digite o numero correspondente ao tipo: ");
            int enterTipo = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int enterGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo:");
            string enterTitulo = Console.ReadLine();

            Console.WriteLine("Digite a descricao:");
            string enterDescricao = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Inicio:");
            int enterAno = int.Parse(Console.ReadLine());

            
            Series atualizacaoSerie = new Series(id: repositorio.ProximoId(),
                                          tipo: (Tipo)enterTipo,
                                          genero: (Genero)enterGenero,
                                          titulo: enterTitulo,
                                          descricao: enterDescricao,
                                          ano: enterAno);
            
            repositorio.Atualiza(IdSerie,atualizacaoSerie);
        }

        private static void Exclui_serie()
        {
            Console.WriteLine("EXCLUSAO - SERIE/FILME");
            Console.WriteLine();
            Console.Write("Digite o ID da serie que deseja excluir: ");
            int IdSerie = int.Parse(Console.ReadLine());
            repositorio.Exclui(IdSerie);
        }

        private static void Listar_series() 
        {
            Console.WriteLine("LISTA DE SERIES E FILMES");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Lista de series/filmes vazia.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine("ID: {0} - Titulo: {1} {2}", serie.RetornoId(), serie.RetornoTitulo(), (excluido ? "--- Serie Excluida" : ""));
            }

        }

    }
}
