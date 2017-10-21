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

	public string[] RetornaPalavra(string[] listaDePalavra, int quantidadePalavrasGeradas, string[] listaProibida){
		quantidadeDePalavras = quantidadePalavrasGeradas;
		int i = 0;
		string palavra;

		while (i < quantidadePalavrasGeradas) {
			int numeroAleatorio = Random.Range(0, 30);

			palavra = listaDePalavra [numeroAleatorio];

			for (int j = 0; j < listaProibida.Length; j++) {
				if (palavra[0] == listaProibida[j][0]) {
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
