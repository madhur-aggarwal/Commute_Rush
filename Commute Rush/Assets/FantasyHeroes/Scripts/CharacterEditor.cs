using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.FantasyHeroes.Scripts
{
    /// <summary>
    /// Defines editor's behaviour
    /// </summary>
    public class CharacterEditor : MonoBehaviour
    {
        public SpriteCollection SpriteCollection;
        public AnimationManager AnimationManager;
        public Character Dummy;

        [Header("UI")]
        public GameObject Editor;
        public GameObject CommonPalette;
        public GameObject SkinPalette;
        public Dropdown HeadDropdown;
        public Dropdown EarsDropdown;
        public Dropdown HairDropdown;
        public Dropdown EyebrowsDropdown;
        public Dropdown EyesDropdown;
        public Dropdown MouthDropdown;
        public Dropdown BeardDropdown;
        public Dropdown BodyDropdown;
        public Dropdown HelmetDropdown;
        public Dropdown ArmorDropdown;
        public Dropdown CloakDropdown;
        public Dropdown MeleeWeapon1HDropdown;
        public Dropdown MeleeWeapon1HPairedDropdown;
        public Dropdown MeleeWeapon2HDropdown;
        public Dropdown ShieldDropdown;
        public Dropdown BowDropdown;
        public List<Button> EditorOnlyButtons;

        /// <summary>
        /// Called automatically on app start
        /// </summary>
        public void Start()
        {
            Refresh();
            InitializeDropdowns();
            EditorOnlyButtons.ForEach(i => i.interactable = Application.isEditor);
        }

        private List<SpriteRenderer> _palleteTargets;

        /// <summary>
        /// Open palette to change sprite color
        /// </summary>
        /// <param name="target">Pass one of the following values: Head, Ears, Body, Hair, Eyes, Mouth</param>
        public void OpenPalette(string target)
        {
            var palette = CommonPalette;

            switch (target)
            {
                case "Head": _palleteTargets = new List<SpriteRenderer> { Dummy.HeadRenderer }; palette = SkinPalette; break;
                case "Ears": _palleteTargets = new List<SpriteRenderer> { Dummy.EarsRenderer }; palette = SkinPalette; break;
                case "Body": _palleteTargets = Dummy.BodyRenderers.ToList(); palette = SkinPalette; break;
                case "Hair": _palleteTargets = new List<SpriteRenderer> { Dummy.HairRenderer }; break;
                case "Eyebrows": _palleteTargets = new List<SpriteRenderer> { Dummy.EyebrowsRenderer }; break;
                case "Eyes": _palleteTargets = new List<SpriteRenderer> { Dummy.EyesRenderer }; break;
                case "Mouth": _palleteTargets = new List<SpriteRenderer> { Dummy.MouthRenderer }; break;
                case "Beard": _palleteTargets = new List<SpriteRenderer> { Dummy.BeardRenderer }; break;
            }

            #if UNITY_EDITOR

            EditorGUIColorField.Open(_palleteTargets[0].color);
            palette.SetActive(false);

            #else

            Editor.SetActive(false);
            palette.SetActive(true);

            #endif
        }

        /// <summary>
        /// Close palette
        /// </summary>
        public void ClosePalette()
        {
            CommonPalette.SetActive(false);
            SkinPalette.SetActive(false);
            Editor.SetActive(true);
        }

        /// <summary>
        /// Remove all equipment
        /// </summary>
        public void Reset()
        {
            Dummy.Helmet = Dummy.Armor = Dummy.Cloak = Dummy.PrimaryMeleeWeapon = Dummy.SecondaryMeleeWeapon = Dummy.Shield = Dummy.Bow = null;
            InitializeDropdowns();
        }

        /// <summary>
        /// Flip character by X-axis
        /// </summary>
        public void Flip()
        {
            var scale = Dummy.transform.localScale;

            scale.x *= -1;
            Dummy.transform.localScale = scale;
        }

        #if UNITY_EDITOR

        /// <summary>
        /// Save character to prefab
        /// </summary>
        public void Save()
        {
            var path = UnityEditor.EditorUtility.SaveFilePanel("Save character prefab", "Assets/FantasyHeroes/Prefabs", "New character", "prefab");

            if (path.Length > 0)
            {
                path = "Assets" + path.Replace(Application.dataPath, null);
                UnityEditor.PrefabUtility.CreatePrefab(path, Dummy.gameObject);
                Debug.LogFormat("Saved as {0}", path);
            }
        }

        /// <summary>
        /// Load character from prefab
        /// </summary>
        public void Load()
        {
            Debug.LogWarning("This feature is only available in full version: http://u3d.as/QCQ");
        }

        #endif

        /// <summary>
        /// Visit publisher on the Asset Store
        /// </summary>
        public void More()
        {
            Application.OpenURL("https://www.assetstore.unity3d.com/en/#!/search/page=1/sortby=popularity/query=publisher:11086");
        }

        /// <summary>
        /// Navigate to URL
        /// </summary>
        public void Navigate(string url)
        {
            Application.OpenURL(url);
        }

        /// <summary>
        /// Pick color and apply to sprite
        /// </summary>
        /// <param name="color"></param>
        public void PickColor(Color color)
        {
            _palleteTargets.ForEach(i => i.color = color);
        }

        private void InitializeDropdowns()
        {
            InitializeDropdown(HeadDropdown, SpriteCollection.Head, Dummy.Head, texture => Dummy.Head = texture);
            InitializeDropdown(EarsDropdown, SpriteCollection.Ears, Dummy.Ears, texture => Dummy.Ears = texture);
            InitializeDropdown(HairDropdown, SpriteCollection.Hair, Dummy.Hair, texture => Dummy.Hair = texture);
            InitializeDropdown(EyebrowsDropdown, SpriteCollection.Eyebrows, Dummy.Eyebrows, texture => Dummy.Eyebrows = texture);
            InitializeDropdown(EyesDropdown, SpriteCollection.Eyes, Dummy.Eyes, texture => Dummy.Eyes = texture);
            InitializeDropdown(MouthDropdown, SpriteCollection.Mouth, Dummy.Mouth, texture => Dummy.Mouth = texture);
            InitializeDropdown(BeardDropdown, SpriteCollection.Beard, Dummy.Beard, texture => Dummy.Beard = texture);
            InitializeDropdown(BodyDropdown, SpriteCollection.Body, Dummy.Body, texture => Dummy.Body = texture);
            InitializeDropdown(HelmetDropdown, SpriteCollection.Helmet, Dummy.Helmet, texture => Dummy.Helmet = texture);
            InitializeDropdown(ArmorDropdown, SpriteCollection.Armor, Dummy.Armor, texture => Dummy.Armor = texture);
            InitializeDropdown(CloakDropdown, SpriteCollection.Cloak, Dummy.Cloak, texture => Dummy.Cloak = texture);
            InitializeDropdown(MeleeWeapon1HDropdown, SpriteCollection.MeleeWeapon1H, Dummy.PrimaryMeleeWeapon, texture => { Dummy.PrimaryMeleeWeapon = texture; if (Dummy.WeaponType != WeaponType.MeleeTween) Dummy.WeaponType = WeaponType.Melee1H; AnimationManager.Reset(); });
            InitializeDropdown(MeleeWeapon1HPairedDropdown, SpriteCollection.MeleeWeapon1H, Dummy.SecondaryMeleeWeapon, texture => { Dummy.SecondaryMeleeWeapon = texture; ReturnMeleeWeapon1H(); Dummy.WeaponType = WeaponType.MeleeTween; AnimationManager.Reset(); });
            InitializeDropdown(MeleeWeapon2HDropdown, SpriteCollection.MeleeWeapon2H, Dummy.PrimaryMeleeWeapon, texture => { Dummy.PrimaryMeleeWeapon = texture; Dummy.WeaponType = WeaponType.Melee2H; AnimationManager.Reset(); });
            InitializeDropdown(ShieldDropdown, SpriteCollection.Shield, Dummy.Shield, texture => { Dummy.Shield = texture; ReturnMeleeWeapon1H(); Dummy.WeaponType = WeaponType.Melee1H; AnimationManager.Reset(); });
            InitializeDropdown(BowDropdown, SpriteCollection.Bow, Dummy.Bow, texture => { Dummy.Bow = texture; Dummy.WeaponType = WeaponType.Bow; AnimationManager.Reset(); });
        }

        private void InitializeDropdown(Dropdown dropdown, List<Texture2D> sprites, Texture2D texture, Action<Texture2D> callback)
        {
            dropdown.options = new List<Dropdown.OptionData> { new Dropdown.OptionData("Empty") }; 
            dropdown.options.AddRange(sprites.Select(i => new Dropdown.OptionData(GetSpriteName(i))));
            dropdown.value = texture == null ? 0 : sprites.Select(i => i.name).ToList().IndexOf(texture.name) + 1;
            dropdown.RefreshShownValue();
            dropdown.onValueChanged.RemoveAllListeners();
            dropdown.onValueChanged.AddListener(index => { callback(index == 0 ? null : sprites[index - 1]); Refresh(); });
        }

        private void ReturnMeleeWeapon1H()
        {
            var index = MeleeWeapon1HDropdown.value;

            Dummy.PrimaryMeleeWeapon = index == 0 ? null : SpriteCollection.MeleeWeapon1H[index - 1];
        }

        private void Refresh()
        {
            if (SpriteCollection.Hair.Contains(Dummy.Hair) && Dummy.Helmet != null)
            {
                Dummy.Hair = SpriteCollection.HairShort.SingleOrDefault(i => i.name == Dummy.Hair.name);
            }
            else if(SpriteCollection.HairShort.Contains(Dummy.Hair) && Dummy.Helmet == null)
            {
                Dummy.Hair = SpriteCollection.Hair.SingleOrDefault(i => i.name == Dummy.Hair.name);
            }

            Dummy.Initialize();
        }

        private static string GetSpriteName(Texture2D texture)
        {
            if (texture == null) return "Empty";
            if (texture.name.All(c => char.IsUpper(c))) return texture.name;

            return Regex.Replace(Regex.Replace(texture.name, "[A-Z]", " $0"), "([a-z])([1-9])", "$1 $2").Trim();
        }
    }
}