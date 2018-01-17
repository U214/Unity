using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    private static ItemManager _instance = null;

    public static ItemManager Instance()
    {
        return _instance;
    }

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        Debug.Log("count : " + GetItemsCount());
    }

    // 파싱한 정보를 모두 저장
    Dictionary<int, ItemInfo> m_dicData = new Dictionary<int, ItemInfo>();

    // 아이템 추가
    public void AddItem(ItemInfo _cInfo)
    {
        // 아이템의 고유성을 위해 체크
        if (m_dicData.ContainsKey(_cInfo.ID)) return;

        // 이제 아이템 추가
        m_dicData.Add(_cInfo.ID, _cInfo);
    }

    // 하나의 아이템 얻기
    public ItemInfo GetItem(int _nID)
    {
        // 있는지 여부 체크
        if (m_dicData.ContainsKey(_nID))
        {
            return m_dicData[_nID];
        }
        // 없으면
        return null;
    }

    // 전체 목록 얻기
    public Dictionary<int, ItemInfo> GetAllItems()
    {
        return m_dicData;
    }

    // 전체 갯수 얻기
    public int GetItemsCount()
    {
        return m_dicData.Count;
    }
}

public class ItemInfo
{
    private int m_nID;
    private string m_strName;
    private string m_strIcon;
    private int m_nBuyCost;
    private int m_nSellCost;

    public int ID
    {
        set { m_nID = value; }
        get { return m_nID; }
    }

    public string NAME
    {
        set { m_strName = value; }
        get { return m_strName; }
    }

    public string ICON
    {
        set { m_strIcon = value; }
        get { return m_strIcon; }
    }

    public int BUY_COST
    {
        set { m_nBuyCost = value; }
        get { return m_nBuyCost; }
    }

    public int SELL_COST
    {
        set { m_nSellCost = value; }
        get { return m_nSellCost; }
    }
}
