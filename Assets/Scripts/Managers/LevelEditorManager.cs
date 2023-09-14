using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    public GameObject m_gravitar;
    public GameObject m_wall;
    public GameObject m_launcher;
    public GameObject m_exit;
    public GameObject m_collectable;

    private List<GameObject> m_placedObjects;
    private Vector2 m_levelSize;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SelectObject(GameObject select)
    {

    }

    public void PlaceSelectedObject(GameObject selected)
    {
        Vector3 _pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GameObject _placed = Instantiate(selected, _pos, Quaternion.Euler(0, 0, 0));
        m_placedObjects.Add(_placed);

    }

    public void RemoveSelectedObject(GameObject selected)
    {
        m_placedObjects.Remove(selected);
        Destroy(selected);
    }
}
