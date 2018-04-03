using UnityEngine;
using System.Collections;
using Entitas;

public class CreateScoreEntity : MonoBehaviour
{
    [SerializeField]
    private int value;
    [SerializeField, Tag]
    private string target;
    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag.Equals(target))
        {
            var input = Contexts.sharedInstance.input.CreateEntity();
            input.AddChangeScore(value, OperationType.ADD);
        }
    }
}
