using UnityEngine;

public class Fighter : MonoBehaviour
{
    [SerializeField] float weaponRange = 1f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float weaponDamage = 20f;

    float timeSinceLastAttack = 0f;

    Transform target;

    private void Update()
    {
        timeSinceLastAttack += Time.deltaTime;
        if (target == null) return;

        if(!GetIsInRange())
        {
            GetComponentInParent<Mover>().MoveTo(target.position);
        }
        else
        {
            GetComponentInParent<Mover>().Stop();
            AttackAnimation();
        }
    }

    private void AttackAnimation()
    {
        if (timeSinceLastAttack > timeBetweenAttacks)
        {
            GetComponent<Animator>().SetTrigger("attack");
            timeSinceLastAttack = 0f;
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.position) < weaponRange;
    }

    public void Attack(CombatTarget combatTarget)
    {
        print("Take that dirty peasant!");
        target = combatTarget.transform;
    }

    public void Hit()
    {
        Health health = target.GetComponent<Health>();
        health.TakeDamage(weaponDamage);
    }

    public void Cancel()
    {
        target = null;
    }

}
