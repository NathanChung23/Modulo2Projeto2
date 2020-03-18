using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace M2_Lista2
{
    public static class ArquivosEPastas
    {
        public static bool CriarEscreverArquvivo(Settings t, string u, string s)
        {
            if (!File.Exists(t.Caminho + t.Pasta + t.Arquivo))
            {
                CriarPasta(t);
                using (StreamWriter sw = File.CreateText(t.Caminho + t.Pasta + t.Arquivo))
                {
                    sw.WriteLine(u);
                    sw.WriteLine(Criptografia.Criptografar(s));
                    return true;
                }
            }
            else
                return false;
        }

        public static bool LerArquivo(Settings t, string u, string s)
        {
            List<string> oList = new List<string>();

            try
            {
                using (StreamReader sr = File.OpenText(t.Caminho + t.Pasta + t.Arquivo))
                {
                    string text = "";
                    while ((text = sr.ReadLine()) != null)
                    {
                        oList.Add(text);
                    }
                }

                if (oList[0] == u && oList[1] == Criptografia.Criptografar(s))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool CriarPasta(Settings t)
        {
            if (!File.Exists(t.Caminho + t.Pasta))
            {
                Directory.CreateDirectory(t.Caminho + t.Pasta);
                return true;
            }
            else
                return false;
        }

        public static bool DeletarPasta(Settings t)
        {
            try
            {
                Directory.Delete(t.Caminho + t.Pasta, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
