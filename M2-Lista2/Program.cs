using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace M2_Lista2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader file = File.OpenText("settings.json"))
            {
               var arquivo = JsonConvert.DeserializeObject<Settings>(file.ReadToEnd());

               StringBuilder builder = new StringBuilder();
               builder.Append("1 – Configurar Usuario / Senha");
               builder.Append("\n2 - Logar");
               builder.Append("\n3 – Limpar base");
               builder.Append("\n4 - Sair");
               int menu;
               do
               {
                   Console.WriteLine(builder.ToString());
                   menu = Convert.ToInt32(Console.ReadLine());
                   switch (menu)
                   {
                       case 1:
                           CadastrarSenha(arquivo);
                           break;
                       case 2:
                            Logar(arquivo);
                           break;
                       case 3:
                            LimparBase(arquivo);
                           break;
                       default:
                           break;
                   }
               } while (menu != 4);
            }
        }

        static void CadastrarSenha(Settings s)
        {
            Console.Write("Crie um usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Crie uma senha: ");
            string senha = Console.ReadLine();
            if (ArquivosEPastas.CriarEscreverArquvivo(s, usuario, senha))
                Console.WriteLine("Conta cadastrada!!");
            else
                Console.WriteLine("Já existe um cadastro!!");
        }

        static void Logar(Settings s)
        {
            Console.Write("Informe o usuário: ");
            string usuario = Console.ReadLine();
            Console.Write("Informe a senha: ");
            string senha = Console.ReadLine();
            if (ArquivosEPastas.LerArquivo(s, usuario, senha))
                Console.WriteLine("Logado com sucesso!!");
            else
                Console.WriteLine("Erro no login!!");
            
        }

        static void LimparBase(Settings s)
        {
            if (ArquivosEPastas.DeletarPasta(s))
                Console.WriteLine("Deletado com sucesso");
            else
                Console.WriteLine("Erro ao deletar");
        }
    }
}
