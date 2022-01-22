using System;

namespace CadastroAlunos
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;

            Console.WriteLine("\n\n********  SEJA MUITO BEM VINDO, ABAIXO VOCÊ PODE ENCONTRAR O MENU INICIAL  ********"); 

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":  ////////////////////////////   ToDo:  Adicionar aluno
                        
                        Aluno aluno = new Aluno();
                        Console.WriteLine("Digite o NOME do aluno:");
                        aluno.Nome = Console.ReadLine();

                        Console.Write("Agora digite a NOTA do aluno:\n");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota)) //tentando fazer o Parse e declarando "nota" dentro do memso IF
                        {
                            aluno.Nota = nota;
                            Console.WriteLine("\n ----  Aluno e nota cadastrados com sucesso!  ----");
                        }
                        else
                        {
                            Console.WriteLine(">>>>>>>>>> VALOR INVÁLIDO, REPITA O PROCEDDO DE CADASTRO <<<<<<<<<<<<\n");
                            continue;
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;                    

                    break;

                    case "2":  ////////////////////////////   ToDo: Pesquisar aluno

                        Console.Write("Informe o nome do aluno que deseja listar: ");
                        string nomePesquisado = Console.ReadLine();
                        Aluno nomeEncontrado = new Aluno();

                        foreach(var a in alunos) //a cada posição do array "alunos", a var "a" herda seu valor
                        {   
                            if (!string.IsNullOrEmpty(a.Nome))
                            {                                            
                                if (nomePesquisado == a.Nome)
                                {
                                    nomeEncontrado = a;
                                }
                            }                              
                        } 

                        if (nomeEncontrado.Nome == nomePesquisado)
                        {
                            Console.WriteLine("ALUNO: " + nomeEncontrado.Nome + "- NOTA: " + nomeEncontrado.Nota);
                        }
                        else
                        {
                            Console.WriteLine(">>>>>>>>>> Aluno não encontrado, tente novamente <<<<<<<<<<<<");
                        }

                                          
                    break;

                    case "3":  /////////////////////////////   ToDo: Listar todos os alunos

                        foreach(var a in alunos)
                        {                            
                            if (!string.IsNullOrEmpty(a.Nome)) // Se "a.Nome" diferente (!) de NullorEmpty
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");
                            }                            
                        }
                    break;

                    case "4":  ////////////////////////////   ToDo: Calcular media geral

                    decimal soma = 0;
                    decimal cont = 0;

                    foreach(var s in alunos)
                    {
                        if(!string.IsNullOrEmpty(s.Nome))
                        {
                            soma = soma + s.Nota;
                            cont++;
                        }
                    }

                    if(soma != 0)
                    {
                        decimal resultado = soma / cont;
                        Console.WriteLine($"\n -------- A média geral dos alunos é: {resultado} -------- ");
                    }
                    else
                    {
                        Console.WriteLine("Os alunos cadastrados não possuem notas suficientes para realizar a média das mesmas");
                    }               

                    break;

                    default:
                        Console.WriteLine(">>>>>>>>>> OPÇÃO INVÁLIDA, TENTE NOVAMENTE <<<<<<<<<<<<");
                        opcaoUsuario = ObterOpcaoUsuario();
                        continue;
                        
                }

                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("\n----------------------------------------\n        INFORME A OPÇÃO DESEJADA\n----------------------------------------\n");
            Console.WriteLine("1 - Inserir novo aluno");
            Console.WriteLine("2 - Pesquisar aluno");
            Console.WriteLine("3 - Listar todos os alunos");
            Console.WriteLine("4 - Calcular a média");
            Console.WriteLine("X - sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
