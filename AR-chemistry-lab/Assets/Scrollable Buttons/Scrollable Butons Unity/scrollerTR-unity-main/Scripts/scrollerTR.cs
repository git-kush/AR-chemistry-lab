using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;


#region Editor

// How to use
// 1) Create Expandable Empty UI GameObject Equal to Canvas Size 
// 2) Add this script to Created GameObject
// 3) Create a child UI Panel also Equal to Canvas Size(Expandable)
// 4) Rename this child Panel to Container
// 5) Now Create Children in this UI Panel Called Container

[CustomEditor(typeof(scrollerTR))]
public class scroll : Editor {
	
	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        scrollerTR mainScript = (scrollerTR)target;

		var style = new GUIStyle(GUI.skin.label);
		style.fontSize = 18; style.fontStyle = FontStyle.Bold;
		style.margin.top = style.margin.bottom = 10;
	

        if (mainScript.repeatScroll)
        {
            GUILayout.Label("Repeat Scroll", style);
            mainScript.maxRepeatScroll = EditorGUILayout.FloatField("Max Repeat Scroll", mainScript.maxRepeatScroll);
            mainScript.minRepeatScroll = EditorGUILayout.FloatField("Min Repeat Scroll", mainScript.minRepeatScroll);
        }

        if (mainScript.scrollScalling)
        {
			GUILayout.Label( "Scale Items", style);
            mainScript.maxScroll_Scalling = EditorGUILayout.FloatField("Max Scale Scroll", mainScript.maxScroll_Scalling);
            mainScript.minScroll_Scalling = EditorGUILayout.FloatField("Min Scale Scroll", mainScript.minScroll_Scalling);
			mainScript.current_Index = EditorGUILayout.IntField("Current Index", mainScript.current_Index);

			ExtrasMethod(mainScript,style);
        }

        

        

        if (mainScript.ReArrange)
        {
            GUILayout.Space(20);
            GUILayout.Label("Arrange", style);

			for(int i=mainScript.item.Count;i>0;i--)
				mainScript.item.RemoveAt(mainScript.item.Count - 1);
			mainScript.setItems();
            mainScript.distanceToSet = EditorGUILayout.FloatField("Distance", mainScript.distanceToSet);
            GUI.skin.button.fontSize = 15;
            GUILayout.Space(5);
            if (GUILayout.Button("Re Arrange", GUILayout.Width(Screen.width), GUILayout.Height(50)))
            {
                for (int i = 0; i < mainScript.item.Count; i++)
                {
                    if (mainScript.type == scrollerTR.options.horizontal)
                        mainScript.item[i].transform.localPosition = new Vector2(i * mainScript.distanceToSet, 0);
                    else
                        mainScript.item[i].transform.localPosition = new Vector2(0, -i * mainScript.distanceToSet);
                }

            }
        }

    }

    private static void ExtrasMethod(scrollerTR mainScript,GUIStyle style)
    {
		GUILayout.Space(20);
		mainScript.extras = EditorGUILayout.Toggle("Extras", mainScript.extras);
		
		
        if (mainScript.extras)
        {
            GUILayout.Label("Attach Extras Item", style);
			List<GameObject> list = mainScript.dispItem;
			//; add lock also
            int size = Mathf.Max(0, EditorGUILayout.IntField("Size", list.Count));  // also can be list.Count

            while (size > list.Count)
            {
                list.Add(null);
            }
            while (size < list.Count)
            {
                list.RemoveAt(list.Count - 1);
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i] = EditorGUILayout.ObjectField("Element " + i, list[i], typeof(GameObject), true) as GameObject;
            }
        }
    }
}
#endregion

