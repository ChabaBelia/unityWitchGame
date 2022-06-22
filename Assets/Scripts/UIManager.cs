using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

	public static UIManager instance;

	void Awake ()
	{
		if (instance != null)
		{
			Debug.LogWarning("More than one instance of Inventory found!");
			return;
		}

		instance = this;
	}

	#endregion

    public InventoryUIManager m_inventoryUIManager;
    public SkillTreeUI m_skillTreeUI;
    // Start is called before the first frame update
    void Start()
    {
        m_skillTreeUI.visible(false);
        m_inventoryUIManager.visible(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            Debug.Log("inventory Open");
            m_inventoryUIManager.visible(!m_inventoryUIManager.isVisible());
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            Debug.Log("Tree Open");
            m_skillTreeUI.visible(!m_skillTreeUI.isVisible());
        }
    }

    void UpdateUI()
    {

    }
}
