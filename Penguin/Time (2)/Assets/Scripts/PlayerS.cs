using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerS : MonoBehaviour
{
    public GatterAbleObject inst;
    public Sprite defaultempty;
    public List<int> ids;
    public List<Image> slots;
    public float range = 1, damage = 10;
    public Animator anim;
    public Caminar2d c2;
    public Vector2 offset;
    public Transform body, selected, inventory;
    public Transform Te;
    Vector3 slp, sln;
    float pt;
    bool b;
    public int objects;
    // Start is called before the first frame update
    void Start()
    {
        c2 = GetComponent<Caminar2d>();
        slp = body.localScale;
        sln = new Vector3(body.localScale.x, body.localScale.y, body.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x - 512 > 340)
            {
                inventory.gameObject.SetActive(false);
            }
            if (Input.mousePosition.x - 512 < -340)
            {
                inventory.gameObject.SetActive(false);
            }
            if (Input.mousePosition.y - 768 / 2 > 150)
            {
                inventory.gameObject.SetActive(false);
            }
            if (Input.mousePosition.y - 768 / 2 < -250)
            {
                inventory.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown("q"))
        {
            if (inventory.gameObject.activeInHierarchy)
                inventory.gameObject.SetActive(false);
            else inventory.gameObject.SetActive(true);
        }
        pt += Time.deltaTime;
        if (anim)
            if (body) if (c2.l)
                {
                    body.localScale = sln;
                }
                else
                {
                    if (c2.r) body.localScale = slp;
                }
        if (Input.GetMouseButton(0))
        {
            if (anim)
                anim.SetBool("punsh", true);
        }
        else
        {
            if (anim)
                anim.SetBool("punsh", false);
        }
    }
    void Punsh()
    {
        {
            if (pt > 1)
                if (anim)
                {
                    foreach (RaycastHit2D col in Physics2D.RaycastAll(transform.position, Vector2.right, range))
                    {
                        EnemyS e = col.transform.GetComponent<EnemyS>();
                        if (e) e.Damaged(damage);
                    }
                    pt = 0;
                }
        }
    }
    public void AddEqup(int ide)
    {
        objects++;
        ids.Add(ide);
        slots[objects - 1].sprite = GameController.GC.Items[ide];
    }
    public void Selected(Transform T)
    {
        Vector2 p = Input.mousePosition;
        selected.position = p + offset;
        Te = T;
    }
    public void Use()
    {
            int ind =slots.IndexOf(Te.GetComponent<Image>());
            slots[ind].sprite = defaultempty;
            Remove(ind);
            selected.position *= 100;
    }
    public void Remove(int ide)
    {
        if (ide < ids.Count)
        {
            objects--;
            ids.Remove(ids[ide]);
        }
        foreach (Image sr in slots)
        {
            
            if (slots.IndexOf(sr) < ids.Count)
            {
                sr.sprite = GameController.GC.Items[ids[slots.IndexOf(sr)]];
            }
            else
            {
                sr.sprite = defaultempty;
            }
        }
    }
}
