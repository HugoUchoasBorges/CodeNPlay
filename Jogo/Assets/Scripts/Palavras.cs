using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palavras : MonoBehaviour {

    public string[] palavrasBoas = {"OPEN", "HAPPY", "ALIVE", "GOOD", "understanding", "great", "playful", "calm", "confident", "courageous", "peaceful", "reliable", "joyous", "energetic", "at ease", "easy", "lucky", "liberated", "comfortable", "amazed", "fortunate", "optimistic", "pleased", "free", "delighted",
		"encouraged", "sympathetic", "overjoyed", "clever", "interested", "gleeful", "free", "surprised", "satisfied", "thankful", "content", "receptive", "important", "animated", "quiet", "accepting", "festive", "spirited", "certain", "kind", "ecstatic", "thrilled", "relaxed", "satisfied", "wonderful", "serene",
		"glad", "cheerful", "bright", "sunny", "blessed", "merry", "reassured", "LOVE", "INTERESTED", "POSITIVE", "STRONG", "loving", "considerate", "free", "affectionate", "fascinated", "earnest", "sure", "sensitive", "certain", "tender", "devoted", "inspired", "unique", "attracted", "determined", "dynamic",
		"passionate", "excited", "admiration", "enthusiastic", "warm", "curious", "bold", "secure", "touched", "brave", "sympathy", "daring", "close", "loved", "optimistic", "comforted", "re-enforced", "confident", "hopeful"
    };

    public string[] palavrasRuins = {"ANGRY", "DEPRESSED", "CONFUSED", "HELPLESS", "irritated", "lousy", "upset", "incapable", "enraged", "disappointed", "doubtful", "alone", "hostile", "discouraged", "uncertain", "paralyzed", "insulting", "ashamed", "indecisive", "fatigued", "sore", "powerless", "perplexed", "useless", "annoyed", "diminished", "embarrassed", "inferior", "upset", "guilty", "hesitant", "vulnerable", "hateful", "dissatisfied", "shy", "empty", "unpleasant", "miserable", "stupefied", "forced", "offensive", "detestable", "disillusioned", "hesitant", "bitter", "repugnant", "unbelieving", "despair", "aggressive", "despicable", "skeptical", "frustrated", "resentful", "disgusting", "distrustful", "distressed", "inflamed", "abominable", "misgiving", "woeful", "provoked", "terrible", "lost", "pathetic", "incensed", "in despair", "unsure", "tragic", "infuriated", "sulky", "uneasy", "in a stew", "cross", "bad", "pessimistic", "dominated", "worked up", "a sense of loss", "tense", "boiling", "fuming", "indignant", "INDIFFERENT", "AFRAID", "HURT", "SAD", "insensitive", "fearful", "crushed", "tearful", "dull", "terrified", "tormented", "sorrowful", "nonchalant", "suspicious", "deprived", "pained", "neutral", "anxious", "pained", "grief", "reserved", "alarmed", "tortured", "anguish", "weary", "panic", "dejected", "desolate", "bored", "nervous", "rejected", "desperate", "preoccupied", "scared", "injured", "pessimistic", "cold", "worried", "offended", "unhappy", "disinterested", "frightened", "afflicted", "lonely", "lifeless", "timid", "aching", "grieved", "shaky", "victimized", "mournful", "restless", "heartbroken", "dismayed", "doubtful", "agonized", "threatened", "appalled", "cowardly", "humiliated", "quaking", "wronged", "menaced", "alienated", "wary"
    };

	public string RetornaPalavra(int sanidade) {
		if (CaracteristicasDoJogo.modoRuim) {
			int numeroAleatorio = Random.Range (0, palavrasRuins.Length);
			return palavrasRuins [numeroAleatorio].ToUpper ();
		} else {
			int numeroAleatorio = Random.Range (0, palavrasBoas.Length);
			return palavrasBoas [numeroAleatorio].ToUpper ();
		}
	}

}
