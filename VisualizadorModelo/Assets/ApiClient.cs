using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ApiClient : MonoBehaviour
{
	public Text name;
	public Text occupation;
	public Text age;
	public Text nationality;
	public Text weaponOfChoice;
	public Text gender;

	const string baseUrl = "http://localhost:53018/API";

	// Use this for initialization
	void Start ()
	{
		//StartCoroutine(PostItemApiAsync());
		StartCoroutine(GetItensApiAsync());

	}

	private IEnumerator PostItemApiAsync()
	{
		WWWForm form = new WWWForm();

		form.AddField("Nome", "ItemFromUnity 2");
		form.AddField("Descricao", "Item enviado por POST para Unity3d (2)");
		form.AddField("DanoMaximo", "50");
		form.AddField("Raridade", "9");
		form.AddField("TipoItemID", "1");

		using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Modelo", form))
		{
			// obsoleto (Unity 2017.1)
			yield return request.Send();

			// (Unity 2017.2)
			//yield return request.SendWebRequest();


			if (request.isNetworkError || request.isHttpError)
			{
				Debug.Log(request.error);
			}
			else
			{
				Debug.Log("Envio do item efetuado com sucesso");
			}

		}
	}

	IEnumerator GetItensApiAsync()
	{
		UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Modelo");

		// obsoleto (Unity 2017.1)
		yield return request.Send();

		// (Unity 2017.2)
		//yield return request.SendWebRequest();

		if (request.isNetworkError || request.isHttpError)
		{
			Debug.Log(request.error);
		}
		else
		{
			string response = request.downloadHandler.text;
			//Debug.Log(response);

			byte[] bytes = request.downloadHandler.data;

			Modelo[] modelos = JsonHelper.getJsonArray<Modelo>(response);

			foreach (Modelo m in modelos)
			{
				ImprimirModelo(m);
			}
		}
	}

	private void ImprimirModelo(Modelo m)
	{
		//Debug.Log("======= Dados Modelo ==========");

		//Debug.Log("Id: " + m.ID);
		//Debug.Log("First Name: " + m.FirstName);
		//Debug.Log("Last Name: " + m.LastName);
		//Debug.Log ("Occupation: " + m.Occupation);
		//Debug.Log("Age: " + m.Age);
		//Debug.Log("Nationality: " + m.Nationality);
		//Debug.Log("Weapon of Choice: " + m.WeaponOfChoice);
		//Debug.Log("Gender: " + m.Gender);


		name.text = "Name: " + m.FirstName + " " + m.LastName;
		occupation.text = "Occupation: " + m.Occupation;
		age.text = "Age: " + m.Age.ToString();
		nationality.text = "Nationality: " + m.Nationality;
		weaponOfChoice.text = "Weapon of Choice: " + m.WeaponOfChoice;
		gender.text = "Gender: " + m.Gender;
	}
}