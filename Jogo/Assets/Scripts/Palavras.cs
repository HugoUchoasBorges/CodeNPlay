using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palavras : MonoBehaviour {

	public int quantidadeDePalavras;
	public string[] vetorFinalDePalavras;

	public string[] palavrasBoa = {"amor", "carinho", "dedicação", "saúde", "alegria",
		"amigo", "esperança", "férias", "coragem", "liberdade",
		"gentileza", "adorável", "paz", "perfeitamente", "reciprocidade",
		"equilíbrio", "respeito", "risos", "vida", "cuidar",
		"coração", "felicidade", "cumplicidade", "amizade", "confiança",
		"competência", "confiável", "empatia", "excelência", "harmonia"
	};

	public string[] palavrasRuins = {"medo", "câncer", "catarro", "chorume", "diarreia",
		"desgraça", "escárnio", "furúnculo", "remorso", "idiota",
		"sórdido", "inimigo", "guerra", "nazismo", "preconceito",
		"morte", "destruição", "caos", "doença", "insanidade",
		"insegurança", "estúpido", "maldade", "sangue", "machucado",
		"conta", "juros", "cobrança", "iptu", "fracasso"
	};

	public string RetornaPalavra(string[] listaDePalavra, int quantidadePalavrasGeradas, string[] listaProibida){
		quantidadeDePalavras = quantidadePalavrasGeradas;
		Random rnd = new Random ();
		int i;
		string palavra;

		while (i < quantidadePalavrasGeradas) {
			int numeroAleatorio = rnd.Next (1, 30);

			palavra = listaDePalavra [rnd];

			for (int j = 0; j < listaProibida.Length; j++) {
				if (palavra.StartsWith == listaProibida [j].StartsWith) {
					break;
				}
				else if(j == (listaProibida.Length - 1)){
					vetorFinalDePalavras [i] = palavra;
					i++;
				}			
			}
		}

		return vetorFinalDePalavras;
	}

}
