using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBehavior : MonoBehaviour
{
    private List<Rigidbody> objectsOnPlate = new List<Rigidbody>();
    [SerializeField] private int actuationMass;
    [SerializeField] private string pressurePlateName;
    [SerializeField] private float debounceTime = 1.0f; // Time in seconds for the debounce delay

    private bool isActivated = false;
    private float lastActivationTime = -1f;

    public GetQuestions checkAnswer;
    
    void OnTriggerEnter(Collider other)
    {
        AddRigidbodyToList(other);
        CheckPlateActivation();
    }

    void OnTriggerExit(Collider other)
    {
        RemoveRigidbodyFromList(other);
        CheckPlateActivation();
    }

    void AddRigidbodyToList(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null && !objectsOnPlate.Contains(rb))
        {
            objectsOnPlate.Add(rb);
        }
    }

    void RemoveRigidbodyFromList(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        if (rb != null)
        {
            objectsOnPlate.Remove(rb);
        }
    }

    void CheckPlateActivation()
    {
        float totalMass = CalculateTotalMass();
        float currentTime = Time.time;

        // Check if enough time has passed since the last activation
        if (currentTime - lastActivationTime > debounceTime)
        {
            if (!isActivated && totalMass >= actuationMass)
            {
                ActivatePlate();
                lastActivationTime = currentTime; 
            }
        }

        // Deactivate if no objects or total mass is below threshold
        if (isActivated && totalMass < actuationMass)
        {
            isActivated = false;
            Debug.Log("Pressure Plate Deactivated");
        }
    }

    private void ActivatePlate()
    {
        checkAnswer.CeckAnswer(pressurePlateName);
        isActivated = true;
        Debug.Log("HELLO PLATE: " + pressurePlateName);
    }

    private float CalculateTotalMass()
    {
        float totalMass = 0;
        foreach (Rigidbody rb in objectsOnPlate)
        {
            totalMass += rb.mass;
        }
        return totalMass;
    }
}
