
Basit ScriptableObject kullanımı: 
	1- Bir SO template oluşturun.(project penceresi)
	2- Bu template'i kullanarak SO nesnesi oluşturun.(project penceresi)
	3- SO nesnesini oyuna yansıtacak olan bir GameObject oluşturun ve içerisine SO class'ını yansıtacak bir script tanımlayın(Hierarchy penceresi)
	4- SO nesnesini oyuna yansıtacak olan kodları yazın(VisualStudio)
	5- SO yasıtıcı nesneye project penceresindeki SO nesnesini atayın(Hierarchy penceresi)

ScriptableObject Template'i oluşturmak için: 
	1- Yeni bir C# script'i oluşturun
	2- MonoBehaviour inherit'ini ScriptableObject olarak değişirin
	3- SO nesnesinde kullanacağınız değişkenleri tanımlayın
	4- Başına [CreateAssetMenu(fileName = "New ExampleSO", menuName = "ExampleSO", order = 1)] ekleyin.

ScriptableObject Template'ini kullanarak SO oluşturmak için: 
	1- Project penceresinde sağ tıklayıp Create>ExampleSO seçin
	2- SO nesnenizi adını verip içeriğini doldurun(hiçbir alan görmüyorsanız SO template'de değişkenlerin public olduğuna emin olun).

Yansıtıcı nesne oluşturmak için : 
	1- Hierarchy peceresınde sağ tıklayıp Create Empty seçin(ctrl+shift+N kısayolu)
	2- Inspector peceresınde Add Component tıklayıp yeni bir script oluşturun.

Oyuna yansıtacak olan kodlarıyazmak için : 
	Bu adım her SO nesnesi için değişebilir. Oyunda nasıl kullanacaksanız kendinize göre tanımlamalısınız.

SO nesnesini Yasıtıcıya atamak için: 
	Project penceresinde atamak istediğiniz SO nesnesini sürükleyip yansıtıcı koddaki uygun alana bırakın


