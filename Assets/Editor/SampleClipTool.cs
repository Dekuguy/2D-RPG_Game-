using UnityEngine;
using UnityEditor;
using System.Collections;

public class SampleClipTool : EditorWindow
{

	class Styles
	{
		public Styles()
		{
		}
	}
	static Styles s_Styles;

	protected GameObject go;
	protected AnimationClip animationClip;
	protected float time = 0.0f;
	protected bool lockSelection = false;
	protected bool animationMode = false;

	protected bool animateAutomate = false;
	protected double lastTime;

	private float speed = 1;

	[MenuItem("Custom Manager/Mecanim/SampleClip")]
	public static void DoWindow()
	{
		GetWindow<SampleClipTool>();
	}

	public void OnEnable()
	{
	}

	public void OnSelectionChange()
	{
		if (!lockSelection)
		{
			go = Selection.activeGameObject;
			Repaint();
		}
	}

	public void OnGUI()
	{
		if (s_Styles == null)
			s_Styles = new Styles();

		if (go == null)
		{
			EditorGUILayout.HelpBox("Please select a GO", MessageType.Info);
			return;
		}

		GUILayout.BeginHorizontal(EditorStyles.toolbar);

		EditorGUI.BeginChangeCheck();
		GUILayout.Toggle(AnimationMode.InAnimationMode(), "Animate", EditorStyles.toolbarButton);
		if (EditorGUI.EndChangeCheck())
			ToggleAnimationMode();

		GUILayout.FlexibleSpace();
		lockSelection = GUILayout.Toggle(lockSelection, "Lock", EditorStyles.toolbarButton);
		GUILayout.EndHorizontal();

		EditorGUILayout.BeginVertical();
		animationClip = EditorGUILayout.ObjectField(animationClip, typeof(AnimationClip), false) as AnimationClip;
		if (animationClip != null)
		{
			float startTime = 0.0f;
			float stopTime = animationClip.length;

			animateAutomate = EditorGUILayout.Toggle(animateAutomate);

			if (animateAutomate)
			{
				speed = EditorGUILayout.FloatField(speed);
			}
			else
			{
				time = EditorGUILayout.Slider(time, startTime, stopTime);
			}
		}
		else if (AnimationMode.InAnimationMode())
			AnimationMode.StopAnimationMode();


		EditorGUILayout.EndVertical();
	}

	void Update()
	{
		if (animateAutomate)
		{
			double current = EditorApplication.timeSinceStartup;
			float deltaTime = (float)(current - lastTime);
			lastTime = current;

			time += deltaTime * speed;

			if (time > animationClip.length)
			{
				time = 0;
			}
		}

		if (go == null)
			return;

		if (animationClip == null)
			return;

		// there is a bug in AnimationMode.SampleAnimationClip which crash unity if there is no valid controller attached
		Animator animator = go.GetComponent<Animator>();
		if (animator != null && animator.runtimeAnimatorController == null)
			return;

		if (!EditorApplication.isPlaying && AnimationMode.InAnimationMode())
		{
			AnimationMode.BeginSampling();
			AnimationMode.SampleAnimationClip(go, animationClip, time);
			AnimationMode.EndSampling();

			SceneView.RepaintAll();
		}
	}

	void ToggleAnimationMode()
	{
		if (AnimationMode.InAnimationMode())
			AnimationMode.StopAnimationMode();
		else
			AnimationMode.StartAnimationMode();
	}
}
