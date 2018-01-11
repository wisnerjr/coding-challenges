using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KingSort
{
    public class KingSort
    {

        public List<string> getSortedList(String[] kings)
        {
            // Função para inicializar o dicionário com todos os números romanos e seus pesos
            var dic = InicializaDicionario();

            // dicionário com chave igual ao nome do rei original com um valor igual a um dicionário aninhado com chave = algarismo romano e valor = correspondente númerico do algarismo
            Dictionary<string, Dictionary<string, int>> dicionario = new Dictionary<string, Dictionary<string, int>>();

            // dicionário auxiliar que será utilizado para receber o dicionário aninhado anterior
            Dictionary<string, int> dicAux = new Dictionary<string, int>();
            List<string> result = new List<string>();

            string rei = string.Empty;
            int titulo = 0;
            string valorRomano = string.Empty;
            string nomeRei = string.Empty;

            String[] aux = new String[2];

            // percorre cada string nome de rei
            foreach (var king in kings)
            {
                // divide cada uma delas entre o nome do rei e seu título
                aux = king.Split(' ');

                nomeRei = aux[0].ToString();

                // encontra no dicionario qual é o valor correspondente ao título em algarismos romanos
                titulo = CalculaTitulacao(aux[1].ToString());


                // verifica se o Rei + Título já foi inserido em um dicionário auxiliar que será utilizado para ordenar utilizar linq
                nomeRei = String.Concat(nomeRei + " " + titulo);
                if (!dicionario.Any(x => x.Key.Equals(nomeRei))) {
                    dicionario.Add(nomeRei, new Dictionary<string, int>());
                    dicionario[nomeRei].Add(aux[1].ToString(), titulo);
                if (!dicAux.Any(x => x.Key.Equals(aux[1].ToString())))
                    dicAux.Add(aux[1].ToString(), titulo);
                }
            }

            string nomeReiAnterior = dicionario.FirstOrDefault().Key.Split(' ')[0];
            string nomeReiAtual = string.Empty;
            int contadorReis = 1;

            // contador para verificar se todos os nomes de reis no array de string são iguais
            for (int v = 1; v < dicionario.Count(); v++)
            {
                nomeReiAtual = dicionario.ElementAtOrDefault(v).Key.Split(' ')[0];
                if (nomeReiAnterior.Equals(nomeReiAtual))
                {
                    contadorReis++;
                }
            }


            // se todos os reis tiverem nome igual, deve efetuar um linq para ordenação de modo diferente
            if (contadorReis == dicionario.Count)
            {
                // como todos os reis tem nome igual, deve-se ordenar primeiramente pelo tamanho da chave e depois pela chave
                var listaOrdenada = dicionario.OrderBy(x => x.Key.Length).ThenBy(x => x.Key);

                // percorre cada item da listaOrdenada para substituir o algarismo na Base 10 para seu correspondente em algarismo romano novamente
                foreach (var valor in listaOrdenada)
                {
                    // recebe o valor da chave do dicionario principal (NomeRei + NúmeroBase10 - Exemplo: Carlos 10)
                    valorRomano = valor.Key.ToString();

                    // split no valorRomano 
                    aux = valorRomano.Split(' ');

                    // recupera o valor númerico associado ao algarismos romanos existentes no dicionário
                    titulo = dicAux.FirstOrDefault(x => x.Value == Convert.ToInt32(aux[1])).Value;

                    // substituição do valor correspondente ao algarismo romano através de pesquisa no dicionário de algarismos romanos
                    nomeRei = valor.Key.Replace(titulo.ToString(), valor.Value.FirstOrDefault(x => x.Value == titulo).Key);

                    // adiciona o nome do rei original, sequencialmente já ordenado, ao resultado final
                    result.Add(nomeRei);
                }

                return result.ToList();
            }
            else
            {
                // ordena utilizando linq através do valor da chave (NomeRei + NúmeroBase 10 - Exemplo: Carlos 10)
                 var listaOrdenada = dicionario.OrderBy(x => x.Key);

                // percorre cada item da listaOrdenada para substituir o algarismo na Base 10 para seu correspondente em algarismo romano novamente
                foreach (var valor in listaOrdenada)
                {
                    // recebe o valor da chave do dicionario principal (NomeRei + NúmeroBase10 - Exemplo: Carlos 10)
                    valorRomano = valor.Key.ToString();

                    // split no valorRomano 
                    aux = valorRomano.Split(' ');

                    // recupera o valor númerico associado ao algarismos romanos existentes no dicionário
                    titulo = dicAux.FirstOrDefault(x => x.Value == Convert.ToInt32(aux[1])).Value;

                    // substituição do valor correspondente ao algarismo romano através de pesquisa no dicionário de algarismos romanos
                    nomeRei = valor.Key.Replace(titulo.ToString(), valor.Value.FirstOrDefault(x => x.Value == titulo).Key);

                    // adiciona o nome do rei original, sequencialmente já ordenado, ao resultado final
                    result.Add(nomeRei);
                }

                return result.ToList();
            }
        }

        // Inicializa dicionário com valores em romanos dos algarismos simples
        public Dictionary<string, int> InicializaDicionario()
        {
            return new Dictionary<string, int>() {
                {"I", 1},
                {"V", 5},
                {"X", 10},
                {"L", 50}
            };
        }

        // Função para calcular o algarismo romano correspondente em número
        public int CalculaTitulacao(string titulo)
        {
            int total = 0;
            var peso = InicializaDicionario();

            for (int i = 0; i < titulo.Length; i++)
            {
                // se i não estiver na última posição e o valor no dicionário = i for menor que o valor no dicionário = i +1
                // significa que não há "regra especial" de composição para o algarismo que está sendo avaliado (exemplo: "regra especial" = IX ou XL) -- de acordo com a estruturação do dicionário (menor p/ maior)
                // caso haja essa "regra especial" então o total será decrementado
                // se não houver, soma o valor do dicionario[i] ao total
                if (i + 1 < titulo.Length && peso[titulo[i].ToString()] < peso[titulo[i + 1].ToString()])
                {
                    total -= peso[titulo[i].ToString()];
                }
                else
                {
                    total += peso[titulo[i].ToString()];
                }
            }
            return total;
        }
    }

}