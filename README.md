# AF_Interview_2025


Polish:

Instrukcja uruchomienia:
Uruchom scenę Loader, odpowiedzialna jest ona za załadowanie wszystkich systemów oraz przygotowanie sceny głównej z UI (UIGameplay).

Konfiguracja obiektów:
Wszystkie konfigurowalne obiekty znajdują sie w lokalizacji: Assets/Data/

Krótki opis ważniejszych pól dla poszczególnych obiektów:
- CraftingMachines - do listy AvailableRecipes przypisujemy Recipes, które mają być dostępne w danej maszynie
- Recipes - słownik ingrediens zawiera klucz z itemem (składnikiem) oraz wartośc (ilość) tego składnika niezbędną do wytworzenia przedmiotu. Analogicznie postępujemy ze słownikiem CraftingResults. Pole CraftingTimeInSeconds - czas w sekundach niezbędny do stworzenia przedmiotu/przedmiotów. Pole CraftingSuccessRateInPercent - procentowa wartość z szansami na stworzenie danego przedmiotu/przedmiotów
- Items - w ścieżce Assets/Data/Items/Bonus znajdują się specjalne przedmioty, posiadają one dodatkowe pola jak BonusType (do wyboru z rozwijanej listy) i BonusValue (wartość ww bonusu).
- Quests - lista CraftingMachinesToUnlock - lista ScriptableObjects CraftingMachines, które mają się odblokować po ukończeniu zadania. FinishRequirements - słownik z przedmiotami do stworzenia w celu zaliczenia zadania, klucz - przedmiot, wartość - ilość przedmiotów do stworzenia

Modyfikacje wartości startowych:
Systemy posiadają swoją bibliotekę danych w formie modyfikowalnych ScriptableObjectów. Ich lokalizacja to: Assets/Data/Libraries

- CraftingMachinesLibrary -> Assets/Data/Libraries/CraftingMachinesLibrary - do listy InitialCraftingMachines wystarczy przypisać odpowiednie ScriptableObject.
- ItemsLibrary -> Assets/Data/Libraries/ItemsLibrary - InitialItemsData pozwala zainicjować startowe wartości ekwipunku:
  ItemData - referencja do ScriptableObject z itemem do ustawienia
  SpawnAmountRange - zakres, z którego losowana jest startowa wartość, jeśli chcemy uzyskac konkretną wartość to wartość minimalna musi być równa maksymalnej
  SpawnChance - procentowa wartość szansy na wylosowanie przedmiotu
- QuestsLibrary -> Assets/Data/Libraries/QuestsLibrary - do listy InitialQuests wystarczy przypisać odpowiednie ScriptableObject

Wykorzystane paczki/assety:
- Zenject
- UniTasks
- MessagePipe
- NaughtyAttributes
- SerializedDictionary

English:

How to launch:
Launch the Loader scene. It is responsible for loading all systems and preparing the main scene with UI (UIGameplay).

Object config:
All configurable objects can be found at: Assets/Data/

Short description of key fields for specific objects:
- CraftingMachines - assign Recipes to the AvailableRecipes list to make them available for a given machine,
- Recipes - the ingredients dictionary contains a key with the item (ingredient)and value (amount) of the ingredient required to craft the item. Similarly, the CraftingResults dictionary follows the same structure. The CraftingTimeInSeconds field is the time in seconds required to craft the item(s). The CraftingSuccessRateInPercent field is the success rate (percentage) to create the item(s).
- Items - special items are in Assets/Data/Items/Bonus. These items have additional fields like BonusType (selectable from a list) and BonusValue (value of the bonus).
- Quests - CraftingMachinesToUnlock list - a list of CraftingMachines ScriptableObjects unlocked after finishing a task. FinishRequirements - a dictionary of items required to complete the quest; key is the item, value is the number of items to craft

Modifing initial values:
Systems store their data in modifiable ScriptableObjects. These are located at: Assets/Data/Libraries

- CraftingMachinesLibrary -> Assets/Data/Libraries/CraftingMachinesLibrary - assign the appropriate ScriptableObject to the InitialCraftingMachines list.
- ItemsLibrary -> Assets/Data/Libraries/ItemsLibrary - InitialItemsData allows setting starting inventory values:
  ItemData - reference to the ScriptableObject for the item to be configured
  SpawnAmountRange - a range from which the starting value is randomly selected. To set a specific value, the minimum and maximum should be the same.
  SpawnChance - the probability (percentage) of the item spawning.
- QuestsLibrary -> Assets/Data/Libraries/QuestsLibrary - assign the appropriate ScriptableObject to the InitialQuests list

Used packages/assets
- Zenject
- UniTasks
- MessagePipe
- NaughtyAttributes
- SerializedDictionary
