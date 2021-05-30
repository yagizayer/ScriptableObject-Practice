# SO-Practise #
 Demonstration of one of most basic ScriptableObject use case

## Simple ScriptableObject usage 
1- Create an SO template.(project window)<br/>
2- Create SO object using this template.(project window)<br/>
3- Create a GameObject that will reflect the SO object to the game and define a script to reflect the SO class in it (Hierarchy window)<br/>
4- Write the codes that will reflect the SO object to the game (VisualStudio)<br/>
5- Assign the SO object in the project window to the SO printer object (Hierarchy window)<br/>
<br/>
### To create the ScriptableObject Template
1.1- Create a new C # script<br/>
1.2- Change MonoBehaviour inherit to ScriptableObject<br/>
1.3- Define the variables you will use in the SO object<br/>
1.4- Add [CreateAssetMenu(fileName = "New ExampleSO", menuName = "ExampleSO", order = 1)] at the beginning.<br/>

### To create SO using the ScriptableObject Template
2.1- Right click in the Project window and select Create > ExampleSO<br/>
2.2- Name your SO object and fill in its contents (if you don't see any fields, make sure the variables are public in the SO template).<br/>

### To create a reflective object
3.1- Right click on the Hierarchy window and select Create Empty<br/>
3.2- Click Add Component in the Inspector window and create a new script.<br/>

### To write the codes that will reflect the game
4.1- This step may vary for each SO object. You should define it according to how you will use it in the game.<br/>

### To assign the SO object to the Writer
5.1- Drag and drop the SO object you want to assign in the Project window to the appropriate area in the reflective code.<br/>
