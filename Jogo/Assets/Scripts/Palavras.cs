using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palavras : MonoBehaviour {

	public int quantidadeDePalavras = 3; //temporariamente 3, mas ela é a quantidade da 
	public string[] vetorFinalDePalavras;
    public ArrayList listaLetraProibida = new ArrayList();

    public string[] palavrasBoa = {"OPEN", "HAPPY", "ALIVE", "GOOD", "understanding", "great", "playful", "calm", "confident", "gay", "courageous", "peaceful", "reliable", "joyous", "energetic", "at ease", "easy", "lucky", "liberated", "comfortable", "amazed", "fortunate", "optimistic", "pleased", "free", "delighted", "provocative", "encouraged", "sympathetic", "overjoyed", "impulsive", "clever", "interested", "gleeful", "free", "surprised", "satisfied", "thankful", "frisky", "content", "receptive", "important", "animated", "quiet", "accepting", "festive", "spirited", "certain", "kind", "ecstatic", "thrilled", "relaxed", "satisfied", "wonderful", "serene", "glad", "free and easy", "cheerful", "bright", "sunny", "blessed", "merry", "reassured", "elated", "jubilant", "LOVE", "INTERESTED", "POSITIVE", "STRONG", "loving", "concerned", "eager", "impulsive", "considerate", "affected", "keen", "free", "affectionate", "fascinated", "earnest", "sure", "sensitive", "intrigued", "intent", "certain", "tender", "absorbed", "anxious", "rebellious", "devoted", "inquisitive", "inspired", "unique", "attracted", "nosy", "determined", "dynamic", "passionate", "snoopy", "excited", "tenacious", "admiration", "engrossed", "enthusiastic", "hardy", "warm", "curious", "bold", "secure", "touched", "brave", "sympathy", "daring", "close", "challenged", "loved", "optimistic", "comforted", "re-enforced", "drawn toward", "confident", "hopeful"
    };

    public string[] palavrasRuins = {"ANGRY", "DEPRESSED", "CONFUSED", "HELPLESS", "irritated", "lousy", "upset", "incapable", "enraged", "disappointed", "doubtful", "alone", "hostile", "discouraged", "uncertain", "paralyzed", "insulting", "ashamed", "indecisive", "fatigued", "sore", "powerless", "perplexed", "useless", "annoyed", "diminished", "embarrassed", "inferior", "upset", "guilty", "hesitant", "vulnerable", "hateful", "dissatisfied", "shy", "empty", "unpleasant", "miserable", "stupefied", "forced", "offensive", "detestable", "disillusioned", "hesitant", "bitter", "repugnant", "unbelieving", "despair", "aggressive", "despicable", "skeptical", "frustrated", "resentful", "disgusting", "distrustful", "distressed", "inflamed", "abominable", "misgiving", "woeful", "provoked", "terrible", "lost", "pathetic", "incensed", "in despair", "unsure", "tragic", "infuriated", "sulky", "uneasy", "in a stew", "cross", "bad", "pessimistic", "dominated", "worked up", "a sense of loss", "tense", "boiling", "fuming", "indignant", "INDIFFERENT", "AFRAID", "HURT", "SAD", "insensitive", "fearful", "crushed", "tearful", "dull", "terrified", "tormented", "sorrowful", "nonchalant", "suspicious", "deprived", "pained", "neutral", "anxious", "pained", "grief", "reserved", "alarmed", "tortured", "anguish", "weary", "panic", "dejected", "desolate", "bored", "nervous", "rejected", "desperate", "preoccupied", "scared", "injured", "pessimistic", "cold", "worried", "offended", "unhappy", "disinterested", "frightened", "afflicted", "lonely", "lifeless", "timid", "aching", "grieved", "shaky", "victimized", "mournful", "restless", "heartbroken", "dismayed", "doubtful", "agonized", "threatened", "appalled", "cowardly", "humiliated", "quaking", "wronged", "menaced", "alienated", "wary"
    };

    public string RetornaPalavra(){
		//int i = 0;
		string palavra;

        while (true) {
			int numeroAleatorio = Random.Range (0, palavrasRuins.Length);
			palavra = palavrasRuins [numeroAleatorio].ToUpper();

            //Debug.Log("Palavra analizada: " + palavra);

			if (listaLetraProibida.Count == 0) {
                listaLetraProibida.Add (palavra [0]);
                //Debug.Log("Palavra retornada: " + palavra);
               //Debug.Log("Letra adicionada na lista: " + palavra[0]);
                return palavra;
			} else {
				if (listaLetraProibida.Contains (palavra [0])) {
                    //Debug.Log("Letra adicionada na lista: " + palavra[0]);
                    continue;
				}

                //Debug.Log("Palavra retornada: " + palavra);
                //Debug.Log("Letra adicionada na lista: " + palavra[0]);
                listaLetraProibida.Add (palavra [0]);
				return palavra;
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
