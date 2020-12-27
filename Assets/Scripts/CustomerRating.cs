using UnityEngine;

[CreateAssetMenu(menuName = "SO/CustomerRating", fileName = "ExampleRating")]
public class CustomerRating : ScriptableObject
{
    public string customerName;
    public int rating;
    [Multiline]
    public string customerMessage;
}
