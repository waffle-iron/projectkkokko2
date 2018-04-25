using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;
using UnityEditor.IMGUI.Controls;

public class ConfigTreeView : TreeView
{
    private Dictionary<UnityEntityConfig, string> _itemguidList;
    private Dictionary<int, UnityEntityConfig> _itemIDList;

    private TreeViewItem root;

    public ConfigTreeView (TreeViewState state) : base(state)
    {
        Reload();
    }

    public UnityEntityConfig GetSelectedItem ()
    {
        var selID = this.GetSelection().FirstOrDefault();
        UnityEntityConfig config = null;
        _itemIDList.TryGetValue(selID, out config);

        return config;
    }

    public void CreateNewFromSelection (object window)
    {
        var selected = GetSelectedItem();
        if (selected != null)
        {
            var path = AssetDatabase.GetAssetPath(selected);
            var newPath = path.Remove(path.LastIndexOf('/') + 1);
            var name = path.Substring(path.LastIndexOf('/') + 1);
            name = name.Remove(name.LastIndexOf('.'));

            var ctr = AssetDatabase.FindAssets(name).Length;
            name = name + $" ({ctr}).asset";
            AssetDatabase.CopyAsset(path, newPath + name);
            AssetDatabase.Refresh();

            Reload();
        }
    }

    public void RenameSelection ()
    {
        var item = this.FindItem(this.GetSelection().SingleOrDefault(), root);
        this.BeginRename(item);
    }

    protected override void RenameEnded (RenameEndedArgs args)
    {
        var item = this.FindItem(args.itemID, root);
        AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(GetSelectedItem()), args.newName);
        Reload();
    }

    public void DeleteSelection ()
    {
        var selected = GetSelectedItem();
        AssetDatabase.DeleteAsset(AssetDatabase.GetAssetPath(selected));
        Reload();
    }

    protected override TreeViewItem BuildRoot ()
    {
        _itemguidList = new Dictionary<UnityEntityConfig, string>();
        _itemIDList = new Dictionary<int, UnityEntityConfig>();

        var guids = AssetDatabase.FindAssets("t:UnityEntityConfig");
        var groupOfItems = guids.Select(guid =>
        {
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var asset = AssetDatabase.LoadAssetAtPath<UnityEntityConfig>(path);
            _itemguidList.Add(asset, guid);
            return asset;
        }).GroupBy(config => config.GetType());

        root = new TreeViewItem(0, -1, "Root");

        var currID = 1;
        foreach (var group in groupOfItems)
        {
            var len = group.Count();
            var typeRoot = new TreeViewItem(currID, 0, group.Key.ToString());
            root.AddChild(typeRoot);
            currID++;

            foreach (var item in group)
            {
                var treeitem = new TreeViewItem(currID, 1, item.name);
                _itemIDList.Add(currID, item);
                currID++;
                typeRoot.AddChild(treeitem);
            }
        }

        root.children.Sort();

        SetupDepthsFromParentsAndChildren(root);

        return root;
    }
}
