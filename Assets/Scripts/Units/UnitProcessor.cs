using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProcessor : MonoBehaviour
{
    [SerializeField] Transform spawnPosition;
    [SerializeField] Unit spawnUnit;
    [SerializeField] List<Unit> unitsList;

    private Unit selectedUnit;
    private int selectedUnitIndex;

    public Unit GetNextUnit() 
    {
        if (unitsList.Count == 0)
            return null;

        if (selectedUnit == null)
            return GetRandomUnit();

        //Debug.Log("pre " + selectedUnitIndex + " / " + unitsList.Count);
        if (selectedUnitIndex + 1 >= unitsList.Count)        
            selectedUnitIndex = -1;
        //Debug.Log("post " + selectedUnitIndex + " / " + unitsList.Count);
        Unit unit = unitsList[++selectedUnitIndex];
        selectedUnit = unit;

        return unit;
    }
    public Unit GetRandomUnit() 
    {
        if (unitsList.Count == 0)
            return null;

        selectedUnitIndex = Random.Range(0, unitsList.Count);
        Unit unit = unitsList[selectedUnitIndex];
        selectedUnit = unit;

        return unit;
    }

    [ContextMenu("Spawn Unit")]
    public void DebugSpawnUnit()
    {
        SpawnUnit(spawnUnit, spawnPosition);
    }

    public void SpawnUnit(Unit unit, Transform targetTransform)
    {
        SpawnUnit(unit, targetTransform.position, targetTransform.rotation);
    }

    public void SpawnUnit(Unit unit, Vector3 targetTransform, Quaternion targetRotation)
    {
        var spawnedUnit = Instantiate(unit, targetTransform, targetRotation);
        unitsList.Add(spawnedUnit);
        spawnedUnit.OnTerminate += OnUnitTerminate;
    }

    public void OnUnitTerminate(Unit unit)
    {
        unitsList.Remove(unit);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            DebugSpawnUnit();
    }
}
