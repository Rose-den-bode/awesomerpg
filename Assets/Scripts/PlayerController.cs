using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Health health;
    Mover mover;
    Fighter fighter;

    public void Start()
    {
        fighter = GetComponentInChildren<Fighter>();
        mover = GetComponent<Mover>();
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (ClickToFight()) return;
        if (ClickToMove()) return;
        print("Nothing going on");

    }

    private bool ClickToFight()
    {
        RaycastHit[] raycastHits = Physics.RaycastAll(GetRay());
        foreach (RaycastHit hit in raycastHits)
        {
            CombatTarget target = hit.transform.GetComponent<CombatTarget>();
            if (target == null) continue;

            if (Input.GetMouseButtonDown(0))
            {
                fighter.Attack(target);
            }
            return true;
        }
        return false;
    }

    bool ClickToMove()
    {
        RaycastHit hit;
        bool hasHit = Physics.Raycast(GetRay(), out hit);
        if (hasHit)
        {
            if (Input.GetMouseButtonDown(0) && !GetComponent<Health>().IsDead())
            {
                fighter.Cancel();
                mover.MoveTo(hit.point);
            }
            return true;
        }
        return false;
    }

    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);
        if (hasHit)
        {
            mover.Move(hit.point, health.IsDead());
        }
    }

    private static Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

}