#endif
public class scrollerTR : MonoBehaviour 
{
	// Public Variables
	public enum options {horizontal,vertical};
	public options type;
	public RectTransform Container;	// To hold the ScrollContainer
	public float Smooth = 5f;
	[HideInInspector]
	//public GameObject[] item;
	public List<GameObject> item = new List<GameObject>();
	[HideInInspector]
	[Tooltip("Right Scroll should be positive and Left Scroll should be negative")]
	public float maxRepeatScroll = 500,minRepeatScroll = -500;
	public bool repeatScroll;
	public bool scrollScalling;
	[HideInInspector]
	public float maxScroll_Scalling=100,minScroll_Scalling=-100;
	[HideInInspector]
	public bool extras;
	[SerializeField]
	[HideInInspector]
	[Tooltip("These item will be equal to the items in Container")]
	public List<GameObject> dispItem = new List<GameObject>();		// items to display
	public bool ReArrange;
	[Tooltip("Depending upon Horizontal or Vertical option. It will set distance between Objects")]
	[HideInInspector]
	public float distanceToSet = 500;
	[HideInInspector]
	public int current_Index;

	// Private Variables
	ScrollRect scrollRect;

	private GameObject center;	// Center to compare the distance for each button


	private float[] distance;	// All buttons' distance to the center
	private float[] distReposition;
	private bool dragging = false;	// Will be true, while we drag the Container
	private int itemDistance;	// Will hold the distance between the buttons
	private int minButtonNum;	// To hold the number of the button, with smallest distance to center
	private int itemLength;

	void Start()
	{
		// create a scroll rect(Component)
		scrollRect = new GameObject().AddComponent<ScrollRect>();
		scrollRect.transform.gameObject.AddComponent<ContentSizeFitter>();
		if(type == options.horizontal)
			scrollRect.GetComponent<ContentSizeFitter>().horizontalFit = ContentSizeFitter.FitMode.PreferredSize;
		else if(type == options.vertical)
			scrollRect.GetComponent<ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
		scrollRect.transform.SetParent(this.transform);
		scrollRect.name = "Scroll Rect";
		scrollRect.transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;  // reset position
		scrollRect.transform.GetComponent<RectTransform>().localScale = new Vector2(1f,1f);  // reset scale
		scrollRect.transform.GetComponent<RectTransform>().anchorMax = new Vector2 (0.5f, 0.5f);	// to expand to parent	
        scrollRect.transform.GetComponent<RectTransform>().anchorMin = new Vector2 (0.5f, 0.5f);	// 


		// set Container as Child of Scroll Rect
		Container.transform.SetParent(scrollRect.transform);

		// set content of scroll rect
		scrollRect.content = Container;
		// to get the center of scroll area
		center = new GameObject();
		center.AddComponent<RectTransform>();
		center.name = "center";
		center.transform.SetParent(scrollRect.transform);
		center.GetComponent<RectTransform>().transform.localPosition = new Vector2(0f,0f);
		
		
		if(type == options.horizontal){
			scrollRect.horizontal = true;
			scrollRect.vertical = false;
		}else if(type == options.vertical){
			scrollRect.vertical = true;
			scrollRect.horizontal = false;
		}

		scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
		
	}
	
