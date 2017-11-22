using UnityEngine;
using UnityEngine.UI;

public class ShopItemData
{
    public string iconName;     // 아이콘 이름
    public string name;         // 아이템 이름
    public int price;           // 가격
    public string description;  // 설명
}

public class ShopItemTableViewCell : TableViewCell<ShopItemData>
{
    [SerializeField] private Image iconImage;   // 아이콘을 표시할 이미지
    [SerializeField] private Text nameLabel;    // 아이템 이름을 표시할 텍스트
    [SerializeField] private Text priceLabel;   // 가격을 표시할 텍스트

    public override void UpdteContent(ShopItemData itemData)
    {
        nameLabel.text = itemData.name;
        priceLabel.text = itemData.price.ToString();
        iconImage.sprite = SpriteSheetManager.GetspriteByName("IconAtlas", itemData.iconName);
    }
}

