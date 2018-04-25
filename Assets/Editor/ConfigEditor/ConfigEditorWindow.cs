using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConfigEditorWindow : EditorWindow
{
    ConfigTreeView _configView;

    private Rect resizer;

    private float sizeRatio = 0.2f;
    private bool isResizing;

    GUIStyle resizerStyle;

    [MenuItem("Project/Config Editor")]
    static void ShowWindow ()
    {
        var window = GetWindow<ConfigEditorWindow>();
        window.titleContent = new GUIContent("Entity Config Editor");
        window.Show();
    }

    private void OnEnable ()
    {
        _configView = new ConfigTreeView(new UnityEditor.IMGUI.Controls.TreeViewState());
        resizerStyle = new GUIStyle();
        resizerStyle.normal.background = EditorGUIUtility.whiteTexture;
        sizeRatio = .2f;
    }

    private void OnFocus ()
    {
        if (_configView != null) { _configView.Reload(); }
    }

    private void OnGUI ()
    {
        var leftRatio = position.width * sizeRatio;
        var rightRatio = position.width * (1 - sizeRatio);

        var leftPanel = new Rect(0, 0, leftRatio, position.height);
        HeirarchyPanel(leftPanel);

        var resizer = DrawResizer();
        ProcessEvents(Event.current);


        var selection = _configView.GetSelectedItem();
        if (selection != null)
        {
            var rightPanel = new Rect(leftPanel.width + resizer.width, 20f, rightRatio - 20f, position.height);
            var obj = new SerializedObject(selection);
            InspectorPanel(new Rect(rightPanel), obj);

            if (Event.current.type == EventType.MouseDown && Event.current.button == 1)
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("duplicate"), false, _configView.CreateNewFromSelection, this);
                menu.AddItem(new GUIContent("rename"), false, _configView.RenameSelection);
                menu.AddItem(new GUIContent("delete"), false, _configView.DeleteSelection);
                menu.ShowAsContext();
            }

            if (Event.current.type == EventType.KeyUp && Event.current.keyCode == KeyCode.D && Event.current.control)
            {
                _configView.CreateNewFromSelection(this);
            }

            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.F2)
            {
                _configView.RenameSelection();
            }

            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Delete)
            {
                _configView.DeleteSelection();
            }
        }

        if (GUI.changed) Repaint();
    }


    void HeirarchyPanel (Rect rect)
    {
        GUILayout.BeginArea(rect);
        _configView.OnGUI(rect);
        GUILayout.EndArea();
    }

    Vector2 currScroll = Vector2.zero;

    void InspectorPanel (Rect rect, SerializedObject obj)
    {
        GUILayout.BeginArea(rect);

        currScroll = GUILayout.BeginScrollView(currScroll);
        SerializedProperty iterator = obj.GetIterator();
        bool enterChildren = true;
        while (iterator.NextVisible(enterChildren))
        {
            enterChildren = false;
            EditorGUILayout.PropertyField(iterator, true, new GUILayoutOption[0]);
        }

        GUILayout.EndScrollView();
        GUILayout.EndArea();

        obj.ApplyModifiedProperties();
        obj.Update();
    }

    private void ProcessEvents (Event e)
    {
        switch (e.type)
        {
            case EventType.MouseDown:
                if (e.button == 0 && resizer.Contains(e.mousePosition))
                {
                    isResizing = true;
                }
                break;

            case EventType.MouseUp:
                isResizing = false;
                break;
        }

        Resize(e);
    }

    private void Resize (Event e)
    {
        if (isResizing)
        {
            sizeRatio = e.mousePosition.x / position.width;
            Repaint();
        }
    }

    Rect DrawResizer ()
    {
        resizer = new Rect((position.width * sizeRatio) - 5f, 0, 10f, position.height);

        GUILayout.BeginArea(new Rect(resizer.position + (Vector2.right * 5f), new Vector2(2, position.height)), resizerStyle);
        GUILayout.EndArea();

        EditorGUIUtility.AddCursorRect(resizer, MouseCursor.ResizeHorizontal);

        return resizer;
    }
}
