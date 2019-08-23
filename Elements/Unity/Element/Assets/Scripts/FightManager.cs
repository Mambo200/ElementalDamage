using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public bool EnemyTurn { get; private set; }
    public List<MainEntity> allEnemys { get; private set; }
    public List<Player> allPlayers { get; private set; }
    private int enemyIndex = 0;
    public int EnemyIndex
    {
        get => enemyIndex;

        private set
        {
            enemyIndex = value;

            if (allEnemys.Count > enemyIndex)
                allEnemys[EnemyIndex].m_Arrow.SetActive(true);
        }
    }



    private static FightManager instance;
    public static FightManager GetFight
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<FightManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("FightManager", typeof(FightManager));
                    instance = go.GetComponent<FightManager>();
                    if (instance == null) Debug.LogWarning("Fightmanager could not be added to new Gameobject", go);
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        EnemyTurn = false;
        allEnemys = FindEnemies();
        allPlayers = FindPlayers();
        allEnemys[0].m_Arrow.SetActive(true);
        EnemyIndex = 0;
    }

    private void Update()
    {
        if (allEnemys.Count != 0)
        {

            CheckPlayersRound();

            if (EnemyTurn)
            {
                foreach (MainEntity me in allEnemys)
                {
                    int playerIndex = Random.Range(0, allPlayers.Count - 1);
                    Elements.Player.Player p = allPlayers[playerIndex].player;
                    float damage = p.TakeDamage(me.Enemy);
                    Debug.Log($"{me.Enemy.Name} dealt {damage} damage to {allPlayers[playerIndex].player.Name}.");

                    ResetPlayersTurn();
                }

                EnemyTurn = false;

                foreach (Player p in allPlayers)
                {
                    Debug.Log($"{p.player.Name}: {p.player.CurrentHealth}/{p.player.MaxHealth}.");
                }
            }
        }


    }

    public void Load() { }

    private List<MainEntity> FindEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<MainEntity> enemyList = new List<MainEntity>();

        foreach (GameObject go in enemies)
            enemyList.Add(go.GetComponent<MainEntity>());

        return enemyList;
    }

    private List<Player> FindPlayers()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        List<Player> playerList = new List<Player>();

        for (int i = 1; i < players.Length; i++)
        {
            playerList.Add(players[i].GetComponent<Player>());

        }
        return playerList;
    }

    public void Attack(Elements.Player.Player _player)
    {
        if (allEnemys == null)
            allEnemys = FindEnemies();

        if (allEnemys.Count == 0) return;

        #region DEBUG ONLY
        // if clicked deal Damage to Enemy
        float damage = allEnemys[EnemyIndex].Enemy.TakeDamage(_player.Weapon);

        Debug.Log($"{allEnemys[EnemyIndex].Enemy.Name} took {damage} damage.\t{(int)(allEnemys[EnemyIndex].Enemy.CurrentHealth + 0.5f)}/{allEnemys[EnemyIndex].Enemy.MaxHealth}");

        // Enemy died
        if (allEnemys[EnemyIndex].Enemy.CurrentHealth == 0)
        {
            Debug.Log($"{allEnemys[EnemyIndex].Enemy.Name} is Dead.");

            // destroy Object
            GameObject.Destroy(allEnemys[EnemyIndex].gameObject);
            allEnemys.RemoveAt(EnemyIndex);

            // Set Index and show arrow
            EnemyIndex = 0;

            if (allEnemys.Count <= 0) BattleOver();

        }
        #endregion
    }

    public void ChangeIndex(GameObject hit)
    {
        for (int i = 0; i < allEnemys.Count; i++)
        {
            if (allEnemys[i].gameObject == hit)
            {
                allEnemys[EnemyIndex].m_Arrow.SetActive(false);
                allEnemys[i].m_Arrow.SetActive(true);
                EnemyIndex = i;
                break;
            }
        }
    }

    public void SetEnemysTurn() => EnemyTurn = true;

    /// <summary>
    /// Checks all players attacked bool. if all are true, set enemysturn to true
    /// </summary>
    private void CheckPlayersRound()
    {
        foreach (Player player in allPlayers)
        {
            // return if one player did not attack
            if (!player.attacked) return;
        }

        EnemyTurn = true;
    }

    /// <summary>
    /// Set all players attacked value to false;
    /// </summary>
    private void ResetPlayersTurn()
    {
        foreach (Player p in allPlayers)
        {
            p.attacked = false;
        }
    }

    public void BattleOver()
    {
        MySceneManager.LoadOverWorldScene();
    }
}