	void Update()
	{
		setItems();

		if(itemLength != item.Count){
			// Get distance between buttons
			if(type == options.horizontal)
				itemDistance  = (int)Mathf.Abs(item[1].GetComponent<RectTransform>().anchoredPosition.x - item[0].GetComponent<RectTransform>().anchoredPosition.x);
			else if(type == options.vertical)
				itemDistance  = (int)Mathf.Abs(item[1].GetComponent<RectTransform>().anchoredPosition.y - item[0].GetComponent<RectTransform>().anchoredPosition.y);

			// get all child
			itemLength = item.Count;
			distance = new float[itemLength];
			distReposition = new float[itemLength];

		}
		

		Vector2 newAnchoredPos = new Vector2(0,0);
		
		for (int i = 0; i < item.Count ; i++)
		{
			if(type == options.horizontal)
				distReposition[i] = center.GetComponent<RectTransform>().position.x - item[i].GetComponent<RectTransform>().position.x;
			else if(type == options.vertical)
				distReposition[i] = center.GetComponent<RectTransform>().position.y - item[i].GetComponent<RectTransform>().position.y;

			
			distance[i] = Mathf.Abs(distReposition[i]);		
			
			if(repeatScroll == true){
				if (distReposition[i] > maxRepeatScroll)
				{
					// use this if you want to replay items
					float curX = item[i].GetComponent<RectTransform>().anchoredPosition.x;
					float curY = item[i].GetComponent<RectTransform>().anchoredPosition.y;
					
					if(type == options.horizontal)
						newAnchoredPos = new Vector2 (curX + (itemLength * itemDistance) , curY );  // 
					else if(type == options.vertical)
						newAnchoredPos = new Vector2 (curX , curY + (itemLength * itemDistance));  // 
					
					item[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos;
					
				}

				if (distReposition[i] < minRepeatScroll)
				{
					// use this if you want to replay items
				
					float curX = item[i].GetComponent<RectTransform>().anchoredPosition.x;
					float curY = item[i].GetComponent<RectTransform>().anchoredPosition.y;
					if(type == options.horizontal)
						newAnchoredPos = new Vector2 (curX - (itemLength * itemDistance) , curY );
					else if(type == options.vertical)
						newAnchoredPos = new Vector2 (curX , curY - (itemLength * itemDistance));

					item[i].GetComponent<RectTransform>().anchoredPosition = newAnchoredPos; // 
				
				}

				
			}	

			// scale
			if(scrollScalling){
				if(distReposition[i]> maxScroll_Scalling ){
					item[i].transform.localScale = new Vector2(0.8f ,0.8f);
				}
				else if(distReposition[i]< minScroll_Scalling ){
					item[i].transform.localScale = new Vector2(0.8f ,0.8f);
				}else{
					item[i].transform.localScale = new Vector2(1f ,1f);
					current_Index = i;
				}
			}

			// extras e.g: display items
			if(extras){
				if(distReposition[i] > maxScroll_Scalling){
					dispItem[i].SetActive(false);
				}
				else if(distReposition[i] < minScroll_Scalling){
					dispItem[i].SetActive(false);
				}else{
					// use only this for all other games
					dispItem[i].SetActive(true);		
				}
			}
		
		}
	
		float minDistance = Mathf.Min(distance);  // Get the min distance

		for (int a = 0; a < item.Count; a++)
		{
			if (minDistance == distance[a])
			{
				minButtonNum = a;
			}
		}

		if (!dragging)
		{
				if(type == options.horizontal)
					LerpToitem (-item[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
				else if(type == options.vertical)
					LerpToitem (-item[minButtonNum].GetComponent<RectTransform>().anchoredPosition.y);
		}
	}
	
	public void setItems(){
		// in case any object deleted at runtime
		if(item.Count > Container.transform.childCount)
			item.RemoveAt(item.Count - 1);
		// set all objects in list of items
		for(int i = item.Count; i < Container.transform.childCount ; i++) {
    		GameObject child = Container.GetChild(i).transform.gameObject;
    		// do whatever you want with each child transform here
			item.Add(child);
	
		}
		
	}



	void LerpToitem(float position)
	{
		Vector2 newPosition = new Vector2(0,0);
		if(type == options.horizontal){
			float newX = Mathf.Lerp (Container.anchoredPosition.x, position, Time.deltaTime * Smooth);
			newPosition = new Vector2 (newX, Container.anchoredPosition.y);
		}else if(type == options.vertical){
			float newY = Mathf.Lerp (Container.anchoredPosition.y, position, Time.deltaTime * Smooth);
			newPosition = new Vector2 (Container.anchoredPosition.x, newY);
		}
		
		Container.anchoredPosition = newPosition;
	}

	public void StartDrag()
	{
		dragging = true;
	}

	public void EndDrag()
	{
		dragging = false;
	}

}