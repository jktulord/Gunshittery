using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class AdvancedSpawnerController : MonoBehaviour
{
    public List<Spawner> Spawners;
    public List<WaveTemplate> WaveTemplates;
    public ObjectPoolTrigger ObjectPoolTrigger;

    public int CurrentWave = 0;

    public UnityEvent AfterBattleEvent;


    public void Activate()
    {
        CurrentWave = 1;
        NextWave();
    }

    public void NextWave()
    {
        if (CurrentWave >= 1)
        {
            WaveTemplate CurrentTemplate = WaveTemplates[CurrentWave - 1];
            for (int i = 0; i < CurrentTemplate.Amount.Length; i++)
            {
                Spawn(CurrentTemplate.Enemies[i], CurrentTemplate.Amount[i]);
            }
            CurrentTemplate.AdditionalEvent.Invoke();
            CurrentWave++;
        }
        else
        {

        }
    }

    public void Spawn(GameObject Enemy, int Amount)
    {
        int DivAmount = Amount / Spawners.Count;
        int ModAmount = Amount % Spawners.Count;
        foreach (Spawner current in Spawners)
        {
            current.Prefab = Enemy;
            current.Amount = DivAmount;
        }
        for (int i = 0; i < ModAmount; i++)
        {
            Spawners[i].Amount++;
        }
        foreach (Spawner current in Spawners)
        {
            ObjectPoolTrigger.ActiveGameObjects.AddRange(current.Spawn());
        }
    }
    
    

}

