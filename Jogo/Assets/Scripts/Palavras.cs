using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palavras : MonoBehaviour {

	public int quantidadeDePalavras = 3; //temporariamente 3, mas ela é a quantidade da 
	public string[] vetorFinalDePalavras;
	public ArrayList listaLetraProibida = new ArrayList();

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

	public string RetornaPalavra(){
		//int i = 0;
		string palavra;

		while (true) {
			int numeroAleatorio = Random.Range (0, 30);
			palavra = palavrasRuins [numeroAleatorio];

			if (listaLetraProibida.Count == 0) {
				listaLetraProibida.Add (palavra [0]);
				return palavra.ToUpper();
			} else {
				if (listaLetraProibida.Contains (palavra [0])) {
					continue;
				}

				listaLetraProibida.Add (palavra [0]);
				return palavra.ToUpper();
			}
		}
	}
		 



	public void liberaPalavra(char letra){
		for (int i = 0; i < listaLetraProibida.Count; i++) {
			if (listaLetraProibida.Contains(letra)){
				listaLetraProibida.Remove(letra);
			}
		}
	}

}
