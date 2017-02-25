using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractionModel : MonoBehaviour {

    [SerializeField]
    private float interactiveradius = 0.8f;
    [SerializeField]
    private float YOffset = 0f;

    [Header("Debug")]
    [SerializeField]
    private bool ShowGizmos = false;

	private GameObject LiftedUpOBJ;


    public void OnInteract()
    {
		if(LiftedUpOBJ != null)
		{
			LiftedUpOBJ.GetComponent<InteractablePickUp>().Throw(Character.m_MovementModel.GetFacingDirection());
			Character.m_MovementModel.ThrowLiftedObject();
			LiftedUpOBJ = null;
			return;
		}

        InteractableBase usableInteractable = FindUsableInteractable();
        if (usableInteractable == null)
        {
            return;
        }
        //Debug.Log("Found Interactable! " + usableInteractable.name);
        usableInteractable.OnInteract();
    }

    InteractableBase FindUsableInteractable()
    {
        Collider2D[] closecolliders = Physics2D.OverlapCircleAll(transform.position + new Vector3(0, YOffset), interactiveradius);

        InteractableBase closestInteractable = null;
        float AngleToClosestInteractable = Mathf.Infinity;

        for (int i = 0; i < closecolliders.Length; i++)
        {
            InteractableBase colliderInteractable = closecolliders[i].GetComponent<InteractableBase>();

            if (colliderInteractable == null)
            {
                continue;
            }

            Vector3 directionToInteractable = closecolliders[i].transform.position - transform.position;
            float angleToInteractable = Vector3.Angle(directionToInteractable, Character.m_MovementModel.GetFacingDirection());
            if (angleToInteractable < 40)
            {
                if (angleToInteractable < AngleToClosestInteractable)
                {
                    closestInteractable = colliderInteractable;
                    AngleToClosestInteractable = angleToInteractable;
                }
            }

            //Debug.Log(i + ": " + closecolliders[i].name + " - Angle: " + angleToInteractable);
        }
        return closestInteractable;
    }

	public void LiftUpObject(GameObject obj)
	{
		if (!obj.GetComponent<InteractablePickUp>().TakeOrginial)
			LiftedUpOBJ = Instantiate(obj);
		else
			LiftedUpOBJ = obj;

		LiftedUpOBJ.transform.parent = Character.m_MovementView.LiftedUpObjectParent.transform;
		LiftedUpOBJ.transform.localPosition = Vector2.zero;

		Character.m_MovementModel.LiftUpObject();


		WorldFunktions.SetObjectSpriteLayer(LiftedUpOBJ, "AbovePlayer");

		Collider2D col = LiftedUpOBJ.GetComponent<Collider2D>();
		if (col)
		{
			col.enabled = false;
		}

		Debug.Log("", obj);
		obj.SendMessage("PickUp", SendMessageOptions.DontRequireReceiver);
	}

    //Debug
    void OnDrawGizmos()
    {
        if (ShowGizmos)
        {
            Gizmos.DrawWireSphere(transform.position + new Vector3(0, YOffset), interactiveradius);
        }
    }
}

