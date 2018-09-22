using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class Cat_Utilites : MonoBehaviour {
	private static string[] firstNames = new string[]
    {
        "Shade","Feather","Bramble","Fire","Red","Blue",
		"Silver","Dusk","Dust","Sand","Gray","Silver","Dark","Long","Bracken","Fern","Duck",
		"Cinder","Ash","Jay","Holly","Lion","Tiger","Squrrel","Night","Willow","Flame","Hawk"
		,"Raven","Black","Gorse","Torn","Thorn","Mouse","Spider","Sorrel","Cloud","White",
		"Shrew","Bright","Rain","Soot","Golden","Frost","Dapple","Speckle","Russet","Little",
		"Oak","Smoke","Tawny","Cedar","Rowan","Talon","Tall","Poppy","Running","Mud","Crow",
		"Bark","One","Web","Morning","Leopard","Misty","Moth","Heavy","Storm","Moss","Dawn",
		"Loud","Barley","Stumpy","Jagged","Rat","Fox","Deer","Bird","Berry","Sparrow","Cherry"
		,"Birch","Maple","Snow","Honey","Ice","Owl","Olive","Toad","Snake","Scorch","Water",
		"Breeze"
    };
	
	private static string[] lastNames = new string[]
	{
		"claw","pelt","fur","face","heart","stripe","foot",
	    "spirit","whisker","feather","tail","storm","leaf","blaze","pool","wing","sky",
	    "berry","nose","ear","eye","flight","flower","cloud","poppy","step","frost","belly",
	    "tooth","eyes","shade","fern","leg","scar","water"
	};

	public List <string> usedNames;
	
	public string RandFirstName (){
		return firstNames[UnityEngine.Random.Range(0, firstNames.Length)];
	}
	
	public string RandLastName (){
		return lastNames[UnityEngine.Random.Range(0, lastNames.Length)];
	}
	
	public string RandWarriorName (){
		return RandFirstName() + RandLastName();
	}

	public string RandApprenticeName (){
		return RandFirstName() + "paw";
	}

	public string RandLeaderName (){
		return RandFirstName() + "star";
	}

	public string RandKitName(){
		return RandFirstName() + "kit";
	}

	public string RandName(Globals.RANK rank){
		if (rank == Globals.RANK.Leader){
			return RandLeaderName();
		}
		else if (rank == Globals.RANK.Warrior){
			return RandWarriorName();
		}
		else if (rank == Globals.RANK.Apprentice){
			return RandApprenticeName();
		}
		else if (rank == Globals.RANK.Healer){
			return RandWarriorName();
		}
		else if (rank == Globals.RANK.Kit){
			return RandKitName();
		}
		else{
			return "invalid rank in RandName";
		}
	}
}
